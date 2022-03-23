using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.SDK.Model
{
	public class Parameter
	{
		/// <summary>
		/// Data type name.
		/// </summary>
		public string DataType { get; set; }

		/// <summary>
		/// Name of parameter.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// File name the parameter is implemented.
		/// </summary>
		public string FileName { get; set; }

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Parameter()
		{
			DataType = string.Empty;
			Name = string.Empty;
			FileName = string.Empty;
		}

		/// <summary>
		/// Create parameter in string.
		/// </summary>
		/// <returns>Parameter in string.</returns>
		public override string ToString()
		{
			string toString = $"{DataType} {Name}";
			return toString;
		}
	}
}
