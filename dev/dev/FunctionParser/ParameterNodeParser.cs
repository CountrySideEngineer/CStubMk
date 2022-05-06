using Parser.SDK.Exception;
using Parser.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionParser
{
	public class ParameterNodeParser
	{
		//Deliminator to separate code into collection of nodes.
		protected char[] CodeDeliminator = { ',' };
		protected char[] CodeDeliminator_TYPE_AND_NAME = { ' ', '\t', '\r', '\n' };
		protected char[] CodeDeliminator_MOD_AND_TYPE = { ' ', '\t', '\r', '\n' };
		protected char[] CodeDeliminator_VOID = { ',', ' ', '\t', '\r', '\n' };

		/// <summary>
		/// 文字列を解析して、Parameterオブジェクトの集合に変換します。
		/// Parse oarameter not and change into Collection of Parameter object.
		/// </summary>
		/// <param name="code">
		/// 解析対象の文字列
		/// String to parse.
		/// </param>
		/// <returns>
		/// 解析したParameterオブジェクトの集合
		/// Colletion of Parameter object parsed from code.
		/// </returns>
		/// <exception cref="ParserException"></exception>
		public virtual IEnumerable<Parameter> Parse(string code)
		{
			if ((string.IsNullOrEmpty(code)) || (string.IsNullOrWhiteSpace(code)))
			{
				throw new ParserException(ParserError.CODE_EMPTY);
			}
			string codeLine = IntoALine(code);
			IEnumerable<string> nodeCollection = NodeToCollection(codeLine, CodeDeliminator);
			IEnumerable<Parameter> parameters = ParseNode(nodeCollection);

			return parameters;
		}

		/// <summary>
		/// パラメータノードを解析して、ParameterオブジェクトのCollectionに変換します。
		/// Parse parameter node and change into Collection of Parameter object.
		/// </summary>
		/// <param name="nodes">
		/// 解析対象の文字列の集合
		/// Collection of string to be parsed.
		/// </param>
		/// <returns>
		/// 解析したParameterオブジェクトの集合
		/// Colletion of Parameter object parsed from code.
		/// </returns>
		/// <exception cref="NullReferenceException"></exception>
		protected virtual IEnumerable<Parameter> ParseNode(IEnumerable<string> nodes)
		{
			var parameters = new List<Parameter>();
			foreach (var node in nodes)
			{
				try
				{
					Parameter parameter = ParseNode(node);
					parameters.Add(parameter);
				}
				catch (ParserException ex)
				{
					Console.WriteLine("An exception detected while parse parameter.");
					Console.WriteLine($"Error code : 0x{ex.Code:X8}");
					Console.WriteLine("Skip the node.");
				}
				catch (ArgumentException)
				{
					Console.WriteLine("An exception detected while parse parameter.");
					Console.WriteLine("Skip the node.");
				}
			}
			return parameters;
		}

		/// <summary>
		/// Parse node and change it into Parameter object.
		/// </summary>
		/// <param name="node">String to be parsed.</param>
		/// <returns>Parameter object parsed from node.</returns>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ParameterException"></exception>
		/// <exception cref="ParserException"></exception>
		protected virtual Parameter ParseNode(string node)
		{
			try
			{
				ParseNode(node, out Parameter parameter);
				parameter.Validate();

				return parameter;
			}
			catch (ParserException)
			{
				throw;
			}
		}

		protected virtual void ParseNode(string node, out Parameter parameter)
		{
			try
			{
				(string type, string name) = SplitToDataTypeAndName(node);
				(IEnumerable<string> modifier, string dataType) = SplitToModifierAndType(type);
				parameter = new Parameter()
				{
					Name = name,
					DataType = dataType,
					PreModifiers = modifier
				};
			}
			catch (ParserException)
			{
				throw;
			}
			catch (ArgumentException)
			{
				bool isVoid = IsVoid(node);
				if (isVoid)
				{
					parameter = new Parameter()
					{
						Name = string.Empty,
						DataType = node
					};
				}
				else
				{
					throw new ParserException(ParserError.INVALID_DATA_TYPE_VOID);
				}
			}
		}

		/// <summary>
		/// ノードをデータ型と名前に分割します。
		/// Split the node into data type and name.
		/// </summary>
		/// <param name="node">
		/// 分割対象のノード
		/// Node to be splitted.
		/// </param>
		/// <returns>
		/// 分割された、タプル形式のデータ型と名前
		/// Splitted data type and name in tuple type.
		/// </returns>
		/// <exception cref="ArgumentException"></exception>
		protected virtual (string dataType, string name) SplitToDataTypeAndName(string node)
		{
			List<string> nodeCollection = NodeToCollection(node, CodeDeliminator_TYPE_AND_NAME).ToList();
			if (nodeCollection.Count() < 2)
			{
				throw new ArgumentException("Input code is invalid.");
			}
			int nameIndex = nodeCollection.Count() - 1;
			string name = nodeCollection.ElementAt(nameIndex);
			nodeCollection.RemoveAt(nameIndex);

			string dataType = string.Join(" ", nodeCollection);
			return (dataType, name);
		}

		/// <summary>
		/// ノードを、修飾子とデータ型に分割します。
		/// Split the node into modifier and data type.
		/// </summary>
		/// <param name="node">
		/// 分割対象のノード
		/// Node to be splitted.
		/// </param>
		/// <returns>
		/// 分割された修飾子とデータ型(タプル形式)
		/// Modifier and data type in tuple.
		/// </returns>
		/// <exception cref="ArgumentException"></exception>
		protected virtual (IEnumerable<string> modifier, string name) SplitToModifierAndType(string node)
		{
			List<string> modifier = null;
			string name = string.Empty;
			var splittedNode = 
				node.Split(CodeDeliminator_MOD_AND_TYPE, StringSplitOptions.RemoveEmptyEntries).ToList();
			if (1 == splittedNode.Count())
			{
				modifier = new List<string>();
				name = splittedNode.First();
			}
			else if (1 < splittedNode.Count())
			{
				int nameIndex = splittedNode.Count() - 1;
				name = splittedNode.ElementAt(nameIndex);
				splittedNode.RemoveAt(nameIndex);
				modifier = splittedNode;
			}
			else
			{
				throw new ArgumentException();
			}
			return (modifier, name);
		}

		/// <summary>
		/// ノードを、文字列のコレクションに変換します。
		/// Change node into collection of string.
		/// </summary>
		/// <param name="node">
		/// 変換対象の文字列
		/// String to be changed.
		/// </param>
		/// <returns>
		/// 変換された、文字列のコレクション。
		/// Collection of string changed from node.
		/// </returns>
		protected virtual IEnumerable<string> NodeToCollection(string node, char[] deliminator)
		{
			IEnumerable<string> nodes = node.Split(deliminator, StringSplitOptions.RemoveEmptyEntries);
			return nodes;
		}

		/// <summary>
		/// 文字列の改行コードを半角スペースに変換し、複数行の文字列を１行にまとめます。
		/// Converts the line feed code of the character string to a half-width space,
		/// and combines the character strings of multiple lines into one line.
		/// </summary>
		/// <param name="node">
		/// 変換対象のコード
		/// Node to be changed.
		/// </param>
		/// <returns>
		/// 1行に変換されたコード
		/// Code changed into a line.
		/// </returns>
		protected virtual string IntoALine(string node)
		{
			string nodeLine = node
				.Replace("\r\n", "\n")
				.Replace("\r", "\n")
				.Replace("\n", " ");
			return nodeLine;
		}

		/// <summary>
		/// コードのデータ型がvoid型か否かを判定する。
		/// Judge whether the data type in a code is void or not.
		/// </summary>
		/// <param name="code">
		/// 確認対象のコード
		/// Code to be judged.
		/// </param>
		/// <returns>
		/// void型の場合にはtrue、それ以外の場合にはfalse.
		/// Returns ture if the data type is "void", otherwise returns false.
		/// </returns>
		protected virtual bool IsVoid(string code)
		{
			IEnumerable<string> nodes = code.Split(CodeDeliminator_VOID, StringSplitOptions.RemoveEmptyEntries);
			if (nodes.Count() < 1)
			{
				return false;
			}
			else
			{
				if (nodes.ElementAt(0).ToLower().Equals("void"))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
	}
}
