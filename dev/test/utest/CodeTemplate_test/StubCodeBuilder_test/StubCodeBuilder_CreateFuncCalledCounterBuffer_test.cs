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
		[TestCategory("CreateFuncCalledCounterBuffer")]
		public void CreateFuncCalledCounterBuffer_test_001()
		{
			Function function = new Function()
			{
				Name = "TargetFunction"
			};
			StubCodeBuilder builder = new StubCodeBuilder();
			string code = builder.CreateFuncCalledCounterBuffer(function);

			Assert.AreEqual("long TargetFunction_called_count", code);
		}
	}
}
