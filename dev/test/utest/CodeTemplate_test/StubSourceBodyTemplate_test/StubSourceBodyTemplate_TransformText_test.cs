using CodeTemplate.Template;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser.SDK.Model;
using System;
using System.Diagnostics;

namespace StubSourceBodyTemplate_test
{
	//[TestClass]
	public partial class StubSourceBodyTemplate_test
	{
		[TestMethod]
		[TestCategory("StubSourceBodyTemplate")]
		[TestCategory("TransformText")]
		public void TransformText_test_001()
		{
			Function function = new Function()
			{
				Name = "TestFunction",
				DataType = "DataType",
				PointerNum = 0,
			};
			var template = new StubSourceBodyTemplate()
			{
				TargetFunc = function
			};
			string code = template.TransformText();
			Debug.Write(code);

			Assert.IsTrue(true);
		}
	}
}
