﻿using CodeTemplate.Builder;
using Parser.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTemplate.Template
{
	public partial class StubBufferDeclarationTemplate
	{
		public Function Function { get; set; }

		/// <summary>
		/// Default constructor.
		/// </summary>
		public StubBufferDeclarationTemplate() : base()
		{
			Function = null;
		}

		/// <summary>
		/// Create code to declare buffer that hold the number of times the function is called.
		/// </summary>
		/// <returns>Code to declare buffer that hold the number of times the function is called.</returns>
		/// <exception cref="FormatException">The Function format data is invalid.</exception>
		/// <exception cref="NullReferenceException">The function data has not been set.</exception>
		public virtual string FuncCalledCounterBufferDeclare()
		{
			try
			{
				var builder = new StubCodeBuilder();
				string bufferDeclare = builder.CreateFuncCalledCounterBuffer(Function);
				string code = $"{bufferDeclare};";
				return code;
			}
			catch (ArgumentException)
			{
				throw new FormatException();
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Create code to declare buffer that hold the value the stub method should return.
		/// </summary>
		/// <returns>Code to declare buffer that hold the value the stub method should return.</returns>
		/// <remarks>
		/// If the function does not return any value, this method returns comment code.
		/// </remarks>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="NullReferenceException"></exception>
		public virtual string FuncReturnValueDeclare()
		{
			try
			{
				var builder = new StubCodeBuilder();
				string retValueDeclare = builder.CreateReturnValueBuffer(Function);
				string buffSizeMacro = builder.CreateBufferSizeMacro1(Function);
				string code = $"{retValueDeclare}[{buffSizeMacro}];";
				return code;
			}
			catch (FormatException)
			{
				string code = $"//{Function.Name} returns no value.";
				return code;
			}
			catch (ArgumentException)
			{
				throw;	
			}
		}

		/// <summary>
		/// Create code to declare buffer to holds argument values.
		/// </summary>
		/// <returns>Code to declare buffer to holds argument values.</returns>
		public virtual string ArgBufferDeclare()
		{
			var arguments = Function.Arguments;
			string code = ArgBufferDeclare(arguments);
			return code;
		}

		/// <summary>
		/// Create code to declare buffer to holds argument values.
		/// </summary>
		/// <param name="arguments">Collection of argument data.</param>
		/// <returns>Code to declare buffer to holds argument values.</returns>
		protected virtual string ArgBufferDeclare(IEnumerable<Parameter> arguments)
		{
			string code = string.Empty;
			try
			{
				var builder = new StubCodeBuilder();
				foreach (var item in arguments)
				{
					Variable argumentItem = item as Variable;
					string bufferDeclare = ArgBufferDeclare(argumentItem);
					code += bufferDeclare;
					code += Environment.NewLine;
				}
				return code;
			}
			catch (FormatException ex)
			{
				if ((!(string.IsNullOrEmpty(code))) && (!(string.IsNullOrWhiteSpace(code))))
				{
					throw new FormatException(ex.Message);
				}
				else
				{
					return string.Empty;
				}
			}
		}

		/// <summary>
		/// Create code to declare buffer to holds argumet value.
		/// </summary>
		/// <param name="argument">Argument data.</param>
		/// <returns>Code to declare buffer to hold argument value.</returns>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="FormatException"></exception>
		/// <exception cref="NullReferenceException"></exception>
		protected virtual string ArgBufferDeclare(Variable argument)
		{
			try
			{
				var builder = new StubCodeBuilder();
				string declare = builder.CreateArgBuffer(Function, argument);
				string macro = builder.CreateBufferSizeMacro1(Function);
				string code = $"{declare}[{macro}];";
				return code;
			}
			catch (Exception ex)
			when ((ex is ArgumentException) ||
				(ex is FormatException) ||
				(ex is NullReferenceException))
			{
				throw;
			}
		}

		/// <summary>
		/// Create code to declare buffer to store values the method will return via pointer argument.
		/// </summary>
		/// <returns>code to declare buffer to store value the method will return via pointer argument.</returns>
		/// <remarks>
		/// If all arguments are not pointer type, this methos return empty string.
		/// </remarks>
		public virtual string ReturnValueViaArgumentBufferDeclare()
		{
			string code = string.Empty;
			IEnumerable<Parameter> arguments = Function.Arguments;
			IEnumerable<Parameter> argumentsWithPointer = arguments.Where(_ => (0 < (_ as Variable).PointerNum));
			if (0 < argumentsWithPointer.Count())
			{
				code = ReturnValueViaArgumentBufferDeclare(argumentsWithPointer);
			}
			return code;
		}

		/// <summary>
		/// Create code to declare buffer to store values the method will return via pointer argument.
		/// </summary>
		/// <param name="arguments">Collection of argument whose data type is pointer.</param>
		/// <returns>code to declare buffer to store values the method will return via pointer argument.</returns>
		protected virtual string ReturnValueViaArgumentBufferDeclare(IEnumerable<Parameter> arguments)
		{
			string code = string.Empty;
			
			foreach (var item in arguments)
			{
				Variable argumentItem = item as Variable;
				string declareCode = ReturnValueViaArgumentBufferDeclare(argumentItem);
				code += declareCode;
				code += Environment.NewLine;
			}
			return code;
		}

		/// <summary>
		/// Create code to declare buffer to store value the method will return via pointer argument.
		/// </summary>
		/// <param name="argument">Argument data.</param>
		/// <returns>code to declare buffer to store value the method will return via pointer argument.</returns>
		protected virtual string ReturnValueViaArgumentBufferDeclare(Variable argument)
		{
			var builder = new StubCodeBuilder();
			string declare = builder.CreateReturnValueBufferViaArg(Function, argument);
			string macro1 = builder.CreateBufferSizeMacro1(Function);
			string macro2 = builder.CreateBufferSizeMacro2(Function);
			string code = $"{declare}[{macro1}][{macro2}];";
			return code;
		}

		/// <summary>
		/// Create code to declare buffer to store values size the method will return via poitner argument.
		/// </summary>
		/// <returns>Code to declare buffer to store data size the method will return via poitner argument.</returns>
		public virtual string ReturnValueSizeViaArgumentBufferDeclare()
		{
			string code = string.Empty;
			if (0 < Function.Arguments.Count())
			{
				var arguments = Function.Arguments;
				code = ReturnValueSizeViaArgumentBufferDeclare(arguments);
			}
			return code;
		}

		/// <summary>
		/// Create code to declare buffer to store values size the method will return via poitner argument.
		/// </summary>
		/// <param name="arguments">Collection of argument with pointer.</param>
		/// <returns>Code to declare buffer to store data size the method will return via pointer argument.</returns>
		protected virtual string ReturnValueSizeViaArgumentBufferDeclare(IEnumerable<Parameter> arguments)
		{
			string code = string.Empty;
			var argumentsWithPointer = arguments.Where(_ => 0 < (_ as Variable).PointerNum);
			if (0 < argumentsWithPointer.Count())
			{
				foreach (var item in argumentsWithPointer)
				{
					var argumentItem = item as Variable;
					string declareCode = ReturnValueSizeViaArgumentBufferDeclare(argumentItem);
					code += declareCode;
					code += Environment.NewLine;
				}
			}
			return code;
		}

		/// <summary>
		/// Create code to declare buffer to store data size the method will return via pointer.
		/// </summary>
		/// <param name="argument">Argument data.</param>
		/// <returns>Code to declare buffer to streo data size the method will return via pointer.</returns>
		protected virtual string ReturnValueSizeViaArgumentBufferDeclare(Variable argument)
		{
			var builder = new StubCodeBuilder();
			string declare = builder.CreateReturnValueSizeBufferViaArg(Function, argument);
			string macro = builder.CreateBufferSizeMacro1(Function);
			string code = $"{declare}[{macro}];";
			return code;
		}

	}
}
