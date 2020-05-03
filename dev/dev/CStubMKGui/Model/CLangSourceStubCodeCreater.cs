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

		#region Protected or private method in calling order
		protected override IEnumerable<string> CreateCode(IEnumerable<Param> parameters)
		{
			var builders = new List<ICodeBuilder>
			{
				new SourceIncludeCodeBuilder(),
				new SourceDefineCodeBuilder()
			};
			var startOfCodes = this.Create(builders, new Param());//The "new"ed Param object is not used.
			var createdCode = base.CreateCode(parameters);
			var code = startOfCodes.Concat(createdCode);

			return code;
		}

		#endregion
	}
}
