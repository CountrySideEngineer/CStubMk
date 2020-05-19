using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CStubMKGui.Model
{
	/// <summary>
	/// Builder class to create code of stub body.
	/// </summary>
	public class SourceStubBodyCodeBuilder : AStubBuilder
	{
		#region Constructor
		/// <summary>
		/// Default constructor.
		/// </summary>
		public SourceStubBodyCodeBuilder() : base(100)
		{
			this.Codes = null;
		}
		#endregion

		#region Public method.
		/// <summary>
		/// Creat codes 
		/// </summary>
		/// <param name="codeSrc">Source object to create code.</param>
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
				this.CreateRetValLatchCode(function);
				this.CreateStoreArgumentCode(function);
				this.CreateIncrementCalledCountCode(function);
				this.CreateCodeToReturnValueCode(function);
				this.SetCode("}", 0);
			}
			catch (InvalidCastException)
			{
				Debug.WriteLine("Input is invalid / SKIP");
			}
		}

		/// <summary>
		/// Get the retult.
		/// </summary>
		/// <returns></returns>
		public override object GetResult()
		{
			return (object)this.Codes;
		}

		/// <summary>
		/// Create code to latch the buffer of return value into local variable.
		/// </summary>
		/// <param name="function">Information of functoin.</param>
		protected void CreateRetValLatchCode(Param function)
		{
			if ((!(string.IsNullOrEmpty(function.DataType))) &&
				(!(string.IsNullOrWhiteSpace(function.DataType))) &&
				(0 != string.Compare(function.DataType, "void", true)))
			{
				string code = "int";
				for (int index = 0; index < function.PointerNum; index++)
				{
					code += PointerModifier;
				}
				code +=
					$" {ReturnValueModifier} = {function.Name}_{ReturnValueModifier}[{base.GetCalledCounterName(function)}];";
				this.SetCode(code);
			}
		}

		/// <summary>
		/// Create code to set the value into buffer and, if the argument is pointer, 
		/// set the value of buffer into pointer argument.
		/// </summary>
		/// <param name="function">Information of function.</param>
		protected void CreateStoreArgumentCode(Param function)
		{
			try
			{
				foreach (var argument in function.Parameters)
				{
					this.CreateStoreArgumentCode(function, argument);
					this.CreateSetOutputValueCode(function, argument);
				}
			}
			catch (NullReferenceException)
			{
				Debug.WriteLine($"{function.Name} has no argument.");
			}
		}

		/// <summary>
		/// Create code to set the value of argument into pointer.
		/// </summary>
		/// <param name="function">Information of function.</param>
		/// <param name="argument">Information of argument.</param>
		protected void CreateStoreArgumentCode(Param function, Param argument)
		{
			string code = $"{function.Name}_{argument.Name}[{base.GetCalledCounterName(function)}]";
			code += ($" = {argument.Name};");
			this.SetCode(code);
		}

		/// <summary>
		/// Create code to set the value of buffer to the substance if the argument is pointer.
		/// </summary>
		/// <param name="function">Information of function.</param>
		/// <param name="argument">Information of argument.</param>
		protected void CreateSetOutputValueCode(Param function, Param argument)
		{
			if (1 == argument.PointerNum)
			{
				this.CreateSetValueToPointerCode(function, argument);
			}
			else if (2 == argument.PointerNum)
			{
				this.CreateSetValueToDoublePointerCode(function, argument);
			}
			else if (2 < argument.PointerNum)
			{
				throw new NotSupportedException(nameof(CreateSetOutputValueCode));
			}
			else
			{
				//Nothig to do if the argument is not pointer.
			}
		}

		/// <summary>
		/// Create code to set the value of buffer into argument passed as argument.
		/// </summary>
		/// <param name="function">Information of function.</param>
		/// <param name="argument">Information of argument.</param>
		protected void CreateSetValueToPointerCode(Param function, Param argument)
		{
			string code = $"{PointerModifier}{argument.Name}"
				+ $" = {function.Name}_{argument.Name}_{PointerValueModifier}"
				+ $"[{base.GetCalledCounterName(function)}];";
			this.SetCode(code);
		}

		/// <summary>
		/// Create code to set the value of buffer into argument passed as argument.
		/// </summary>
		/// <param name="function">Information of function.</param>
		/// <param name="argument">Information of argument.</param>
		protected void CreateSetValueToDoublePointerCode(Param function, Param argument)
		{
			string code = $"{PointerModifier}{argument.Name}"
				+ $" = {function.Name}_{argument.Name}_{PointerValueModifier}"
				+ $"[{base.GetCalledCounterName(function)}];";
			this.SetCode(code);
		}

		/// <summary>
		/// Create code to increment the value of buffer storing the number of the stub called.
		/// </summary>
		/// <param name="function">Information of function.</param>
		/// <param name="argument">Information of argument, not used.</param>
		protected void CreateIncrementCalledCountCode(Param function)
		{
			string code = $"{base.GetCalledCounterName(function)}++;";
			this.SetCode(code);
		}

		/// <summary>
		/// Create code to return the latched value if the function has return value.
		/// </summary>
		/// <param name="function">Information of function.</param>
		protected void CreateCodeToReturnValueCode(Param function)
		{
			if ((!(string.IsNullOrEmpty(function.DataType))) &&
				(!(string.IsNullOrWhiteSpace(function.DataType))) &&
				(0 != string.Compare(function.DataType, "void", true)))
			{
				string code = $"return {ReturnValueModifier};";
				this.SetCode(code);
			}
		}
		#endregion
	}
}
