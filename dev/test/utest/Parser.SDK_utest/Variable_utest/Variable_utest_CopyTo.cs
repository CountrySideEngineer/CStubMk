using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser.SDK.Model;
using System;
using System.Collections.Generic;

namespace Variable_utest
{
	//[TestClass]
	public partial class Variable_utest
	{
		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Variable")]
		[TestCategory("CopyTo")]
		public void CopyTo_test_001()
		{
			Variable variable = new Variable()
			{
				DataType = "DataType",
				Name = "VarName",
				PointerNum = 0
			};
			Variable dst = new Variable();
			variable.CopyTo(dst);

			Assert.AreEqual("DataType", dst.DataType);
			Assert.AreEqual("VarName", dst.Name);
			Assert.AreEqual(0, dst.PointerNum);
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Variable")]
		[TestCategory("CopyTo")]
		public void CopyTo_test_002()
		{
			Variable variable = new Variable()
			{
				DataType = "DataType",
				Name = "VarName",
				PointerNum = 1
			};
			Variable dst = new Variable();
			variable.CopyTo(dst);

			Assert.AreEqual("DataType", dst.DataType);
			Assert.AreEqual("VarName", dst.Name);
			Assert.AreEqual(1, dst.PointerNum);
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Variable")]
		[TestCategory("CopyTo")]
		public void CopyTo_test_003()
		{
			Parameter parameter = new Parameter()
			{
				DataType = "DataType",
				Name = "VarName"
			};
			Variable dst = new Variable();
			parameter.CopyTo(dst);

			Assert.AreEqual("DataType", dst.DataType);
			Assert.AreEqual("VarName", dst.Name);
			Assert.AreEqual(0, dst.PointerNum);
		}
	}
}
