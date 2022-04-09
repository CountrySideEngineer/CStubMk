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
		[TestCategory("FuncCalledCounterBufferDeclare")]
		public void FuncCalledCounterBufferDeclare_test_001()
		{
			Function function = new Function()
			{
				DataType = "DataType",
				Name = "TargetFunction"
			};
			var template = new StubBufferDeclarationTemplate()
			{
				TargetFunc = function
			};
			string code = template.FuncCalledCounterBufferDeclare();
			Assert.AreEqual("long TargetFunction_called_count;", code);
		}
	}
}
