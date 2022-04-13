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
			return string.Empty;
		}

		public virtual string GenerateBufferDeclareCode()
		{
			return string.Empty;
		}

		public virtual string GenerateBufferInitCode()
		{
			return string.Empty;
		}
	}
}
