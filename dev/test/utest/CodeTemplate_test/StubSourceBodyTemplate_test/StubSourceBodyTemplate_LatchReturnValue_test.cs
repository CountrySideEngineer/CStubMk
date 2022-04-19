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
		[TestCategory("LatchReturnValue")]
		public void LatchReturnValue_test_001()
		{
			Function function = new Function()
			{
				Name = "TestFunction",
				DataType = "DataType"
			};
			var template = new StubSourceBodyTemplate()
			{
				TargetFunc = function
			};
			string code = template.LatchReturnValue();
			string expected = $"DataType return_latch = TestFunction_return_value[TestFunction_called_count];";
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubSourceBodyTemplate")]
		[TestCategory("LatchReturnValue")]
		public void LatchReturnValue_test_002()
		{
			Function function = new Function()
			{
				Name = "TestFunction",
				DataType = "DataType",
				PointerNum = 1
			};
			var template = new StubSourceBodyTemplate()
			{
				TargetFunc = function
			};
			string code = template.LatchReturnValue();
			string expected = $"DataType* return_latch = TestFunction_return_value[TestFunction_called_count];";
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubSourceBodyTemplate")]
		[TestCategory("LatchReturnValue")]
		public void LatchReturnValue_test_003()
		{
			Function function = new Function()
			{
				Name = "TestFunction",
				DataType = "DataType",
				PointerNum = 2
			};
			var template = new StubSourceBodyTemplate()
			{
				TargetFunc = function
			};
			string code = template.LatchReturnValue();
			string expected = $"DataType** return_latch = TestFunction_return_value[TestFunction_called_count];";
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubSourceBodyTemplate")]
		[TestCategory("LatchReturnValue")]
		public void LatchReturnValue_test_004()
		{
			Function function = new Function()
			{
				Name = "TestFunction",
				DataType = "void"
			};
			var template = new StubSourceBodyTemplate()
			{
				TargetFunc = function
			};
			string code = template.LatchReturnValue();
			string expected = string.Empty;
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubSourceBodyTemplate")]
		[TestCategory("LatchReturnValue")]
		public void LatchReturnValue_test_005()
		{
			Function function = new Function()
			{
				Name = "TestFunction",
				DataType = "void",
				PointerNum = 1
			};
			var template = new StubSourceBodyTemplate()
			{
				TargetFunc = function
			};
			string code = template.LatchReturnValue();
			string expected = $"void* return_latch = TestFunction_return_value[TestFunction_called_count];";
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubSourceBodyTemplate")]
		[TestCategory("LatchReturnValue")]
		public void LatchReturnValue_test_006()
		{
			Function function = new Function()
			{
				Name = "TestFunction",
				DataType = "void",
				PointerNum = 2
			};
			var template = new StubSourceBodyTemplate()
			{
				TargetFunc = function
			};
			string code = template.LatchReturnValue();
			string expected = $"void** return_latch = TestFunction_return_value[TestFunction_called_count];";
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubSourceBodyTemplate")]
		[TestCategory("LatchReturnValue")]
		public void LatchReturnValue_test_008()
		{
			Function function = new Function()
			{
				Name = "TestFunction",
				DataType = "VOID",
				PointerNum = 1
			};
			var template = new StubSourceBodyTemplate()
			{
				TargetFunc = function
			};
			string code = template.LatchReturnValue();
			string expected = $"VOID* return_latch = TestFunction_return_value[TestFunction_called_count];";
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubSourceBodyTemplate")]
		[TestCategory("LatchReturnValue")]
		public void LatchReturnValue_test_009()
		{
			Function function = new Function()
			{
				Name = "TestFunction",
				DataType = "VOID",
				PointerNum = 1
			};
			var template = new StubSourceBodyTemplate()
			{
				TargetFunc = function
			};
			string code = template.LatchReturnValue();
			string expected = $"VOID* return_latch = TestFunction_return_value[TestFunction_called_count];";
			Assert.AreEqual(expected, code);
		}
	}
}
