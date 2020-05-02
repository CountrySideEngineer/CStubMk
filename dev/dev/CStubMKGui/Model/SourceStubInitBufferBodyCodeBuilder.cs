using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CStubMKGui.Model
{
	/// <summary>
	/// Class to creat code of method to initialize buffers of method.
	/// </summary>
	public class SourceStubInitBufferBodyCodeBuilder : AStubBuilder
	{
		#region Constant.
		protected readonly string BufferInitForLoopCounter = "id1";
		protected readonly string BufferInitForSubLoopCounter = "id2";
		#endregion

		#region Public method, override of interface.
		/// <summary>
		/// Create code of method body to initiailze the buffer of stub/
		/// </summary>
		/// <param name="codeSrc">Object about the function.</param>
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

				this.SetCode("{", 0);
				this.CreateDeclareIdVariableCode(function);
				this.CreateInitLoopStartCode(function);
				this.CreateInitBufferCode(function);
				this.CreateInitLoopEndCode(function);
				this.CreateInitCalledCounterCode(function);
				this.SetCode("}", 0);
			}
			catch (InvalidCastException)
			{
				Debug.WriteLine("Input is invalid / SKIP");
			}
		}

		/// <summary>
		/// Get the result.
		/// </summary>
		/// <returns>Object contains the codes.</returns>
		public override object GetResult()
		{
			return (object)this.Codes;
		}
		#endregion

		#region Protected or private method.
		/// <summary>
		/// Create code to declare the variables to loop counter.
		/// </summary>
		/// <param name="function">Information of function(not in use).</param>
		/// <remarks>
		/// The code this method creates is in format below.
		/// <code>
		/// int id1 = 0;
		/// int id2 = 0;
		/// </code>
		/// </remarks>
		protected void CreateDeclareIdVariableCode(Param function)
		{
			string code = $"int {BufferInitForLoopCounter} = 0;";
			base.SetCode(code);
			code = $"int {BufferInitForSubLoopCounter} = 0;";
			base.SetCode(code);
		}

		/// <summary>
		/// Create code to start the "for" loop to initialize buffers.
		/// </summary>
		/// <param name="function">Information of function(not in use).</param>
		protected void CreateInitLoopStartCode(Param function)
		{
			string code = $"for ({BufferInitForLoopCounter} = 0; " +
				$"{BufferInitForLoopCounter} < {base.BufferSizeMacroCode}; " +
				$"{BufferInitForLoopCounter}++) {{";
			base.SetCode(code);
		}

		/// <summary>
		/// Create the code of loop end.
		/// </summary>
		/// <param name="function">Information of function(not in use).</param>
		protected void CreateInitLoopEndCode(Param function)
		{
			string code = "}";
			base.SetCode(code);
		}

		/// <summary>
		/// /Create code to initialize buffer.
		/// </summary>
		/// <param name="function">Information of function</param>
		protected void CreateInitBufferCode(Param function)
		{
			foreach(var argument in function.Parameters)
			{
				this.CreateInitBufferCode(function, argument);
			}
			this.CreateInitRetValBufferCode(function);
		}

		/// <summary>
		/// Create code to initialize buffer.
		/// </summary>
		/// <param name="function">Information of function</param>
		/// <param name="argument">Information of argument.</param>
		protected void CreateInitBufferCode(Param function, Param argument)
		{
			if (0 == argument.PointerNum)
			{
				this.CreateInitNonePointerBufferCode(function, argument);
			}
			else if (0 < argument.PointerNum)
			{
				this.CreateInitPointerBufferCode(function, argument);
			}
			else
			{
				//Nothig to do if the number of pointer is smaller than 0.
			}
		}

		/// <summary>
		/// Create code to initialize the buffer to store the argument value.
		/// </summary>
		/// <param name="function">Information of function</param>
		/// <param name="argument">Information of argument.</param>
		/// <remarks>
		/// The code this method creates is in format below.
		/// <c>"FunctionName"_"ArgumentName"[id1] = 0;</c>
		/// </remarks>
		protected void CreateInitNonePointerBufferCode(Param function, Param argument)
		{
			string code = $"{base.GetBufferName(function, argument)}[{BufferInitForLoopCounter}] = 0;";
			base.SetCode(code, 2);
		}

		/// <summary>
		/// Create code to initialize single pointer code.
		/// </summary>
		/// <param name="function">Information of function</param>
		/// <param name="argument">Information of argument.</param>
		/// <exception cref="NotSupportedException">The number of pointer is larger than 3.</exception>
		protected void CreateInitPointerBufferCode(Param function, Param argument)
		{
			if (1 == argument.PointerNum)
			{
				this.CreateInitSinglePointerBufferCode(function, argument);
				this.CreateInitSinglePointerValueCode(function, argument);
			}
			else if (2 == argument.PointerNum)
			{
				this.CreateInitDoublePointerBufferCode(function, argument);
				this.CreateInitDoublePoinerValueCode(function, argument);
			}
			else if (2 < argument.PointerNum)
			{
				throw new NotSupportedException(nameof(CreateInitPointerBufferCode));
			}
			else
			{
				//Nothing to do if the number of pointer is smaller than 0.
			}
		}

		/// <summary>
		/// Create code to initialize buffer to store addres points an argument.
		/// </summary>
		/// <param name="function">Information of function</param>
		/// <param name="argument">Information of argument.</param>
		/// <remarks>
		/// The code this method creates is in format below.
		/// <c>"FunctionName"_"ArgumentName"[id1] = NULL;</c>
		/// </remarks>
		protected void CreateInitSinglePointerBufferCode(Param function, Param argument)
		{
			string code = $"{base.GetBufferName(function, argument)}[{BufferInitForLoopCounter}] = NULL;";
			base.SetCode(code, 2);
		}

		/// <summary>
		/// Create code to initialize buffer stores the return value as pointer entity.
		/// </summary>
		/// <param name="function">Information of function</param>
		/// <param name="argument">Information of argument.</param>
		/// <remarks>
		/// The code this method creates is in format below.
		/// <c>"FunctionName"_"ArgumentName"[id1] = 0;</c>
		/// </remarks>
		protected void CreateInitSinglePointerValueCode(Param function, Param argument)
		{
			string code = $"{base.GetBufferName(function, argument)}_{PointerValueModifier}[{BufferInitForLoopCounter}] = 0;";
			base.SetCode(code, 2);
		}

		/// <summary>
		/// Create code buffer of pointer.
		/// </summary>
		/// <param name="function">Information of function</param>
		/// <param name="argument">Information of argument.</param>
		/// <remarks>
		/// The code this method creates is in foramt below.
		/// <c>"FunctioName"_"ArgumentName"[id1] = NULL;</c>
		/// </remarks>
		protected void CreateInitDoublePointerBufferCode(Param function, Param argument)
		{
			string code = $"{function.Name}_{argument.Name}[{BufferInitForLoopCounter}] = {PointerInitialValue};";
			base.SetCode(code, 2);
		}

		/// <summary>
		/// Create code staring "for" loop to initialize buffer to store the value to be set as a return.
		/// </summary>
		/// <param name="function">Information of function</param>
		/// <param name="argument">Information of argument.</param>
		/// <remarks>
		/// The code this method creates is in format below.
		/// <c>for (int id1 = 0; id1 < STUB_BUFFER_SIZE; id1++) {</c>
		/// </remarks>
		protected void CreateInitDoublePointerForLoopStartCode(Param function, Param argument)
		{
			string code = $"\tfor ({BufferInitForSubLoopCounter} = 0; " +
				$"{BufferInitForSubLoopCounter} < {base.BufferSizeMacroCode}; " +
				$"{BufferInitForSubLoopCounter}++) {{";
			base.SetCode(code);
		}

		/// <summary>
		/// Run the sequence to create code to initialize buffer storing the return value.
		/// </summary>
		/// <param name="function">Information of function</param>
		/// <param name="argument">Information of argument.</param>
		protected void CreateInitDoublePoinerValueCode(Param function, Param argument)
		{
			this.CreateInitDoublePointerForLoopStartCode(function, argument);
			this.CreateInitDoublePoinerValueBuffCode(function, argument);
			this.CreateInitDoublePointerForLoopEndCode(function, argument);
		}

		/// <summary>
		/// Create code to initialize buffer to store actual value the double pointer points.
		/// </summary>
		/// <param name="function">Information of function</param>
		/// <param name="argument">Information of argument.</param>
		/// <remarks>
		/// The code this method creates is in the format below.
		/// <c>"FunctionName"_"ArgumentName"[id1][id2] = NULL;</c>
		/// </remarks>
		protected void CreateInitDoublePoinerValueBuffCode(Param function, Param argument)
		{
			string code =
				$"{base.GetBufferName(function, argument)}_{PointerValueModifier}" +
				$"[{BufferInitForLoopCounter}][{BufferInitForSubLoopCounter}]" +
				$" = {PointerInitialValue};";
			base.SetCode(code, 3);
		}

		/// <summary>
		/// Create code to close for-loop of code initializing the double pointer.
		/// </summary>
		/// <param name="function">Information of function</param>
		/// <param name="argument">Information of argument.</param>
		protected void CreateInitDoublePointerForLoopEndCode(Param function, Param argument)
		{
			string code = "}";
			base.SetCode(code, 2);
		}

		/// <summary>
		/// Create code to initialize the buffer to store value to return.
		/// </summary>
		/// <param name="function">Information of function</param>
		/// <remarks>
		/// The created code is in format below if the data type of method is not pointer.
		/// <c>"FunctionName"_ret_val = 0;</c>
		/// Otherwise, if it is pointer, the code is below.
		/// <c>"FunctionName"_ret_val = NULL;</c>
		/// </remarks>
		protected void CreateInitRetValBufferCode(Param function)
		{
			string retValInitValue = "";
			if (0 == function.PointerNum)
			{
				retValInitValue = $"{Convert.ToString(CalledCountInitialValue)}";
			}
			else if (0 < function.PointerNum)
			{
				retValInitValue = $"{PointerInitialValue}";
			}
			else
			{
				throw new NotSupportedException(nameof(CreateInitRetValBufferCode));
			}
			string code = $"{function.Name}_{ReturnValueModifier}[{BufferInitForLoopCounter}] = {retValInitValue}";
			base.SetCode(code, 2);
		}

		/// <summary>
		/// Create code to initialize the variable to count the number of the method called.
		/// </summary>
		/// <param name="function">Information of function</param>
		/// <remarks>
		/// The created code is in format below.
		/// <c>
		/// "FunctioName"_called_count = 0;
		/// </c>
		/// </remarks>
		protected void CreateInitCalledCounterCode(Param function)
		{
			string code = $"{function.Name}_{CalledCountModifier} = {Convert.ToString(CalledCountInitialValue)};";
			base.SetCode(code);
		}
		#endregion
	}
}
