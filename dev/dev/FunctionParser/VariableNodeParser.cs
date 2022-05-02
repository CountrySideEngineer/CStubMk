using Parser.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionParser
{
	public class VariableNodeParser : ParameterNodeParser
	{
		/// <summary>
		/// Parse node and change it into Variable object.
		/// </summary>
		/// <param name="node">String to be parsed.</param>
		/// <returns>Variable object parsed from node.</returns>
		/// <exception cref="ArgumentException"></exception>
		protected override Parameter ParseNode(string node)
		{
			try
			{
				Parameter baseParameter = base.ParseNode(node);
				Parameter variable = new Variable();
				baseParameter.CopyTo(variable);
				((Variable)variable).PointerNum = GetPointerNum(baseParameter.DataType);
				((Variable)variable).DataType = RemovePointer(baseParameter.DataType);
				return variable;
			}
			catch (ArgumentException ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// ノードをデータ型と名前に分割します。
		/// ポインタ文字は、データ型にまとめられます。
		/// Split the node into data type and name.
		/// Pointer characters are set to the data type.
		/// </summary>
		/// <param name="node">
		/// 分割対象のノード
		/// Node to be splitted.
		/// </param>
		/// <returns>
		/// 分割された、タプル形式のデータ型と名前
		/// Splitted data type and name in tuple type.
		/// </returns>
		protected override (string dataType, string name) SplitToDataTypeAndName(string node)
		{
			string pointerSpacedNode = node.Replace("*", " * ");
			(string dataType, string name) = base.SplitToDataTypeAndName(pointerSpacedNode);
			/*
			 * Data type in splittedNode.dataType has white space in front and behind of "*".
			 * The space make the data type invalid.
			 * To correct the format of it, remove them.
			 */
			string dataTypeWithPointer = dataType
				.Replace(" *", "*")
				.Replace("* ", "*");
			return (dataTypeWithPointer, name);
		}

		protected override IEnumerable<string> NodeToCollection(string node, char[] deliminator)
		{
			IEnumerable<string> nodes = base.NodeToCollection(node, deliminator);
			IEnumerable<string> nodesWithoutWhiteSpace = nodes.Where(_ => (!string.IsNullOrEmpty(_)) && (!(string.IsNullOrWhiteSpace(_))));
			return nodesWithoutWhiteSpace;
		}

		/// <summary>
		/// Get the number of pointer character "*" in the data type.
		/// </summary>
		/// <param name="dataType">Data type code to check.</param>
		/// <returns>The number of pointer in the dataType.</returns>
		/// <exception cref="ArgumentException"></exception>
		protected virtual int GetPointerNum(string dataType)
		{
			int pointerNum = 0;
			int dataTypeLen = dataType.Length;
			int indexToCheck = dataTypeLen;
			while (0 < indexToCheck)
			{
				string character = dataType.Substring(indexToCheck - 1, 1);
				if (character.Equals("*")) {
					pointerNum++;
					indexToCheck--;
				}
				else
				{
					break;
				}
			}

			//データ型に含まれる「*」とポインタ数が一致していない場合、エラーとする。
			//When the number of "*" in data type doest not equal to the value pointerNum,
			//throw exception (ArgumetnException) as error.
			int pointerSignNum = dataType.Length - dataType.Replace("*", "").Length;
			if (pointerNum != pointerSignNum)
			{
				throw new ArgumentException();
			}
			return pointerNum;
		}

		/// <summary>
		/// データ型から、ポインタ文字「*」を削除します。
		/// Remove pointer character "*" from the data type.
		/// </summary>
		/// <param name="dataType">Code to remove "*" from.</param>
		/// <returns>Data type "*" removed from.</returns>
		protected virtual string RemovePointer(string dataType)
		{
			string dataTypeWithoutPoiter = dataType.Replace("*", "").Trim();
			return dataTypeWithoutPoiter;
		}
	}
}
