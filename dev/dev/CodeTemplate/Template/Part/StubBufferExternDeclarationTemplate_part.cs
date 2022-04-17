using CodeTemplate.Builder;
using Parser.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTemplate.Template
{
	public partial class StubBufferExternDeclarationTemplate : StubBufferDeclarationTemplate
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public StubBufferExternDeclarationTemplate() : base() { }

		public override string FuncCalledCounterBufferDeclare()
		{
			try
			{
				string baseCode = base.FuncCalledCounterBufferDeclare();
				string code = $"extern {baseCode}";
				return code;
			}
			catch (Exception ex)
			when ((ex is FormatException) || (ex is NullReferenceException))
			{
				throw;
			}
			catch (Exception)
			{
				throw;
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
		protected override string ArgBufferDeclare(Variable argument)
		{
			try
			{
				var builder = new StubCodeBuilder();
				string declare = builder.CreateArgBuffer(TargetFunc, argument);
				string macro = builder.CreateBufferSizeMacro1(TargetFunc);
				string code = $"extern {declare}[];";
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

		public override string FuncReturnValueDeclare()
		{
			try
			{
				var builder = new StubCodeBuilder();
				string retValueDeclare = builder.CreateReturnValueBuffer(TargetFunc);
				string code = $"extern {retValueDeclare}[];";
				return code;
			}
			catch (FormatException)
			{
				string code = string.Empty;
				return code;
			}
			catch (ArgumentException)
			{
				throw;
			}
		}

		protected override string ReturnValueViaArgumentBufferDeclare(Variable argument)
		{
			var builder = new StubCodeBuilder();
			string declare = builder.CreateReturnValueBufferViaArg(TargetFunc, argument);
			string macro2 = builder.CreateBufferSizeMacro2(TargetFunc);
			string code = $"extern {declare}[][{macro2}];";
			return code;
		}

		protected override string ReturnValueSizeViaArgumentBufferDeclare(Variable argument)
		{
			var builder = new StubCodeBuilder();
			string declare = builder.CreateReturnValueSizeBufferViaArg(TargetFunc, argument);
			string code = $"extern {declare}[];";
			return code;
		}
	}
}
