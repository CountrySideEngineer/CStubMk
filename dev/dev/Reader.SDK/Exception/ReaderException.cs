using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader.SDK.Exception
{
	public class ReaderException : System.Exception
	{
		/// <summary>
		/// Error code.
		/// </summary>
		public UInt32	Code { get; protected set; }

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ReaderException() : base() { }

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="errorCode">Error code.</param>
		public ReaderException(UInt32 errorCode) : base()
		{
			Code = errorCode;
		}

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="message">Exception message.</param>
		public ReaderException(string message) : base(message) { }

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="message">Exception message</param>
		/// <param name="innerException">Inner exception.</param>
		public ReaderException(string message, System.Exception innerException) : base(message, innerException) { }

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="errorCode">Error code.</param>
		/// <param name="message">Exception message</param>
		/// <param name="innerException">Inner exception.</param>
		public ReaderException(UInt32 errorCode, string message, System.Exception innerException) 
			: base(message, innerException)
		{
			Code = errorCode;
		}

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="errorCode">Error code.</param>
		/// <param name="innerException">Inner exception.</param>
		public ReaderException(UInt32 errorCode, System.Exception innerException) 
			: base(string.Empty, innerException)
		{
			Code = errorCode;
		}
	}
}
