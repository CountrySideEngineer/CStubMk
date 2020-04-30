using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CStubMKGui.Model
{
	/// <summary>
	/// Builder class to create comment about function header.
	/// </summary>
	public class SourceFunctionHeaderCodeBuilder : AStubBuilder
	{
		#region Constant
		protected readonly string CommentLineStartTag = "/*----";
		protected readonly string CommentLineEndTag = "----*/";
		protected readonly string HeaderStartTag = "Start";
		protected readonly string HeaderStubTag = "stub";
		protected readonly string SpacerHyphen = "-";
		protected readonly string SpacerWhireSpace = " ";
		#endregion

		#region Constructor
		/// <summary>
		/// Default constructor.
		/// </summary>
		public SourceFunctionHeaderCodeBuilder() : base(100)
		{
			this.Codes = null;
		}
		#endregion

		#region Public methods
		/// <summary>
		/// Create method header.
		/// </summary>
		/// <param name="codeSrc">Parameter ot create method header.</param>
		public override void CreateCode(object codeSrc)
		{
			try
			{
				if (null == codeSrc)
				{
					throw new ArgumentNullException(nameof(CreateCode));
				}
				var function = (Param)codeSrc;

				this.Codes = new List<string>();
				this.Codes.Clear();

				this.CreateCodeOfTopAndBottom(function);
				this.CreateCodeOfMiddle(function);
				this.CreateCodeOfSummary(function);
				this.CreateCodeOfMiddle(function);
				this.CreateCodeOfTopAndBottom(function);
			}
			catch (InvalidCastException)
			{
				Debug.WriteLine("Input is invalid / SKIP");
			}
		}

		/// <summary>
		/// Get the result.
		/// </summary>
		/// <returns>Comment codes of method. </returns>
		public override object GetResult()
		{
			return (object)this.Codes;
		}
		#endregion

		#region protected or private methods.
		/// <summary>
		/// Create code of start and end line of method header.
		/// </summary>
		/// <param name="function">Information of method.</param>
		protected void CreateCodeOfTopAndBottom(Param function)
		{
			string topAndBottomLine = this.CreateSpaceLine(function, SpacerHyphen);
			this.Codes.Add(topAndBottomLine);
		}

		/// <summary>
		/// Create code of middle line in method header.
		/// </summary>
		/// <param name="function">Information of method.</param>
		protected void CreateCodeOfMiddle(Param function)
		{
			string middleLine = this.CreateSpaceLine(function, SpacerWhireSpace);
			this.Codes.Add(middleLine);
		}

		/// <summary>
		/// Create code of summary of function.
		/// </summary>
		/// <param name="function">Information of method.</param>
		protected void CreateCodeOfSummary(Param function)
		{
			string code = this.CreateTitleLine(function);
			this.Codes.Add(code);
		}

		/// <summary>
		/// Create code of method title.
		/// </summary>
		/// <param name="function">Information of method.</param>
		/// <returns>Comment of line showing name of method.</returns>
		/// <remarks>
		/// The format of line is next.
		/// "/*---- Start {Name of function} stub ----*/"
		/// </remarks>
		protected string CreateTitleLine(Param function)
		{
			string code = "";
			code = $"{CommentLineStartTag} {HeaderStartTag} {function.Name} {HeaderStubTag} {CommentLineEndTag}";
			return code;
		}

		/// <summary>
		/// Create code of line including spacer.
		/// </summary>
		/// <param name="function">Information of method.</param>
		/// <param name="spacer">A character to set as spacer.</param>
		/// <returns>Code of line with spacer.</returns>
		protected string CreateSpaceLine(Param function, string spacer)
		{
			string titleLine = this.CreateTitleLine(function);

			int titleLineLen = titleLine.Length;
			int spacerNum = titleLine.Length - ((this.CommentLineStartTag.Length) + (this.CommentLineEndTag.Length));
			string spaceLine = CommentLineStartTag;
			for (int index = 0; index < spacerNum; index++)
			{
				spaceLine += spacer;

			}
			spaceLine += CommentLineEndTag;
			return spaceLine;
		}
		#endregion

		#region Properties
		/// <summary>
		/// List of code.
		/// </summary>
		protected List<string> Codes;
		#endregion
	}
}
