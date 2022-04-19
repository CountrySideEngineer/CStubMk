using Parser.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTemplate.Template;

namespace CodeWriter.Stub
{
	public class StubSourceCodeWriter : AStubCodeWriter
	{
		public override void Write(string path, Parameter parameter)
		{
			var template = new SourceStubTemplate();
			Write(path, parameter, template);
		}

		public override void Write(string path, IEnumerable<Parameter> parameters)
		{
			var template = new SourceStubTemplate();
			Write(path, parameters, template);
		}
	}
}
