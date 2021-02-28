using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CStubMKGui.Model
{
	/// <summary>
	/// Class to create code of each line to declare buffers for stub method.
	/// </summary>
	public class HeaderStubBufferDeclareCodeBuilder : SourceStubBufferDeclareCodeBuilder
	{
		#region Constants
		protected readonly string BufferExternModifier = "extern";
		#endregion

		#region Constructor
		/// <summary>
		/// Default constructor
		/// </summary>
		public HeaderStubBufferDeclareCodeBuilder() : base() { }
		#endregion

		#region Public method.
		/// <summary>
		/// Create code to count the number of the method called.
		/// </summary>
		/// <param name="function">Information of method</param>
		/// <remarks>
		/// The code created in this method is in the format below.
		/// <c>extern int "FunctionName"_called_count;</c>
		/// </remarks>
		protected override void CreateCalledCounter(Param function)
		{
			string code = $"{BufferExternModifier} int {base.GetCalledCounterName(function)};";
			this.SetCode(code, 0);
		}

		/// <summary>
		/// Create code to declare extern.
		/// </summary>
		/// <param name="function">Information of function.</param>
		/// <param name="argument">Information of argument</param>
		/// <remarks>
		/// The code this method creates is in the format below.
		/// <c>extern "DataType" "FunctoinName"_"ArgumentName"[];</c>
		/// </remarks>
		protected override void CreateBufferDeclare(Param function, Param argument)
		{
			string code = $"{BufferExternModifier} {argument.DataType}";
			for (int pointerNum = 0; pointerNum < argument.PointerNum; pointerNum++)
			{
				code += PointerModifier;
			}
			code += SpaceModifier;
			code += $"{function.Name}_{argument.Name}[];";
			this.SetCode(code, 0);
		}

		/// <summary>
		/// Create code to decalre buffer with extern.
		/// </summary>
		/// <param name="function">Information of function.</param>
		/// <param name="argument">Information of method.</param>
		protected override void CreateBufferForOutputDeclare(Param function, Param argument)
		{
			if (argument.Mode.Equals(Param.AccessMode.Out))
			{
				if (1 == argument.PointerNum)
				{
					this.CreateBufferForSinglePointerOutputDeclare(function, argument);
				}
				else if(2 == argument.PointerNum)
				{
					this.CreateBufferForDoublePointerOutputDeclare(function, argument);
				}
			}
		}

		/// <summary>
		/// Create code to declare buffer for primitive data type of C language in extern.
		/// </summary>
		/// <param name="function">Information of function.</param>
		/// <param name="argument">Information of argument</param>
		/// <remarks>
		/// The code this methos creates is in the format below.
		/// <c>extern "DataTyp" "FunctionName"_"ArgumentName"[];</c>
		/// </remarks>
		protected virtual void CreateBufferForNonePointerOutputDeclare(Param function, Param argument)
		{
			string code =
				$"{BufferExternModifier} " +
				$"{argument.DataType} " +
				$"{base.GetBufferName(function, argument)}_{PointerValueModifier}[];";
			this.SetCode(code, 0);
		}

		/// <summary>
		/// Create code to declare buffer with one poiner and extern.
		/// </summary>
		/// <param name="function">Information of function.</param>
		/// <param name="argument">Information of argument.</param>
		/// <remarks>
		/// The code this method creates is in the format below.
		/// <c>extern "DataType" "ArgumentName"[];</c>
		/// </remarks>
		protected virtual void CreateBufferForSinglePointerOutputDeclare(Param function, Param argument)
		{
			string code = 
				$"{BufferExternModifier} " +
				$"{argument.DataType} " +
				$"{base.GetBufferName(function, argument)}_{PointerValueModifier}[];";
			this.SetCode(code, 0);
		}

		/// <summary>
		/// Create code to external declare the double pointer varible. 
		/// </summary>
		/// <param name="function">Information of function.</param>
		/// <param name="argument">Information of argument.</param>
		/// <remarks>
		/// The created code of this method is in the format below.
		/// <c>extern "DataType"* "ArgumentName"[];</c>
		/// </remarks>
		protected virtual void CreateBufferForDoublePointerOutputDeclare(Param function, Param argument)
		{
			string code = 
				$"{BufferExternModifier} " +
				$"{argument.DataType}{PointerModifier} " +
				$"{base.GetBufferName(function, argument)}_{PointerValueModifier}[];";
			this.SetCode(code, 0);
		}

		/// <summary>
		/// Create code to declare buffer to store the value the stub returns.
		/// </summary>
		/// <param name="function">Information of function.</param>
		protected override void CreateReturnValueBufferDeclare(Param function)
		{
			if (0 != string.Compare(function.DataType, "void", true))
			{
				string code = $"{BufferExternModifier} {function.DataType}";
				for (int index = 0; index < function.PointerNum; index++)
				{
					code += PointerModifier;
				}
				code += $" {function.Name}_{ReturnValueModifier}[];";
				this.SetCode(code, 0);
			}
		}
		#endregion
	}
}
