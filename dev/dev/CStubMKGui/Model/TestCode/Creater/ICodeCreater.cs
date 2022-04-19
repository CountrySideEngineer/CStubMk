using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
	/// <summary>
	/// Interface to convert parameters, as Param object to code.
	/// </summary>
	public interface ICodeCreater
	{
		/// <summary>
		/// Method to create codes.
		/// </summary>
		/// <param name="parameters">Source information for code.</param>
		/// <returns>List of codes.</returns>
		public IEnumerable<string> Create(IEnumerable<Param> parameters);
	}
}
