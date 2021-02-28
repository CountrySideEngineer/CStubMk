using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
	public abstract class ASourceFileCreater : ISourceFileCreater
	{
		#region Factory method. / Abstract method.
		/// <summary>
		/// Abstract method to create object to write code into a target device.
		/// </summary>
		/// <param name="outputPath">Path to output the code.</param>
		/// <returns>Object inherits ICodeWriter interface.</returns>
		public abstract ICodeWriter GetCodeWriter(string outputPath);

		/// <summary>
		/// Abstract method to create object to create list of codes derived from parameters.
		/// </summary>
		/// <returns>Object inherits ICodeCreater interface.</returns>
		public abstract ICodeCreater GetCodeCreater();
		#endregion

		#region Override of interface.
		/// <summary>
		/// Create code file from parameters.
		/// </summary>
		/// <param name="outputPath">Path to folder the file should be created.</param>
		/// <param name="parameters">Parameters for output file.</param>
		public void Create(string outputPath, IEnumerable<Param> parameters)
		{
			this.CreateCode(outputPath, parameters);
		}
		#endregion

		#region Protected or private methods.
		/// <summary>
		/// Create code file from parameters by running a sequence to write into.
		/// </summary>
		/// <param name="outputPath">Path to folder the file should be created.</param>
		/// <param name="parameters">Parameters for output file.</param>
		/// <returns>List of codes to be written into a file.</returns>
		protected virtual void CreateCode(string outputPath, IEnumerable<Param> parameters)
		{
			var codes = this.CreateCode(parameters);
			this.WriteCode(outputPath, codes);
		}

		/// <summary>
		/// Create code file from parameters by running a sequence to write into.
		/// </summary>
		/// <param name="parameters">Parameters for output file.</param>
		/// <returns>List of codes to be written into a file.</returns>
		protected virtual IEnumerable<string> CreateCode(IEnumerable<Param> parameters)
		{
			var codeCreater = this.GetCodeCreater();
			var codes = this.CreateCode(codeCreater, parameters);

			return codes;
		}

		/// <summary>
		/// Create list of codes to be written into a file.
		/// </summary>
		/// <param name="codeCreater">Object to create list of codes.</param>
		/// <param name="parameters">Parameters for output file.</param>
		/// <returns>List of codes to be written into a file.</returns>
		protected virtual IEnumerable<string> CreateCode(ICodeCreater codeCreater, IEnumerable<Param> parameters)
		{
			var codes = codeCreater.Create(parameters);
			return codes;
		}

		/// <summary>
		/// Write codes into a file.
		/// </summary>
		/// <param name="outputPath">Path to folder the file output.</param>
		/// <param name="codes">List of codes to be written into a file.</param>
		protected virtual void WriteCode(string outputPath, IEnumerable<string> codes)
		{
			var writer = this.GetCodeWriter(outputPath);
			this.WriteCode(writer, codes);
		}

		/// <summary>
		/// Write codes into a file.
		/// </summary>
		/// <param name="writer">Object, inherits ICodeWriter, to write code into a file.</param>
		/// <param name="codes">List of codes to be written into a file.</param>
		protected virtual void WriteCode(ICodeWriter writer, IEnumerable<string> codes)
		{
			writer.WriteCode(codes);
		}
		#endregion
	}
}
