using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CStubMk.Model
{
	public class InputInfo
	{
		/// <summary>
		/// Path to file the target function informations are set.
		/// </summary>
		public string TargetFilePath { get; set; } = string.Empty;

		/// <summary>
		/// Path to Directroy to output.
		/// </summary>
		public string OuptutDirPath { get; set; } = string.Empty;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public InputInfo() { }
	}
}
