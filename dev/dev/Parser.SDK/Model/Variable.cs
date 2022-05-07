using Parser.SDK.Exception;
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
			string toString = string.Empty;
			foreach (var item in PreModifiers)
			{
				toString += item;
				toString += " ";
			}
			string pointers = string.Empty;
			for (int index = 0; index < PointerNum; index++)
			{
				pointers += "*";
			}
			toString += $"{DataType}{pointers}";
			if ((!(string.IsNullOrEmpty(Name))) && (!(string.IsNullOrWhiteSpace(Name))))
			{
				toString += $" {Name}";
			}
			return toString;
		}

		/// <summary>
		/// Copy data to Variable object.
		/// </summary>
		/// <param name="dst">Reference to Variable object, Parameter object data type, to copy to.</param>
		public override void CopyTo(Parameter dst)
		{
			base.CopyTo(dst);
			if (dst is Variable)
			{
				var variable = dst as Variable;
				variable.PointerNum = PointerNum;
			}
		}

		/// <summary>
		/// Validate parameters.
		/// </summary>
		/// <exception cref="InvalidOperationException"></exception>
		public override void Validate()
		{
			try
			{
				base.Validate();
			}
			catch (ParameterException ex)
			{
				if (ex.Code.Equals(ParserError.INVALID_DATA_TYPE_VOID))
				{
					if ((DataType.ToLower().Equals("void")) &&
						(PointerNum < 1) &&
						((!string.IsNullOrEmpty(Name)) && (!string.IsNullOrWhiteSpace(Name))))
					{
						throw;
					}
				}
				else
				{
					throw;
				}
			}

			if (PointerNum < 0)
			{
				throw new ParameterException(ParserError.INVALID_POINTER_LEVEL);
			}
		}
	}
}
