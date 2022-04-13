using CodeTemplate.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTemplate.Template
{
	public partial class StubBufferSizeMacroDefineTemplate : StubCodeTemplateCommonBase
	{
		public int BufferSize1 { get; set; }
		public int BufferSize2 { get; set; }

		/// <summary>
		/// Default constructor.
		/// </summary>
		StubBufferSizeMacroDefineTemplate() : base()
		{
			BufferSize1 = 100;
			BufferSize2 = 100;
		}

		/// <summary>
		/// Create macro name defining buffer size.
		/// </summary>
		/// <returns>Macro name defining buffer size.</returns>
		public virtual string StubBufferSizeMacro1()
		{
			var builder = new StubCodeBuilder();
			string code = builder.CreateBufferSizeMacro1(TargetFunc);
			return code;
			
		}

		/// <summary>
		/// Create macro name defining buffer size.
		/// </summary>
		/// <returns>Macro name defining buffer size.</returns>
		public virtual string StubBufferSizeMacro2()
		{
			var builder = new StubCodeBuilder();
			string code = builder.CreateBufferSizeMacro2(TargetFunc);
			return code;
		}

		public virtual string StubBufferSize1()
		{
			string bufferSize = Convert.ToString(BufferSize1);
			return bufferSize;
		}

		public virtual string StubBufferSize2()
		{
			string bufferSize = Convert.ToString(BufferSize2);
			return bufferSize;
		}

	}
}
