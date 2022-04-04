using Parser.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTemplate.Template
{
	public partial class SourceStubTemplate
	{
		public Function TargetFunc { get; set; }

		/// <summary>
		/// Default constructor.
		/// </summary>
		public SourceStubTemplate() : base()
		{
			TargetFunc = null;
		}

		/// <summary>
		/// Generate code to declare buffers.
		/// </summary>
		/// <returns>Code to declare buffers.</returns>
		public string GenerateBufferDeclareCode()
		{
			return string.Empty;
		}

		/// <summary>
		/// Generate method code to initialize 
		/// </summary>
		/// <returns>Codes of method to initialize buffers.</returns>
		public string GenerateBufferInitCode()
		{
			return string.Empty;
		}

		/// <summary>
		/// Generate stub body.
		/// </summary>
		/// <returns>Codes of stub method body.</returns>
		public string GenerateStubCode()
		{
			return string.Empty;
		}
	}
}
