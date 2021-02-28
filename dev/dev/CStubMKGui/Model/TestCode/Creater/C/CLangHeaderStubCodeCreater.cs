using System;
using System.Collections.Generic;
using System.Linq;
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
				new SourceFunctionHeaderCodeBuilder(),
				new HeaderStubBufferDeclareCodeBuilder(),
				new HeaderStubInitBufferEntryPointCodeBuilder()
			};
			return builders;
		}
		#endregion

		#region Protected or private method in calling order.
		/// <summary>
		/// Create code from parameters.
		/// </summary>
		/// <param name="parameters">Source information for code.</param>
		/// <returns>List of codes.</returns>
		protected override IEnumerable<string> CreateCode(IEnumerable<Param> parameters)
		{
			var builderForTop = new HeaderDefineTopCodeBuilder();
			var tempParam = new Param();
			var startCodes = base.Create(builderForTop, tempParam);
			var codes = startCodes.Concat(base.CreateCode(parameters));

			var builderForBottom = new HeaderDefineBottomCodeBuilder();
			var endCodes = base.Create(builderForBottom, tempParam);
			codes = codes.Concat(endCodes);

			return codes;
		}
		#endregion
	}
}
