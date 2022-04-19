using CodeTemplate.Template;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser.SDK.Model;
using System;

namespace StubSourceBodyTemplate_test
{
	//[TestClass]
	public partial class StubSourceBodyTemplate_test
	{
		[TestMethod]
		[TestCategory("StubSourceBodyTemplate")]
		[TestCategory("StubBodyEntryPoint")]
		public void StubBodyEntryPoint_test_001()
		{
			Function function = new Function()
			{
				Name = "TestFunction",
				DataType = "DataType",
				PointerNum = 0
			};
			var template = new StubSourceBodyTemplate()
			{
				TargetFunc = function
			};
			string code = template.StubBodyEntryPoint();
			string expected = $"DataType TestFunction()";
			Assert.AreEqual(expected, code);
		}
	}
}
