using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
	public class HeaderStubInitBufferEntryPointCodeBuilder : SourceStubInitBufferEntryPointCodeBuilder
	{
		#region Constants
		protected readonly string BufferExternModifier = "extern";
		#endregion

		#region Protected or private method.
		/// <summary>
		/// Create code to delcare external of entry point of method to initialize buffer of stub.
		/// </summary>
		/// <param name="function">Information of method.</param>
		/// <remarks>
		/// The code this method creates is in the format below.
		/// <c>extern void "FunctionName"_init();</c>
		/// </remarks>
		protected override void CreateEntryPoint(Param function)
		{
			string code = $"{BufferExternModifier} {BufferInitMethodDataType} {function.Name}{BufferInitMethodPostfix}();";
			this.Codes.Add(code);
		}
		#endregion
	}
}
