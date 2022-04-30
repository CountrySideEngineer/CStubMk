﻿using CodeTemplate.Template;
using CStubMk.Model;
using Parser;
using Parser.SDK.Model;
using Reader;
using Reader.FunctionReader;
using Reader.SDK.Exception;
using Reader.SDK.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CStubMk.Command
{
	public class StubCommand : ICommand
	{
		public void Execute(InputInfo input)
		{
			try
			{
				IEnumerable<ParameterInformation> infos = GetInformations(input);
				IEnumerable<Parameter> parameters = ParseParameters(infos);
				(string srcCode, string hdrCode) = GenerateStubCode(parameters);
				(string srcPath, string hdrPath) = GetStubFilePath(input);
				if ((CheckFile(srcPath)) && (CheckFile(hdrPath)))
				{
					WriteCode(srcPath, srcCode);
					WriteCode(hdrPath, hdrCode);
				}
				else
				{
					throw new FileNotFoundException();
				}

				return;
			}
			catch (ReaderException)
			{
				throw new Exception("An exception has been detected while reading input file.");
			}
		}

		protected virtual IEnumerable<ParameterInformation> GetInformations(InputInfo input)
		{
			AFunctionReader reader = ReaderFactory.Factory(input.TargetFilePath);
			IEnumerable<ParameterInformation> infos = reader.Read(input.TargetFilePath);
			return infos;
		}

		protected virtual IEnumerable<Parameter> ParseParameters(IEnumerable<ParameterInformation> paramInfos)
		{
			var codes = new List<string>();
			foreach (var paramInfo in paramInfos)
			{
				codes.Add(paramInfo.Code);
			}
			var parser = new Parser.FunctionParser();
			IEnumerable<Parameter> parameters = parser.Parse(codes);
			return parameters;
		}

		protected virtual (string, string) GenerateStubCode(IEnumerable<Parameter> parameters)
		{
			string srcCode = GenerateStubSourceCode(parameters);
			string hdrCode = GenerateStubHeaderCode(parameters);
			return (srcCode, hdrCode);
		}

		protected virtual string GenerateStubSourceCode(IEnumerable<Parameter> parameters)
		{
			var template = new SourceStubTemplate();
			string code = GenerateStubCode(parameters, template);
			return code;
		}

		protected virtual string GenerateStubHeaderCode(IEnumerable<Parameter> parameters)
		{
			var template = new HeaderStubTemplate();
			string code = GenerateStubCode(parameters, template);
			return code;
		}

		protected virtual string GenerateStubCode(IEnumerable<Parameter> parameters, StubCodeTemplateCommonBase template)
		{
			string code = string.Empty;
			foreach (var parameter in parameters)
			{
				template.TargetFunc = (Function)parameter;
				code = template.TransformText();
			}
			return code;
		}

		protected bool CheckFile(string path)
		{
			try
			{
				string code = string.Empty;
				WriteCode(path, code);

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		protected void WriteCode(string path, string code)
		{
			using (var stream = new StreamWriter(path, false, Encoding.UTF8))
			{
				stream.Write(code);
			}
		}

		protected (string, string) GetStubFilePath(InputInfo inputInfo)
		{
			string inputFileName = System.IO.Path.GetFileNameWithoutExtension(inputInfo.TargetFilePath);
			string stubSrcFileName = $"{inputFileName}_stub.cpp";
			string stubHdrFileName = $"{inputFileName}_stub.h";
			string stubSrcFilePath = System.IO.Path.Combine(inputInfo.OuptutDirPath, stubSrcFileName);
			string stubHdrFilePath = System.IO.Path.Combine(inputInfo.OuptutDirPath, stubHdrFileName);
			return (stubSrcFilePath, stubHdrFilePath);
		}
	}
}