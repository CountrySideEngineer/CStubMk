using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
	public abstract class AStubBuilder : ICodeBuilder
	{
		#region Abstract method.
		public abstract void CreateCode(object codeSrc);
		public abstract object GetResult();
		#endregion

		#region Properties
		protected readonly string BufferSizeMacroCode = @"STUB_BUFFER_SIZE";
		protected const string SpaceModifier = " ";
		protected const string PointerModifier = "*";
		protected const int CalledCountInitialValue = 0;
		protected const string ConnectModifier = "_";
		protected const string CalledCountDataType = "int";
		protected const string CalledCountModifier = "called_count";
		protected const string ReturnValueModifier = "ret_val";
		protected const string PointerValueModifier = "value";
		protected const string PointerAmpasandModifier = "&";
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="buffSize">Size of buffer</param>
		/// <remarks>The default value of variable buffSize is 100.</remarks>
		public AStubBuilder(int buffSize = 100) { }

		/// <summary>
		/// Create name of variable which is used to store how many times the method
		/// is called.
		/// </summary>
		/// <param name="function">Data of the method.</param>
		/// <returns>Called counter variable name.</returns>
		protected string GetCalledCounterName(Param function)
		{
			return $"{function.Name}_{CalledCountModifier}";
		}

		/// <summary>
		/// Create name of variable to hold the argument.
		/// </summary>
		/// <param name="function">Data of method.</param>
		/// <param name="argument">Data of argument</param>
		/// <returns>Argument buffer name.</returns>
		protected string GetBufferName(Param function, Param argument)
		{
			return $"{function.Name}_{argument.Name}";
		}
		#endregion
	}
}
