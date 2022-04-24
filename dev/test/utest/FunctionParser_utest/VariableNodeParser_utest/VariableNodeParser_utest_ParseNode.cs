using FunctionParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser.SDK.Model;
using System;

namespace VariableNodeParser_utest
{
	//[TestClass]
	public partial class VariableNodeParser_utest
	{
		[TestMethod]
		[TestCategory("VariableNodeParser")]
		[TestCategory("ParseNode")]
		public void ParseNode_test_001()
		{
			string node = "Type Variable";
			var parser = new VariableNodeParser();
			var privateParser = new PrivateObject(parser);
			var variable = (Variable)privateParser.Invoke("ParseNode", node);

			Assert.AreEqual("Type", variable.DataType);
			Assert.AreEqual("Variable", variable.Name);
			Assert.AreEqual(0, variable.PointerNum);
		}

		[TestMethod]
		[TestCategory("VariableNodeParser")]
		[TestCategory("ParseNode")]
		public void ParseNode_test_002()
		{
			string node = "Type* Variable";
			var parser = new VariableNodeParser();
			var privateParser = new PrivateObject(parser);
			var variable = (Variable)privateParser.Invoke("ParseNode", node);

			Assert.AreEqual("Type", variable.DataType);
			Assert.AreEqual("Variable", variable.Name);
			Assert.AreEqual(1, variable.PointerNum);
		}

		[TestMethod]
		[TestCategory("VariableNodeParser")]
		[TestCategory("ParseNode")]
		public void ParseNode_test_003()
		{
			string node = "Type *Variable";
			var parser = new VariableNodeParser();
			var privateParser = new PrivateObject(parser);
			var variable = (Variable)privateParser.Invoke("ParseNode", node);

			Assert.AreEqual("Type", variable.DataType);
			Assert.AreEqual("Variable", variable.Name);
			Assert.AreEqual(1, variable.PointerNum);
		}

		[TestMethod]
		[TestCategory("VariableNodeParser")]
		[TestCategory("ParseNode")]
		public void ParseNode_test_004()
		{
			string node = "Type * Variable";
			var parser = new VariableNodeParser();
			var privateParser = new PrivateObject(parser);
			var variable = (Variable)privateParser.Invoke("ParseNode", node);

			Assert.AreEqual("Type", variable.DataType);
			Assert.AreEqual("Variable", variable.Name);
			Assert.AreEqual(1, variable.PointerNum);
		}
	}
}
