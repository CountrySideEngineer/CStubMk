using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CStubMKGui.Model
{
	public class CLangHeaderCodeWriter : ACLangCodeWriter
	{
		#region Constructor
		public CLangHeaderCodeWriter(string outputPath, string fileName)
		{
			try
			{
				this.OutputFilePath = $@"{outputPath}\{fileName}";
			}
			catch (Exception)
			{
				this.OutputFilePath = @"./default_c_source.h";
			}
		}
		#endregion

		#region Public properties
		/// <summary>
		/// Path to file.(Absolute file path)
		/// </summary>
		public string OutputFilePath { get; protected set; }
		#endregion

		#region Methods in calling order.
		/// <summary>
		/// Wrtie code into a file.
		/// </summary>
		/// <param name="codes">List of code to write into file.</param>
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
