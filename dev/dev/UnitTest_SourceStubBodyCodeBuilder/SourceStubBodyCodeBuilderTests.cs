using System;
using System.Collections.Generic;
using System.Linq;
using CStubMKGui.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest_SourceStubBodyCodeBuilder
{
	[TestClass]
	public class SourceStubBodyCodeBuilderTests
	{
		[TestMethod]
		[TestCategory("Protected")]
		[Description("SetCode")]
		public void SetCode_Test_001()
		{
			string code = "code";
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("SetCode", code, 0);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("code", result.ElementAt(0));
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("SetCode")]
		public void SetCode_Test_002()
		{
			string code = "code";
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("SetCode", code, 1);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("\tcode", result.ElementAt(0));
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("SetCode")]
		public void SetCode_Test_003()
		{
			string code = "code";
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("SetCode", code, 2);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("\t\tcode", result.ElementAt(0));
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateCodeToReturnValueCode")]
		public void CreateCodeToReturnValueCode_Test_001()
		{
			var function = new Param()
			{
				DataType = "DataType"
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateCodeToReturnValueCode", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("\treturn ret_val;", result.ElementAt(0));
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateCodeToReturnValueCode/void(lower scale)")]
		public void CreateCodeToReturnValueCode_Test_002()
		{
			var function = new Param()
			{
				DataType = "void"
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateCodeToReturnValueCode", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateCodeToReturnValueCode/void(upper scale)")]
		public void CreateCodeToReturnValueCode_Test_003()
		{
			var function = new Param()
			{
				DataType = "VOID"
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateCodeToReturnValueCode", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateCodeToReturnValueCode/void(upper/lower scale mixed)")]
		public void CreateCodeToReturnValueCode_Test_004()
		{
			var function = new Param()
			{
				DataType = "Void"
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateCodeToReturnValueCode", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateCodeToReturnValueCode/Empty")]
		public void CreateCodeToReturnValueCode_Test_005()
		{
			var function = new Param()
			{
				DataType = ""
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateCodeToReturnValueCode", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateCodeToReturnValueCode/Empty")]
		public void CreateCodeToReturnValueCode_Test_006()
		{
			var function = new Param()
			{
				DataType = " "
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateCodeToReturnValueCode", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateIncrementCalledCountCode")]
		public void CreateIncrementCalledCountCode_Test_001()
		{
			var function = new Param()
			{
				Name = "function"
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateIncrementCalledCountCode", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("\tfunction_called_count++;", result.ElementAt(0));
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateSetValueToDoublePointerCode")]
		public void CreateSetValueToDoublePointerCode_Test_001()
		{
			var function = new Param()
			{
				Name = "function"
			};
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType"
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateSetValueToDoublePointerCode", function, argument);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("\t*Argument = &function_Argument_value[function_called_count];", result.ElementAt(0));
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateSetValueToPointerCode")]
		public void CreateSetValueToPointerCode_Test_001()
		{
			var function = new Param()
			{
				Name = "function"
			};
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType"
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateSetValueToPointerCode", function, argument);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("\t*Argument = function_Argument_value[function_called_count];", result.ElementAt(0));
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateSetOutputValueCode")]
		public void CreateSetOutputValueCode_Test_001()
		{
			var function = new Param()
			{
				Name = "function"
			};
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType",
				PointerNum = 0
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateSetOutputValueCode", function, argument);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateSetOutputValueCode")]
		public void CreateSetOutputValueCode_Test_002()
		{
			var function = new Param()
			{
				Name = "function"
			};
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType",
				PointerNum = 1
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateSetOutputValueCode", function, argument);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("\t*Argument = function_Argument_value[function_called_count];", result.ElementAt(0));
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateSetOutputValueCode")]
		public void CreateSetOutputValueCode_Test_003()
		{
			var function = new Param()
			{
				Name = "function"
			};
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType",
				PointerNum = 2
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateSetOutputValueCode", function, argument);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("\t*Argument = &function_Argument_value[function_called_count];", result.ElementAt(0));
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateSetOutputValueCode")]
		[ExpectedException(typeof(NotSupportedException))]
		public void CreateSetOutputValueCode_Test_004()
		{
			var function = new Param()
			{
				Name = "function"
			};
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType",
				PointerNum = 3
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateSetOutputValueCode", function, argument);
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateStoreArgumentCode")]
		public void CreateStoreArgumentCode_Test_001()
		{
			var function = new Param()
			{
				Name = "function"
			};
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType",
				PointerNum = 3
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateStoreArgumentCode", function, argument);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("\tfunction_Argument[function_called_count] = Argument;", result.ElementAt(0));
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateStoreArgumentCode")]
		public void CreateStoreArgumentCode_Test_002()
		{
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType"
			};
			var function = new Param()
			{
				Name = "function",
				Parameters = new List<Param>() { argument }
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateStoreArgumentCode", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("\tfunction_Argument[function_called_count] = Argument;", result.ElementAt(0));
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateStoreArgumentCode")]
		public void CreateStoreArgumentCode_Test_003()
		{
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType",
				PointerNum = 1
			};
			var function = new Param()
			{
				Name = "function",
				Parameters = new List<Param>() { argument }
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateStoreArgumentCode", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(2, result.Count());
			Assert.AreEqual("\tfunction_Argument[function_called_count] = Argument;", result.ElementAt(0));
			Assert.AreEqual("\t*Argument = function_Argument_value[function_called_count];", result.ElementAt(1));
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateStoreArgumentCode")]
		public void CreateStoreArgumentCode_Test_004()
		{
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType",
				PointerNum = 2
			};
			var function = new Param()
			{
				Name = "function",
				Parameters = new List<Param>() { argument }
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateStoreArgumentCode", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(2, result.Count());
			Assert.AreEqual("\tfunction_Argument[function_called_count] = Argument;", result.ElementAt(0));
			Assert.AreEqual("\t*Argument = &function_Argument_value[function_called_count];", result.ElementAt(1));
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateStoreArgumentCode")]
		public void CreateStoreArgumentCode_Test_005()
		{
			var function = new Param()
			{
				Name = "function",
				Parameters = null
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateStoreArgumentCode", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateRetValLatchCode")]
		public void CreateRetValLatchCode_Test_001()
		{
			var function = new Param()
			{
				Name = "function",
				DataType = "DataType"
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateRetValLatchCode", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("\tint ret_val = function_ret_val[function_called_count];", result.ElementAt(0));
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateRetValLatchCode")]
		public void CreateRetValLatchCode_Test_002()
		{
			var function = new Param()
			{
				Name = "function",
				DataType = "DataType",
				PointerNum = 1
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateRetValLatchCode", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("\tint* ret_val = function_ret_val[function_called_count];", result.ElementAt(0));
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateRetValLatchCode")]
		public void CreateRetValLatchCode_Test_003()
		{
			var function = new Param()
			{
				Name = "function",
				DataType = "DataType",
				PointerNum = 2
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateRetValLatchCode", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("\tint** ret_val = function_ret_val[function_called_count];", result.ElementAt(0));
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateRetValLatchCode")]
		public void CreateRetValLatchCode_Test_004()
		{
			var function = new Param()
			{
				Name = "function",
				DataType = "void"
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateRetValLatchCode", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateRetValLatchCode")]
		public void CreateRetValLatchCode_Test_005()
		{
			var function = new Param()
			{
				Name = "function",
				DataType = "VOID"
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateRetValLatchCode", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateRetValLatchCode")]
		public void CreateRetValLatchCode_Test_006()
		{
			var function = new Param()
			{
				Name = "function",
				DataType = ""
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateRetValLatchCode", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateRetValLatchCode")]
		public void CreateRetValLatchCode_Test_007()
		{
			var function = new Param()
			{
				Name = "function",
				DataType = " "
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateRetValLatchCode", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateRetValLatchCode")]
		public void CreateRetValLatchCode_Test_008()
		{
			var function = new Param()
			{
				Name = "function",
				DataType = "\t"
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateRetValLatchCode", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateRetValLatchCode")]
		public void CreateRetValLatchCode_Test_009()
		{
			var function = new Param()
			{
				Name = "function",
				DataType = "\t "
			};
			var builder = new SourceStubBodyCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateRetValLatchCode", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		[TestCategory("public")]
		[Description("CreateCode")]
		public void CreateCode_Test_001()
		{
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType"
			};
			var function = new Param()
			{
				Name = "function",
				DataType = "DataType",
				Parameters = new List<Param> { argument }
			};
			var builder = new SourceStubBodyCodeBuilder();
			builder.CreateCode(function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(6, result.Count());
			Assert.AreEqual("{", result.ElementAt(0));
			Assert.AreEqual("\tint ret_val = function_ret_val[function_called_count];", result.ElementAt(1));
			Assert.AreEqual("\tfunction_Argument[function_called_count] = Argument;", result.ElementAt(2));
			Assert.AreEqual("\tfunction_called_count++;", result.ElementAt(3));
			Assert.AreEqual("\treturn ret_val;", result.ElementAt(4));
			Assert.AreEqual("}", result.ElementAt(5));
		}

		[TestMethod]
		[TestCategory("public")]
		[Description("CreateCode")]
		public void CreateCode_Test_002()
		{
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType"
			};
			var function = new Param()
			{
				Name = "function",
				DataType = "void",
				Parameters = new List<Param> { argument }
			};
			var builder = new SourceStubBodyCodeBuilder();
			builder.CreateCode(function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(4, result.Count());
			Assert.AreEqual("{", result.ElementAt(0));
			Assert.AreEqual("\tfunction_Argument[function_called_count] = Argument;", result.ElementAt(1));
			Assert.AreEqual("\tfunction_called_count++;", result.ElementAt(2));
			Assert.AreEqual("}", result.ElementAt(3));
		}

		[TestMethod]
		[TestCategory("public")]
		[Description("CreateCode")]
		public void CreateCode_Test_003()
		{
			var argument1 = new Param()
			{
				Name = "Argument1",
				DataType = "DataType1"
			};
			var argument2 = new Param()
			{
				Name = "Argument2",
				DataType = "DataType2"
			};
			var function = new Param()
			{
				Name = "function",
				DataType = "void",
				Parameters = new List<Param> { argument1, argument2 }
			};
			var builder = new SourceStubBodyCodeBuilder();
			builder.CreateCode(function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(5, result.Count());
			Assert.AreEqual("{", result.ElementAt(0));
			Assert.AreEqual("\tfunction_Argument1[function_called_count] = Argument1;", result.ElementAt(1));
			Assert.AreEqual("\tfunction_Argument2[function_called_count] = Argument2;", result.ElementAt(2));
			Assert.AreEqual("\tfunction_called_count++;", result.ElementAt(3));
			Assert.AreEqual("}", result.ElementAt(4));
		}

		[TestMethod]
		[TestCategory("public")]
		[Description("CreateCode")]
		public void CreateCode_Test_004()
		{
			var argument1 = new Param()
			{
				Name = "Argument1",
				DataType = "DataType1"
			};
			var argument2 = new Param()
			{
				Name = "Argument2",
				DataType = "DataType2"
			};
			var function = new Param()
			{
				Name = "function",
				DataType = "DataType",
				Parameters = new List<Param> { argument1, argument2 }
			};
			var builder = new SourceStubBodyCodeBuilder();
			builder.CreateCode(function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(7, result.Count());
			Assert.AreEqual("{", result.ElementAt(0));
			Assert.AreEqual("\tint ret_val = function_ret_val[function_called_count];", result.ElementAt(1));
			Assert.AreEqual("\tfunction_Argument1[function_called_count] = Argument1;", result.ElementAt(2));
			Assert.AreEqual("\tfunction_Argument2[function_called_count] = Argument2;", result.ElementAt(3));
			Assert.AreEqual("\tfunction_called_count++;", result.ElementAt(4));
			Assert.AreEqual("\treturn ret_val;", result.ElementAt(5));
			Assert.AreEqual("}", result.ElementAt(6));
		}

		[TestMethod]
		[TestCategory("public")]
		[Description("CreateCode")]
		public void CreateCode_Test_005()
		{
			int function = 0;
			var builder = new SourceStubBodyCodeBuilder();
			builder.CreateCode(function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		[TestCategory("public")]
		[Description("CreateCode")]
		[ExpectedException(typeof(ArgumentNullException))]
		public void CreateCode_Test_006()
		{
			var builder = new SourceStubBodyCodeBuilder();
			builder.CreateCode(null);
		}
	}
}
