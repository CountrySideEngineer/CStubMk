using FunctionParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser.SDK.Exception;
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
		[TestCategory("ParseNode")]
		public void ParseNode_overload_001_test_001()
		{
			string code = "int function";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			Parameter parameter = (Parameter)parserPrivate.Invoke("ParseNode", code);

			Assert.AreEqual("int", parameter.DataType);
			Assert.AreEqual("function", parameter.Name);
			Assert.AreEqual(string.Empty, parameter.FileName);
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("ParseNode")]
		public void ParseNode_overload_001_test_002()
		{
			string code = "void";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			Parameter parameter = (Parameter)parserPrivate.Invoke("ParseNode", code);

			Assert.AreEqual("void", parameter.DataType);
			Assert.AreEqual(string.Empty, parameter.Name);
			Assert.AreEqual(string.Empty, parameter.FileName);
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("ParseNode")]
		public void ParseNode_overload_001_test_003()
		{
			string code = "VOID";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			Parameter parameter = (Parameter)parserPrivate.Invoke("ParseNode", code);

			Assert.AreEqual("VOID", parameter.DataType);
			Assert.AreEqual(string.Empty, parameter.Name);
			Assert.AreEqual(string.Empty, parameter.FileName);
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("ParseNode")]
		[ExpectedException(typeof(ParserException))]
		public void ParseNode_overload_001_test_004()
		{
			string code = "int";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			Parameter parameter = (Parameter)parserPrivate.Invoke("ParseNode", code);

			Assert.Fail();
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("ParseNode")]
		[ExpectedException(typeof(ParserException))]
		public void ParseNode_overload_001_test_005()
		{
			string code = string.Empty;
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			Parameter parameter = (Parameter)parserPrivate.Invoke("ParseNode", code);

			Assert.Fail();
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("ParseNode")]
		public void ParseNode_overload_002_test_001()
		{
			IEnumerable<string> codes = new List<string>()
			{
				"int function_001",
			};
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			IEnumerable<Parameter> nodes = (IEnumerable<Parameter>)parserPrivate.Invoke("ParseNode", codes);

			Assert.AreEqual(1, nodes.Count());
			Assert.AreEqual("int", nodes.ElementAt(0).DataType);
			Assert.AreEqual("function_001", nodes.ElementAt(0).Name);
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("ParseNode")]
		public void ParseNode_overload_002_test_002()
		{
			IEnumerable<string> codes = new List<string>()
			{
				"int function_001",
				"TYPE function_002",
			};
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			IEnumerable<Parameter> nodes = (IEnumerable<Parameter>)parserPrivate.Invoke("ParseNode", codes);

			Assert.AreEqual(2, nodes.Count());
			Assert.AreEqual("int", nodes.ElementAt(0).DataType);
			Assert.AreEqual("function_001", nodes.ElementAt(0).Name);
			Assert.AreEqual("TYPE", nodes.ElementAt(1).DataType);
			Assert.AreEqual("function_002", nodes.ElementAt(1).Name);
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("ParseNode")]
		public void ParseNode_overload_002_test_003()
		{
			IEnumerable<string> codes = new List<string>()
			{
				"int function_001",
				"TYPE",
			};
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			IEnumerable<Parameter> nodes = (IEnumerable<Parameter>)parserPrivate.Invoke("ParseNode", codes);

			Assert.AreEqual(1, nodes.Count());
			Assert.AreEqual("int", nodes.ElementAt(0).DataType);
			Assert.AreEqual("function_001", nodes.ElementAt(0).Name);
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("ParseNode")]
		public void ParseNode_overload_002_test_004()
		{
			IEnumerable<string> codes = new List<string>()
			{
				"TYPE",
				"int function_001",
			};
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			IEnumerable<Parameter> nodes = (IEnumerable<Parameter>)parserPrivate.Invoke("ParseNode", codes);

			Assert.AreEqual(1, nodes.Count());
			Assert.AreEqual("int", nodes.ElementAt(0).DataType);
			Assert.AreEqual("function_001", nodes.ElementAt(0).Name);
		}
	}
}
