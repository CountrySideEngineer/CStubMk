using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
	/// <summary>
	/// Builder class to create code to include default header files.
	/// </summary>
	public class SourceIncludeCodeBuilder : AStubBuilder
	{
		#region Constructors and the finalizer
		/// <summary>
		/// Default constructor.
		/// </summary>
		public SourceIncludeCodeBuilder() : base(100) { }
		#endregion

		#region Override interface.
		/// <summary>
		/// Create code to include header files.
		/// </summary>
		/// <param name="codeSrc">Function information.</param>
		public override void CreateCode(object codeSrc)
		{
			this.Codes = new List<string>();
			this.Codes.Clear();

			this.CreateIncludePart();
		}

		/// <summary>
		/// Get code object.
		/// </summary>
		/// <returns>Created codes.</returns>
		public override object GetResult()
		{
			return (object)this.Codes;
		}
		#endregion

		#region Protected or private methods.
		/// <summary>
		/// Create code to inlucde standart header files.
		/// </summary>
		protected void CreateIncludePart()
		{
			string code = "#include <stdio.h>";
			this.SetCode(code, 0);
		}
		#endregion
	}
}
