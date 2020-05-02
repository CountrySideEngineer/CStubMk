using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CStubMKGui.Model
{
	/// <summary>
	/// Abstract class to create stub code.
	/// </summary>
	public abstract class AStubCodeCreater : ICodeCreater
	{
		#region Factory methods
		/// <summary>
		/// Create director to create code using builder, ICodeBuilder object
		/// </summary>
		/// <returns>Director to create code by builder</returns>
		protected abstract SourceCodeDirector GetDirector(ICodeBuilder builder);
		#endregion

		#region Methods and private properties in calling order
		/// <summary>
		/// Create list of builders , ICodeBuilder, to create stub code.
		/// </summary>
		/// <returns>List of builders to create stub code.</returns>
		protected abstract IEnumerable<ICodeBuilder> GetBuilders();
		#endregion

		#region Override of interface.

		/// <summary>
		/// Method to create codes.
		/// </summary>
		/// <param name="parameters">Source information for code.</param>
		/// <returns>List of codes, a code in a line.</returns>
		public virtual IEnumerable<string> Create(IEnumerable<Param> parameters)
		{
			return this.CreateCode(parameters);
		}
		#endregion

		#region Protected or private method in calling order
		/// <summary>
		/// Create code from parameters.
		/// </summary>
		/// <param name="parameters">Parameters for create stub codes.</param>
		/// <returns>List of stub codes.</returns>
		protected virtual IEnumerable<string> CreateCode(IEnumerable<Param> parameters)
		{
			var builders = this.GetBuilders();
			return this.Create(builders, parameters);
		}

		/// <summary>
		/// Create code from builders and parameters.
		/// </summary>
		/// <param name="builders">List of builders to create codes.</param>
		/// <param name="parameter">List of parameters for create codes.</param>
		/// <returns>List of codes.</returns>
		protected IEnumerable<string> Create(IEnumerable<ICodeBuilder> builders, IEnumerable<Param> parameters)
		{
			IEnumerable<string> createdCodes = null;
			foreach (var parameter in parameters)
			{
				var codes = this.Create(builders, parameter);
				if (null == createdCodes)
				{
					createdCodes = codes;
				}
				else
				{
					createdCodes = createdCodes.Concat(codes);
				}
			}
			return createdCodes;
		}

		/// <summary>
		/// Create code from builders and parameters.
		/// </summary>
		/// <param name="builders">List of builders to create codes.</param>
		/// <param name="parameter">Parameters for create codes.</param>
		/// <returns>List of codes.</returns>
		protected IEnumerable<string> Create(IEnumerable<ICodeBuilder> builders, Param parameter)
		{
			IEnumerable<string> createdCodes = null;
			foreach (var builder in builders)
			{
				var codes = this.Create(builder, parameter);
				if (null == createdCodes)
				{
					createdCodes = codes;
				}
				else
				{
					createdCodes = createdCodes.Concat(codes);
				}
			}
			return createdCodes;
		}

		/// <summary>
		/// Create code from parameter using builder.
		/// </summary>
		/// <param name="builder">Builder class to create codes.</param>
		/// <param name="parameter"></param>
		/// <returns>List of codes.</returns>
		protected IEnumerable<string> Create(ICodeBuilder builder, Param parameter)
		{
			var director = this.GetDirector(builder);
			director.Construct(parameter);
			var codes = builder.GetResult();

			return (IEnumerable<string>)codes;
		}
		#endregion
	}
}
