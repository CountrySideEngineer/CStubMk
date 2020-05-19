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
		protected const int NumberInitialValue = 0;
		protected const int CalledCountInitialValue = 0;
		protected const string PointerInitialValue = "NULL";
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
		public AStubBuilder(int buffSize = 100)
		{
			this.Codes = null;
			this.BuffSize = buffSize;
		}

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

		/// <summary>
		/// Add code to list with indent, the "TAB".
		/// </summary>
		/// <param name="code">Code to add to list.</param>
		/// <param name="indentLevel">Indent level. Default value is 1</param>
		protected void SetCode(string code, int indentLevel = 1)
		{
			string codeToSet = "";
			for (int level = 0; level < indentLevel; level++)
			{
				codeToSet += "\t";
			}
			codeToSet += code;
			this.Codes.Add(codeToSet);
		}
		#endregion

		#region Properties
		/// <summary>
		/// List of codes.
		/// </summary>
		protected List<string> Codes { get; set; }

		/// <summary>
		/// Size of stub buffer.
		/// </summary>
		protected int BuffSize { get; set; }
		#endregion
	}
}
