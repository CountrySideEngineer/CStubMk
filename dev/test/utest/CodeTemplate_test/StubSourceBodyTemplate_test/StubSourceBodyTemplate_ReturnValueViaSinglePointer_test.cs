using CodeTemplate.Template;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser.SDK.Model;
using System;
using System.Collections.Generic;

namespace StubSourceBodyTemplate_test
{
	//[TestClass]
	public partial class StubSourceBodyTemplate_test
	{
		[TestMethod]
		[TestCategory("StubSourceBodyTemplate")]
		[TestCategory("ReturnValueViaSinglePointer")]
		public void ReturnValueViaSinglePointer_test_001()
		{
			Function function = new Function()
			{
				Name = "TestFunction"
			};
			Variable argument = new Variable()
			{
				Name = "Argument",
				DataType = "ArgDataType",
				PointerNum = 1
			};
			var template = new StubSourceBodyTemplate()
			{
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaSinglePointer", argument);
			string expected =
				$"for (int index1 = 0; index1 < TestFunction_Argument_value_size[TestFunction_called_count]; index1++) {{" +
				Environment.NewLine +
				$"\t*(Argument + index1) = TestFunction_Argument_value[TestFunction_called_count][index1];" +
				Environment.NewLine +
				$"}}";
			;
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubSourceBodyTemplate")]
		[TestCategory("ReturnValueViaSinglePointer")]
		public void ReturnValueViaSinglePointer_test_002()
		{
			Variable argument = new Variable()
			{
				Name = "Argument",
				DataType = "ArgDataType",
				PointerNum = 1
			};
			Function function = new Function()
			{
				Name = "TestFunction",
				Arguments = new List<Parameter>
				{
					argument
				}
			};
			var template = new StubSourceBodyTemplate()
			{
				TargetFunc = function,
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaSinglePointer", function.Arguments);
			string expected =
				$"for (int index1 = 0; index1 < TestFunction_Argument_value_size[TestFunction_called_count]; index1++) {{" +
				Environment.NewLine +
				$"\t*(Argument + index1) = TestFunction_Argument_value[TestFunction_called_count][index1];" +
				Environment.NewLine +
				$"}}" +
				Environment.NewLine;

			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubSourceBodyTemplate")]
		[TestCategory("ReturnValueViaSinglePointer")]
		public void ReturnValueViaSinglePointer_test_003()
		{
			Variable argument1 = new Variable()
			{
				Name = "Argument1",
				DataType = "ArgDataType",
				PointerNum = 1
			};
			Variable argument2 = new Variable()
			{
				Name = "Argument2",
				DataType = "ArgDataType",
				PointerNum = 1
			};
			Function function = new Function()
			{
				Name = "TestFunction",
				Arguments = new List<Parameter>
				{
					argument1, argument2
				}
			};
			var template = new StubSourceBodyTemplate()
			{
				TargetFunc = function,
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaSinglePointer", function.Arguments);
			string expected =
				$"for (int index1 = 0; index1 < TestFunction_Argument1_value_size[TestFunction_called_count]; index1++) {{" +
				Environment.NewLine +
				$"\t*(Argument1 + index1) = TestFunction_Argument1_value[TestFunction_called_count][index1];" +
				Environment.NewLine +
				$"}}" +
				Environment.NewLine +
				$"for (int index1 = 0; index1 < TestFunction_Argument2_value_size[TestFunction_called_count]; index1++) {{" +
				Environment.NewLine +
				$"\t*(Argument2 + index1) = TestFunction_Argument2_value[TestFunction_called_count][index1];" +
				Environment.NewLine +
				$"}}" +
				Environment.NewLine;

			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubSourceBodyTemplate")]
		[TestCategory("ReturnValueViaSinglePointer")]
		public void ReturnValueViaSinglePointer_test_004()
		{
			Variable argument1 = new Variable()
			{
				Name = "Argument1",
				DataType = "ArgDataType",
				PointerNum = 1
			};
			Variable argument2 = new Variable()
			{
				Name = "Argument2",
				DataType = "ArgDataType",
				PointerNum = 0
			};
			Function function = new Function()
			{
				Name = "TestFunction",
				Arguments = new List<Parameter>
				{
					argument1, argument2
				}
			};
			var template = new StubSourceBodyTemplate()
			{
				TargetFunc = function,
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaSinglePointer", function.Arguments);
			string expected =
				$"for (int index1 = 0; index1 < TestFunction_Argument1_value_size[TestFunction_called_count]; index1++) {{" +
				Environment.NewLine +
				$"\t*(Argument1 + index1) = TestFunction_Argument1_value[TestFunction_called_count][index1];" +
				Environment.NewLine +
				$"}}" +
				Environment.NewLine;

			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubSourceBodyTemplate")]
		[TestCategory("ReturnValueViaSinglePointer")]
		public void ReturnValueViaSinglePointer_test_005()
		{
			Variable argument1 = new Variable()
			{
				Name = "Argument1",
				DataType = "ArgDataType",
				PointerNum = 0
			};
			Variable argument2 = new Variable()
			{
				Name = "Argument2",
				DataType = "ArgDataType",
				PointerNum = 1
			};
			Function function = new Function()
			{
				Name = "TestFunction",
				Arguments = new List<Parameter>
				{
					argument1, argument2
				}
			};
			var template = new StubSourceBodyTemplate()
			{
				TargetFunc = function,
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaSinglePointer", function.Arguments);
			string expected =
				$"for (int index1 = 0; index1 < TestFunction_Argument2_value_size[TestFunction_called_count]; index1++) {{" +
				Environment.NewLine +
				$"\t*(Argument2 + index1) = TestFunction_Argument2_value[TestFunction_called_count][index1];" +
				Environment.NewLine +
				$"}}" +
				Environment.NewLine;

			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubSourceBodyTemplate")]
		[TestCategory("ReturnValueViaSinglePointer")]
		public void ReturnValueViaSinglePointer_test_006()
		{
			Variable argument1 = new Variable()
			{
				Name = "Argument1",
				DataType = "ArgDataType",
				PointerNum = 1
			};
			Variable argument2 = new Variable()
			{
				Name = "Argument2",
				DataType = "ArgDataType",
				PointerNum = 2
			};
			Function function = new Function()
			{
				Name = "TestFunction",
				Arguments = new List<Parameter>
				{
					argument1, argument2
				}
			};
			var template = new StubSourceBodyTemplate()
			{
				TargetFunc = function,
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaSinglePointer", function.Arguments);
			string expected =
				$"for (int index1 = 0; index1 < TestFunction_Argument1_value_size[TestFunction_called_count]; index1++) {{" +
				Environment.NewLine +
				$"\t*(Argument1 + index1) = TestFunction_Argument1_value[TestFunction_called_count][index1];" +
				Environment.NewLine +
				$"}}" +
				Environment.NewLine;

			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubSourceBodyTemplate")]
		[TestCategory("ReturnValueViaSinglePointer")]
		[ExpectedException(typeof(ArgumentException))]
		public void ReturnValueViaSinglePointer_test_007()
		{
			Variable argument1 = new Variable()
			{
				Name = "Argument1",
				DataType = "ArgDataType",
				PointerNum = 0
			};
			Variable argument2 = new Variable()
			{
				Name = "Argument2",
				DataType = "ArgDataType",
				PointerNum = 0
			};
			Function function = new Function()
			{
				Name = "TestFunction",
				Arguments = new List<Parameter>
				{
					argument1, argument2
				}
			};
			var template = new StubSourceBodyTemplate()
			{
				TargetFunc = function,
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaSinglePointer", function.Arguments);
			Assert.Fail();
		}
	}
}
