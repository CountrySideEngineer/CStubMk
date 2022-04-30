using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reader;
using Reader.FunctionReader;
using System;

namespace ReaderFactory_utest
{
	//[TestClass]
	public partial class ReaderFactory_UnitTest
	{
		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		public void Factory_Test_001()
		{
			string inputFile = @"..\SampleFile.txt";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.IsTrue(reader is FunctionInTextReader);
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		public void Factory_Test_002()
		{
			string inputFile = @"..\SampleFile.TXT";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.IsTrue(reader is FunctionInTextReader);
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		public void Factory_Test_003()
		{
			string inputFile = @"..\SampleFile.Txt";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.IsTrue(reader is FunctionInTextReader);
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		public void Factory_Test_004()
		{
			string inputFile = @"..\SampleFile.tXt";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.IsTrue(reader is FunctionInTextReader);
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		public void Factory_Test_005()
		{
			string inputFile = @"..\SampleFile.txT";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.IsTrue(reader is FunctionInTextReader);
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		public void Factory_Test_006()
		{
			string inputFile = @"..\SampleFile.TXt";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.IsTrue(reader is FunctionInTextReader);
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		public void Factory_Test_007()
		{
			string inputFile = @"..\SampleFile.tXT";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.IsTrue(reader is FunctionInTextReader);
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		public void Factory_Test_008()
		{
			string inputFile = @"..\SampleFile.TxT";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.IsTrue(reader is FunctionInTextReader);
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		public void Factory_Test_009()
		{
			string inputFile = @"..\SampleFile.xlsx";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.IsTrue(reader is FunctionInExcelReader);
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		public void Factory_Test_010()
		{
			string inputFile = @"..\SampleFile.xlsx";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.IsTrue(reader is FunctionInExcelReader);
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		public void Factory_Test_011()
		{
			string inputFile = @"..\SampleFile.XLSX";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.IsTrue(reader is FunctionInExcelReader);
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		public void Factory_Test_012()
		{
			string inputFile = @"..\SampleFile.Xlsx";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.IsTrue(reader is FunctionInExcelReader);
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		public void Factory_Test_013()
		{
			string inputFile = @"..\SampleFile.xLsx";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.IsTrue(reader is FunctionInExcelReader);
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		public void Factory_Test_014()
		{
			string inputFile = @"..\SampleFile.xlSx";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.IsTrue(reader is FunctionInExcelReader);
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		public void Factory_Test_015()
		{
			string inputFile = @"..\SampleFile.xlsX";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.IsTrue(reader is FunctionInExcelReader);
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		public void Factory_Test_016()
		{
			string inputFile = @"..\SampleFile.XLsx";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.IsTrue(reader is FunctionInExcelReader);
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		public void Factory_Test_017()
		{
			string inputFile = @"..\SampleFile.xLSx";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.IsTrue(reader is FunctionInExcelReader);
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		public void Factory_Test_018()
		{
			string inputFile = @"..\SampleFile.xlSX";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.IsTrue(reader is FunctionInExcelReader);
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		public void Factory_Test_019()
		{
			string inputFile = @"..\SampleFile.XlsX";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.IsTrue(reader is FunctionInExcelReader);
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		public void Factory_Test_020()
		{
			string inputFile = @"..\SampleFile.XlSx";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.IsTrue(reader is FunctionInExcelReader);
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		public void Factory_Test_021()
		{
			string inputFile = @"..\SampleFile.xLsX";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.IsTrue(reader is FunctionInExcelReader);
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		public void Factory_Test_022()
		{
			string inputFile = @"..\SampleFile.xLsX";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.IsTrue(reader is FunctionInExcelReader);
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		[ExpectedException(typeof(NotSupportedException))]
		public void Factory_Test_023()
		{
			string inputFile = @"..\SampleFile.sxt";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.Fail();
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		[ExpectedException(typeof(NotSupportedException))]
		public void Factory_Test_024()
		{
			string inputFile = @"..\SampleFile.uxt";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.Fail();
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		[ExpectedException(typeof(NotSupportedException))]
		public void Factory_Test_025()
		{
			string inputFile = @"..\SampleFile.txs";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.Fail();
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		[ExpectedException(typeof(NotSupportedException))]
		public void Factory_Test_026()
		{
			string inputFile = @"..\SampleFile.txu";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.Fail();
		}

		[TestMethod]
		[TestCategory("ReaderFactory")]
		[TestCategory("Factory")]
		[ExpectedException(typeof(ArgumentException))]
		public void Factory_Test_027()
		{
			string inputFile = @"..\unknown.txt";
			AFunctionReader reader = ReaderFactory.Factory(inputFile);

			Assert.Fail();
		}
	}
}
