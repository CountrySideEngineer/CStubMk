using FunctionParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParameterNodeParser_utest
{
	//[TestClass]
	public partial class ParameterNodeParser_utest
	{
		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("SplitToDataTypeAndName")]
		public void SplitToDataTypeAndName_test_001()
		{
			string code = "int function";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			(string dataType, string name) = ((string, string))parserPrivate.Invoke("SplitToDataTypeAndName", code);

			Assert.AreEqual("int", dataType);
			Assert.AreEqual("function", name);
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("SplitToDataTypeAndName")]
		public void SplitToDataTypeAndName_test_002()
		{
			string code = "int\tfunction";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			(string dataType, string name) = ((string, string))parserPrivate.Invoke("SplitToDataTypeAndName", code);

			Assert.AreEqual("int", dataType);
			Assert.AreEqual("function", name);
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("SplitToDataTypeAndName")]
		public void SplitToDataTypeAndName_test_003()
		{
			string code = "int\rfunction";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			(string dataType, string name) = ((string, string))parserPrivate.Invoke("SplitToDataTypeAndName", code);

			Assert.AreEqual("int", dataType);
			Assert.AreEqual("function", name);
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("SplitToDataTypeAndName")]
		public void SplitToDataTypeAndName_test_004()
		{
			string code = "int\nfunction";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			(string dataType, string name) = ((string, string))parserPrivate.Invoke("SplitToDataTypeAndName", code);

			Assert.AreEqual("int", dataType);
			Assert.AreEqual("function", name);
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("SplitToDataTypeAndName")]
		public void SplitToDataTypeAndName_test_005()
		{
			string code = "int\r\nfunction";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			(string dataType, string name) = ((string, string))parserPrivate.Invoke("SplitToDataTypeAndName", code);

			Assert.AreEqual("int", dataType);
			Assert.AreEqual("function", name);
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("SplitToDataTypeAndName")]
		public void SplitToDataTypeAndName_test_006()
		{
			string code = "int\r\nfunction\t";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			(string dataType, string name) = ((string, string))parserPrivate.Invoke("SplitToDataTypeAndName", code);

			Assert.AreEqual("int", dataType);
			Assert.AreEqual("function", name);
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("SplitToDataTypeAndName")]
		public void SplitToDataTypeAndName_test_007()
		{
			string code = " int function";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			(string dataType, string name) = ((string, string))parserPrivate.Invoke("SplitToDataTypeAndName", code);

			Assert.AreEqual("int", dataType);
			Assert.AreEqual("function", name);
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("SplitToDataTypeAndName")]
		public void SplitToDataTypeAndName_test_008()
		{
			string code = " int function ";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			(string dataType, string name) = ((string, string))parserPrivate.Invoke("SplitToDataTypeAndName", code);

			Assert.AreEqual("int", dataType);
			Assert.AreEqual("function", name);
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("SplitToDataTypeAndName")]
		[ExpectedException(typeof(ArgumentException))]
		public void SplitToDataTypeAndName_test_009()
		{
			string code = " int ";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			(string dataType, string name) = ((string, string))parserPrivate.Invoke("SplitToDataTypeAndName", code);

			Assert.Fail();
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("SplitToDataTypeAndName")]
		[ExpectedException(typeof(ArgumentException))]
		public void SplitToDataTypeAndName_test_010()
		{
			string code = " ";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			(string dataType, string name) = ((string, string))parserPrivate.Invoke("SplitToDataTypeAndName", code);

			Assert.Fail();
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("SplitToDataTypeAndName")]
		[ExpectedException(typeof(ArgumentException))]
		public void SplitToDataTypeAndName_test_011()
		{
			string code = "\t";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			(string dataType, string name) = ((string, string))parserPrivate.Invoke("SplitToDataTypeAndName", code);

			Assert.Fail();
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("SplitToDataTypeAndName")]
		[ExpectedException(typeof(ArgumentException))]
		public void SplitToDataTypeAndName_test_012()
		{
			string code = "\r";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			(string dataType, string name) = ((string, string))parserPrivate.Invoke("SplitToDataTypeAndName", code);

			Assert.Fail();
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("SplitToDataTypeAndName")]
		[ExpectedException(typeof(ArgumentException))]
		public void SplitToDataTypeAndName_test_013()
		{
			string code = "\n";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			(string dataType, string name) = ((string, string))parserPrivate.Invoke("SplitToDataTypeAndName", code);

			Assert.Fail();
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("SplitToDataTypeAndName")]
		public void SplitToDataTypeAndName_test_014()
		{
			string code = "const int function";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			(string dataType, string name) = ((string, string))parserPrivate.Invoke("SplitToDataTypeAndName", code);

			Assert.AreEqual("const int", dataType);
			Assert.AreEqual("function", name);
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("SplitToDataTypeAndName")]
		public void SplitToDataTypeAndName_test_015()
		{
			string code = "const int* function";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			(string dataType, string name) = ((string, string))parserPrivate.Invoke("SplitToDataTypeAndName", code);

			Assert.AreEqual("const int*", dataType);
			Assert.AreEqual("function", name);
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("SplitToDataTypeAndName")]
		public void SplitToDataTypeAndName_test_016()
		{
			string code = "const int * function";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			(string dataType, string name) = ((string, string))parserPrivate.Invoke("SplitToDataTypeAndName", code);

			Assert.AreEqual("const int *", dataType);
			Assert.AreEqual("function", name);
		}
	}
}
