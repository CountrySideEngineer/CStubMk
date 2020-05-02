using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
	public class CLangHeaderStubCodeCreater : ACLangStubCodeCreater
	{
		protected override SourceCodeDirector GetDirector(ICodeBuilder builder)
		{
			return new SourceCodeDirector(builder);
		}

		protected override IEnumerable<ICodeBuilder> GetBuilders()
		{
			var builders = new List<ICodeBuilder>
			{
				new HeaderStubBufferDeclareCodeBuilder(),
				new HeaderStubInitBufferEntryPointCodeBuilder()
			};
			return builders;
		}
	}
}
