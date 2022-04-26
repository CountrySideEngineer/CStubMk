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
		public void GetPointerNum_test_001()
		{
			string dataType = "int";
			var parser = new VariableNodeParser();
			var privateParser = new PrivateObject(parser);
			int pointerNum = (int)privateParser.Invoke("GetPointerNum", dataType);

			Assert.AreEqual(0, pointerNum);
		}

		[TestMethod]
		[TestCategory("VariableNodeParser")]
		[TestCategory("RemovePointer")]
		public void GetPointerNum_test_002()
		{
			string dataType = "int*";
			var parser = new VariableNodeParser();
			var privateParser = new PrivateObject(parser);
			int pointerNum = (int)privateParser.Invoke("GetPointerNum", dataType);

			Assert.AreEqual(1, pointerNum);
		}

		[TestMethod]
		[TestCategory("VariableNodeParser")]
		[TestCategory("RemovePointer")]
		public void GetPointerNum_test_003()
		{
			string dataType = "int**";
			var parser = new VariableNodeParser();
			var privateParser = new PrivateObject(parser);
			int pointerNum = (int)privateParser.Invoke("GetPointerNum", dataType);

			Assert.AreEqual(2, pointerNum);
		}

		[TestMethod]
		[TestCategory("VariableNodeParser")]
		[TestCategory("RemovePointer")]
		public void GetPointerNum_test_004()
		{
			string dataType = string.Empty;
			var parser = new VariableNodeParser();
			var privateParser = new PrivateObject(parser);
			int pointerNum = (int)privateParser.Invoke("GetPointerNum", dataType);

			Assert.AreEqual(0, pointerNum); ;
		}
	}
}
