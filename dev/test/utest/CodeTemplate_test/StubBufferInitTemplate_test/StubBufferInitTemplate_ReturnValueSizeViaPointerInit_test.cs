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
		[TestCategory("ReturnValueSizeViaPointerBufferInit")]
		public void ReturnValueSizeViaPointerBufferInit_test_001()
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
			var template = new StubBufferInitTemplate()
			{
				Function = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueSizeViaPointerBufferInit", argument);

			Assert.AreEqual("TestFunction_Argument_value_size[index1] = 1;", code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ReturnValueSizeViaPointerBufferInit")]
		public void ReturnValueSizeViaPointerBufferInit_test_002()
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
			var template = new StubBufferInitTemplate()
			{
				Function = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueSizeViaPointerBufferInit", function.Arguments);
			string expected = "\tTestFunction_Argument_value_size[index1] = 1;" + Environment.NewLine;

			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ReturnValueSizeViaPointerBufferInit")]
		public void ReturnValueSizeViaPointerBufferInit_test_003()
		{
			Variable argument1 = new Variable()
			{
				DataType = "ArgDataType",
				Name = "Argument1",
				PointerNum = 1
			};
			Variable argument2 = new Variable()
			{
				DataType = "ArgDataType",
				Name = "Argument2",
				PointerNum = 1
			};
			Function function = new Function()
			{
				DataType = "DataType",
				Name = "TestFunction",
				Arguments = new List<Parameter>
				{
					argument1, argument2
				}
			};
			var template = new StubBufferInitTemplate()
			{
				Function = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueSizeViaPointerBufferInit", function.Arguments);
			string expected =
				"\tTestFunction_Argument1_value_size[index1] = 1;" + Environment.NewLine +
				"\tTestFunction_Argument2_value_size[index1] = 1;" + Environment.NewLine;
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ReturnValueSizeViaPointerBufferInit")]
		public void ReturnValueSizeViaPointerBufferInit_test_004()
		{
			Variable argument1 = new Variable()
			{
				DataType = "ArgDataType",
				Name = "Argument1",
				PointerNum = 1
			};
			Variable argument2 = new Variable()
			{
				DataType = "ArgDataType",
				Name = "Argument2",
				PointerNum = 1
			};
			Variable argument3 = new Variable()
			{
				DataType = "ArgDataType",
				Name = "Argument3",
				PointerNum = 1
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
			var template = new StubBufferInitTemplate()
			{
				Function = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueSizeViaPointerBufferInit", function.Arguments);
			string expected =
				"\tTestFunction_Argument1_value_size[index1] = 1;" + Environment.NewLine +
				"\tTestFunction_Argument2_value_size[index1] = 1;" + Environment.NewLine +
				"\tTestFunction_Argument3_value_size[index1] = 1;" + Environment.NewLine;
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ReturnValueSizeViaPointerBufferInit")]
		public void ReturnValueSizeViaPointerBufferInit_test_005()
		{
			Variable argument1 = new Variable()
			{
				DataType = "ArgDataType",
				Name = "Argument1",
				PointerNum = 0
			};
			Variable argument2 = new Variable()
			{
				DataType = "ArgDataType",
				Name = "Argument2",
				PointerNum = 1
			};
			Variable argument3 = new Variable()
			{
				DataType = "ArgDataType",
				Name = "Argument3",
				PointerNum = 1
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
			var template = new StubBufferInitTemplate()
			{
				Function = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueSizeViaPointerBufferInit", function.Arguments);
			string expected =
				"\tTestFunction_Argument2_value_size[index1] = 1;" + Environment.NewLine +
				"\tTestFunction_Argument3_value_size[index1] = 1;" + Environment.NewLine;
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ReturnValueSizeViaPointerBufferInit")]
		public void ReturnValueSizeViaPointerBufferInit_test_006()
		{
			Variable argument1 = new Variable()
			{
				DataType = "ArgDataType",
				Name = "Argument1",
				PointerNum = 1
			};
			Variable argument2 = new Variable()
			{
				DataType = "ArgDataType",
				Name = "Argument2",
				PointerNum = 0
			};
			Variable argument3 = new Variable()
			{
				DataType = "ArgDataType",
				Name = "Argument3",
				PointerNum = 1
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
			var template = new StubBufferInitTemplate()
			{
				Function = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueSizeViaPointerBufferInit", function.Arguments);
			string expected =
				"\tTestFunction_Argument1_value_size[index1] = 1;" + Environment.NewLine +
				"\tTestFunction_Argument3_value_size[index1] = 1;" + Environment.NewLine;
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ReturnValueSizeViaPointerBufferInit")]
		public void ReturnValueSizeViaPointerBufferInit_test_007()
		{
			Variable argument1 = new Variable()
			{
				DataType = "ArgDataType",
				Name = "Argument1",
				PointerNum = 1
			};
			Variable argument2 = new Variable()
			{
				DataType = "ArgDataType",
				Name = "Argument2",
				PointerNum = 1
			};
			Variable argument3 = new Variable()
			{
				DataType = "ArgDataType",
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
			var template = new StubBufferInitTemplate()
			{
				Function = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueSizeViaPointerBufferInit", function.Arguments);
			string expected =
				"\tTestFunction_Argument1_value_size[index1] = 1;" + Environment.NewLine +
				"\tTestFunction_Argument2_value_size[index1] = 1;" + Environment.NewLine;
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ReturnValueSizeViaPointerBufferInit")]
		public void ReturnValueSizeViaPointerBufferInit_test_008()
		{
			Variable argument1 = new Variable()
			{
				DataType = "ArgDataType",
				Name = "Argument1",
				PointerNum = 0
			};
			Variable argument2 = new Variable()
			{
				DataType = "ArgDataType",
				Name = "Argument2",
				PointerNum = 0
			};
			Variable argument3 = new Variable()
			{
				DataType = "ArgDataType",
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
			var template = new StubBufferInitTemplate()
			{
				Function = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueSizeViaPointerBufferInit", function.Arguments);
			string expected = string.Empty;
			Assert.AreEqual(expected, code);
		}
	}
}
