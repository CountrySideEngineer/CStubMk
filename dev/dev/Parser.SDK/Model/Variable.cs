using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.SDK.Model
{
	public class Variable : Parameter
	{
		/// <summary>
		/// The number of pointer.
		/// </summary>
		public int PointerNum { get; set; }

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Variable() : base()
		{
			PointerNum = 0;
		}

		/// <summary>
		/// Convert to string.
		/// </summary>
		/// <returns>Variable in string.</returns>
		public override string ToString()
		{
			string pointers = string.Empty;
			for (int index = 0; index < PointerNum; index++)
			{
				pointers += "*";
			}

			string toString = $"{DataType}{pointers} {DataType}";
			return toString;
		}
	}
}
