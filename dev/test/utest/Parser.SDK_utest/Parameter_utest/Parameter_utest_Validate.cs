using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser.SDK.Exception;
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
		[TestCategory("Validate")]
		public void Validate_test_001()
		{
			Parameter parameter = new Parameter()
			{
				DataType = "DataType",
				Name = "ParamName"
			};
			parameter.Validate();

			Assert.IsTrue(true);
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Parameter")]
		[TestCategory("Validate")]
		public void Validate_test_002()
		{
			Parameter parameter = new Parameter()
			{
				DataType = "DataType",
				Name = string.Empty
			};
			try
			{
				parameter.Validate();

				Assert.Fail();
			}
			catch (ParameterException ex)
			{
				Assert.AreEqual(ParserError.NAME_EMPTY, ex.Code);
			}
			catch (Exception)
			{
				Assert.Fail();
			}
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Parameter")]
		[TestCategory("Validate")]
		public void Validate_test_003()
		{
			Parameter parameter = new Parameter()
			{
				DataType = "DataType",
				Name = " "
			};
			try
			{
				parameter.Validate();

				Assert.Fail();
			}
			catch (ParameterException ex)
			{
				Assert.AreEqual(ParserError.NAME_EMPTY, ex.Code);
			}
			catch (Exception)
			{
				Assert.Fail();
			}
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Parameter")]
		[TestCategory("Validate")]
		public void Validate_test_004()
		{
			Parameter parameter = new Parameter()
			{
				DataType = "DataType",
				Name = null
			};
			try
			{
				parameter.Validate();

				Assert.Fail();
			}
			catch (ParameterException ex)
			{
				Assert.AreEqual(ParserError.NAME_EMPTY, ex.Code);
			}
			catch (Exception)
			{
				Assert.Fail();
			}
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Parameter")]
		[TestCategory("Validate")]
		public void Validate_test_005()
		{
			Parameter parameter = new Parameter()
			{
				DataType = "DataType",
				Name = ""
			};
			try
			{
				parameter.Validate();

				Assert.Fail();
			}
			catch (ParameterException ex)
			{
				Assert.AreEqual(ParserError.NAME_EMPTY, ex.Code);
			}
			catch (Exception)
			{
				Assert.Fail();
			}
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Parameter")]
		[TestCategory("Validate")]
		public void Validate_test_006()
		{
			Parameter parameter = new Parameter()
			{
				DataType = string.Empty,
				Name = "ParamName"
			};
			try
			{
				parameter.Validate();

				Assert.Fail();
			}
			catch (ParameterException ex)
			{
				Assert.AreEqual(ParserError.DATA_TYPE_EMPTY, ex.Code);
			}
			catch (Exception)
			{
				Assert.Fail();
			}
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Parameter")]
		[TestCategory("Validate")]
		public void Validate_test_007()
		{
			Parameter parameter = new Parameter()
			{
				DataType = " ",
				Name = "ParamName"
			};
			try
			{
				parameter.Validate();

				Assert.Fail();
			}
			catch (ParameterException ex)
			{
				Assert.AreEqual(ParserError.DATA_TYPE_EMPTY, ex.Code);
			}
			catch (Exception)
			{
				Assert.Fail();
			}
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Parameter")]
		[TestCategory("Validate")]
		public void Validate_test_008()
		{
			Parameter parameter = new Parameter()
			{
				DataType = null,
				Name = "ParamName"
			};
			try
			{
				parameter.Validate();

				Assert.Fail();
			}
			catch (ParameterException ex)
			{
				Assert.AreEqual(ParserError.DATA_TYPE_EMPTY, ex.Code);
			}
			catch (Exception)
			{
				Assert.Fail();
			}
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Parameter")]
		[TestCategory("Validate")]
		public void Validate_test_009()
		{
			Parameter parameter = new Parameter()
			{
				DataType = null,
				Name = "ParamName"
			};
			try
			{
				parameter.Validate();

				Assert.Fail();
			}
			catch (ParameterException ex)
			{
				Assert.AreEqual(ParserError.DATA_TYPE_EMPTY, ex.Code);
			}
			catch (Exception)
			{
				Assert.Fail();
			}
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Parameter")]
		[TestCategory("Validate")]
		public void Validate_test_010()
		{
			Parameter parameter = new Parameter()
			{
				DataType = "void",
				Name = "ParamName"
			};
			try
			{
				parameter.Validate();

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
		[TestCategory("Parameter")]
		[TestCategory("Validate")]
		public void Validate_test_011()
		{
			Parameter parameter = new Parameter()
			{
				DataType = "void",
				Name = ""
			};
			parameter.Validate();
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Parameter")]
		[TestCategory("Validate")]
		public void Validate_test_012()
		{
			Parameter parameter = new Parameter()
			{
				DataType = "void",
				Name = null
			};
			parameter.Validate();
		}
	}
}
