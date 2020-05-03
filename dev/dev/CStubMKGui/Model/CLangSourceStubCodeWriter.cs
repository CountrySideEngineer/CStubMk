using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
	/// <summary>
	/// Class to wrtie code of stub of C language into a text file.
	/// </summary>
	public class CLangSourceStubCodeWriter : CLangSourceCodeWriter
	{
		#region Public static read-only fields
		/// <summary>
		/// Output stub file name.
		/// </summary>
		protected static readonly string StubFileName = "stub.c";
		#endregion

		#region Constructors and the finalizer
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="outputPath">Path to directory to output source code.</param>
		public CLangSourceStubCodeWriter(string outputPath) : base(outputPath, StubFileName) { }
		#endregion
	}
}
