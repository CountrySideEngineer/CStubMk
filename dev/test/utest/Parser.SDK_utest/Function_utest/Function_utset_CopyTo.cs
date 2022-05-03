using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Function_utest
{
	//[TestClass]
	public partial class Function_utset
	{
		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Function")]
		[TestCategory("CopyTo")]
		public void CopyTo_test_001()
		{
			Function src = new Function()
			{
				DataType = "DataType",
				Name = "Function"
			};
			Function dst = new Function();
			src.CopyTo(dst);

			Assert.AreEqual("DataType", dst.DataType);
			Assert.AreEqual("Function", dst.Name);
			Assert.AreEqual(0, dst.Arguments.Count());
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Function")]
		[TestCategory("CopyTo")]
		public void CopyTo_test_002()
		{
			Function src = new Function()
			{
				DataType = "DataType",
				Name = "Function",
				Arguments = new List<Parameter>()
				{
					new Variable()
					{
						DataType = "ArgType1",
						Name = "ArgName1",
						PointerNum = 0
					},
				}
			};
			Function dst = new Function();
			src.CopyTo(dst);

			Assert.AreEqual("DataType", dst.DataType);
			Assert.AreEqual("Function", dst.Name);
			Assert.AreEqual(1, dst.Arguments.Count());
			Assert.AreEqual("ArgType1", dst.Arguments.ElementAt(0).DataType);
			Assert.AreEqual("ArgName1", dst.Arguments.ElementAt(0).Name);
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Function")]
		[TestCategory("CopyTo")]
		public void CopyTo_test_003()
		{
			Function src = new Function()
			{
				DataType = "DataType",
				Name = "Function",
				Arguments = new List<Parameter>()
				{
					new Variable()
					{
						DataType = "ArgType1",
						Name = "ArgName1",
						PointerNum = 0
					},
				}
			};
			Variable dst = new Variable();
			src.CopyTo(dst);

			Assert.AreEqual("DataType", dst.DataType);
			Assert.AreEqual("Function", dst.Name);
			Assert.AreEqual(0, dst.PointerNum);
		}
	}
}
