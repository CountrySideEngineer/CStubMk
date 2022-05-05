using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Parameter_utest
{
	//[TestClass]
	public partial class Parameter_utest
	{
		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Parameter")]
		[TestCategory("CopyTo")]
		public void CopyTo_test_001()
		{
			Parameter parameter = new Parameter()
			{
				DataType = "DataType",
				Name = "ParamName"
			};
			Parameter dst = new Parameter();
			parameter.CopyTo(dst);

			Assert.AreEqual("DataType", dst.DataType);
			Assert.AreEqual("ParamName", dst.Name);
			Assert.AreEqual(0, dst.PreModifiers.Count());
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Parameter")]
		[TestCategory("CopyTo")]
		public void CopyTo_test_002()
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
			Parameter dst = new Parameter();
			parameter.CopyTo(dst);

			Assert.AreEqual("DataType", dst.DataType);
			Assert.AreEqual("ParamName", dst.Name);
			Assert.AreEqual(1, dst.PreModifiers.Count());
			Assert.AreEqual("const", dst.PreModifiers.ElementAt(0));
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Parameter")]
		[TestCategory("CopyTo")]
		public void CopyTo_test_003()
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
			Parameter dst = new Parameter();
			parameter.CopyTo(dst);

			Assert.AreEqual("DataType", dst.DataType);
			Assert.AreEqual("ParamName", dst.Name);
			Assert.AreEqual(2, dst.PreModifiers.Count());
			Assert.AreEqual("static", dst.PreModifiers.ElementAt(0));
			Assert.AreEqual("const", dst.PreModifiers.ElementAt(1));
		}
	}
}
