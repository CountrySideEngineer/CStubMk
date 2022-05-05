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
		[TestCategory("ToString")]
		public void ToString_test_001()
		{
			Variable variable = new Variable()
			{
				DataType = "DataType",
				Name = "VarName",
				PointerNum = 0
			};
			string actual = variable.ToString();
			string expected = "DataType VarName";

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Variable")]
		[TestCategory("ToString")]
		public void ToString_test_002()
		{
			Variable variable = new Variable()
			{
				DataType = "DataType",
				Name = "VarName",
				PointerNum = 1
			};
			string actual = variable.ToString();
			string expected = "DataType* VarName";

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Variable")]
		[TestCategory("ToString")]
		public void ToString_test_003()
		{
			Variable variable = new Variable()
			{
				DataType = "DataType",
				Name = "VarName",
				PointerNum = 2
			};
			string actual = variable.ToString();
			string expected = "DataType** VarName";

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Variable")]
		[TestCategory("ToString")]
		public void ToString_test_004()
		{
			Variable variable = new Variable()
			{
				DataType = "DataType",
				Name = "VarName",
				PointerNum = -1
			};
			string actual = variable.ToString();
			string expected = "DataType VarName";

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Variable")]
		[TestCategory("ToString")]
		public void ToString_test_005()
		{
			Variable variable = new Variable()
			{
				DataType = "DataType",
				Name = "VarName",
				PointerNum = 0,
				PreModifiers = new List<string>()
				{
					"const"
				}
			};
			string actual = variable.ToString();
			string expected = "const DataType VarName";

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Variable")]
		[TestCategory("ToString")]
		public void ToString_test_006()
		{
			Variable variable = new Variable()
			{
				DataType = "DataType",
				Name = "VarName",
				PointerNum = 0,
				PreModifiers = new List<string>()
				{
					"static", "const"
				}
			};
			string actual = variable.ToString();
			string expected = "static const DataType VarName";

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Variable")]
		[TestCategory("ToString")]
		public void ToString_test_007()
		{
			Variable variable = new Variable()
			{
				DataType = "DataType",
				Name = "VarName",
				PointerNum = 1,
				PreModifiers = new List<string>()
				{
					"static", "const"
				}
			};
			string actual = variable.ToString();
			string expected = "static const DataType* VarName";

			Assert.AreEqual(expected, actual);
		}
	}
}
