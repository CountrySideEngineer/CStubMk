using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelReader.Exception
{
	public class ExcelReaderException : System.Exception
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public ExcelReaderException() : base() { }

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="message">Message about exception.</param>
		public ExcelReaderException(string message) : base(message) { }

		/// <summary>
		/// Constructor with argument about messag and exceptoin.
		/// </summary>
		/// <param name="message">Message about exception.</param>
		/// <param name="innerException">Inner exception.</param>
		public ExcelReaderException(string message, System.Exception innerException) 
			: base(message, innerException) { }
	}
}
