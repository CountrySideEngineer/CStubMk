using CodeTemplate.Template;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser.SDK.Model;
using System;
using System.Collections.Generic;

namespace StubBufferDeclarationTemplate_test
{
	//[TestClass]
	public partial class StubBufferDeclarationTemplate_test
	{
		[TestMethod]
		[TestCategory("StubBufferDeclarationTemplate")]
		[TestCategory("ReturnValueViaArgumentBufferDeclare")]
		public void ReturnValueViaArgumentBufferDeclare_test_001()
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
				Name = "TestFunction",
				Arguments = new List<Parameter>
				{
					argument
				}
			};
			var template = new StubBufferDeclarationTemplate()
			{
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaArgumentBufferDeclare");
			string expect = $"ArgDataType TestFunction_Argument_value[TESTFUNCTION_STUB_BUFF_SIZE_1][TESTFUNCTION_STUB_BUFF_SIZE_2];" +
				$"{Environment.NewLine}";
			Assert.AreEqual(expect, code);
		}

		[TestMethod]
		[TestCategory("StubBufferDeclarationTemplate")]
		[TestCategory("ReturnValueViaArgumentBufferDeclare")]
		public void ReturnValueViaArgumentBufferDeclare_test_002()
		{
			Variable argument1 = new Variable()
			{
				DataType = "ArgDataType1",
				Name = "Argument1",
				PointerNum = 1
			};
			Variable argument2 = new Variable()
			{
				DataType = "ArgDataType2",
				Name = "Argument2",
				PointerNum = 1
			};
			Function function = new Function()
			{
				DataType = "DataType",
				Name = "TestFunction",
				Arguments = new List<Parameter>
				{
					argument1, 
					argument2
				}
			};
			var template = new StubBufferDeclarationTemplate()
			{
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaArgumentBufferDeclare");
			string expect = $"ArgDataType1 TestFunction_Argument1_value[TESTFUNCTION_STUB_BUFF_SIZE_1][TESTFUNCTION_STUB_BUFF_SIZE_2];" +
				$"{Environment.NewLine}" +
				$"ArgDataType2 TestFunction_Argument2_value[TESTFUNCTION_STUB_BUFF_SIZE_1][TESTFUNCTION_STUB_BUFF_SIZE_2];" +
				$"{Environment.NewLine}";
			Assert.AreEqual(expect, code);
		}

		[TestMethod]
		[TestCategory("StubBufferDeclarationTemplate")]
		[TestCategory("ReturnValueViaArgumentBufferDeclare")]
		public void ReturnValueViaArgumentBufferDeclare_test_003()
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
				Name = "TestFunction",
				Arguments = new List<Parameter>
				{
					argument
				}
			};
			var template = new StubBufferDeclarationTemplate()
			{
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaArgumentBufferDeclare");
			string expect = $"ArgDataType TestFunction_Argument_value[TESTFUNCTION_STUB_BUFF_SIZE_1][TESTFUNCTION_STUB_BUFF_SIZE_2];" +
				$"{Environment.NewLine}";
			Assert.AreEqual(expect, code);
		}

		[TestMethod]
		[TestCategory("StubBufferDeclarationTemplate")]
		[TestCategory("ReturnValueViaArgumentBufferDeclare")]
		public void ReturnValueViaArgumentBufferDeclare_test_004()
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
				Name = "TestFunction",
				Arguments = new List<Parameter>
				{
					argument
				}
			};
			var template = new StubBufferDeclarationTemplate()
			{
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaArgumentBufferDeclare");
			string expect = string.Empty;
			Assert.AreEqual(expect, code);
		}

		[TestMethod]
		[TestCategory("StubBufferDeclarationTemplate")]
		[TestCategory("ReturnValueViaArgumentBufferDeclare")]
		public void ReturnValueViaArgumentBufferDeclare_test_005()
		{
			Variable argument1 = new Variable()
			{
				DataType = "ArgDataType1",
				Name = "Argument1",
				PointerNum = 0
			};
			Variable argument2 = new Variable()
			{
				DataType = "ArgDataType2",
				Name = "Argument2",
				PointerNum = 1
			};
			Function function = new Function()
			{
				DataType = "DataType",
				Name = "TestFunction",
				Arguments = new List<Parameter>
				{
					argument1,
					argument2
				}
			};
			var template = new StubBufferDeclarationTemplate()
			{
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaArgumentBufferDeclare");
			string expect = $"ArgDataType2 TestFunction_Argument2_value[TESTFUNCTION_STUB_BUFF_SIZE_1][TESTFUNCTION_STUB_BUFF_SIZE_2];" +
				$"{Environment.NewLine}";
			Assert.AreEqual(expect, code);
		}

		[TestMethod]
		[TestCategory("StubBufferDeclarationTemplate")]
		[TestCategory("ReturnValueViaArgumentBufferDeclare")]
		public void ReturnValueViaArgumentBufferDeclare_test_006()
		{
			Variable argument1 = new Variable()
			{
				DataType = "ArgDataType1",
				Name = "Argument1",
				PointerNum = 0
			};
			Variable argument2 = new Variable()
			{
				DataType = "ArgDataType2",
				Name = "Argument2",
				PointerNum = 1
			};
			Variable argument3 = new Variable()
			{
				DataType = "ArgDataType3",
				Name = "Argument3",
				PointerNum = 0
			};
			Function function = new Function()
			{
				DataType = "DataType",
				Name = "TestFunction",
				Arguments = new List<Parameter>
				{
					argument1, argument2, argument3
				}
			};
			var template = new StubBufferDeclarationTemplate()
			{
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaArgumentBufferDeclare");
			string expect = $"ArgDataType2 TestFunction_Argument2_value[TESTFUNCTION_STUB_BUFF_SIZE_1][TESTFUNCTION_STUB_BUFF_SIZE_2];" +
				$"{Environment.NewLine}";
			Assert.AreEqual(expect, code);
		}

		[TestMethod]
		[TestCategory("StubBufferDeclarationTemplate")]
		[TestCategory("ReturnValueViaArgumentBufferDeclare")]
		public void ReturnValueViaArgumentBufferDeclare_test_007()
		{
			Variable argument1 = new Variable()
			{
				DataType = "ArgDataType1",
				Name = "Argument1",
				PointerNum = 0
			};
			Variable argument2 = new Variable()
			{
				DataType = "ArgDataType2",
				Name = "Argument2",
				PointerNum = 1
			};
			Variable argument3 = new Variable()
			{
				DataType = "ArgDataType3",
				Name = "Argument3",
				PointerNum = 0
			};
			Function function = new Function()
			{
				DataType = "DataType",
				Name = "TestFunction",
				Arguments = new List<Parameter>
				{
				}
			};
			var template = new StubBufferDeclarationTemplate()
			{
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaArgumentBufferDeclare");
			string expect = string.Empty;
			Assert.AreEqual(expect, code);
		}
	}
}
