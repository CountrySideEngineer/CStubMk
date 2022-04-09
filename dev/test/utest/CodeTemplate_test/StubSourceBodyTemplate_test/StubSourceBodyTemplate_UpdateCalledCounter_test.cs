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
		[TestCategory("UpdateCalledCounter")]
		public void UpdateCalledCounter_test_001()
		{
			Function function = new Function()
			{
				Name = "TestFunction"
			};
			var template = new StubSourceBodyTemplate()
			{
				TargetFunc = function
			};
			string code = template.UpdateCalledCounter();
			string expected = $"TestFunction_called_count++;";
			Assert.AreEqual(expected, code);
		}
	}
}
