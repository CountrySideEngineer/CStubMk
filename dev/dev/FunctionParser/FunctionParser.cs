using FunctionParser;
using Parser.SDK.Exception;
using Parser.SDK.Interface;
using Parser.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
	public class FunctionParser : IParser
	{
		public virtual IEnumerable<Parameter> Parse(IEnumerable<string> codes)
		{
			var parameters = new List<Parameter>();
			foreach (var item in codes)
			{
				Parameter parameter = Parse(item);
				parameters.Add(parameter);
			}
			return parameters;
		}

		public virtual Parameter Parse(string code)
		{
			var parser = new FunctionNodeParser();
			IEnumerable<Parameter> parameters = Parse(code, parser);
			Parameter parameter = parameters.ElementAt(0);
			return parameter;
		}

		protected virtual IEnumerable<Parameter> Parse(string code, ParameterNodeParser parser)
		{
			IEnumerable<Parameter> parameters = parser.Parse(code);
			return parameters;
		}
	}
}
