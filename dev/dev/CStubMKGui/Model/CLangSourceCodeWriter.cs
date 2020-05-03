using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CStubMKGui.Model
{
	/// <summary>
	/// Class to write code of C language into a text file.
	/// </summary>
	public class CLangSourceCodeWriter : ACLangCodeWriter
	{
		/// <summary>
		/// Constructor of CLangSourceCodeWriter class.
		/// </summary>
		/// <param name="outputPath">Path to directory to output file.</param>
		/// <param name="fileName">Name of file</param>
		public CLangSourceCodeWriter(string outputPath, string fileName)
		{
			try
			{
				this.OutputFilePath = $@"{outputPath}\{fileName}";
			}
			catch (Exception)
			{
				this.OutputFilePath = @"./default_c_source.c";
			}
		}

		/// <summary>
		/// Constructor of CLangSourceCodeWriter class with output file path.
		/// </summary>
		/// <param name="outputFilePath">File path to output the code.</param>
		public CLangSourceCodeWriter(string outputFilePath)
		{
			this.OutputFilePath = outputFilePath;
		}

		#region Public properties

		/// <summary>
		/// Path to file. (Absolute path to file).
		/// </summary>
		public string OutputFilePath { get; protected set; }
		#endregion

		#region Method in calling order.
		/// <summary>
		/// Write code into a file.
		/// </summary>
		/// <param name="codes">Codes to write into, a code in a line.</param>
		public override void WriteCode(IEnumerable<string> codes)
		{
			this.WriteCode(this.OutputFilePath, codes);
		}

		/// <summary>
		/// Write code into a file specified by argument outputFilePath.
		/// </summary>
		/// <param name="outputFilePath">Path to output file.</param>
		/// <param name="codes">List of code to write into the stream.</param>
		/// <remarks>If the file specified by outputFilePath has already been exit, it is overwritten by new codes.</remarks>
		protected void WriteCode(string outputFilePath, IEnumerable<string> codes)
		{
			using (var writer = new StreamWriter(outputFilePath, false, Encoding.GetEncoding("UTF-8")))
			{
				this.WriteCode(writer, codes);
			}
		}

		/// <summary>
		/// Write code into text file
		/// </summary>
		/// <param name="writer">Text stream to output</param>
		/// <param name="codes">List of code to write into the stream.</param>
		protected void WriteCode(TextWriter writer, IEnumerable<string> codes)
		{
			foreach (var code in codes)
			{
				writer.WriteLine(code);
			}
		}
		#endregion
	}
}
