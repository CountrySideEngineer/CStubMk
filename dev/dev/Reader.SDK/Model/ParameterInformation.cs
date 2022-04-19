using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader.SDK.Model
{
	public class ParameterInformation
	{
		/// <summary>
		/// Code declaring function or variables.
		/// </summary>
		public string Code { get; set; }

		/// <summary>
		/// File the code is implemented.
		/// </summary>
		public string File { get; set; }
	}
}
