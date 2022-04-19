using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser;
using Parser.SDK.Exception;
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
		[TestCategory("ParseArguments")]
		public void ParseArguments_Test_001()
		{
			string argumentCode = "dataType1 arg1";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			IEnumerable<Variable> arguments = (IEnumerable<Variable>)parserPrivate.Invoke("ParseArguments", argumentCode);

			Assert.AreEqual(1, arguments.Count());
			Assert.AreEqual("dataType1", arguments.ElementAt(0).DataType);
			Assert.AreEqual("arg1", arguments.ElementAt(0).Name);
			Assert.AreEqual(0, arguments.ElementAt(0).PointerNum);
		}

		[TestMethod]
		[TestCategory("ParseArguments")]
		public void ParseArguments_Test_002()
		{
			string argumentCode = "dataType1 arg1, dataType2 arg2";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			IEnumerable<Variable> arguments = (IEnumerable<Variable>)parserPrivate.Invoke("ParseArguments", argumentCode);

			Assert.AreEqual(2, arguments.Count());
			Assert.AreEqual("dataType1", arguments.ElementAt(0).DataType);
			Assert.AreEqual("arg1", arguments.ElementAt(0).Name);
			Assert.AreEqual(0, arguments.ElementAt(0).PointerNum);
			Assert.AreEqual("dataType2", arguments.ElementAt(1).DataType);
			Assert.AreEqual("arg2", arguments.ElementAt(1).Name);
			Assert.AreEqual(0, arguments.ElementAt(1).PointerNum);
		}

		[TestMethod]
		[TestCategory("ParseArguments")]
		public void ParseArguments_Test_003()
		{
			string argumentCode = "dataType1 *arg1, dataType2 arg2";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			IEnumerable<Variable> arguments = (IEnumerable<Variable>)parserPrivate.Invoke("ParseArguments", argumentCode);

			Assert.AreEqual(2, arguments.Count());
			Assert.AreEqual("dataType1", arguments.ElementAt(0).DataType);
			Assert.AreEqual("arg1", arguments.ElementAt(0).Name);
			Assert.AreEqual(1, arguments.ElementAt(0).PointerNum);
			Assert.AreEqual("dataType2", arguments.ElementAt(1).DataType);
			Assert.AreEqual("arg2", arguments.ElementAt(1).Name);
			Assert.AreEqual(0, arguments.ElementAt(1).PointerNum);
		}

		[TestMethod]
		[TestCategory("ParseArguments")]
		public void ParseArguments_Test_004()
		{
			string argumentCode = "dataType1* arg1, dataType2 arg2";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			IEnumerable<Variable> arguments = (IEnumerable<Variable>)parserPrivate.Invoke("ParseArguments", argumentCode);

			Assert.AreEqual(2, arguments.Count());
			Assert.AreEqual("dataType1", arguments.ElementAt(0).DataType);
			Assert.AreEqual("arg1", arguments.ElementAt(0).Name);
			Assert.AreEqual(1, arguments.ElementAt(0).PointerNum);
			Assert.AreEqual("dataType2", arguments.ElementAt(1).DataType);
			Assert.AreEqual("arg2", arguments.ElementAt(1).Name);
			Assert.AreEqual(0, arguments.ElementAt(1).PointerNum);
		}

		[TestMethod]
		[TestCategory("ParseArguments")]
		public void ParseArguments_Test_005()
		{
			string argumentCode = "\tdataType1* arg1,\r\n\tdataType2 arg2\r\n";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			IEnumerable<Variable> arguments = (IEnumerable<Variable>)parserPrivate.Invoke("ParseArguments", argumentCode);

			Assert.AreEqual(2, arguments.Count());
			Assert.AreEqual("dataType1", arguments.ElementAt(0).DataType);
			Assert.AreEqual("arg1", arguments.ElementAt(0).Name);
			Assert.AreEqual(1, arguments.ElementAt(0).PointerNum);
			Assert.AreEqual("dataType2", arguments.ElementAt(1).DataType);
			Assert.AreEqual("arg2", arguments.ElementAt(1).Name);
			Assert.AreEqual(0, arguments.ElementAt(1).PointerNum);
		}

		[TestMethod]
		[TestCategory("ParseArguments")]
		public void ParseArguments_Test_006()
		{
			string argumentCode = "void";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			IEnumerable<Variable> arguments = (IEnumerable<Variable>)parserPrivate.Invoke("ParseArguments", argumentCode);

			Assert.AreEqual(1, arguments.Count());
			Assert.AreEqual("void", arguments.ElementAt(0).DataType);
		}

		[TestMethod]
		[TestCategory("ParseArguments")]
		public void ParseArguments_Test_007()
		{
			string argumentCode = "VOID";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			IEnumerable<Variable> arguments = (IEnumerable<Variable>)parserPrivate.Invoke("ParseArguments", argumentCode);

			Assert.AreEqual(1, arguments.Count());
			Assert.AreEqual("VOID", arguments.ElementAt(0).DataType);
		}

		[TestMethod]
		[TestCategory("ParseArguments")]
		[ExpectedException(typeof(ParserException))]
		public void ParseArguments_Test_008()
		{
			string argumentCode = "int arg1,void";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			IEnumerable<Variable> arguments = (IEnumerable<Variable>)parserPrivate.Invoke("ParseArguments", argumentCode);

			Assert.AreEqual(1, arguments.Count());
			Assert.AreEqual("VOID", arguments.ElementAt(0).DataType);
		}
	}
}
