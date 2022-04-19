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
		[TestCategory("ReturnValueViaDoublePointer")]
		public void ReturnValueViaDoublePointer_test_001()
		{
			Function function = new Function()
			{
				Name = "TestFunction"
			};
			Variable argument = new Variable()
			{
				Name = "Argument",
				DataType = "ArgDataType",
				PointerNum = 2
			};
			var template = new StubSourceBodyTemplate()
			{
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaDoublePointer", argument);
			string expected =
				$"*Argument = &TestFunction_Argument_value[TestFunction_called_count][0];";
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubSourceBodyTemplate")]
		[TestCategory("ReturnValueViaDoublePointer")]
		public void ReturnValueViaDoublePointer_test_002()
		{
			Variable argument1 = new Variable()
			{
				Name = "Argument1",
				DataType = "ArgDataType",
				PointerNum = 2
			};
			Function function = new Function()
			{
				Name = "TestFunction",
				Arguments = new List<Parameter>
				{
					argument1
				}
			};
			var template = new StubSourceBodyTemplate()
			{
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaDoublePointer", function.Arguments);
			string expected =
				$"*Argument1 = &TestFunction_Argument1_value[TestFunction_called_count][0];" +
				Environment.NewLine;
			Assert.AreEqual(expected, code);
		}

		[TestMethod]
		[TestCategory("StubSourceBodyTemplate")]
		[TestCategory("ReturnValueViaDoublePointer")]
		public void ReturnValueViaDoublePointer_test_003()
		{
			Variable argument1 = new Variable()
			{
				Name = "Argument1",
				DataType = "ArgDataType",
				PointerNum = 2
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
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ReturnValueViaDoublePointer", function.Arguments);
			string expected =
				$"*Argument1 = &TestFunction_Argument1_value[TestFunction_called_count][0];" +
				Environment.NewLine +
				$"*Argument2 = &TestFunction_Argument2_value[TestFunction_called_count][0];" +
				Environment.NewLine;
			Assert.AreEqual(expected, code);
		}
	}
}
