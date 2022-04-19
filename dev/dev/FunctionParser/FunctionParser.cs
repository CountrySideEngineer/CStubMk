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
		protected char[] _codeDeliminator = { ' ', '\t', '\r', '\n' };

		public IEnumerable<Parameter> Parse(IEnumerable<string> codes)
		{
			var parameters = new List<Parameter>();
			foreach (var item in codes)
			{
				Parameter parameter = Parse(item);
				parameters.Add(parameter);
			}
			return parameters;
		}

		public Parameter Parse(string code)
		{
			//Split code into "function declare" part and "arguments".
			char[] deliminator = { '(', ')' };
			IEnumerable<string> nodes = code
				.Split(deliminator)
				.Where(_ => (!string.IsNullOrEmpty(_)) && (!string.IsNullOrWhiteSpace(_)));
			if (nodes.Count() < 1)
			{
				throw new ParserException("Function definition code invalid.");
			}

			string functionCode = nodes.ElementAt(0);
			Function function = ParseFunction(functionCode);
			try
			{
				var argumentNode = nodes.ElementAt(1);
				IEnumerable<Variable> arguments = ParseArguments(argumentNode);
				function.Arguments = arguments;
			}
			catch (ArgumentOutOfRangeException)
			{
				/*
				 * 関数の引数なし
				 *	→	意図して、あるいはルール上の都合によりVOIDを設定していない可能性がある。
				 *		そのため、引数にVOIDが指定された場合とは区別する。
				 *		「引数の宣言なし」の場合には、引数の配列を空配列に設定する。
				 */
				var arguments = new List<Parameter>();
				arguments.Clear();
				function.Arguments = arguments;
			}
			return function;
		}

		/// <summary>
		/// Parse function name and data type and convert into Function object
		/// </summary>
		/// <param name="code">Code to declare function.</param>
		/// <returns>Function object which contains name and data type.</returns>
		protected Function ParseFunction(string code)
		{
			List<string> nodes = codeToNodes(code).ToList();
			if (nodes.Count() < 2)
			{
				throw new ParserException("Function declare invalid.");
			}
			int nameIndex = nodes.Count() - 1;
			string name = nodes.ElementAt(nameIndex);
			nodes.RemoveAt(nameIndex);

			//Generate code for data type only.
			string variableCode = nodes.Aggregate((dataTypeCodePart, part) => $"{dataTypeCodePart} {part}");
			Variable variable = ParseDataTypeNode(variableCode);
			var function = new Function()
			{
				DataType = variable.DataType,
				Name = name,
				PointerNum = variable.PointerNum
			};
			return function;
		}

		/// <summary>
		/// Parse code about argument of method into collection of variable objects.
		/// </summary>
		/// <param name="code">Code to parser</param>
		/// <returns>Collection of <para>variable</para> objects.</returns>
		protected IEnumerable<Variable> ParseArguments(string code)
		{
			char[] deliminator = { ',' };
			IEnumerable<string> nodes = code.Split(deliminator);
			if (nodes.Count() < 1)
			{
				throw new ParserException("Arguments definition invalid.");
			}

			var arguments = new List<Variable>();
			arguments.Clear();
			foreach (var nodeItem in nodes)
			{
				if (IsVoid(nodeItem))
				{
					if (0 == arguments.Count())
					{
						Variable variable = new Variable()
						{
							DataType = nodeItem,
							Name = string.Empty,
							PointerNum = 0
						};
						arguments.Add(variable);
						break;
					}
					else
					{
						throw new ParserException("\"VOID\" data type set in invalid position.");
					}
				}
				else
				{
					var variableItem = ParseVariableNode(nodeItem);
					arguments.Add(variableItem);
				}
			}
			return arguments;
		}

		protected bool IsVoid(string code)
		{
			IEnumerable<string> nodes = code.Split(_codeDeliminator, StringSplitOptions.RemoveEmptyEntries);
			if (nodes.ElementAt(0).ToLower().Equals("void"))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		protected IEnumerable<string> codeToNodes(string code)
		{
			string codePointerWithSpace = code.Replace("*", " * ");
			string codeWithoutLf = codePointerWithSpace.Replace("\r\n", "\n");
			IEnumerable<string> nodes = codeWithoutLf
				.Split(_codeDeliminator, StringSplitOptions.RemoveEmptyEntries)
				.Where((_) => ((!string.IsNullOrWhiteSpace(_)) && (!string.IsNullOrEmpty(_))));
			return nodes;
		}

		protected IEnumerable<Variable> ParseVariableNode(IEnumerable<string> codes)
		{
			var variables = new List<Variable>();
			foreach (var codeItem in codes)
			{
				Variable variableItem = ParseVariableNode(codeItem);
				variables.Add(variableItem);
			}
			return variables;
		}

		/// <summary>
		/// Parse code to declare variable code.
		/// </summary>
		/// <param name="code">Code to declare variable.</param>
		/// <returns>Variable obkect about the variable.</returns>
		/// <exception cref="ParserException">The argument code is invalid.</exception>
		protected Variable ParseVariableNode(string code)
		{
			List<string> nodes = codeToNodes(code).ToList();
			if (nodes.Count() < 2)
			{
				try
				{
					/*
					 * VOID型か否か確認
					 *	→	非ポインタのVOID型の場合には、変数の名前は存在しない。
					 *		そのため、これ以上の処理の実施は不要となり、処理を終了する。
					 */
					if (nodes.ElementAt(0).ToLower().Equals("void"))
					{
						Variable voidVariable = new Variable()
						{
							DataType = nodes.ElementAt(0),
							Name = string.Empty,
							PointerNum = 0
						};
						return voidVariable;
					}
					else
					{
						throw new ParserException("Function code invalid.");
					}
				}
				catch (ArgumentOutOfRangeException)
				{
					throw new ParserException("Function code invalid.");
				}
			}

			try
			{
				int nameIndex = nodes.Count() - 1;
				string name = nodes.ElementAt(nameIndex);
				nodes.RemoveAt(nameIndex);

				//Generate code for data type only.
				string variableCode = nodes.Aggregate((dataTypeCodePart, part) => $"{dataTypeCodePart} {part}");
				Variable variable = (Variable)ParseDataTypeNode(variableCode);
				variable.Name = name;
				return variable;
			}
			catch (ParserException)
			{
				throw;
			}
		}

		/// <summary>
		/// Parse data type node
		/// </summary>
		/// <param name="code">Code of data type to parse.</param>
		/// <returns>Parameter object about data type.</returns>
		/// <exception cref="ParserException">The argument code is invalid format.</exception>
		protected Variable ParseDataTypeNode(string code)
		{
			IEnumerable<string> nodes = codeToNodes(code);
			if (nodes.Count() < 1)
			{
				throw new ParserException("Variable codes invalid.");
			}
			string dataType = string.Empty;
			string firstItem = nodes.ElementAt(0);
			int dataTypeIndex = 0;
			if ("const".Equals(firstItem.ToLower()))
			{
				dataTypeIndex = 1;
			}
			dataType = nodes.ElementAt(dataTypeIndex);

			int pointerNum = 0;
			try
			{
				IEnumerable<string> pointerNodes = nodes.Where(_ => _.Equals("*"));
				pointerNum = pointerNodes.Count();
			}
			catch (NullReferenceException)
			{
				pointerNum = 0;
			}

			var variable = new Variable()
			{
				DataType = dataType,
				PointerNum = pointerNum
			};

			return variable;
		}
	}
}
