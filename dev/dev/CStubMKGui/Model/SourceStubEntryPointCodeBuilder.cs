using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CStubMKGui.Model
{
	/// <summary>
	/// Class to create code 
	/// </summary>
	public class SourceStubEntryPointCodeBuilder : AStubBuilder
	{
		#region Constructors and the finalizer
		/// <summary>
		/// Default constructor.
		/// </summary>
		public SourceStubEntryPointCodeBuilder()
		{
			this.Codes = new List<string>();
			this.Codes.Clear();
		}
		#endregion

		#region Properties
		protected List<string> Codes;
		#endregion

		#region public methods.
		/// <summary>
		/// Create codes.
		/// </summary>
		/// <param name="codeSrc">Function information.</param>
		public override void CreateCode(object codeSrc)
		{
			try
			{
				if (null == codeSrc)
				{
					throw new ArgumentNullException(nameof(this.CreateCode));
				}
				var function = (Param)codeSrc;

				this.CreateEntryPoint(function);
				this.Codes.Add("(");
				this.CreateArgumentDeclare(function);
				this.Codes.Add(")");
			}
			catch (InvalidCastException)
			{
				Debug.WriteLine("Input is invalid / SKIP");
			}
		}

		/// <summary>
		/// Get code object.
		/// </summary>
		/// <returns>Created codes.</returns>
		public override object GetResult()
		{
			return (object)this.Codes;
		}

		/// <summary>
		/// Create code of entry point of stub method.
		/// </summary>
		/// <param name="function"></param>
		protected virtual void CreateEntryPoint(Param function)
		{
			string code = $"{function.DataType} {function.Name}";
			this.Codes.Add(code);
		}

		/// <summary>
		/// Create code declaring the arguments.
		/// </summary>
		/// <param name="function">Informatino of the stub function.</param>
		protected virtual void CreateArgumentDeclare(Param function)
		{
			try
			{
				int argCount = 0;
				string code = "";
				foreach (var argument in function.Parameters)
				{
					code = this.GetArgumentDeclare(argument);
					if (0 < argCount)
					{
						code = $", {code}";
					}
					code = $"\t{code}"; //Set indent.
					this.Codes.Add(code);
					argCount++;
				}
			}
			catch (NullReferenceException)
			{
				Debug.WriteLine("No argument / SKIP.");
			}
		}

		/// <summary>
		/// Create code declaring argument for stub.
		/// </summary>
		/// <param name="argument">Parameter of argument</param>
		/// <returns>Code declaring the arguments.</returns>
		protected virtual string GetArgumentDeclare(Param argument)
		{
			string code = "";
			if ((!(string.IsNullOrEmpty(argument.Prefix))) && (!(string.IsNullOrWhiteSpace(argument.Prefix))))
			{
				code += $"{argument.Prefix} ";
			}
			code += $"{argument.DataType}";
			for (int pointerNum = 0; pointerNum < argument.PointerNum; pointerNum++)
			{
				code += PointerModifier;
			}
			code += $"{SpaceModifier}";
			if ((!(string.IsNullOrEmpty(argument.Postifx))) && (!(string.IsNullOrWhiteSpace(argument.Postifx))))
			{
				code += $"{argument.Postifx} ";
			}
			code += $"{argument.Name}";
			return code;
		}
		#endregion
	}
}
