using Parser.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTemplate.Template
{
	public partial class HeaderStubTemplate
	{
		public Function TargetFunction { get; set; }

		/// <summary>
		/// Default constructor.
		/// </summary>
		public HeaderStubTemplate() : base()
		{
			TargetFunction = null;
		}

		public virtual string GenerateStubBufferSizeMacroDefine()
		{
			var template = new StubBufferSizeMacroDefineTemplate();
			string code = base.GenerateCode(template);
			return code;
		}

		public virtual string GenerateBufferDeclareCode()
		{
			var template = new StubBufferExternDeclarationTemplate();
			string code = base.GenerateCode(template);
			return code;
		}

		public virtual string GenerateBufferInitCode()
		{
			var template = new StubBufferExternInitTemplate();
			string code = base.GenerateCode(template);
			return code;
		}
	}
}
