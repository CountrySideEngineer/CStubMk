using Parser.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FunctionParser
{
	public class FunctionNodeParser : VariableNodeParser
	{
		protected char[] CodeDeliminator_FUNC = { ';' };
		protected char[] CodeDeliminator_FUNC_AND_ARG = { '(', ')' };

		public override IEnumerable<Parameter> Parse(string code)
		{
			try
			{
				IEnumerable<string> nodeCollection = NodeToCollection(code, CodeDeliminator_FUNC);
				List<Function> functions = new List<Function>();
				foreach (var item in nodeCollection)
				{
					(string func, string arg) = SplitToFuncAndArg(item);
					IEnumerable<Parameter> args = base.Parse(arg);
					Variable variable = (Variable)base.ParseNode(func);
					Function function = new Function()
					{
						DataType = variable.DataType,
						Name = variable.Name,
						PointerNum = variable.PointerNum,
						Arguments = args
					};
					functions.Add(function);
				}

				return functions;
			}
			catch (Exception ex)
			when ((ex is ArgumentException) || (ex is FormatException))
			{
				throw ex;
			}
		}

		/// <summary>
		/// 関数定義の文字列を、関数部分と引数部分に分割する。
		/// Divide the function definition string into the function part and argument part.
		/// </summary>
		/// <param name="node">Code node to be splitted.</param>
		/// <returns>Function argument in tuple.</returns>
		/// <exception cref="FormatException"></exception>
		protected virtual (string func, string arg) SplitToFuncAndArg(string node)
		{
			string func = string.Empty;
			string arg = string.Empty;
			try
			{
				IEnumerable<string> splittedNode = NodeToCollection(node, CodeDeliminator_FUNC_AND_ARG);
				func = splittedNode.ElementAt(0);
				arg = splittedNode.ElementAt(1);
				return (func, arg);
			}
			catch (ArgumentException)
			{
				string codeToCheck = func + "()";
				if (node.Equals(codeToCheck))
				{
					arg = string.Empty;
					return (func, arg);
				}
				else
				{
					throw;
				}
			}
		}
	}
}
