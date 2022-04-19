using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Parser.SDK.Model;
using CodeTemplate.Builder;

namespace StubCodeBuilder_test
{
	//[TestClass]
	public partial class StubCodeBuilder_test
	{
		[TestMethod]
		[TestCategory("CreateReturnValueBufferName")]
		public void CreateReturnValueBufferName_test_001()
		{
			Function function = new Function()
			{
				Name = "TargetFunction"
			};
			StubCodeBuilder builder = new StubCodeBuilder();
			string code = builder.CreateReturnValueBufferName(function);

			Assert.AreEqual("TargetFunction_return_value", code);
		}
	}
}
