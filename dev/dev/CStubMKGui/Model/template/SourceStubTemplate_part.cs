using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model.template
{
	public partial class SourceStubTemplate : StubCodeTemplateBase
	{
		#region Constructor
		public SourceStubTemplate(IEnumerable<Param> functions) : base( functions)
		{
			//Nothing to do!
		}

		public string MemberFunc()
		{
			return "This is sampel functoin";
		}
		#endregion
	}
}
