using CodeTemplate.Template;
using CStubMk.Model;
using Parser;
using Parser.SDK.Exception;
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
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CStubMk.Command
{
	public class StubCommand : ICommand
	{
		protected string StubSourcePostFix = "stub.cpp";
		protected string StubHeaderPostFix = "stub.h";

		/// <summary>
		/// Execute "stub" command
		/// </summary>
		/// <param name="input">Command input information,</param>
		/// <exception cref="Exception"></exception>
		public void Execute(InputInfo input)
		{
			try
			{
				CommandSequence(input);
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Run "stub" command sequence
		/// </summary>
		/// <param name="input">Command input information</param>
		/// <exception cref="ReaderException"></exception>
		/// <exception cref="ParserException"></exception>
		protected virtual void CommandSequence(InputInfo input)
		{
			try
			{
				AFunctionReader reader = GetReader(input);
				IEnumerable<ParameterInformation> parameterInfos = GetInformationsByReader(input, reader);
				IEnumerable<Parameter> parameters = ParseParameters(parameterInfos);
				(string srcCode, string hdrCode) = GenerateStubCode(parameters);
				(string srcPath, string hdrPath) = GetStubFilePath(input);
				if ((CheckFile(srcPath)) && (CheckFile(hdrPath)))
				{
					WriteCode(srcPath, srcCode);
					WriteCode(hdrPath, hdrCode);
				}
				else
				{
					string message = "Target file can not open.";
					throw new UnauthorizedAccessException(message);
				}

				return;
			}
			catch (ReaderException ex)
			{
				string message = "An exception has been detected while reading input file. " +
					$"Errro code - 0x{ex.Code:X8}";
				throw new Exception(message);
			}
			catch (ParserException ex)
			{
				string message = $"An exception has been detected while parsing data. " +
					$"Error code - 0x{ex.Code:X8}";
				throw new Exception(message);
			}
		}

		protected virtual AFunctionReader GetReader(InputInfo input)
		{
			AFunctionReader reader = ReaderFactory.Factory(input.TargetFilePath);
			return reader;
		}

		protected virtual IEnumerable<ParameterInformation> GetInformationsByReader(InputInfo input, AFunctionReader reader)
		{
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

		/// <summary>
		/// コードをファイルに書き込みます。
		/// Write code into a file.
		/// </summary>
		/// <param name="path">Path to file to write code into.</param>
		/// <param name="code">Code to write.</param>
		/// <exception cref=UnauthorizedAccessException"/>
		/// <exception cref=ArgumentException"/>
		/// <exception cref=ArgumentNullException"/>
		/// <exception cref=DirectoryNotFoundException"/>
		/// <exception cref=IOException"/>
		/// <exception cref=PathTooLongException"/>
		/// <exception cref=SecurityException"/>
		protected void WriteCode(string path, string code)
		{
			try
			{
				using (var stream = new StreamWriter(path, false, Encoding.UTF8))
				{
					stream.Write(code);
				}
			}
			catch (Exception ex)
			when ((ex is UnauthorizedAccessException) || 
				(ex is ArgumentException) || 
				(ex is ArgumentNullException) || 
				(ex is DirectoryNotFoundException) || 
				(ex is IOException) || 
				(ex is PathTooLongException) || 
				(ex is SecurityException))
			{
				throw;
			}
		}

		/// <summary>
		/// スタブファイルのパスを生成します。
		/// Create path to stub file.
		/// </summary>
		/// <param name="inputInfo">
		/// 入力情報
		/// Input file information.
		/// </param>
		/// <returns></returns>
		protected (string, string) GetStubFilePath(InputInfo inputInfo)
		{
			string stubSrcFilePath = GetStubSourceFilePath(inputInfo);
			string stubHdrFilePath = GetStubHeaderFilePath(inputInfo);
			return (stubSrcFilePath, stubHdrFilePath);
		}

		/// <summary>
		/// スタブのソースファイルのパスを生成します。
		/// Create path to stub source file.
		/// </summary>
		/// <param name="inputInfo">
		/// 入力情報
		/// Input file information
		/// </param>
		/// <returns>
		/// スタブのソースファイルのパス
		/// Path to stub source file.
		/// </returns>
		protected virtual string GetStubSourceFilePath(InputInfo inputInfo)
		{
			string filePath = GetStubFilePath(inputInfo, StubSourcePostFix);
			return filePath;
		}

		/// <summary>
		/// スタブのヘッダファイルのパスを生成します。
		/// Create path to stub header file.
		/// </summary>
		/// <param name="inputInfo">
		/// 入力情報
		/// Input file information
		/// </param>
		/// <returns>
		/// スタブのヘッダファイルのパス
		/// Path to stub header file.
		/// </returns>
		protected virtual string GetStubHeaderFilePath(InputInfo inputInfo)
		{
			string filePath = GetStubFilePath(inputInfo, StubHeaderPostFix);
			return filePath;
		}

		/// <summary>
		/// 生成するスタブファイルのパスを生成します。
		/// Create path to file to stub file to create.
		/// </summary>
		/// <param name="inputInfo">
		/// 入力情報
		/// Input file information.
		/// </param>
		/// <param name="postFix">
		/// ファイルの後置修飾子(拡張子含む)
		/// Post fix including extention.
		/// </param>
		/// <returns>
		/// スタブファイルへのパス
		/// Path to stub file.
		/// </returns>
		/// <exception cref="ArgumentException"></exception>
		protected virtual string GetStubFilePath(InputInfo inputInfo, string postFix)
		{
			try
			{
				string inputFileName = System.IO.Path.GetFileNameWithoutExtension(inputInfo.TargetFilePath);
				string stubFileName = $"{inputFileName}_{postFix}";
				string stubFilePath = System.IO.Path.Combine(inputInfo.OuptutDirPath, stubFileName);
				return stubFilePath;
			}
			catch (ArgumentException)
			{
				throw new ArgumentException("Input information invalid.");
			}
		}
	}
}
