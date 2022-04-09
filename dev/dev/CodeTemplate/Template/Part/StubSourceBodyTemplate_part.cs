using CodeTemplate.Builder;
using Parser.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTemplate.Template
{
	public partial class StubSourceBodyTemplate : StubCodeTemplateCommonBase
	{
		protected static string INDEXER_1 = "index1";
		protected static string INDEXER_2 = "index2";

		static protected string RETURN_LATCH_VARIABLE = "return_latch";

		/// <summary>
		/// Default constructor.
		/// </summary>
		public StubSourceBodyTemplate() : base() { }

		/// <summary>
		/// Create method entry point to initialize stub buffers.
		/// </summary>
		/// <returns></returns>
		public virtual string StubBodyEntryPoint()
		{
			string code = this.TargetFunc.ToString();
			return code;
		}

		/// <summary>
		/// Create code to latch return value.
		/// </summary>
		/// <returns></returns>
		public virtual string LatchReturnValue()
		{
			string code = string.Empty;
			if ((TargetFunc.DataType.ToLower().Equals("void")) && (!(0 < TargetFunc.PointerNum)))
			{
				//Nothing to do!
			}
			else
			{
				string dataType = TargetFunc.DataType;
				for (int index = 0; index < TargetFunc.PointerNum; index++)
				{
					dataType += "*";
				}
				var builder = new StubCodeBuilder();
				string returnValue = builder.CreateReturnValueBufferName(TargetFunc);
				string calledCounter = builder.CreateFuncCalledCounterBufferName(TargetFunc);
				code =$"{dataType} {RETURN_LATCH_VARIABLE} = {returnValue}[{calledCounter}];";
			}
			return code;
		}

		public virtual string BackupArgToBuffer()
		{
			string code = string.Empty;
			try
			{
				foreach (var item in TargetFunc.Arguments)
				{
					Variable argItem = item as Variable;
					code += BackupArgToBuffer(argItem);
				}
				return code;
			}
			catch (NullReferenceException)
			{
				code = string.Empty;
				return code;
			}
		}

		protected virtual string BackupArgToBuffer(Variable argument)
		{
			var builder = new StubCodeBuilder();
			string calledCounter = builder.CreateFuncCalledCounterBufferName(TargetFunc);
			string argBuffer = builder.CreateArgBufferName(TargetFunc, argument);
			string code = $"{argBuffer}[{calledCounter}] = {argument.Name};";

			return code;
		}

		public virtual string ReturnValueViaPointer()
		{
			string code = string.Empty;

			try
			{
				code += ReturnValueViaSinglePointer(TargetFunc.Arguments);
			}
			catch (ArgumentException)
			{
				//Ignore the Exception.
			}
			try
			{
				code += ReturnValueViaDoublePointer(TargetFunc.Arguments);
			}
			catch (ArgumentException)
			{
				//Ignore the Exception.
			}
			return code;
		}

		protected virtual string ReturnValueViaSinglePointer(IEnumerable<Parameter> arguments)
		{
			IEnumerable<Parameter> singplePointerArguments = arguments.Where(_ => 1 == (_ as Variable).PointerNum);
			if (0 == singplePointerArguments.Count())
			{
				throw new ArgumentException("No argument is single pointer.");
			}

			string code = string.Empty;
			foreach (var item in singplePointerArguments)
			{
				var argItem = item as Variable;
				code += ReturnValueViaSinglePointer(argItem);
				code += Environment.NewLine;
			}
			return code;
		}

		protected virtual string ReturnValueViaSinglePointer(Variable argument)
		{
			var builder = new StubCodeBuilder();
			string calledCounter = builder.CreateFuncCalledCounterBufferName(TargetFunc);
			string returnValueSizeName = builder.CreateReturnValueSizeBufferViaArgName(TargetFunc, argument);
			string returnValueName = builder.CreateReturnValueBufferViaArgName(TargetFunc, argument);
			string forLoopStartCode = 
				$"for (int {INDEXER_1} = 0; {INDEXER_1} < {returnValueSizeName}[{calledCounter}]; {INDEXER_1}++) {{";
			string forLoopEndCode = "}";
			string code = $"{forLoopStartCode}" +
				Environment.NewLine +
				$"\t*({argument.Name} + {INDEXER_1}) = {returnValueName}[{calledCounter}][{INDEXER_1}];" +
				Environment.NewLine +
				$"{forLoopEndCode}";
			return code;
		}

		protected virtual string ReturnValueViaDoublePointer(IEnumerable<Parameter> arguments)
		{
			IEnumerable<Parameter> doublePointerArguments = arguments.Where(_ => 2 == (_ as Variable).PointerNum);
			if (0 == doublePointerArguments.Count())
			{
				throw new ArgumentException("No argument is double pointer.");
			}

			string code = string.Empty;
			foreach (var item in arguments)
			{
				Variable argItem = item as Variable;
				code += ReturnValueViaDoublePointer(argItem);
				code += Environment.NewLine;
			}
			return code;
		}

		protected virtual string ReturnValueViaDoublePointer(Variable argument)
		{
			var builder = new StubCodeBuilder();
			string calledCounter = builder.CreateFuncCalledCounterBufferName(TargetFunc);
			string returnValueName = builder.CreateReturnValueBufferViaArgName(TargetFunc, argument);
			string code = $"*{argument.Name} = &{returnValueName}[{calledCounter}][0];";
			return code;
		}

		public virtual string UpdateCalledCounter()
		{
			var builder = new StubCodeBuilder();
			string calledCounter = builder.CreateFuncCalledCounterBufferName(TargetFunc);
			string code = $"{calledCounter}++;";
			return code;
		}

		public virtual string ReturnValue()
		{
			string code = string.Empty;
			if ((TargetFunc.DataType.ToLower().Equals("void")) && (!(0 < TargetFunc.PointerNum)))
			{
				//Target function has no return value.
			}
			else
			{
				code = $"return {RETURN_LATCH_VARIABLE};";
			}
			return code;
		}
	}
}
