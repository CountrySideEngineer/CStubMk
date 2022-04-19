using CodeTemplate.Template;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser.SDK.Model;
using System;
using System.Collections.Generic;

namespace StubBufferInitTemplate_test
{
	//[TestClass]
	public partial class StubBufferInitTemplate_test
	{
		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("StubInitializeEntryPoint")]
		public void StubInitializeEntryPoint_test_001()
		{
			Function function = new Function()
			{
				DataType = "DataType",
				Name = "TestFunction",
			};
			var template = new StubBufferInitTemplate()
			{
				TargetFunc = function
			};
			string code = template.StubInitializeEntryPoint();
			string expect = "void TestFunction_init()";

			Assert.AreEqual(expect, code);
		}
	}
}
