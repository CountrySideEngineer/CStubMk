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
		[TestCategory("CreateFuncCalledCounterBufferName")]
		public void CreateFuncCalledCounterBufferName_test_001()
		{
			Function function = new Function()
			{
				Name = "TargetFunction"
			};
			StubCodeBuilder builder = new StubCodeBuilder();
			string code = builder.CreateFuncCalledCounterBufferName(function);

			Assert.AreEqual("TargetFunction_called_count", code);
		}
	}
}
