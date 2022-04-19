using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reader.FunctionReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader_utest
{
	//[TestClass]
	public partial class FunctionInTextReader_UnitTest
	{
		[TestMethod]
		[TestCategory("FunctionInTextReader")]
		[TestCategory("ToCodes")]
		public void ToCodes_Test_001()
		{
			string srcCode = "int function(void)";
			var reader = new FunctionInTextReader();
			var privateReader = new PrivateObject(reader);
			IEnumerable<string> codes = (IEnumerable<string>)privateReader.Invoke("ToCodes", srcCode);

			Assert.AreEqual(1, codes.Count());
			Assert.AreEqual("int function(void)", codes.ElementAt(0));
		}

		[TestMethod]
		[TestCategory("FunctionInTextReader")]
		[TestCategory("ToCodes")]
		public void ToCodes_Test_002()
		{
			string srcCode = "int function(void);" +
				Environment.NewLine +
				"int function1(int data1);" +
				Environment.NewLine +
				Environment.NewLine +
				"int function2(int data2);";
			var reader = new FunctionInTextReader();
			var privateReader = new PrivateObject(reader);
			IEnumerable<string> codes = (IEnumerable<string>)privateReader.Invoke("ToCodes", srcCode);

			Assert.AreEqual(3, codes.Count());
			Assert.AreEqual("int function(void)", codes.ElementAt(0));
			Assert.AreEqual("int function1(int data1)", codes.ElementAt(1));
			Assert.AreEqual("int function2(int data2)", codes.ElementAt(2));
		}

		[TestMethod]
		[TestCategory("FunctionInTextReader")]
		[TestCategory("ToCodes")]
		public void ToCodes_Test_003()
		{
			string srcCode = "int function(void);" +
				"int function1(int data1);" +
				"int function2(int data2);";
			var reader = new FunctionInTextReader();
			var privateReader = new PrivateObject(reader);
			IEnumerable<string> codes = (IEnumerable<string>)privateReader.Invoke("ToCodes", srcCode);

			Assert.AreEqual(3, codes.Count());
			Assert.AreEqual("int function(void)", codes.ElementAt(0));
			Assert.AreEqual("int function1(int data1)", codes.ElementAt(1));
			Assert.AreEqual("int function2(int data2)", codes.ElementAt(2));
		}

		[TestMethod]
		[TestCategory("FunctionInTextReader")]
		[TestCategory("ToCodes")]
		public void ToCodes_Test_004()
		{
			string srcCode = "int function(void);" +
				"int function1(" +
				Environment.NewLine +
				"int data1" +
				Environment.NewLine +
				");" +
				Environment.NewLine +
				"int function2(" +
				Environment.NewLine +
				"int data2" +
				Environment.NewLine +
				");";
			var reader = new FunctionInTextReader();
			var privateReader = new PrivateObject(reader);
			IEnumerable<string> codes = (IEnumerable<string>)privateReader.Invoke("ToCodes", srcCode);

			Assert.AreEqual(3, codes.Count());
			Assert.AreEqual("int function(void)", codes.ElementAt(0));
			Assert.AreEqual("int function1(int data1)", codes.ElementAt(1));
			Assert.AreEqual("int function2(int data2)", codes.ElementAt(2));
		}

		[TestMethod]
		[TestCategory("FunctionInTextReader")]
		[TestCategory("ToCodes")]
		public void ToCodes_Test_005()
		{
			string srcCode = "int function(void);" +
				Environment.NewLine +
				"int function1(int data1);" +
				"int function2(int data2);";
			var reader = new FunctionInTextReader();
			var privateReader = new PrivateObject(reader);
			IEnumerable<string> codes = (IEnumerable<string>)privateReader.Invoke("ToCodes", srcCode);

			Assert.AreEqual(3, codes.Count());
			Assert.AreEqual("int function(void)", codes.ElementAt(0));
			Assert.AreEqual("int function1(int data1)", codes.ElementAt(1));
			Assert.AreEqual("int function2(int data2)", codes.ElementAt(2));
		}

		[TestMethod]
		[TestCategory("FunctionInTextReader")]
		[TestCategory("ToCodes")]
		public void ToCodes_Test_006()
		{
			string srcCode = "int function(void);" +
				"int function1(int data1);" +
				Environment.NewLine +
				"int function2(int data2);";
			var reader = new FunctionInTextReader();
			var privateReader = new PrivateObject(reader);
			IEnumerable<string> codes = (IEnumerable<string>)privateReader.Invoke("ToCodes", srcCode);

			Assert.AreEqual(3, codes.Count());
			Assert.AreEqual("int function(void)", codes.ElementAt(0));
			Assert.AreEqual("int function1(int data1)", codes.ElementAt(1));
			Assert.AreEqual("int function2(int data2)", codes.ElementAt(2));
		}

		[TestMethod]
		[TestCategory("FunctionInTextReader")]
		[TestCategory("ToCodes")]
		public void ToCodes_Test_007()
		{
			string srcCode = "int function(void);" +
				"int function1(int data1);" +
				"int function2(int data2);" +
				Environment.NewLine;
			var reader = new FunctionInTextReader();
			var privateReader = new PrivateObject(reader);
			IEnumerable<string> codes = (IEnumerable<string>)privateReader.Invoke("ToCodes", srcCode);

			Assert.AreEqual(3, codes.Count());
			Assert.AreEqual("int function(void)", codes.ElementAt(0));
			Assert.AreEqual("int function1(int data1)", codes.ElementAt(1));
			Assert.AreEqual("int function2(int data2)", codes.ElementAt(2));
		}
	}
}
