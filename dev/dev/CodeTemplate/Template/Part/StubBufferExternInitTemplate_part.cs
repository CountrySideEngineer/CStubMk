using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTemplate.Template
{
	public partial class StubBufferExternInitTemplate : StubBufferInitTemplate
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public StubBufferExternInitTemplate() : base() { }

		public override string StubInitializeEntryPoint()
		{
			string baseCode = base.StubInitializeEntryPoint();
			string code = $"{baseCode};";
			return code;
		}
	}
}
