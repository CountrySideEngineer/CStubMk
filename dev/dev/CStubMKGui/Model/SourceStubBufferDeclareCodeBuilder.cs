using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CStubMKGui.Model
{
	public class SourceStubBufferDeclareCodeBuilder : AStubBuilder
	{
		#region Constructor
		/// <summary>
		/// Default constructor
		/// </summary>
		public SourceStubBufferDeclareCodeBuilder() : base(100)
		{
			this.Codes = new List<string>();
			this.Codes.Clear();
		}
		#endregion

		#region Public methods
		/// <summary>
		/// Creat codes 
		/// </summary>
		/// <param name="codeSrc"></param>
		public override void CreateCode(object codeSrc)
		{
			try
			{
				if (null == codeSrc)
				{
					throw new ArgumentNullException(nameof(this.CreateCode));
				}
				var function = (Param)codeSrc;

				this.CreateCalledCounter(function);
				this.CreateBufferDeclare(function);
				this.CreateReturnValueBufferDeclare(function);
			}
			catch (InvalidCastException)
			{
				Debug.WriteLine("Input is invalid / SKIP");
			}
		}

		/// <summary>
		/// Get code object.
		/// </summary>
		/// <returns>Created codes.</returns>
		public override object GetResult()
		{
			return (object)this.Codes;
		}

		/// <summary>
		/// Create code to declare and initialize variable to store how many times
		/// the stub is called.
		/// </summary>
		/// <param name="function">Information of the stub function.</param>
		protected virtual void CreateCalledCounter(Param function)
		{
			string code = $"int {base.GetCalledCounterName(function)} = 0;";
			this.Codes.Add(code);
		}

		/// <summary>
		/// Create code to declare the buffer for arguments of function.
		/// </summary>
		/// <param name="function">Information of function.</param>
		protected virtual void CreateBufferDeclare(Param function)
		{
			try
			{
				foreach (var argument in function.Parameters)
				{
					this.CreateBufferDeclare(function, argument);
					this.CreateBufferForOutputDeclare(function, argument);
				}
			}
			catch (NullReferenceException)
			{
				Debug.WriteLine($"{function} has not argument.");
			}
		}

		/// <summary>
		/// Create code to declare the buffer for arguments of function.
		/// </summary>
		/// <param name="function">Information of function.</param>
		/// <param name="argument">Information of argument.</param>
		protected virtual void CreateBufferDeclare(Param function, Param argument)
		{
			string code = argument.DataType;
			for (int pointerNum = 0; pointerNum < argument.PointerNum; pointerNum++)
			{
				code += PointerModifier;
			}
			code += SpaceModifier;
			code += $"{function.Name}_{argument.Name}[{BufferSizeMacroCode}];";
			this.Codes.Add(code);
		}

		/// <summary>
		/// Create code to declare the buffer 
		/// </summary>
		/// <param name="function"></param>
		/// <param name="argument"></param>
		protected virtual void CreateBufferForOutputDeclare(Param function, Param argument)
		{
			if (argument.Mode.Equals(Param.AccessMode.Out))
			{
				string code = 
					$"{argument.DataType} {function.Name}_{argument.Name}_{PointerValueModifier}";
				for (int pointerNum = 0; pointerNum < argument.PointerNum; pointerNum++)
				{
					code += $"[{BufferSizeMacroCode}]";
				}
				code += ";";
				this.Codes.Add(code);
			}
		}

		/// <summary>
		/// Create code to declare buffer to store the value the stub returns.
		/// </summary>
		/// <param name="function">Information of function.</param>
		protected virtual void CreateReturnValueBufferDeclare(Param function)
		{
			if (0 != string.Compare(function.DataType, "void", true))
			{
				string code = $"{function.DataType}";
				for (int index = 0; index < function.PointerNum; index++)
				{
					code += PointerModifier;
				}

				code += $" {function.Name}_{ReturnValueModifier}[{BufferSizeMacroCode}];";
				this.Codes.Add(code);
			}
		}
		#endregion

		#region Properties
		protected List<string> Codes;
		#endregion
	}
}
