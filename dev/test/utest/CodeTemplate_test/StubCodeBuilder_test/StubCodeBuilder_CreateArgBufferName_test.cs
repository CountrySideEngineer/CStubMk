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
		[TestCategory("CreateArgBufferName")]
		public void CreateArgBufferName_test_001()
		{
			Variable argument = new Variable()
			{
				DataType = "ArgDataType",
				Name = "Argument",
				PointerNum = 0
			};
			Function function = new Function()
			{
				DataType = "DataType",
				Name = "TargetFunction",
				PointerNum = 0,
			};
			StubCodeBuilder builder = new StubCodeBuilder();
			string code = builder.CreateArgBufferName(function, argument);

			Assert.AreEqual("TargetFunction_Argument", code);
		}

	}
}
