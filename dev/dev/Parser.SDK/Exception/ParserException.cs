using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.SDK.Exception
{
	public class ParserException : System.Exception
	{
		/// <summary>
		/// Error code.
		/// </summary>
		public UInt32 Code { get; protected set; }

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ParserException() : base() { }

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="errorCode">Error code.</param>
		public ParserException(UInt32 errorCode) : base()
		{
			Code = errorCode;
		}

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="message">Exception message.</param>
		public ParserException(string message) : base(message) { }

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="message">Exception message</param>
		/// <param name="innerException">Inner exception.</param>
		public ParserException(string message, System.Exception innerException) : base(message, innerException) { }

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="errorCode">Error code.</param>
		/// <param name="message">Exception message</param>
		/// <param name="innerException">Inner exception.</param>
		public ParserException(UInt32 errorCode, string message, System.Exception innerException)
			: base(message, innerException)
		{
			Code = errorCode;
		}
	}
}
