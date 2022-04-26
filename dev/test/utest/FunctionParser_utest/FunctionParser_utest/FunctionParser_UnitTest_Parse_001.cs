using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser;
using Parser.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionParser_utest
{
	//[TestClass]
	public partial class FunctionParser_UnitTest
	{
		[TestMethod]
		[TestCategory("Parse")]
		[TestCategory("FunctionParser")]
		public void Parse_Test_001_001()
		{
			string code = "void SampleFunction(void)";
			var parser = new Parser.FunctionParser();
			Parameter parameter = parser.Parse(code);

			Assert.AreEqual("void", parameter.DataType);
			Assert.AreEqual("SampleFunction", parameter.Name);
			Assert.AreEqual(0, (parameter as Function).PointerNum);
			Assert.AreEqual(0, (parameter as Function).Arguments.Count());
		}

		[TestMethod]
		[TestCategory("Parse")]
		[TestCategory("FunctionParser")]
		public void Parse_Test_001_002()
		{
			string code = "int SampleFunction(int argument)";
			var parser = new Parser.FunctionParser();
			Parameter parameter = parser.Parse(code);

			Assert.AreEqual("int", parameter.DataType);
			Assert.AreEqual("SampleFunction", parameter.Name);
			Assert.AreEqual(0, (parameter as Function).PointerNum);
			Assert.AreEqual(1, (parameter as Function).Arguments.Count());
			Assert.AreEqual("int", (parameter as Function).Arguments.ElementAt(0).DataType);
			Assert.AreEqual("argument", (parameter as Function).Arguments.ElementAt(0).Name);
			Assert.AreEqual(0, (((parameter as Function).Arguments.ElementAt(0)) as Variable).PointerNum);
		}

		[TestMethod]
		[TestCategory("Parse")]
		[TestCategory("FunctionParser")]
		public void Parse_Test_001_003()
		{
			string code = "int SampleFunction(int* argument)";
			var parser = new Parser.FunctionParser();
			Parameter parameter = parser.Parse(code);

			Assert.AreEqual("int", parameter.DataType);
			Assert.AreEqual("SampleFunction", parameter.Name);
			Assert.AreEqual(0, (parameter as Function).PointerNum);
			Assert.AreEqual(1, (parameter as Function).Arguments.Count());
			Assert.AreEqual("int", (parameter as Function).Arguments.ElementAt(0).DataType);
			Assert.AreEqual("argument", (parameter as Function).Arguments.ElementAt(0).Name);
			Assert.AreEqual(1, (((parameter as Function).Arguments.ElementAt(0)) as Variable).PointerNum);
		}

		[TestMethod]
		[TestCategory("Parse")]
		[TestCategory("FunctionParser")]
		public void Parse_Test_001_004()
		{
			string code = "int* SampleFunction(int** argument)";
			var parser = new Parser.FunctionParser();
			Parameter parameter = parser.Parse(code);

			Assert.AreEqual("int", parameter.DataType);
			Assert.AreEqual("SampleFunction", parameter.Name);
			Assert.AreEqual(1, (parameter as Function).PointerNum);
			Assert.AreEqual(1, (parameter as Function).Arguments.Count());
			Assert.AreEqual("int", (parameter as Function).Arguments.ElementAt(0).DataType);
			Assert.AreEqual("argument", (parameter as Function).Arguments.ElementAt(0).Name);
			Assert.AreEqual(2, (((parameter as Function).Arguments.ElementAt(0)) as Variable).PointerNum);
		}

		[TestMethod]
		[TestCategory("Parse")]
		[TestCategory("FunctionParser")]
		public void Parse_Test_001_005()
		{
			string code = "int* SampleFunction(int** argument_1, short argument_2)";
			var parser = new Parser.FunctionParser();
			Parameter parameter = parser.Parse(code);

			Assert.AreEqual("int", parameter.DataType);
			Assert.AreEqual("SampleFunction", parameter.Name);
			Assert.AreEqual(1, (parameter as Function).PointerNum);
			Assert.AreEqual(2, (parameter as Function).Arguments.Count());
			Assert.AreEqual("int", (parameter as Function).Arguments.ElementAt(0).DataType);
			Assert.AreEqual("argument_1", (parameter as Function).Arguments.ElementAt(0).Name);
			Assert.AreEqual(2, (((parameter as Function).Arguments.ElementAt(0)) as Variable).PointerNum);
			Assert.AreEqual("short", (parameter as Function).Arguments.ElementAt(1).DataType);
			Assert.AreEqual("argument_2", (parameter as Function).Arguments.ElementAt(1).Name);
			Assert.AreEqual(0, (((parameter as Function).Arguments.ElementAt(1)) as Variable).PointerNum);
		}

		[TestMethod]
		[TestCategory("Parse")]
		[TestCategory("FunctionParser")]
		public void Parse_Test_001_006()
		{
			string code = "int** SampleFunction(int** argument_1, short argument_2, long *argument_3)";
			var parser = new Parser.FunctionParser();
			Parameter parameter = parser.Parse(code);

			Assert.AreEqual("int", parameter.DataType);
			Assert.AreEqual("SampleFunction", parameter.Name);
			Assert.AreEqual(2, (parameter as Function).PointerNum);
			Assert.AreEqual(3, (parameter as Function).Arguments.Count());
			Assert.AreEqual("int", (parameter as Function).Arguments.ElementAt(0).DataType);
			Assert.AreEqual("argument_1", (parameter as Function).Arguments.ElementAt(0).Name);
			Assert.AreEqual(2, (((parameter as Function).Arguments.ElementAt(0)) as Variable).PointerNum);
			Assert.AreEqual("short", (parameter as Function).Arguments.ElementAt(1).DataType);
			Assert.AreEqual("argument_2", (parameter as Function).Arguments.ElementAt(1).Name);
			Assert.AreEqual(0, (((parameter as Function).Arguments.ElementAt(1)) as Variable).PointerNum);
			Assert.AreEqual("long", (parameter as Function).Arguments.ElementAt(2).DataType);
			Assert.AreEqual("argument_3", (parameter as Function).Arguments.ElementAt(2).Name);
			Assert.AreEqual(1, (((parameter as Function).Arguments.ElementAt(2)) as Variable).PointerNum);
		}

		[TestMethod]
		[TestCategory("Parse")]
		[TestCategory("FunctionParser")]
		[ExpectedException(typeof(ArgumentException))]
		public void Parse_Test_001_007()
		{
			string code = "int SampleFunction(int argument, void data)";
			var parser = new Parser.FunctionParser();
			Parameter parameter = parser.Parse(code);

			Assert.Fail();
		}

		[TestMethod]
		[TestCategory("Parse")]
		[TestCategory("FunctionParser")]
		public void Parse_Test_001_008()
		{
			string code = "int SampleFunction(int argument, void* data)";
			var parser = new Parser.FunctionParser();
			Parameter parameter = parser.Parse(code);

			Assert.AreEqual("int", parameter.DataType);
			Assert.AreEqual("SampleFunction", parameter.Name);
			Assert.AreEqual(0, (parameter as Function).PointerNum);
			Assert.AreEqual(2, (parameter as Function).Arguments.Count());
			Assert.AreEqual("int", (parameter as Function).Arguments.ElementAt(0).DataType);
			Assert.AreEqual("argument", (parameter as Function).Arguments.ElementAt(0).Name);
			Assert.AreEqual(0, (((parameter as Function).Arguments.ElementAt(0)) as Variable).PointerNum);
			Assert.AreEqual("void", (parameter as Function).Arguments.ElementAt(1).DataType);
			Assert.AreEqual("data", (parameter as Function).Arguments.ElementAt(1).Name);
			Assert.AreEqual(1, (((parameter as Function).Arguments.ElementAt(1)) as Variable).PointerNum);
		}

		[TestMethod]
		[TestCategory("Parse")]
		[TestCategory("FunctionParser")]
		public void Parse_Test_002_001()
		{
			string code1 = "Data1 SampleFunction1(int arg_1_1);";
			string code2 = "Data2 SampleFunction2(int arg_2_1);";
			IEnumerable<string> codes = new List<string>()
			{
				code1, code2
			};
			var parser = new Parser.FunctionParser();
			IEnumerable<Parameter> parameters = parser.Parse(codes);

			Assert.AreEqual(2, parameters.Count());
			Parameter parameter = parameters.ElementAt(0);
			Assert.AreEqual("Data1", parameter.DataType);
			Assert.AreEqual("SampleFunction1", parameter.Name);
			Assert.AreEqual(0, (parameter as Function).PointerNum);
			Assert.AreEqual(1, (parameter as Function).Arguments.Count());
			Assert.AreEqual("int", (parameter as Function).Arguments.ElementAt(0).DataType);
			Assert.AreEqual("arg_1_1", (parameter as Function).Arguments.ElementAt(0).Name);
			Assert.AreEqual(0, (((parameter as Function).Arguments.ElementAt(0)) as Variable).PointerNum);

			parameter = parameters.ElementAt(1);
			Assert.AreEqual("Data2", parameter.DataType);
			Assert.AreEqual("SampleFunction2", parameter.Name);
			Assert.AreEqual(0, (parameter as Function).PointerNum);
			Assert.AreEqual(1, (parameter as Function).Arguments.Count());
			Assert.AreEqual("int", (parameter as Function).Arguments.ElementAt(0).DataType);
			Assert.AreEqual("arg_2_1", (parameter as Function).Arguments.ElementAt(0).Name);
			Assert.AreEqual(0, (((parameter as Function).Arguments.ElementAt(0)) as Variable).PointerNum);

		}
	}
}
