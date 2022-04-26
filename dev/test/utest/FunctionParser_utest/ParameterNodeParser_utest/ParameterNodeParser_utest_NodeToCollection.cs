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
		[TestCategory("NodeToCollection")]
		public void NodeToCollection_test_001()
		{
			string code = "int function";
			char[] deliminator = { ' ', '\t', '\r', '\n' };
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			IEnumerable<string> nodeCollection = (IEnumerable<string>)parserPrivate.Invoke("NodeToCollection", code, deliminator);

			Assert.AreEqual(2, nodeCollection.Count());
			Assert.AreEqual("int", nodeCollection.ElementAt(0));
			Assert.AreEqual("function", nodeCollection.ElementAt(1));
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("NodeToCollection")]
		public void NodeToCollection_test_002()
		{
			string code = "int\tfunction";
			char[] deliminator = { ' ', '\t', '\r', '\n' };
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			IEnumerable<string> nodeCollection = (IEnumerable<string>)parserPrivate.Invoke("NodeToCollection", code, deliminator);

			Assert.AreEqual(2, nodeCollection.Count());
			Assert.AreEqual("int", nodeCollection.ElementAt(0));
			Assert.AreEqual("function", nodeCollection.ElementAt(1));
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("NodeToCollection")]
		public void NodeToCollection_test_003()
		{
			string code = "int\rfunction";
			char[] deliminator = { ' ', '\t', '\r', '\n' };
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			IEnumerable<string> nodeCollection = (IEnumerable<string>)parserPrivate.Invoke("NodeToCollection", code, deliminator);

			Assert.AreEqual(2, nodeCollection.Count());
			Assert.AreEqual("int", nodeCollection.ElementAt(0));
			Assert.AreEqual("function", nodeCollection.ElementAt(1));
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("NodeToCollection")]
		public void NodeToCollection_test_004()
		{
			string code = "int\nfunction";
			char[] deliminator = { ' ', '\t', '\r', '\n' };
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			IEnumerable<string> nodeCollection = (IEnumerable<string>)parserPrivate.Invoke("NodeToCollection", code, deliminator);

			Assert.AreEqual(2, nodeCollection.Count());
			Assert.AreEqual("int", nodeCollection.ElementAt(0));
			Assert.AreEqual("function", nodeCollection.ElementAt(1));
		}

		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("NodeToCollection")]
		public void NodeToCollection_test_005()
		{
			string code = "int\r\nfunction";
			char[] deliminator = { ' ', '\t', '\r', '\n' };
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			IEnumerable<string> nodeCollection = (IEnumerable<string>)parserPrivate.Invoke("NodeToCollection", code, deliminator);

			Assert.AreEqual(2, nodeCollection.Count());
			Assert.AreEqual("int", nodeCollection.ElementAt(0));
			Assert.AreEqual("function", nodeCollection.ElementAt(1));
		}
	}
}
