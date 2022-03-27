using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.SDK.Model
{
	public class Function : Variable
	{
		/// <summary>
		/// Arguments.
		/// </summary>
		public IEnumerable<Parameter> Arguments { get; set; }

		/// <summary>
		/// Convert to string.
		/// </summary>
		/// <returns>Function in string data type.</returns>
		public override string ToString()
		{
			string toString = string.Empty;

			//関数宣言
			toString = $"{DataType}";
			for (int index = 0; index < PointerNum; index++)
			{
				toString += "*";
			}
			toString += $" {Name}";
			toString += "(";
			bool isTop = true;
			foreach (var item in Arguments)
			{
				if (!isTop)
				{
					toString += ", ";
				}
				toString += item.ToString();
			}
			toString += ")";

			return toString;
		}
	}
}
