using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
	/// <summary>
	/// Create header code of stub in C language.
	/// </summary>
	public class CLangHeaderStubCodeCreater : ACLangStubCodeCreater
	{
		#region Override of interface / Factory method.
		/// <summary>
		/// Create director to create code using builder obejct derived from ICodeBuilder.
		/// </summary>
		/// <param name="builder">Object to be used to create the director.</param>
		/// <returns>Director object to create header file.</returns>
		protected override SourceCodeDirector GetDirector(ICodeBuilder builder)
		{
			return new SourceCodeDirector(builder);
		}

		/// <summary>
		/// Create list of builders.
		/// </summary>
		/// <returns>List ob builders.</returns>
		protected override IEnumerable<ICodeBuilder> GetBuilders()
		{
			var builders = new List<ICodeBuilder>
			{
				new HeaderStubBufferDeclareCodeBuilder(),
				new HeaderStubInitBufferEntryPointCodeBuilder()
			};
			return builders;
		}
		#endregion
	}
}
