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
		[TestCategory("CreateReturnValueBuffer")]
		public void CreateReturnValueBuffer_test_001()
		{
			Function function = new Function()
			{
				DataType = "DataType",
				Name = "TargetFunction",
				PointerNum = 0
			};
			StubCodeBuilder builder = new StubCodeBuilder();
			string code = builder.CreateReturnValueBuffer(function);

			Assert.AreEqual("DataType TargetFunction_return_value", code);
		}

		[TestMethod]
		[TestCategory("CreateReturnValueBuffer")]
		public void CreateReturnValueBuffer_test_002()
		{
			Function function = new Function()
			{
				DataType = "DataType",
				Name = "TargetFunction",
				PointerNum = 1
			};
			StubCodeBuilder builder = new StubCodeBuilder();
			string code = builder.CreateReturnValueBuffer(function);

			Assert.AreEqual("DataType* TargetFunction_return_value", code);
		}

		[TestMethod]
		[TestCategory("CreateReturnValueBuffer")]
		public void CreateReturnValueBuffer_test_003()
		{
			Function function = new Function()
			{
				DataType = "DataType",
				Name = "TargetFunction",
				PointerNum = 2
			};
			StubCodeBuilder builder = new StubCodeBuilder();
			string code = builder.CreateReturnValueBuffer(function);

			Assert.AreEqual("DataType** TargetFunction_return_value", code);
		}

		[TestMethod]
		[TestCategory("CreateReturnValueBuffer")]
		public void CreateReturnValueBuffer_test_004()
		{
			Function function = new Function()
			{
				DataType = "void",
				Name = "TargetFunction",
				PointerNum = 1
			};
			StubCodeBuilder builder = new StubCodeBuilder();
			string code = builder.CreateReturnValueBuffer(function);

			Assert.AreEqual("void* TargetFunction_return_value", code);
		}

		[TestMethod]
		[TestCategory("CreateReturnValueBuffer")]
		public void CreateReturnValueBuffer_test_005()
		{
			Function function = new Function()
			{
				DataType = "VOID",
				Name = "TargetFunction",
				PointerNum = 1
			};
			StubCodeBuilder builder = new StubCodeBuilder();
			string code = builder.CreateReturnValueBuffer(function);

			Assert.AreEqual("VOID* TargetFunction_return_value", code);
		}
	}
}
