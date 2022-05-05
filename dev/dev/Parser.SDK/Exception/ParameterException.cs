using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.SDK.Exception
{
	public class ParameterException : System.Exception
	{
		/// <summary>
		/// Error code.
		/// </summary>
		public UInt32 Code { get; protected set; }

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ParameterException() : base() { }

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="errorCode">Error code about exception.</param>
		public ParameterException(UInt32 errorCode) : base()
		{
			Code = errorCode;
		}

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="errorCode">Error code about exception.</param>
		/// <param name="message">Error message.</param>
		public ParameterException(UInt32 errorCode, string message) : base(message)
		{
			Code = errorCode;
		}

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="errorCode">Error code about exception.</param>
		/// <param name="message">Error message.</param>
		/// <param name="innerException">Inner exception.</param>
		public ParameterException(UInt32 errorCode, string message, System.Exception innerException) 
			: base(message, innerException) 
		{
			Code = errorCode;
		}
	}
}
