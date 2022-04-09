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
		[TestCategory("ReturnValue")]
		public void ReturnValue_test_001()
		{
			Function function = new Function()
			{
				Name = "TestFunction",
				DataType = "DataType"
			};
			var template = new StubSourceBodyTemplate()
			{
				TargetFunc = function
			};
			string code = template.ReturnValue();
			string expected = $"return return_latch;";
			Assert.AreEqual(expected, code);
		}
	}
}
