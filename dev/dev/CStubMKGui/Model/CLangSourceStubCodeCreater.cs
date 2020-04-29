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
		#region Factory method.
		/// <summary>
		/// Create director to create code using bilder, ICodeBuilder object
		/// </summary>
		/// <returns>Director to create code by </returns>
		protected override SourceCodeDirector GetDirector(ICodeBuilder builder)
		{
			return new SourceCodeDirector(builder);
		}
		#endregion

		#region Public method of interface.
		/// <summary>
		/// Create codes of stub in C language method.
		/// </summary>
		/// <param name="parameters">Parameters of method.</param>
		/// <returns>List of code in C language, a code in a line.</returns>
		public override IEnumerable<string> Create(IEnumerable<Param> parameters)
		{
			return this.CreateCode(parameters);
		}
		#endregion

		#region Protecte or private method.
		/// <summary>
		/// Create code from parameters.
		/// </summary>
		/// <param name="parameters">List of parameters to create codes.</param>
		/// <returns>List of codes.</returns>
		protected IEnumerable<string> CreateCode(IEnumerable<Param> parameters)
		{
			var builders = new List<ICodeBuilder>
				{
					new SourceStubBufferDeclareCodeBuilder(),
					new SourceStubEntryPointCodeBuilder(),
					new SourceStubBodyCodeBuilder()
				};
			var codes = base.Create(builders, parameters);

			return codes;
		}
		#endregion
	}
}
