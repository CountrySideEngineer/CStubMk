using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser;
using Parser.SDK.Model;
using System;
using System.Linq;

namespace FunctionParser_utest
{
	//[TestClass]
	public partial class FunctionParser_UnitTest
	{
		[TestMethod]
		[TestCategory("Parse")]
		public void Parse_Test_001_001()
		{
			string code = "void SampleFunction(void)";
			var parser = new FunctionParser();
			Parameter parameter = parser.Parse(code);

			Assert.AreEqual("void", parameter.DataType);
			Assert.AreEqual("SampleFunction", parameter.Name);
			Assert.AreEqual(0, (parameter as Function).PointerNum);
			Assert.AreEqual(1, (parameter as Function).Arguments.Count());
			Assert.AreEqual("void", (parameter as Function).Arguments.ElementAt(0).DataType);
			Assert.IsTrue(string.IsNullOrEmpty((parameter as Function).Arguments.ElementAt(0).Name));
			Assert.AreEqual(0, (((parameter as Function).Arguments.ElementAt(0)) as Variable).PointerNum);
		}

		[TestMethod]
		[TestCategory("Parse")]
		public void Parse_Test_001_002()
		{
			string code = "void SampleFunction()";
			var parser = new FunctionParser();
			Parameter parameter = parser.Parse(code);

			Assert.AreEqual("void", parameter.DataType);
			Assert.AreEqual("SampleFunction", parameter.Name);
			Assert.AreEqual(0, (parameter as Function).PointerNum);
			Assert.AreEqual(0, (parameter as Function).Arguments.Count());
		}

		[TestMethod]
		[TestCategory("Parse")]
		public void Parse_Test_001_003()
		{
			string code = "int SampleFunction(int arg1)";
			var parser = new FunctionParser();
			Parameter parameter = parser.Parse(code);

			Assert.AreEqual("int", parameter.DataType);
			Assert.AreEqual("SampleFunction", parameter.Name);
			Assert.AreEqual(0, (parameter as Function).PointerNum);
			Assert.AreEqual(1, (parameter as Function).Arguments.Count());
			Assert.AreEqual("int", (((parameter as Function).Arguments.ElementAt(0)) as Variable).DataType);
			Assert.AreEqual("arg1", (((parameter as Function).Arguments.ElementAt(0)) as Variable).Name);
		}

		[TestMethod]
		[TestCategory("Parse")]
		public void Parse_Test_001_004()
		{
			string code = "int SampleFunction(int arg1, int arg2)";
			var parser = new FunctionParser();
			Parameter parameter = parser.Parse(code);

			Assert.AreEqual("int", parameter.DataType);
			Assert.AreEqual("SampleFunction", parameter.Name);
			Assert.AreEqual(0, (parameter as Function).PointerNum);
			Assert.AreEqual(2, (parameter as Function).Arguments.Count());
			Assert.AreEqual("int", (((parameter as Function).Arguments.ElementAt(0)) as Variable).DataType);
			Assert.AreEqual("arg1", (((parameter as Function).Arguments.ElementAt(0)) as Variable).Name);
			Assert.AreEqual("int", (((parameter as Function).Arguments.ElementAt(1)) as Variable).DataType);
			Assert.AreEqual("arg2", (((parameter as Function).Arguments.ElementAt(1)) as Variable).Name);
		}
	}
}
