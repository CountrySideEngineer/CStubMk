using CodeTemplate.Template;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser.SDK.Model;
using System;

namespace StubBufferDeclarationTemplate_test
{
	//[TestClass]
	public partial class StubBufferDeclarationTemplate_test
	{
		[TestMethod]
		[TestCategory("StubBufferDeclarationTemplate")]
		[TestCategory("FuncReturnValueDeclare")]
		public void FuncReturnValueDeclare_test_001()
		{
			Function function = new Function()
			{
				DataType = "DataType",
				Name = "TargetFunction",
				PointerNum = 0
			};
			var template = new StubBufferDeclarationTemplate()
			{
				Function = function
			};
			string code = template.FuncReturnValueDeclare();
			Assert.AreEqual("DataType TargetFunction_return_value[TARGETFUNCTION_STUB_BUFF_SIZE_1];", code);
		}

		[TestMethod]
		[TestCategory("StubBufferDeclarationTemplate")]
		[TestCategory("FuncReturnValueDeclare")]
		public void FuncReturnValueDeclare_test_002()
		{
			Function function = new Function()
			{
				DataType = "void",
				Name = "TargetFunction",
				PointerNum = 0
			};
			var template = new StubBufferDeclarationTemplate()
			{
				Function = function
			};
			string code = template.FuncReturnValueDeclare();
			Assert.AreEqual("//TargetFunction returns no value.", code);
		}
	}
}
