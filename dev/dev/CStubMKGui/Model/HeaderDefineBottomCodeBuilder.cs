using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
	/// <summary>
	/// Create code of "#endif" code to be set at the end of header file.
	/// </summary>
	public class HeaderDefineBottomCodeBuilder : AStubBuilder
	{
		#region Constructors and the finalizer
		/// <summary>
		/// Default constructor.
		/// </summary>
		public HeaderDefineBottomCodeBuilder() : base(100) { }
		#endregion

		#region Override of interface.
		/// <summary>
		/// Create code of the end of "#ifdef" define part.
		/// </summary>
		/// <param name="codeSrc"></param>
		public override void CreateCode(object codeSrc)
		{
			this.Codes = new List<string>();
			this.Codes.Clear();

			this.CreateDefineEndPart();
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

		#region MyRegion
		/// <summary>
		/// Create code of define macro to set at the end of header file.
		/// </summary>
		protected void CreateDefineEndPart()
		{
			string code = "#endif";
			this.SetCode(code, 0);
		}
		#endregion
	}
}
