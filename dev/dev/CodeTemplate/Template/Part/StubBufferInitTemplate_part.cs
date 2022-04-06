using CodeTemplate.Builder;
using Parser.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTemplate.Template
{
	public partial class StubBufferInitTemplate
	{
		protected static string INDEXER_1 = "index1";

		protected static string INDEXER_2 = "index2";

		/// <summary>
		/// Target function.
		/// </summary>
		public Function Function { get; set; }

		/// <summary>
		/// Default constructor.
		/// </summary>
		public StubBufferInitTemplate() : base() { }

		/// <summary>
		/// Create entry point code to initialize stub buffers.
		/// </summary>
		/// <returns>Entry point code.</returns>
		/// <exception cref="AggregateException"></exception>
		public virtual string StubInitializeEntryPoint()
		{
			try
			{
				if ((string.IsNullOrEmpty(Function.Name)) || (string.IsNullOrWhiteSpace(Function.Name)))
				{
					throw new ArgumentException("Name property is invalid.");
				}
				string code = $"void {Function.Name}_init()";
				return code;
			}
			catch (NullReferenceException)
			{
				throw;
			}
		}

		public virtual string FuncCalledCountInit()
		{
			try
			{
				var builder = new StubCodeBuilder();
				string calledCount = builder.CreateFuncCalledCounterBufferName(Function);
				string code = $"{calledCount} = 0;";
				return code;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public virtual string FuncReturnValueInit()
		{
			try
			{
				var builder = new StubCodeBuilder();
				string returnValue = builder.CreateReturnValueBufferName(Function);
				string code = string.Empty;
				if (0 == Function.PointerNum)
				{
					code = $"{returnValue} = 0;";
				}
				else
				{
					code = $"{returnValue} = null;";
				}
				return code;
			}
			catch (FormatException)
			{
				string code = $"//{Function.Name} has no return value.";
				return code;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public virtual string ArgBufferInit()
		{
			try
			{
				string code = string.Empty;
				code += ArgBufferInit(Function.Arguments);
				code += ReturnValueViaPointerBufferInit();
				code += ReturnValueSizeViaPointerBufferInit(Function.Arguments);

				if (!(string.IsNullOrEmpty(code)))
				{
					var builder = new StubCodeBuilder();
					string bufferSizeMacro = builder.CreateBufferSizeMacro1(Function);

					/*
					 * for (int index1 = 0; index1 < MACRO; index1++) {
					 */
					string forLoopStart = $"for (int {INDEXER_1} = 0; " +
						$"{INDEXER_1} < {bufferSizeMacro}; " +
						$"{INDEXER_1}++) {{" +
						Environment.NewLine;
					string forLoopEnd = $"}}{Environment.NewLine}";

					code = $"{forLoopStart}{code}{forLoopEnd}";
				}
				else
				{
					code = $"//{Function.Name} has no argument.";
				}
				return code;
			}
			catch (Exception ex)
			when ((ex is ArgumentException) || (ex is NullReferenceException))
			{
				throw;
			}
		}

		protected virtual string ArgBufferInit(IEnumerable<Parameter> arguments)
		{
			try
			{
				string code = string.Empty;
				foreach (var item in arguments)
				{
					var argument = item as Variable;
					string initializeCode = ArgBufferInit(argument);
					code += $"\t{initializeCode}";
					code += Environment.NewLine;
				}
				return code;
			}
			catch (NullReferenceException)
			{
				return string.Empty;
			}
		}

		protected virtual string ArgBufferInit(Variable argument)
		{
			try
			{
				var builder = new StubCodeBuilder();
				string bufferName = builder.CreateArgBufferName(Function, argument);
				string code = $"{bufferName}[{INDEXER_1}] = 0;";
				return code;
			}
			catch (Exception ex)
			when ((ex is ArgumentException) || (ex is NullReferenceException))
			{
				throw ex;
			}
		}

		protected virtual string ReturnValueSizeViaPointerBufferInit(IEnumerable<Parameter> arguments)
		{
			var argumentsWithPointer = arguments.Where(_ => (0 < (_ as Variable).PointerNum));
			string code = string.Empty;
			try
			{
				foreach (var item in argumentsWithPointer)
				{
					var argItem = item as Variable;
					string initializeCode = ReturnValueSizeViaPointerBufferInit(argItem);
					code += $"\t{initializeCode}";
					code += Environment.NewLine;
				}
			}
			catch (NullReferenceException)
			{
				code = string.Empty;
			}
			return code;
		}

		protected virtual string ReturnValueSizeViaPointerBufferInit(Variable argument)
		{
			var builder = new StubCodeBuilder();
			string bufferName = builder.CreateReturnValueSizeBufferViaArgName(Function, argument);
			string code = $"{bufferName}[{INDEXER_1}] = 1;";
			return code;
		}

		public virtual string ReturnValueViaPointerBufferInit()
		{
			string code = string.Empty;
			IEnumerable<Parameter> arguments = Function.Arguments;
			code = ReturnValueViaPointerBufferInit(arguments);
			if (!(string.IsNullOrEmpty(code)))
			{
				var builder = new StubCodeBuilder();
				string bufferSizeMacro2 = builder.CreateBufferSizeMacro2(Function);
				string forLoopStart =
					$"\tfor (int {INDEXER_2} = 0; " +
					$"{INDEXER_2} < {bufferSizeMacro2}; " +
					$"{INDEXER_2}++) {{" +
					Environment.NewLine;
				string forLoopEnd = "\t}" + Environment.NewLine;
				code = $"{forLoopStart}{code}{forLoopEnd}";
			}
			return code;
		}

		protected virtual string ReturnValueViaPointerBufferInit(IEnumerable<Parameter> arguments)
		{
			var argumentsWithPointer = arguments.Where(_ => (0 < (_ as Variable).PointerNum));
			string code = string.Empty;
			foreach (var item in argumentsWithPointer)
			{
				var argumentItem = item as Variable;
				string initializeCode = ReturnValueViaPointerBufferInit(argumentItem);
				code += $"\t\t{initializeCode}";
				code += Environment.NewLine;
			}
			return code;
		}

		protected virtual string ReturnValueViaPointerBufferInit(Variable argument)
		{
			try
			{
				var builder = new StubCodeBuilder();
				string valueBuffer = builder.CreateReturnValueBufferViaArgName(Function, argument);
				string code = $"{valueBuffer}[{INDEXER_1}][{INDEXER_2}] = 0;";
				return code;
			}
			catch (Exception ex)
			when ((ex is ArgumentException) || (ex is NullReferenceException))
			{
				throw;
			}
		}
	}
}
