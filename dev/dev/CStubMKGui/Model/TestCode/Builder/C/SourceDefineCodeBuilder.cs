using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
	public class SourceDefineCodeBuilder : AStubBuilder
	{
		#region Constructors and the finalizer
		/// <summary>
		/// Default constructor.
		/// </summary>
		public SourceDefineCodeBuilder() : base(100) { }
		#endregion

		#region Override of interface.
		public override void CreateCode(object codeSrc)
		{
			this.Codes = new List<string>();
			this.Codes.Clear();

			this.CreateDefinePart();
		}

		public override object GetResult()
		{
			return (object)this.Codes;
		}
		#endregion

		#region Protected and private method.
		protected void CreateDefinePart()
		{
			string buffSizeString = Convert.ToString(base.BuffSize);
			string code = $"#define\t\t{base.BufferSizeMacroCode}\t\t\t({buffSizeString})";
			this.SetCode(code, 0);
		}
		#endregion
	}
}
