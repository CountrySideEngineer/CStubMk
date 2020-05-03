using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
	/// <summary>
	/// Abstract class to write code.
	/// </summary>
	public abstract class ACLangCodeWriter : ICodeWriter
	{
		/// <summary>
		/// Interface to write code via writer.
		/// </summary>
		/// <param name="codes">List of code to write in.</param>
		public abstract void WriteCode(IEnumerable<string> codes);
	}
}
