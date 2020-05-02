using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
	public class CLangHeaderStubCodeWriter : CLangHeaderCodeWriter
	{
		#region Constant
		/// <summary>
		/// Output stub header file name.
		/// </summary>
		protected static readonly string StubHeaderFileName = "stub.h";
		#endregion

		#region Constructor
		/// <summary>
		/// Default constructor
		/// </summary>
		/// <param name="outputPath"></param>
		public CLangHeaderStubCodeWriter(string outputPath) : base(outputPath, StubHeaderFileName) { }
		#endregion
	}
}
