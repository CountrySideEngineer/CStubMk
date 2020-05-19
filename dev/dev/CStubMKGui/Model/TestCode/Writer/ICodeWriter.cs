using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
	/// <summary>
	/// Interface of class to write code.
	/// </summary>
	public interface ICodeWriter
	{
		/// <summary>
		/// Interface to write code via writer.
		/// </summary>
		/// <param name="codes">List of code to write in.</param>
		public void WriteCode(IEnumerable<string> codes);
	}
}
