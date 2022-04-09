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
		[TestCategory("ReturnValueViaPointerBufferInit")]
		public void ReturnValueViaPointerBufferInit_test_001()
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
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaPointerBufferInit", argument);

			Assert.AreEqual("TestFunction_Argument_value[index1][index2] = 0;", code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ReturnValueViaPointerBufferInit")]
		public void ReturnValueViaPointerBufferInit_test_002()
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
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaPointerBufferInit", function.Arguments);
			string expected = $"\t\tTestFunction_Argument_value[index1][index2] = 0;{Environment.NewLine}";
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ReturnValueViaPointerBufferInit")]
		public void ReturnValueViaPointerBufferInit_test_003()
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
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaPointerBufferInit", function.Arguments);
			string expected = $"\t\tTestFunction_Argument1_value[index1][index2] = 0;{Environment.NewLine}" +
				$"\t\tTestFunction_Argument2_value[index1][index2] = 0;{Environment.NewLine}";
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ReturnValueViaPointerBufferInit")]
		public void ReturnValueViaPointerBufferInit_test_004()
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
				PointerNum = 2
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
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaPointerBufferInit", function.Arguments);
			string expected = $"\t\tTestFunction_Argument1_value[index1][index2] = 0;{Environment.NewLine}" +
				$"\t\tTestFunction_Argument2_value[index1][index2] = 0;{Environment.NewLine}";
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ReturnValueViaPointerBufferInit")]
		public void ReturnValueViaPointerBufferInit_test_005()
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
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaPointerBufferInit", function.Arguments);
			string expected = $"\t\tTestFunction_Argument1_value[index1][index2] = 0;{Environment.NewLine}";
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ReturnValueViaPointerBufferInit")]
		public void ReturnValueViaPointerBufferInit_test_006()
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
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaPointerBufferInit", function.Arguments);
			string expected = $"\t\tTestFunction_Argument2_value[index1][index2] = 0;{Environment.NewLine}";
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ReturnValueViaPointerBufferInit")]
		public void ReturnValueViaPointerBufferInit_test_007()
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
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaPointerBufferInit", function.Arguments);
			string expected = string.Empty;
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ReturnValueViaPointerBufferInit")]
		public void ReturnValueViaPointerBufferInit_test_008()
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
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaPointerBufferInit", function.Arguments);
			string expected = $"\t\tTestFunction_Argument1_value[index1][index2] = 0;{Environment.NewLine}" +
				$"\t\tTestFunction_Argument3_value[index1][index2] = 0;{Environment.NewLine}";
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ReturnValueViaPointerBufferInit")]
		public void ReturnValueViaPointerBufferInit_test_009()
		{
			Variable argument1 = new Variable()
			{
				DataType = "ArgDataType",
				Name = "Argument1",
				PointerNum = 1
			};
			Function function = new Function()
			{
				DataType = "DataType",
				Name = "TestFunction",
				Arguments = new List<Parameter>
				{
					argument1
				}
			};
			var template = new StubBufferInitTemplate()
			{
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaPointerBufferInit");
			string expected =
				"\tfor (int index2 = 0; index2 < TESTFUNCTION_STUB_BUFF_SIZE_2; index2++) {" + Environment.NewLine +
				"\t\tTestFunction_Argument1_value[index1][index2] = 0;" + Environment.NewLine +
				"\t}" + Environment.NewLine;
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ReturnValueViaPointerBufferInit")]
		public void ReturnValueViaPointerBufferInit_test_010()
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
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaPointerBufferInit");
			string expected =
				"\tfor (int index2 = 0; index2 < TESTFUNCTION_STUB_BUFF_SIZE_2; index2++) {" + Environment.NewLine +
				"\t\tTestFunction_Argument1_value[index1][index2] = 0;" + Environment.NewLine +
				"\t\tTestFunction_Argument2_value[index1][index2] = 0;" + Environment.NewLine +
				"\t}" + Environment.NewLine;
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ReturnValueViaPointerBufferInit")]
		public void ReturnValueViaPointerBufferInit_test_011()
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
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaPointerBufferInit");
			string expected =
				"\tfor (int index2 = 0; index2 < TESTFUNCTION_STUB_BUFF_SIZE_2; index2++) {" + Environment.NewLine +
				"\t\tTestFunction_Argument1_value[index1][index2] = 0;" + Environment.NewLine +
				"\t\tTestFunction_Argument2_value[index1][index2] = 0;" + Environment.NewLine +
				"\t\tTestFunction_Argument3_value[index1][index2] = 0;" + Environment.NewLine +
				"\t}" + Environment.NewLine;
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ReturnValueViaPointerBufferInit")]
		public void ReturnValueViaPointerBufferInit_test_012()
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
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaPointerBufferInit");
			string expected =
				"\tfor (int index2 = 0; index2 < TESTFUNCTION_STUB_BUFF_SIZE_2; index2++) {" + Environment.NewLine +
				"\t\tTestFunction_Argument2_value[index1][index2] = 0;" + Environment.NewLine +
				"\t\tTestFunction_Argument3_value[index1][index2] = 0;" + Environment.NewLine +
				"\t}" + Environment.NewLine;
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ReturnValueViaPointerBufferInit")]
		public void ReturnValueViaPointerBufferInit_test_013()
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
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaPointerBufferInit");
			string expected =
				"\tfor (int index2 = 0; index2 < TESTFUNCTION_STUB_BUFF_SIZE_2; index2++) {" + Environment.NewLine +
				"\t\tTestFunction_Argument1_value[index1][index2] = 0;" + Environment.NewLine +
				"\t\tTestFunction_Argument3_value[index1][index2] = 0;" + Environment.NewLine +
				"\t}" + Environment.NewLine;
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ReturnValueViaPointerBufferInit")]
		public void ReturnValueViaPointerBufferInit_test_014()
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
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaPointerBufferInit");
			string expected =
				"\tfor (int index2 = 0; index2 < TESTFUNCTION_STUB_BUFF_SIZE_2; index2++) {" + Environment.NewLine +
				"\t\tTestFunction_Argument1_value[index1][index2] = 0;" + Environment.NewLine +
				"\t\tTestFunction_Argument2_value[index1][index2] = 0;" + Environment.NewLine +
				"\t}" + Environment.NewLine;
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ReturnValueViaPointerBufferInit")]
		public void ReturnValueViaPointerBufferInit_test_015()
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
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaPointerBufferInit");
			string expected = string.Empty;
			Assert.AreEqual(expected, code);
		}
	}
}
