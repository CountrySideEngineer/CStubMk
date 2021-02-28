using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
	public class StubSourceFileCreater : ASourceFileCreater
	{
		#region Override abstract methods.
		/// <summary>
		/// Returns object to create code.
		/// </summary>
		/// <returns>Object to create code.</returns>
		public override ICodeCreater GetCodeCreater()
		{
			var creater = new CLangSourceStubCodeCreater();
			return creater;
		}

		/// <summary>
		/// Retunrs object to write code into a file.
		/// </summary>
		/// <param name="outputPath">Path to folder to output a file.</param>
		/// <returns>Object to write code.</returns>
		public override ICodeWriter GetCodeWriter(string outputPath)
		{
			var writer = new CLangSourceStubCodeWriter(outputPath);
			return writer;
		}
		#endregion
	}
}
