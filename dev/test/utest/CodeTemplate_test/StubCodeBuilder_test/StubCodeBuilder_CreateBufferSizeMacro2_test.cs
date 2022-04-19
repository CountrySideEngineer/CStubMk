using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Parser.SDK.Model;
using CodeTemplate.Builder;
using System.Collections.Generic;

namespace StubCodeBuilder_test
{
	//[TestClass]
	public partial class StubCodeBuilder_test
	{
		[TestMethod]
		[TestCategory("CreateBufferSizeMacro2")]
		public void CreateBufferSizeMacro2_test_001()
		{
			Function function = new Function()
			{
				DataType = "DataType",
				Name = "TargetFunction",
				PointerNum = 0,
			};
			StubCodeBuilder builder = new StubCodeBuilder();
			string code = builder.CreateBufferSizeMacro2(function);

			Assert.AreEqual("TARGETFUNCTION_STUB_BUFF_SIZE_2", code);
		}
	}
}
