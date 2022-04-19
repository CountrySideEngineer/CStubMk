using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reader.SDK;
using Reader.SDK.Model;

namespace Reader
{
	public abstract class AFunctionReader : IReader
	{
		/// <summary>
		/// Method to read function list in a file. 
		/// </summary>
		/// <param name="path">Path to file to read.</param>
		/// <returns>Collection of code read from the file.</returns>
		public abstract IEnumerable<ParameterInformation> Read(string path);

		/// <summary>
		/// Delegate to handle "LOG" event.
		/// </summary>
		/// <param name="sender">Event sender</param>
		/// <param name="message">Event message.</param>
		public delegate void LogEventHandler(object sender, string message);

		/// <summary>
		/// "INFO" level event.
		/// </summary>
		public event LogEventHandler InfoLog;

		/// <summary>
		/// "DEBUG" level event.
		/// </summary>
		public event LogEventHandler DebugLog;

		/// <summary>
		/// "WARNING" level event
		/// </summary>
		public event LogEventHandler WarnLog;

		/// <summary>
		/// "ERROR" level event.
		/// </summary>
		public event LogEventHandler ErrorLog;

		/// <summary>
		/// "FATAL" level event.
		/// </summary>
		public event LogEventHandler FatalLog;

		/// <summary>
		/// Raise INFO level event.
		/// </summary>
		/// <param name="message">Event message.</param>
		public void INFO(string message) { InfoLog?.Invoke(this, message); }
		
		/// <summary>
		/// Raise DEBUG level event.
		/// </summary>
		/// <param name="message">Event message</param>
		public void DEBUG(string message) { DebugLog?.Invoke(this, message); }

		/// <summary>
		/// Raise WARNING level event.
		/// </summary>
		/// <param name="message">Event message.</param>
		public void WARN(string message) { WarnLog?.Invoke(this, message); }

		/// <summary>
		/// Raise ERROR level event.
		/// </summary>
		/// <param name="message">Event message.</param>
		public void ERROR(string message) { ErrorLog?.Invoke(this, message);  }

		/// <summary>
		/// Raise FATAL level event.
		/// </summary>
		/// <param name="message">Event message.</param>
		public void FATAL(string message) { FatalLog?.Invoke(this, message); }
	}
}
