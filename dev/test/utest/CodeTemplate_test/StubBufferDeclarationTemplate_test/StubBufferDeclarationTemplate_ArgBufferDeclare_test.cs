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
		[TestCategory("ArgBufferDeclare")]
		public void ArgBufferDeclare_test_001()
		{
			Variable argument = new Variable()
			{
				DataType = "ArgDataType",
				Name = "argument",
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
			string code = (string)privateTemplate.Invoke("ArgBufferDeclare", argument);
			Assert.AreEqual("ArgDataType TestFunction_argument[TESTFUNCTION_STUB_BUFF_SIZE_1];", code);
		}

		[TestMethod]
		[TestCategory("StubBufferDeclarationTemplate")]
		[TestCategory("ArgBufferDeclare")]
		public void ArgBufferDeclare_test_101()
		{
			Variable argument1 = new Variable()
			{
				DataType = "ArgDataType1",
				Name = "argument1",
				PointerNum = 0
			};
			Variable argument2 = new Variable()
			{
				DataType = "ArgDataType2",
				Name = "argument2",
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
			var template = new StubBufferDeclarationTemplate()
			{
				TargetFunc = function
			};
			var privateTemplate = new PrivateObject(template);
			string code = (string)privateTemplate.Invoke("ArgBufferDeclare", function.Arguments);
			string expect = $"ArgDataType1 TestFunction_argument1[TESTFUNCTION_STUB_BUFF_SIZE_1];";
			expect += Environment.NewLine;
			expect += $"ArgDataType2 TestFunction_argument2[TESTFUNCTION_STUB_BUFF_SIZE_1];";
			expect += Environment.NewLine;
			Assert.AreEqual(expect, code);
		}

		[TestMethod]
		[TestCategory("StubBufferDeclarationTemplate")]
		[TestCategory("ArgBufferDeclare")]
		public void ArgBufferDeclare_test_201()
		{
			Variable argument = new Variable()
			{
				DataType = "ArgDataType",
				Name ="argument",
				PointerNum = 0
			};
			Function function = new Function()
			{
				DataType = "DataType",
				Name = "TargetFunction",
				Arguments = new List<Parameter>
				{
					argument
				}
			};
			var template = new StubBufferDeclarationTemplate()
			{
				TargetFunc = function
			};
			string code = template.ArgBufferDeclare();
			Assert.AreEqual($"ArgDataType TargetFunction_argument[TARGETFUNCTION_STUB_BUFF_SIZE_1];{Environment.NewLine}", code);
		}
	}
}
