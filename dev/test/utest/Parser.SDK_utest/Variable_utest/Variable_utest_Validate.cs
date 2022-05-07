using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser.SDK.Exception;
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
		[TestCategory("Validate")]
		public void Validate_test_001()
		{
			try
			{
				Variable variable = new Variable()
				{
					DataType = "void",
					Name = "VariableName",
					PointerNum = 0
				};
				variable.Validate();
				Assert.Fail();
			}
			catch (ParameterException ex)
			{
				Assert.AreEqual(ParserError.INVALID_DATA_TYPE_VOID, ex.Code);
			}
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Variable")]
		[TestCategory("Validate")]
		public void Validate_test_002()
		{
			Variable variable = new Variable()
			{
				DataType = "void",
				Name = "VariableName",
				PointerNum = 1
			};
			variable.Validate();
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Variable")]
		[TestCategory("Validate")]
		public void Validate_test_003()
		{
			try
			{
				Variable variable = new Variable()
				{
					DataType = "",
					Name = "VariableName",
					PointerNum = 1
				};
				variable.Validate();
			}
			catch (ParameterException ex)
			{
				Assert.AreEqual(ParserError.DATA_TYPE_EMPTY, ex.Code);
			}
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Variable")]
		[TestCategory("Validate")]
		public void Validate_test_004()
		{
			try
			{
				Variable variable = new Variable()
				{
					DataType = "",
					Name = "VariableName",
					PointerNum = 1
				};
				variable.Validate();
			}
			catch (ParameterException ex)
			{
				Assert.AreEqual(ParserError.DATA_TYPE_EMPTY, ex.Code);
			}
		}

		[TestMethod]
		[TestCategory("Parser.SDK")]
		[TestCategory("Variable")]
		[TestCategory("Validate")]
		public void Validate_test_005()
		{
			try
			{
				Variable variable = new Variable()
				{
					DataType = "DataType",
					Name = "VariableName",
					PointerNum = -1
				};
				variable.Validate();
			}
			catch (ParameterException ex)
			{
				Assert.AreEqual(ParserError.INVALID_POINTER_LEVEL, ex.Code);
			}
		}
	}
}
