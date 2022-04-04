using Parser.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTemplate.Builder
{
	public class StubCodeBuilder
	{
		/// <summary>
		/// Create buffer name to holds the number of function called.
		/// </summary>
		/// <param name="function">Function data.</param>
		/// <returns>Buffer name to holds the number of function called.</returns>
		/// <remarks>
		/// The format of buffer name this function will create is below:
		/// {function.Name}_called_count
		/// </remarks>
		/// <exception cref="ArgumentException">Name property of function is empty or all white space.</exception>
		/// <exception cref="NullReferenceException">Argument function is null.</exception>
		public virtual string CreateFuncCalledCounterBufferName(Function function)
		{
			try
			{
				if ((string.IsNullOrEmpty(function.Name)) || (string.IsNullOrWhiteSpace(function.Name)))
				{
					throw new ArgumentException("Name property is invalid.");
				}
				string code = $"{function.Name}_called_count";
				return code;
			}
			catch (NullReferenceException)
			{
				throw;
			}
		}

		/// <summary>
		/// Create code to declare a buffer to holds the number of a method called.
		/// </summary>
		/// <param name="function">Function data.</param>
		/// <returns>Code to declare the buffer to holds the number of the method called.</returns>
		/// <exception cref="NullReferenceException">Argument is NULL.</exception>
		/// <exception cref="ArgumentException">"Name" property of Function object is empty.</exception>
		public virtual string CreateFuncCalledCounterBuffer(Function function)
		{
			try
			{
				string name = CreateFuncCalledCounterBufferName(function);
				string dataType = "long";
				string code = $"{dataType} {name}";
				return code;
			}
			catch (Exception ex)
			when ((ex is NullReferenceException) || (ex is ArgumentException))
			{
				throw;
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Create buffer name to holds the argument value.
		/// </summary>
		/// <param name="function">Function data.</param>
		/// <returns>Buffer name to holds the argument value.</returns>
		/// <remarks>
		/// The format of buffer name this function will create is below:
		/// {function.Name}_return_value
		/// </remarks>
		/// <exception cref="ArgumentException">Function name is empty or all white space.</exception>
		/// <exception cref="FormatException">Function has no return value.</exception>
		public virtual string CreateReturnValueBufferName(Function function)
		{
			try
			{
				if ((string.IsNullOrEmpty(function.Name)) || (string.IsNullOrWhiteSpace(function.Name)))
				{
					throw new ArgumentException("DataType property is invalid.");
				}
				if ((function.DataType.ToLower().Equals("void")) && (!(0 < function.PointerNum)))
				{
					throw new FormatException("The function has no return value.");
				}
				string code = $"{function.Name}_return_value";
				return code;
			}
			catch (NullReferenceException)
			{
				throw;
			}
		}

		/// <summary>
		/// Create code to declare a buffer to holds the value the function, stub will return.
		/// </summary>
		/// <param name="function">Function data.</param>
		/// <returns>Code to decalre a buffer to holds the value the function, stub will return.</returns>
		/// <remarks>
		/// The format of code this function will create is below:
		/// {function.DataType}(*) {function.Name}
		/// </remarks>
		/// <exception cref="ArgumentException">DataType property is empty or all white space.</exception>
		/// <exception cref="FormatException">The function has no return value.</exception>
		public virtual string CreateReturnValueBuffer(Function function)
		{
			try
			{
				if ((string.IsNullOrEmpty(function.DataType)) || (string.IsNullOrWhiteSpace(function.DataType)))
				{
					throw new ArgumentException("DataType property is invalid.");
				}
				string bufferDataType = function.DataType;
				for (int index = 0; index < function.PointerNum; index++)
				{
					bufferDataType += "*";
				}
				string name = CreateReturnValueBufferName(function);
				string code = $"{bufferDataType} {name}";
				return code;
			}
			catch (FormatException)
			{
				throw;
			}
			catch (NullReferenceException)
			{
				throw;
			}
		}

		/// <summary>
		/// Create buffer name to hold argument value.
		/// </summary>
		/// <param name="function">Function data.</param>
		/// <param name="argument">Argument data.</param>
		/// <returns>Buffer name to hold argument value.</returns>
		/// <remarks>
		/// The format of code this method will create is below:
		/// {function.Name}_{argument.Name}
		/// </remarks>
		/// <exception cref="ArgumentException">Function or argument name is empty.</exception>
		/// <exception cref="NullReferenceException">Function or argument object has been null.</exception>
		public virtual string CreateArgBufferName(Function function, Variable argument)
		{
			try
			{
				if (((string.IsNullOrEmpty(function.Name)) || (string.IsNullOrWhiteSpace(function.Name))) ||
					((string.IsNullOrEmpty(argument.Name)) || (string.IsNullOrWhiteSpace(argument.Name))))
				{
					throw new ArgumentException("Name property of function or argument is invalid.");
				}
				string code = $"{function.Name}_{argument.Name}";
				return code;
			}
			catch (NullReferenceException)
			{
				throw;
			}
		}

		/// <summary>
		/// Create code to declare buffer to holds an argument value.
		/// </summary>
		/// <param name="function">Function data</param>
		/// <param name="argument">Argument data</param>
		/// <returns>code to declare buffer to holds an argument value.</returns>
		/// <remarks>
		/// The format of code this method will create is below:
		/// {argument.DataType}(*) {function.Name}_{argument.Name}
		/// </remarks>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="FormatException"></exception>
		/// <exception cref="NullReferenceException"></exception>
		public virtual string CreateArgBuffer(Function function, Variable argument)
		{
			try
			{
				if ((string.IsNullOrEmpty(argument.DataType)) || (string.IsNullOrWhiteSpace(argument.DataType)))
				{
					throw new ArgumentException("Name property of function or argument is invalid.");
				}
				if ((argument.DataType.ToLower().Equals("void")) && (!(0 < argument.PointerNum)))
				{
					throw new FormatException("The argument has no return value.");
				}
				string buffDataType = $"{argument.DataType}";
				for (int index = 0; index < argument.PointerNum; index++)
				{
					buffDataType += "*";
				}
				string name = CreateArgBufferName(function, argument);
				string code = $"{buffDataType} {name}";

				return code;
			}
			catch (NullReferenceException)
			{
				throw;
			}
		}

		/// <summary>
		/// Create buffer name to store value the function will return via argument with pointer.
		/// </summary>
		/// <param name="function">Function data.</param>
		/// <param name="argument">Argument data.</param>
		/// <returns>Buffer name to store value the function will return via argument with pointer.</returns>
		/// <remarks>
		/// The format of name this method will create is below:
		/// {function.Name}_{argument.Name}_value
		/// </remarks>
		/// <exception cref="ArgumentException"></exception>
		public virtual string CreateReturnValueBufferViaArgName(Function function, Variable argument)
		{
			if (((string.IsNullOrEmpty(function.Name)) || (string.IsNullOrWhiteSpace(function.Name))) ||
				((string.IsNullOrEmpty(function.DataType)) || (string.IsNullOrWhiteSpace(function.DataType))) ||
				((string.IsNullOrEmpty(argument.Name)) || (string.IsNullOrWhiteSpace(argument.Name))) ||
				((string.IsNullOrEmpty(argument.DataType)) || (string.IsNullOrWhiteSpace(argument.DataType))))
			{
				throw new ArgumentException("Data type property of function or argument is invalid.");
			}
			string code = $"{function.Name}_{argument.Name}_value";
			return code;
		}

		/// <summary>
		/// Create code to declare buffer to store value the method will return via pointer value.
		/// </summary>
		/// <param name="function">Function data</param>
		/// <param name="argument">Argument data</param>
		/// <returns>Code to declare buffer to store value the method will return via pointer value.</returns>
		/// <remarks>
		/// The format of code this method will create is below:
		/// {argument.DataType} {function.Name}_{argument.Name}_value
		/// </remarks>
		/// <exception cref="FormatException"></exception>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="NullReferenceException"></exception>
		public virtual string CreateReturnValueBufferViaArg(Function function, Variable argument)
		{
			try
			{
				if ((argument.DataType.ToLower().Equals("void")) && (!(0 < argument.PointerNum)))
				{
					throw new FormatException("The argument has no return value.");
				}
				string buffDataType = argument.DataType;
				if (buffDataType.ToLower().Equals("void"))
				{
					buffDataType = "int";
				}
				string name = CreateReturnValueBufferViaArgName(function, argument);
				string code = $"{buffDataType} {name}";

				return code;
			}
			catch (NullReferenceException)
			{
				throw;
			}
		}

		/// <summary>
		/// Create buffer name to store a size of data the stub will return via argument.
		/// </summary>
		/// <param name="function">Function data</param>
		/// <param name="argument">Argument data</param>
		/// <returns>Buffer name to store a size of data the stub will return via argument.</returns>
		/// <remarks>
		/// The format of code this method will return is below:
		/// {function.Name}_{argument.Name}_value_size
		/// </remarks>
		public virtual string CreateReturnValueSizeBufferViaArgName(Function function, Variable argument)
		{
			if (((string.IsNullOrEmpty(function.Name)) || (string.IsNullOrWhiteSpace(function.Name))) ||
				((string.IsNullOrEmpty(function.DataType)) || (string.IsNullOrWhiteSpace(function.DataType))) ||
				((string.IsNullOrEmpty(argument.Name)) || (string.IsNullOrWhiteSpace(argument.Name))) ||
				((string.IsNullOrEmpty(argument.DataType)) || (string.IsNullOrWhiteSpace(argument.DataType))))
			{
				throw new ArgumentException("Data type property of function or argument is invalid.");
			}
			string code = $"{function.Name}_{argument.Name}_value_size";
			return code;
		}

		/// <summary>
		/// Create code to declare buffer to store the data length the stub will return via pointer value.
		/// </summary>
		/// <param name="function">Function data</param>	
		/// <param name="argument">Argument data</param>
		/// <returns>Code to declare buffer to store the data length the stub will return via pointer value.</returns>
		/// <remarks>
		/// The format of code this method will return is bewlo:
		/// long {function.Name}_{argument.Name}_value_size
		/// </remarks>
		public virtual string CreateReturnValueSizeBufferViaArg(Function function, Variable argument)
		{
			string name = CreateReturnValueSizeBufferViaArgName(function, argument);
			string buffDataType = "long";
			string code = $"{buffDataType} {name}";
			return code;
		}

		/// <summary>
		/// Create macro name to define buffer size.
		/// </summary>
		/// <param name="baseName">Base name for macro</param>
		/// <returns>Macro name</returns>
		public virtual string CreateBufferSizeMacro1(string baseName)
		{
			try
			{
				string baseMacro = CreateBufferSizeMacroCommon(baseName);
				string macro = $"{baseMacro}_1";
				return macro;
			}
			catch (AggregateException)
			{
				throw new ArgumentException("Base name is empty.");
			}
		}

		/// <summary>
		/// Create macro name to define buffer size.
		/// </summary>
		/// <param name="function">Function data.</param>
		/// <returns>Macro name to define buffer size.</returns>
		/// <returns>Macro name.
		/// The format is below.
		/// {FUNCTION_NAME}_STUB_BUFF_SIZE_1
		/// </returns>
		/// <exception cref="ArgumentException"></exception>
		public virtual string CreateBufferSizeMacro1(Function function)
		{
			try
			{
				string macro = CreateBufferSizeMacro1(function.Name);
				return macro;
			}
			catch (ArgumentException)
			{
				throw new ArgumentException("Function name is empty.");
			}
		}

		/// <summary>
		/// Create macro name to define buffer size.
		/// </summary>
		/// <param name="baseName">Base name for macro</param>
		/// <returns>Macro name.
		/// The format is below.
		/// {FUNCTION_NAME}_STUB_BUFF_SIZE_2
		/// </returns>
		/// <exception cref="ArgumentException"></exception>
		public virtual string CreateBufferSizeMacro2(string baseName)
		{
			try
			{
				string baseMacro = CreateBufferSizeMacroCommon(baseName);
				string macro = $"{baseMacro}_2";
				return macro;
			}
			catch (AggregateException)
			{
				throw new ArgumentException("Base name is empty.");
			}
		}

		/// <summary>
		/// Create macro name to define buffer size.
		/// </summary>
		/// <param name="function">Function data.</param>
		/// <returns>Macro name to define buffer size.</returns>
		/// <exception cref="ArgumentException"></exception>
		public virtual string CreateBufferSizeMacro2(Function function)
		{
			try
			{
				string macro = CreateBufferSizeMacro2(function.Name);
				return macro;
			}
			catch (ArgumentException)
			{
				throw new ArgumentException("Function name is empty.");
			}
		}

		/// <summary>
		/// Create macro name to define buffer size.
		/// </summary>
		/// <param name="function">Function data.</param>
		/// <returns>Macro name to define buffer size.</returns>
		/// <exception cref="ArgumentException">Base name for macro is empty.</exception>
		protected virtual string CreateBufferSizeMacroCommon(string baseName)
		{
			if ((string.IsNullOrEmpty(baseName)) || (string.IsNullOrWhiteSpace(baseName)))
			{
				throw new ArgumentException("Base name for macro is empty.");
			}
			string macro_lower = $"{baseName}_stub_buff_size";
			string macro = macro_lower.ToUpper();
			return macro;
		}
	}
}
