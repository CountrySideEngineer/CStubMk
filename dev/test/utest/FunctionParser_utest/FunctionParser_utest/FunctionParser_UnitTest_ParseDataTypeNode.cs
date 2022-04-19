using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Parser;
using Parser.SDK.Model;

namespace FunctionParser_utest
{
	//[TestClass]
	public partial class FunctionParser_UnitTest
	{
		[TestMethod]
		[TestCategory("ParseDataTypeNode")]
		public void ParseDataTypeNode_Test_001()
		{
			string code = "int";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseDataTypeNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.PointerNum, 0);
		}

		[TestMethod]
		[TestCategory("ParseDataTypeNode")]
		public void ParseDataTypeNode_Test_002()
		{
			string code = "const int";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Parameter parameter = (Parameter)parserPrivate.Invoke("ParseDataTypeNode", code);

			Variable variable = (Variable)parserPrivate.Invoke("ParseDataTypeNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.PointerNum, 0);
		}

		[TestMethod]
		[TestCategory("ParseDataTypeNode")]
		public void ParseDataTypeNode_Test_003()
		{
			string code = "int*";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Parameter parameter = (Parameter)parserPrivate.Invoke("ParseDataTypeNode", code);

			Variable variable = (Variable)parserPrivate.Invoke("ParseDataTypeNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.PointerNum, 1);
		}

		[TestMethod]
		[TestCategory("ParseDataTypeNode")]
		public void ParseDataTypeNode_Test_004()
		{
			string code = "int**";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Parameter parameter = (Parameter)parserPrivate.Invoke("ParseDataTypeNode", code);

			Variable variable = (Variable)parserPrivate.Invoke("ParseDataTypeNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.PointerNum, 2);
		}
	}
}
