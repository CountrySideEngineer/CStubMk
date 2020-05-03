using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
	/// <summary>
	/// Interface class creating code.
	/// </summary>
	public interface ICodeBuilder
	{
		/// <summary>
		/// Create code.
		/// </summary>
		/// <param name="codeSrc">Source object of code.</param>
		void CreateCode(object codeSrc);

		/// <summary>
		/// Get code object.
		/// </summary>
		/// <returns>Result of codes.</returns>
		object GetResult();
	}
}
