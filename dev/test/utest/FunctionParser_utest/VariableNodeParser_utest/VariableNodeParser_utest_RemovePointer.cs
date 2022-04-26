using FunctionParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace VariableNodeParser_utest
{
	//[TestClass]
	public partial class VariableNodeParser_utest
	{
		[TestMethod]
		[TestCategory("VariableNodeParser")]
		[TestCategory("RemovePointer")]
		public void RemovePointer_test_001()
		{
			string dataType = "int";
			var parser = new VariableNodeParser();
			var privateParser = new PrivateObject(parser);
			string dataTypeWithoutPoitner = (string)privateParser.Invoke("RemovePointer", dataType);

			Assert.AreEqual("int", dataTypeWithoutPoitner);
		}

		[TestMethod]
		[TestCategory("VariableNodeParser")]
		[TestCategory("RemovePointer")]
		public void RemovePointer_test_002()
		{
			string dataType = "int*";
			var parser = new VariableNodeParser();
			var privateParser = new PrivateObject(parser);
			string dataTypeWithoutPoitner = (string)privateParser.Invoke("RemovePointer", dataType);

			Assert.AreEqual("int", dataTypeWithoutPoitner);
		}

		[TestMethod]
		[TestCategory("VariableNodeParser")]
		[TestCategory("RemovePointer")]
		public void RemovePointer_test_003()
		{
			string dataType = "int**";
			var parser = new VariableNodeParser();
			var privateParser = new PrivateObject(parser);
			string dataTypeWithoutPoitner = (string)privateParser.Invoke("RemovePointer", dataType);

			Assert.AreEqual("int", dataTypeWithoutPoitner);
		}
	}
}
