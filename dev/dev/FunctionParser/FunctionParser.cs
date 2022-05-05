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
		/// <summary>
		/// Parse codes into collectin of Parameter object.
		/// </summary>
		/// <param name="codes">Collection of code to be parsed.</param>
		/// <returns>Parameter object parsed from codes</returns>
		/// <exception cref="ParserException"></exception>
		public virtual IEnumerable<Parameter> Parse(IEnumerable<string> codes)
		{
			try
			{
				var parameters = new List<Parameter>();
				foreach (var item in codes)
				{
					Parameter parameter = Parse(item);
					parameters.Add(parameter);
				}
				return parameters;
			}
			catch (ParserException)
			{
				throw;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public virtual Parameter Parse(string code)
		{
			try
			{
				var parser = new FunctionNodeParser();
				IEnumerable<Parameter> parameters = Parse(code, parser);
				Parameter parameter = parameters.ElementAt(0);
				return parameter;
			}
			catch (ParserException)
			{
				throw;
			}
		}

		protected virtual IEnumerable<Parameter> Parse(string code, ParameterNodeParser parser)
		{
			try
			{
				IEnumerable<Parameter> parameters = parser.Parse(code);
				return parameters;
			}
			catch (ParserException)
			{
				throw;
			}
		}
	}
}
