using CodeTemplate.Template;
using CodeWriter.SDK;
using Parser.SDK.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWriter.Stub
{
	public abstract class AStubCodeWriter : IWriter
	{
		public abstract void Write(string path, Parameter parameter);

		public void Write(string path, Parameter parameter, StubCodeTemplateCommonBase template)
		{
			string code = GetCode(parameter, template);
			Write(path, code);
		}

		public void Write(string path, IEnumerable<Parameter> parameters, StubCodeTemplateCommonBase template)
		{
			string code = GetCode(parameters, template);
			Write(path, code);
		}

		public abstract void Write(string path, IEnumerable<Parameter> parameters);

		protected virtual string GetCode(IEnumerable<Parameter> parameters, StubCodeTemplateCommonBase template)
		{
			string code = string.Empty;
			foreach (var item in parameters)
			{
				code += GetCode(item, template);
			}
			return code;
		}

		protected virtual string GetCode(Parameter parameter, StubCodeTemplateCommonBase template)
		{
			var function = (Function)parameter;
			template.TargetFunc = function;
			string code = template.TransformText();
			return code;
		}

		protected virtual void Write(string path, string code)
		{
			using (var writer = File.CreateText(path))
			{
				writer.Write(code);
			}
		}
	}
}
