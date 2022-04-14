using Parser.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTemplate.Template;

namespace CodeWriter.Stub
{
	public class StubHeaderCodeWriter : AStubCodeWriter
	{
		public override void Write(string path, Parameter parameter)
		{
			var template = new HeaderStubTemplate();
			Write(path, parameter, template);
		}

		public override void Write(string path, IEnumerable<Parameter> parameters)
		{
			var template = new HeaderStubTemplate();
			Write(path, parameters, template);
		}
	}
}
