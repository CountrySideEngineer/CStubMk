using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser.SDK.Exception;
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
		[TestCategory("Validate")]
		public void Validate_test_001()
		{
			Function function = new Function()
			{
				DataType = "DataType",
				Name = "Function"
			};
			function.Validate();
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Function")]
		[TestCategory("Validate")]
		public void Validate_test_002()
		{
			Function function = new Function()
			{
				DataType = "void",
				Name = "Function"
			};
			function.Validate();
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Function")]
		[TestCategory("Validate")]
		public void Validate_test_003()
		{
			Function function = new Function()
			{
				DataType = "void",
				Name = "Function",
				PointerNum = 1
			};
			function.Validate();
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Function")]
		[TestCategory("Validate")]
		public void Validate_test_004()
		{
			Function function = new Function()
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
			function.Validate();
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Function")]
		[TestCategory("Validate")]
		public void Validate_test_005()
		{
			try
			{
				Function function = new Function()
				{
					DataType = "DataType",
					Name = "Function",
					Arguments = new List<Parameter>()
				{
					new Variable()
					{
						DataType = "void"
					},
					new Variable()
					{
						DataType = "void",
						Name = "Argument2"
					},
				}
				};
				function.Validate();

				Assert.Fail();
			}
			catch (ParameterException ex)
			{
				Assert.AreEqual(ParserError.INVALID_DATA_TYPE_VOID, ex.Code);
			}
			catch (Exception)
			{
				Assert.Fail();
			}
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Function")]
		[TestCategory("Validate")]
		public void Validate_test_006()
		{
			Function function = new Function()
			{
				DataType = "DataType",
				Name = "Function",
				Arguments = new List<Parameter>()
				{
					new Variable()
					{
						DataType = "void"
					},
					new Variable()
					{
						DataType = "void",
						Name = "Argument2",
						PointerNum = 1,
					},
				}
			};
			function.Validate();
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Function")]
		[TestCategory("Validate")]
		public void Validate_test_007()
		{
			try
			{
				Function function = new Function()
				{
					DataType = "DataType",
					Name = "Function",
					Arguments = new List<Parameter>()
					{
						new Variable()
						{
							DataType = "void",
							Name = "Argument1",
							PointerNum = 1,
						},
						new Variable()
						{
							DataType = "void",
						},
					}
				};
				function.Validate();
			}
			catch (ParameterException ex)
			{
				Assert.AreEqual(ParserError.INVALID_DATA_TYPE_VOID, ex.Code);
			}
		}
	}
}
