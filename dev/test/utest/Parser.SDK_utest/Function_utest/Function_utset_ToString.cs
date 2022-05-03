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
		[TestCategory("ToString")]
		public void ToSting_test_001()
		{
			Function src = new Function()
			{
				DataType = "DataType",
				Name = "Function"
			};
			string toSting = src.ToString();

			Assert.AreEqual("DataType Function()", toSting);
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Function")]
		[TestCategory("ToString")]
		public void ToSting_test_002()
		{
			Function src = new Function()
			{
				DataType = "DataType",
				Name = "Function",
				PreModifiers = new List<string>()
				{
					"static", "const"
				}
			};
			string toSting = src.ToString();

			Assert.AreEqual("static const DataType Function()", toSting);
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Function")]
		[TestCategory("ToString")]
		public void ToSting_test_003()
		{
			Function src = new Function()
			{
				DataType = "DataType",
				Name = "Function",
				Arguments = new List<Parameter>()
				{
					new Variable()
					{
						DataType = "int",
						Name = "Argument1"
					}
				}
			};
			string toSting = src.ToString();

			Assert.AreEqual("DataType Function(int Argument1)", toSting);
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Function")]
		[TestCategory("ToString")]
		public void ToSting_test_004()
		{
			Function src = new Function()
			{
				DataType = "DataType",
				Name = "Function",
				Arguments = new List<Parameter>()
				{
					new Variable()
					{
						DataType = "int",
						Name = "Argument1"
					},
					new Variable()
					{
						DataType = "short",
						Name = "Argument2",
						PointerNum = 1
					}
				}
			};
			string toSting = src.ToString();

			Assert.AreEqual("DataType Function(int Argument1, short* Argument2)", toSting);
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Function")]
		[TestCategory("ToString")]
		public void ToSting_test_005()
		{
			Function src = new Function()
			{
				DataType = "DataType",
				Name = "Function",
				Arguments = new List<Parameter>()
				{
					new Variable()
					{
						DataType = "int",
						Name = "Argument1"
					},
					new Variable()
					{
						DataType = "short",
						Name = "Argument2",
						PointerNum = 1
					},
					new Variable()
					{
						DataType = "long",
						Name = "Argument3",
						PointerNum = 2
					}
				}
			};
			string toSting = src.ToString();

			Assert.AreEqual("DataType Function(int Argument1, short* Argument2, long** Argument3)", toSting);
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Function")]
		[TestCategory("ToString")]
		public void ToSting_test_006()
		{
			Function src = new Function()
			{
				DataType = "DataType",
				Name = "Function",
				Arguments = new List<Parameter>()
				{
					new Variable()
					{
						DataType = "void"
					}
				}
			};
			string toSting = src.ToString();

			Assert.AreEqual("DataType Function(void)", toSting);
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Function")]
		[TestCategory("ToString")]
		public void ToSting_test_007()
		{
			Function src = new Function()
			{
				DataType = "DataType",
				Name = "Function",
				Arguments = new List<Parameter>()
				{
					new Variable()
					{
						DataType = "int",
						Name = "Argument1"
					},
					new Variable()
					{
						DataType = "void",
					},
				}
			};
			string toSting = src.ToString();

			Assert.AreEqual("DataType Function(int Argument1, void)", toSting);
		}
	}
}
