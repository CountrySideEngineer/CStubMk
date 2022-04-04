using Parser.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTemplate.Template
{
	public partial class StubCodeTemplateCommonBase
	{
		/// <summary>
		/// Target function data.
		/// </summary>
		public Function TargetFunc { get; set; }

		/// <summary>
		/// File name to output the codes.
		/// </summary>
		public string FileName { get; set; }

		/// <summary>
		/// Default constructor.
		/// </summary>
		public StubCodeTemplateCommonBase()
		{
			TargetFunc = null;
			FileName = string.Empty;
		}
	}
}
