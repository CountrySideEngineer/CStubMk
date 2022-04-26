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
		[TestCategory("IsVoid")]
		[TestCategory("ParameterNodeParser")]
		public void IsVoid_test_001()
		{
			string code = "void test";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			bool isVoid = (bool)parserPrivate.Invoke("IsVoid", code);

			Assert.IsTrue(isVoid);
		}

		[TestMethod]
		[TestCategory("IsVoid")]
		[TestCategory("ParameterNodeParser")]
		public void IsVoid_test_002()
		{
			string code = "void test,";
			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			bool isVoid = (bool)parserPrivate.Invoke("IsVoid", code);

			Assert.IsTrue(isVoid);
		}

		[TestMethod]
		[TestCategory("IsVoid")]
		[TestCategory("ParameterNodeParser")]
		public void IsVoid_test_003()
		{
			string code = "void" + Environment.NewLine + "test";

			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			bool isVoid = (bool)parserPrivate.Invoke("IsVoid", code);

			Assert.IsTrue(isVoid);
		}

		[TestMethod]
		[TestCategory("IsVoid")]
		[TestCategory("ParameterNodeParser")]
		public void IsVoid_test_004()
		{
			string code = "void\ttest";

			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			bool isVoid = (bool)parserPrivate.Invoke("IsVoid", code);

			Assert.IsTrue(isVoid);
		}

		[TestMethod]
		[TestCategory("IsVoid")]
		[TestCategory("ParameterNodeParser")]
		public void IsVoid_test_005()
		{
			string code = "void\rtest";

			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			bool isVoid = (bool)parserPrivate.Invoke("IsVoid", code);

			Assert.IsTrue(isVoid);
		}

		[TestMethod]
		[TestCategory("IsVoid")]
		[TestCategory("ParameterNodeParser")]
		public void IsVoid_test_006()
		{
			string code = "void\ntest";

			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			bool isVoid = (bool)parserPrivate.Invoke("IsVoid", code);

			Assert.IsTrue(isVoid);
		}

		[TestMethod]
		[TestCategory("IsVoid")]
		[TestCategory("ParameterNodeParser")]
		public void IsVoid_test_007()
		{
			string code = "VOID test";

			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			bool isVoid = (bool)parserPrivate.Invoke("IsVoid", code);

			Assert.IsTrue(isVoid);
		}

		[TestMethod]
		[TestCategory("IsVoid")]
		[TestCategory("ParameterNodeParser")]
		public void IsVoid_test_008()
		{
			string code = "voidtest";

			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			bool isVoid = (bool)parserPrivate.Invoke("IsVoid", code);

			Assert.IsFalse(isVoid);
		}

		[TestMethod]
		[TestCategory("IsVoid")]
		[TestCategory("ParameterNodeParser")]
		public void IsVoid_test_009()
		{
			string code = "v oid test";

			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			bool isVoid = (bool)parserPrivate.Invoke("IsVoid", code);

			Assert.IsFalse(isVoid);
		}

		[TestMethod]
		[TestCategory("IsVoid")]
		[TestCategory("ParameterNodeParser")]
		public void IsVoid_test_010()
		{
			string code = "voi d test";

			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			bool isVoid = (bool)parserPrivate.Invoke("IsVoid", code);

			Assert.IsFalse(isVoid);
		}

		[TestMethod]
		[TestCategory("IsVoid")]
		[TestCategory("ParameterNodeParser")]
		public void IsVoid_test_011()
		{
			string code = "void";

			var parser = new ParameterNodeParser();
			var parserPrivate = new PrivateObject(parser);
			bool isVoid = (bool)parserPrivate.Invoke("IsVoid", code);

			Assert.IsTrue(isVoid);
		}
	}
}
