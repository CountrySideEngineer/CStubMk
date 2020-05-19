using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CStubMKGui.Model
{
	/// <summary>
	/// Builder class to create netry point of method to initialize 
	/// </summary>
	public class SourceStubInitBufferEntryPointCodeBuilder : AStubBuilder
	{
		#region Constant
		protected readonly string BufferInitMethodDataType = "void";
		protected readonly string BufferInitMethodPostfix = "_init";
		#endregion

		#region Constructor
		/// <summary>
		/// Default constructor.
		/// </summary>
		public SourceStubInitBufferEntryPointCodeBuilder() : base(100) { }
		#endregion


		#region Public method, override of interface.
		/// <summary>
		/// Create entry point of method to initialize 
		/// </summary>
		/// <param name="codeSrc"></param>
		public override void CreateCode(object codeSrc)
		{
			try
			{
				if (null == codeSrc)
				{
					throw new ArgumentNullException(nameof(CreateCode));
				}
				var function = (Param)codeSrc;

				this.Codes = new List<string>();
				this.Codes.Clear();

				this.CreateEntryPoint(function);
			}
			catch (InvalidCastException)
			{
				Debug.WriteLine("Input is invalid / SKIP");
			}
		}

		/// <summary>
		/// Get the result.
		/// </summary>
		/// <returns>Code of entry point of method to initialize buffer of stub.</returns>
		public override object GetResult()
		{
			return (object)this.Codes;
		}
		#endregion

		#region Protected or private method.
		/// <summary>
		/// Create code of entry point of method to initialize buffer of stub.
		/// </summary>
		/// <param name="function">Information of method.</param>
		protected virtual void CreateEntryPoint(Param function)
		{
			string code = $"{BufferInitMethodDataType} {function.Name}{BufferInitMethodPostfix}()";
			this.Codes.Add(code);

		}
		#endregion
	}
}
