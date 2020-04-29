using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
	/// <summary>
	/// Director class to run ICodeBuilder, the BUILDER pattern.
	/// </summary>
	public class SourceCodeDirector
	{
		/// <summary>
		/// Interface of ICodeBuilder, the builder class.
		/// </summary>
		protected ICodeBuilder builder { get; set; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="builder">Builder object to run.</param>
		public SourceCodeDirector(ICodeBuilder builder)
		{
			this.builder = builder;
		}

		/// <summary>
		/// Run the sequence to construct products via builder, ICodeBuilder interface.
		/// </summary>
		/// <param name="param">Parameter passed into builder class.</param>
		public void Construct(Param param)
		{
			this.builder.CreateCode(param);
		}
	}
}
