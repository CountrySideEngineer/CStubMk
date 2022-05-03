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

		/// <summary>
		/// 文字列を解析して、Parameterオブジェクトの集合に変換します。
		/// Parse oarameter not and change into Collection of Parameter object.
		/// </summary>
		/// <param name="code">
		/// 解析対象の関数定義の文字列
		/// String to parse defining functions.
		/// </param>
		/// <returns>
		/// 解析したParameterオブジェクトの集合
		/// Colletion of Parameter object parsed from code.
		/// </returns>
		public override IEnumerable<Parameter> Parse(string code)
		{
			try
			{
				IEnumerable<string> nodeCollection = NodeToCollection(code, CodeDeliminator_FUNC);
				IEnumerable<Parameter> functions = Parse(nodeCollection);
				return functions;
			}
			catch (Exception ex)
			when ((ex is ArgumentException) || (ex is FormatException))
			{
				throw ex;
			}
		}

		/// <summary>
		/// 文字列のノードの集合をそれぞれ解析して、Parameterオブジェクトに変換します。
		/// Parse each item in collection of string and change it into Parameter object.
		/// </summary>
		/// <param name="nodes">
		/// 解析対象の文字列
		/// Collection of string to parse.
		/// </param>
		/// <returns>
		/// 解析したParameterオブジェクトの集合
		/// Colletion of Parameter object parsed from code.
		/// </returns>
		protected virtual IEnumerable<Parameter> Parse(IEnumerable<string> nodes)
		{
			List<Parameter> functions = new List<Parameter>();
			foreach (var nodeItem in nodes)
			{
				Parameter parameter = ParseFuncNode(nodeItem);
				functions.Add(parameter);
			}
			return functions;
		}

		/// <summary>
		/// 関数ノードを解析して、Parameterオブジェクトを返す。
		/// Parse function node and change it into Parameter object.
		/// </summary>
		/// <param name="node">
		/// 解析対象の文字列
		/// String to parse.
		/// </param>
		/// <returns>
		/// 解析したParameterオブジェクト
		/// Parsed Parameter object.
		/// </returns>
		protected virtual Parameter ParseFuncNode(string node)
		{
			(string func, string arg) = SplitToFuncAndArg(node);
			IEnumerable<Parameter> args = ParseArgNode(arg);
			Variable variable = (Variable)base.ParseNode(func);
			Parameter function = new Function();
			variable.CopyTo(function);
			((Function)function).Arguments = args;
			return function;
		}

		/// <summary>
		/// 引数ノードを解析して、Parameterオブジェクトの集合に変換する。
		/// Parse node about argument and returns the collection of parameter node.
		/// </summary>
		/// <param name="node">Node to be parsed.</param>
		/// <returns>Collection of parameter object about argument.</returns>
		/// <exception cref="ArgumentException"></exception>
		protected virtual IEnumerable<Parameter> ParseArgNode(string node)
		{
			IEnumerable<Parameter> args = base.Parse(node);
			bool isTop = true;
			foreach (var item in args)
			{
				Variable variable = item as Variable;
				if (isTop)
				{
					if ((variable.DataType.ToLower().Equals("void")) &&
						(variable.PointerNum < 1))
					{
						if (1 == args.Count())
						{
							args = new List<Parameter>(0);
							break;
						}
					}
				}
				else
				{
					if ((variable.DataType.ToLower().Equals("void")) &&
						(variable.PointerNum < 1))
					{
						throw new ArgumentException();
					}
				}
				isTop = false;
			}
			return args;
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
			try
			{
				IEnumerable<string> splittedNode = NodeToCollection(node, CodeDeliminator_FUNC_AND_ARG);
				func = splittedNode.ElementAt(0);
				string arg = splittedNode.ElementAt(1);
				return (func, arg);
			}
			catch (ArgumentException)
			{
				string codeToCheck = func + "()";
				if (node.Equals(codeToCheck))
				{
					string arg = string.Empty;
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
