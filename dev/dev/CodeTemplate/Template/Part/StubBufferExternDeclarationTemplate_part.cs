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

		public override string FuncReturnValueDeclare()
		{
			string baseCode = base.FuncReturnValueDeclare();
			string code = $"extern {baseCode}";
			return code;
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
