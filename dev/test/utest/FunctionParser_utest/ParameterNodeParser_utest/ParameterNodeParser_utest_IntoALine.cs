using FunctionParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser.SDK.Model;
using System;

namespace ParameterNodeParser_utest
{
	//[TestClass]
	public partial class ParameterNodeParser_utest
	{
		[TestMethod]
		[TestCategory("IntoALine")]
		[TestCategory("ParameterNodeParser")]
		public void IntoALine_test_001()
		{
			string code = "int function";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			string aLine = (string)parserPrivate.Invoke("IntoALine", code);

			Assert.AreEqual("int function", aLine);
		}

		[TestMethod]
		[TestCategory("IntoALine")]
		[TestCategory("ParameterNodeParser")]
		public void IntoALine_test_002()
		{
			string code = "int function_001\nint_function_002";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			string aLine = (string)parserPrivate.Invoke("IntoALine", code);

			Assert.AreEqual("int function_001 int_function_002", aLine);
		}

		[TestMethod]
		[TestCategory("IntoALine")]
		[TestCategory("ParameterNodeParser")]
		public void IntoALine_test_003()
		{
			string code = "int function_001\rint_function_002";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			string aLine = (string)parserPrivate.Invoke("IntoALine", code);

			Assert.AreEqual("int function_001 int_function_002", aLine);
		}

		[TestMethod]
		[TestCategory("IntoALine")]
		[TestCategory("ParameterNodeParser")]
		public void IntoALine_test_004()
		{
			string code = "int function_001\r\nint_function_002";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			string aLine = (string)parserPrivate.Invoke("IntoALine", code);

			Assert.AreEqual("int function_001 int_function_002", aLine);
		}

		[TestMethod]
		[TestCategory("IntoALine")]
		[TestCategory("ParameterNodeParser")]
		public void IntoALine_test_005()
		{
			string code = "int function_001\r\nint_function_002\n";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			string aLine = (string)parserPrivate.Invoke("IntoALine", code);

			Assert.AreEqual("int function_001 int_function_002 ", aLine);
		}
	}
}
