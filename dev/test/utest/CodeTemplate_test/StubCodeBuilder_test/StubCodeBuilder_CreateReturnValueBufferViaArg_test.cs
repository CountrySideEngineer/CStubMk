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
		[TestCategory("CreateReturnValueBufferViaArg")]
		public void CreateReturnValueBufferViaArg_test_001()
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
			string code = builder.CreateReturnValueBufferViaArg(function, argument);

			Assert.AreEqual("ArgDataType TargetFunction_Argument_value", code);
		}

		[TestMethod]
		[TestCategory("CreateReturnValueBufferViaArg")]
		public void CreateReturnValueBufferViaArg_test_002()
		{
			Variable argument = new Variable()
			{
				DataType = "ArgDataType",
				Name = "Argument",
				PointerNum = 1
			};
			Function function = new Function()
			{
				DataType = "DataType",
				Name = "TargetFunction",
				PointerNum = 0,
			};
			StubCodeBuilder builder = new StubCodeBuilder();
			string code = builder.CreateReturnValueBufferViaArg(function, argument);

			Assert.AreEqual("ArgDataType TargetFunction_Argument_value", code);
		}

		[TestMethod]
		[TestCategory("CreateReturnValueBufferViaArg")]
		public void CreateReturnValueBufferViaArg_test_003()
		{
			Variable argument = new Variable()
			{
				DataType = "ArgDataType",
				Name = "Argument",
				PointerNum = 2
			};
			Function function = new Function()
			{
				DataType = "DataType",
				Name = "TargetFunction",
				PointerNum = 0,
			};
			StubCodeBuilder builder = new StubCodeBuilder();
			string code = builder.CreateReturnValueBufferViaArg(function, argument);

			Assert.AreEqual("ArgDataType TargetFunction_Argument_value", code);
		}

		[TestMethod]
		[TestCategory("CreateReturnValueBufferViaArg")]
		public void CreateReturnValueBufferViaArg_test_004()
		{
			Variable argument = new Variable()
			{
				DataType = "VOID",
				Name = "Argument",
				PointerNum = 1
			};
			Function function = new Function()
			{
				DataType = "DataType",
				Name = "TargetFunction",
				PointerNum = 0,
			};
			StubCodeBuilder builder = new StubCodeBuilder();
			string code = builder.CreateReturnValueBufferViaArg(function, argument);

			Assert.AreEqual("int TargetFunction_Argument_value", code);
		}

		[TestMethod]
		[TestCategory("CreateReturnValueBufferViaArg")]
		public void CreateReturnValueBufferViaArg_test_005()
		{
			Variable argument = new Variable()
			{
				DataType = "VOID",
				Name = "Argument",
				PointerNum = 2
			};
			Function function = new Function()
			{
				DataType = "DataType",
				Name = "TargetFunction",
				PointerNum = 0,
			};
			StubCodeBuilder builder = new StubCodeBuilder();
			string code = builder.CreateReturnValueBufferViaArg(function, argument);

			Assert.AreEqual("int TargetFunction_Argument_value", code);
		}
	}
}
