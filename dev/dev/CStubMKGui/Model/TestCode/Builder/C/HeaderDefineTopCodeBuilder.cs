using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
	/// <summary>
	/// Create code of "#ifndef" code to be set at the top of header file.
	/// </summary>
	public class HeaderDefineTopCodeBuilder : AStubBuilder
	{
		#region Constructors and the finalizer
		/// <summary>
		/// Default constructor.
		/// </summary>
		public HeaderDefineTopCodeBuilder() : base(100) { }
		#endregion

		#region Override of interface.
		/// <summary>
		/// Create code to define part to prevent include duplicate.
		/// </summary>
		/// <param name="codeSrc">Function information.</param>
		public override void CreateCode(object codeSrc)
		{
			this.Codes = new List<string>();
			this.Codes.Clear();

			this.CreateDefineTopPart();
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
		/// Create code of define macro to set at the start of header file.
		/// </summary>
		protected void CreateDefineTopPart()
		{
			string code = "#ifndef _STUB_H_";
			this.SetCode(code, 0);

			code = "#define _STUB_H_";
			this.SetCode(code, 0);
		}
		#endregion
	}
}
