using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser.SDK.Model;
using System;
using System.Collections.Generic;

namespace Parameter_utest
{
	//[TestClass]
	public partial class Parameter_utest
	{
		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Parameter")]
		[TestCategory("ToString")]
		public void ToString_test_001()
		{
			Parameter parameter = new Parameter()
			{
				DataType = "DataType",
				Name = "ParamName"
			};
			string actual = parameter.ToString();
			string expected = "DataType ParamName";

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Parameter")]
		[TestCategory("ToString")]
		public void ToString_test_002()
		{
			Parameter parameter = new Parameter()
			{
				DataType = "DataType*",
				Name = "ParamName"
			};
			string actual = parameter.ToString();
			string expected = "DataType* ParamName";

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Parameter")]
		[TestCategory("ToString")]
		public void ToString_test_003()
		{
			Parameter parameter = new Parameter()
			{
				DataType = "DataType",
				Name = "*ParamName"
			};
			string actual = parameter.ToString();
			string expected = "DataType *ParamName";

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Parameter")]
		[TestCategory("ToString")]
		public void ToString_test_004()
		{
			Parameter parameter = new Parameter()
			{
				DataType = "DataType",
				Name = "*ParamName"
			};
			string actual = parameter.ToString();
			string expected = "DataType *ParamName";

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Parameter")]
		[TestCategory("ToString")]
		public void ToString_test_005()
		{
			Parameter parameter = new Parameter()
			{
				DataType = "DataType",
				Name = "ParamName",
				PreModifiers = new List<string>()
				{
					"const"
				}
			};
			string actual = parameter.ToString();
			string expected = "const DataType ParamName";

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Parameter")]
		[TestCategory("ToString")]
		public void ToString_test_006()
		{
			Parameter parameter = new Parameter()
			{
				DataType = "DataType",
				Name = "ParamName",
				PreModifiers = new List<string>()
				{
					"static", "const"
				}
			};
			string actual = parameter.ToString();
			string expected = "static const DataType ParamName";

			Assert.AreEqual(expected, actual);
		}
	}
}
