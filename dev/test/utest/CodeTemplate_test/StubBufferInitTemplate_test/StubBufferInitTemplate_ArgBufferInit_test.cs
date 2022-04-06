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
		[TestCategory("ArgBufferInit")]
		public void ArgBufferInit_test_001()
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
			string code = (string)privateTemplate.Invoke("ArgBufferInit", argument);

			Assert.AreEqual("TestFunction_Argument[index1] = 0;", code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ArgBufferInit")]
		public void ArgBufferInit_test_002()
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
			string code = (string)privateTemplate.Invoke("ArgBufferInit", function.Arguments);
			string expect =
				"\tTestFunction_Argument1[index1] = 0;" + Environment.NewLine +
				"\tTestFunction_Argument2[index1] = 0;" + Environment.NewLine;

			Assert.AreEqual(expect, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ArgBufferInit")]
		public void ArgBufferInit_test_003()
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
			string code = (string)privateTemplate.Invoke("ArgBufferInit", function.Arguments);
			string expect =
				"\tTestFunction_Argument1[index1] = 0;" + Environment.NewLine +
				"\tTestFunction_Argument2[index1] = 0;" + Environment.NewLine +
				"\tTestFunction_Argument3[index1] = 0;" + Environment.NewLine;

			Assert.AreEqual(expect, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ArgBufferInit")]
		public void ArgBufferInit_test_004()
		{
			Variable argument1 = new Variable()
			{
				DataType = "ArgDataType",
				Name = "Argument1",
				PointerNum = 0
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
				Function = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = template.ArgBufferInit();
			string expect =
				"for (int index1 = 0; index1 < TESTFUNCTION_STUB_BUFF_SIZE_1; index1++) {" + Environment.NewLine +
				"\tTestFunction_Argument1[index1] = 0;" + Environment.NewLine +
				"}" + Environment.NewLine;
			Assert.AreEqual(expect, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ArgBufferInit")]
		public void ArgBufferInit_test_005()
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
				Function = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = template.ArgBufferInit();
			string expect =
				"for (int index1 = 0; index1 < TESTFUNCTION_STUB_BUFF_SIZE_1; index1++) {" + Environment.NewLine +
				"\tTestFunction_Argument1[index1] = 0;" + Environment.NewLine +
				"\tfor (int index2 = 0; index2 < TESTFUNCTION_STUB_BUFF_SIZE_2; index2++) {" + Environment.NewLine +
				"\t\tTestFunction_Argument1_value[index1][index2] = 0;" + Environment.NewLine +
				"\t}" + Environment.NewLine +
				"\tTestFunction_Argument1_value_size[index1] = 1;" + Environment.NewLine +
				"}" + Environment.NewLine;
			Assert.AreEqual(expect, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ArgBufferInit")]
		public void ArgBufferInit_test_006()
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
				Function = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = template.ArgBufferInit();
			string expect =
				"for (int index1 = 0; index1 < TESTFUNCTION_STUB_BUFF_SIZE_1; index1++) {" + Environment.NewLine +
				"\tTestFunction_Argument1[index1] = 0;" + Environment.NewLine +
				"\tTestFunction_Argument2[index1] = 0;" + Environment.NewLine +
				"\tfor (int index2 = 0; index2 < TESTFUNCTION_STUB_BUFF_SIZE_2; index2++) {" + Environment.NewLine +
				"\t\tTestFunction_Argument1_value[index1][index2] = 0;" + Environment.NewLine +
				"\t}" + Environment.NewLine +
				"\tTestFunction_Argument1_value_size[index1] = 1;" + Environment.NewLine +
				"}" + Environment.NewLine;
			Assert.AreEqual(expect, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ArgBufferInit")]
		public void ArgBufferInit_test_007()
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
			string code = template.ArgBufferInit();
			string expect =
				"for (int index1 = 0; index1 < TESTFUNCTION_STUB_BUFF_SIZE_1; index1++) {" + Environment.NewLine +
				"\tTestFunction_Argument1[index1] = 0;" + Environment.NewLine +
				"\tTestFunction_Argument2[index1] = 0;" + Environment.NewLine +
				"\tfor (int index2 = 0; index2 < TESTFUNCTION_STUB_BUFF_SIZE_2; index2++) {" + Environment.NewLine +
				"\t\tTestFunction_Argument1_value[index1][index2] = 0;" + Environment.NewLine +
				"\t\tTestFunction_Argument2_value[index1][index2] = 0;" + Environment.NewLine +
				"\t}" + Environment.NewLine +
				"\tTestFunction_Argument1_value_size[index1] = 1;" + Environment.NewLine +
				"\tTestFunction_Argument2_value_size[index1] = 1;" + Environment.NewLine +
				"}" + Environment.NewLine;
			Assert.AreEqual(expect, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ArgBufferInit")]
		public void ArgBufferInit_test_008()
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
			string code = template.ArgBufferInit();
			string expect =
				"for (int index1 = 0; index1 < TESTFUNCTION_STUB_BUFF_SIZE_1; index1++) {" + Environment.NewLine +
				"\tTestFunction_Argument1[index1] = 0;" + Environment.NewLine +
				"\tTestFunction_Argument2[index1] = 0;" + Environment.NewLine +
				"\tTestFunction_Argument3[index1] = 0;" + Environment.NewLine +
				"\tfor (int index2 = 0; index2 < TESTFUNCTION_STUB_BUFF_SIZE_2; index2++) {" + Environment.NewLine +
				"\t\tTestFunction_Argument1_value[index1][index2] = 0;" + Environment.NewLine +
				"\t\tTestFunction_Argument2_value[index1][index2] = 0;" + Environment.NewLine +
				"\t}" + Environment.NewLine +
				"\tTestFunction_Argument1_value_size[index1] = 1;" + Environment.NewLine +
				"\tTestFunction_Argument2_value_size[index1] = 1;" + Environment.NewLine +
				"}" + Environment.NewLine;
			Assert.AreEqual(expect, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ArgBufferInit")]
		public void ArgBufferInit_test_009()
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
			string code = template.ArgBufferInit();
			string expect =
				"for (int index1 = 0; index1 < TESTFUNCTION_STUB_BUFF_SIZE_1; index1++) {" + Environment.NewLine +
				"\tTestFunction_Argument1[index1] = 0;" + Environment.NewLine +
				"\tTestFunction_Argument2[index1] = 0;" + Environment.NewLine +
				"\tTestFunction_Argument3[index1] = 0;" + Environment.NewLine +
				"\tfor (int index2 = 0; index2 < TESTFUNCTION_STUB_BUFF_SIZE_2; index2++) {" + Environment.NewLine +
				"\t\tTestFunction_Argument1_value[index1][index2] = 0;" + Environment.NewLine +
				"\t\tTestFunction_Argument2_value[index1][index2] = 0;" + Environment.NewLine +
				"\t\tTestFunction_Argument3_value[index1][index2] = 0;" + Environment.NewLine +
				"\t}" + Environment.NewLine +
				"\tTestFunction_Argument1_value_size[index1] = 1;" + Environment.NewLine +
				"\tTestFunction_Argument2_value_size[index1] = 1;" + Environment.NewLine +
				"\tTestFunction_Argument3_value_size[index1] = 1;" + Environment.NewLine +
				"}" + Environment.NewLine;
			Assert.AreEqual(expect, code);
		}

		[TestMethod]
		[TestCategory("StubBufferInitTemplate")]
		[TestCategory("ArgBufferInit")]
		public void ArgBufferInit_test_010()
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
				}
			};
			var template = new StubBufferInitTemplate()
			{
				Function = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = template.ArgBufferInit();
			string expect = "//TestFunction has no argument.";
			Assert.AreEqual(expect, code);
		}
	}
}
