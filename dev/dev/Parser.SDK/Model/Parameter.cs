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
		/// Collection of prefix modifier.
		/// </summary>
		public IEnumerable<string> PreModifiers {get;set;}

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
			PreModifiers = new List<string>();
		}

		/// <summary>
		/// Create parameter in string.
		/// </summary>
		/// <returns>Parameter in string.</returns>
		public override string ToString()
		{
			string toString = string.Empty;
			foreach (var item in PreModifiers)
			{
				toString += item;
				toString += " ";
			}
			toString += DataType;
			if ((!(string.IsNullOrEmpty(Name))) && (!(string.IsNullOrWhiteSpace(Name))))
			{
				toString += $" {Name}";
			}
			return toString;
		}

		public virtual void CopyTo(Parameter dst)
		{
			dst.Name = Name;
			dst.DataType = DataType;
			dst.FileName = FileName;
			dst.PreModifiers = new List<string>(PreModifiers);
		}
	}
}
