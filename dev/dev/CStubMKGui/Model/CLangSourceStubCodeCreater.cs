using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CStubMKGui.Model
{
	/// <summary>
	/// Create source code of stub in C language.
	/// </summary>
	public class CLangSourceStubCodeCreater : ACLangStubCodeCreater
	{
		#region Override of interface / Factory method.
		/// <summary>
		/// Create director to create code using builder, ICodeBuilder object
		/// </summary>
		/// <returns>Director to create code by </returns>
		protected override SourceCodeDirector GetDirector(ICodeBuilder builder)
		{
			return new SourceCodeDirector(builder);
		}

		/// <summary>
		/// Create list of builders 
		/// </summary>
		/// <returns></returns>
		protected override IEnumerable<ICodeBuilder> GetBuilders()
		{
			var builders = new List<ICodeBuilder>
			{
				new SourceFunctionHeaderCodeBuilder(),
				new SourceStubBufferDeclareCodeBuilder(),
				new SourceStubEntryPointCodeBuilder(),
				new SourceStubBodyCodeBuilder(),
				new SourceStubInitBufferEntryPointCodeBuilder(),
				new SourceStubInitBufferBodyCodeBuilder()
			};
			return builders;
		}
		#endregion
	}
}
