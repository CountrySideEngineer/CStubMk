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
		Function Function { get; set; }

		/// <summary>
		/// Default constructor.
		/// </summary>
		public StubBufferInitTemplate() : base() { }

		/// <summary>
		/// Create entry point code to initialize stub buffers.
		/// </summary>
		/// <returns>Entry point code.</returns>
		public virtual string StubInitializeEntryPoint()
		{
			string code = $"void {Function.Name}_init()";
			return code;
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
				var builder = new StubCodeBuilder();
				string bufferSizeMacro = builder.CreateBufferSizeMacro1(Function);
				string code = string.Empty;
				code += ArgBufferInit(Function.Arguments);
				code += ReturnValueViaPointerInit(Function.Arguments);

				if (!(string.IsNullOrEmpty(code)))
				{
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
			string code = string.Empty;
			try
			{
				if (0 < arguments.Count())
				{
					foreach (var item in arguments)
					{
						var argument = item as Variable;
						string initializeCode = ArgBufferInit(argument);
						code += initializeCode;
						code += Environment.NewLine;
					}
				}
			}
			catch (NullReferenceException)
			{
				code = string.Empty;
			}
			return code;
		}

		protected virtual string ArgBufferInit(Variable argument)
		{
			var builder = new StubCodeBuilder();
			string bufferName = builder.CreateArgBufferName(Function, argument);
			string initialValue = "0";
			string code = $"{bufferName}[{INDEXER_1}] = {initialValue}";
			return code;
		}

		protected virtual string ReturnValueViaPointerInit(IEnumerable<Parameter> arguments)
		{
			var argumentsWithPointer = arguments.Where(_ => (0 < (_ as Variable).PointerNum));
			string code = string.Empty;
			try
			{
				if (0 < argumentsWithPointer.Count())
				{
					foreach (var item in argumentsWithPointer)
					{
						var argItem = item as Variable;
						string initializeCode = ReturnValueViaPointerInit(argItem);
						code += initializeCode;
						code += Environment.NewLine;
					}
				}
				else
				{
					code = string.Empty;
				}
			}
			catch (NullReferenceException)
			{
				code = string.Empty;
			}
			return code;

		}

		protected virtual string ReturnValueViaPointerInit(Variable argument)
		{
			var builder = new StubCodeBuilder();
			string bufferName = builder.CreateReturnValueSizeBufferViaArgName(Function, argument);
			string code = $"{bufferName}[{INDEXER_1}] = 1;";
			return code;
		}



		public virtual string PointerArgBufferInit()
		{
			string code = string.Empty;
			IEnumerable<Parameter> arguments = Function.Arguments;
			if (0 < arguments.Count())
			{
				code = PointerArgBufferInit(arguments);
				if (!(string.IsNullOrEmpty(code)))
				{
					var builder = new StubCodeBuilder();
					string bufferSizeMacro1 = builder.CreateBufferSizeMacro1(Function);
					string bufferSizeMacro2 = builder.CreateBufferSizeMacro2(Function);
					string forLoopStart = 
						$"for (int {INDEXER_1} = 0; " +
						$"{INDEXER_1} < {bufferSizeMacro1}; " +
						$"{INDEXER_1}++) {{" +
						Environment.NewLine;
					forLoopStart += 
						$"\tfor (int {INDEXER_2} = 0; " +
						$"{INDEXER_2} < {bufferSizeMacro2}; " +
						$"{INDEXER_2}++) {{" +
						Environment.NewLine;
					string forLoopEnd = "\t}" + Environment.NewLine + "}" + Environment.NewLine;
					code = $"{forLoopStart}{code}{forLoopEnd}";
				}
			}
			return code;
		}

		protected virtual string PointerArgBufferInit(IEnumerable<Parameter> arguments)
		{
			var argumentsWithPointer = arguments.Where(_ => (0 < (_ as Variable).PointerNum));
			string code = string.Empty;
			if (0 < argumentsWithPointer.Count())
			{
				foreach (var item in argumentsWithPointer)
				{
					var argumentItem = item as Variable;
					string initializeCode = PointerArgBufferInit(argumentItem);
					code += $"\t\t{initializeCode}";
					code += Environment.NewLine;
				}
			}
			return code;
		}

		protected virtual string PointerArgBufferInit(Variable argument)
		{
			var builder = new StubCodeBuilder();
			string valueSizeBuffer = builder.CreateReturnValueSizeBufferViaArgName(Function, argument);
			string code = $"{valueSizeBuffer}[{INDEXER_1}][{INDEXER_2}] = 0;";
			return code;
		}
	}
}
