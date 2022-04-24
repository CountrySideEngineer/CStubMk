using FunctionParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FunctionNodeParser_utest
{
	//[TestClass]
	public partial class FunctionNodeParse_utest
	{
		[TestMethod]
		[TestCategory("FunctionNodeParse")]
		[TestCategory("SplitToFuncAndArg")]
		public void SplitToFuncAndArg_test_001()
		{
			string code = "int func(int data1)";
			FunctionNodeParser parser = new FunctionNodeParser();
			var privateParser = new PrivateObject(parser);
			(string func, string arg) = ((string, string))privateParser.Invoke("SplitToFuncAndArg", code);

			Assert.AreEqual("int func", func);
			Assert.AreEqual("int data1", arg);
		}

		[TestMethod]
		[TestCategory("FunctionNodeParse")]
		[TestCategory("SplitToFuncAndArg")]
		public void SplitToFuncAndArg_test_002()
		{
			string code = "int func(int data1, int data2)";
			FunctionNodeParser parser = new FunctionNodeParser();
			var privateParser = new PrivateObject(parser);
			(string func, string arg) = ((string, string))privateParser.Invoke("SplitToFuncAndArg", code);

			Assert.AreEqual("int func", func);
			Assert.AreEqual("int data1, int data2", arg);
		}

		[TestMethod]
		[TestCategory("FunctionNodeParse")]
		[TestCategory("SplitToFuncAndArg")]
		public void SplitToFuncAndArg_test_003()
		{
			string code = "int func()";
			FunctionNodeParser parser = new FunctionNodeParser();
			var privateParser = new PrivateObject(parser);
			(string func, string arg) = ((string, string))privateParser.Invoke("SplitToFuncAndArg", code);

			Assert.AreEqual("int func", func);
			Assert.AreEqual(string.Empty, arg);
		}
	}
}
