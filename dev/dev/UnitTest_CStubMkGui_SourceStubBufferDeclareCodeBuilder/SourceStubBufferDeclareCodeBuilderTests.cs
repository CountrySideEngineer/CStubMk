using System;
using System.Collections.Generic;
using System.Linq;
using CStubMKGui.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest_SourceStubBufferDeclareCodeBuilder_Test
{
	[TestClass]
	public class SourceStubBufferDeclareCodeBuilderTests
	{
		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateCalledCounter")]
		public void CreateCalledCounter_Test_001()
		{
			var param = new Param()
			{
				Name = "Function"
			};
			var builder = new SourceStubBufferDeclareCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateCalledCounter", param);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("int Function_called_count = 0;", result.First());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateBufferDeclare, not pointer")]
		public void CreateBufferDeclare_Test_001()
		{
			var function = new Param()
			{
				Name = "Function"
			};
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType"
			};
			var builder = new SourceStubBufferDeclareCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateBufferDeclare", function, argument);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("DataType Function_Argument[STUB_BUFFER_SIZE];", result.First());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateBufferDeclare/pointer")]
		public void CreateBufferDeclare_Test_002()
		{
			var function = new Param()
			{
				Name = "Function"
			};
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType",
				PointerNum = 1
			};
			var builder = new SourceStubBufferDeclareCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateBufferDeclare", function, argument);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("DataType* Function_Argument[STUB_BUFFER_SIZE];", result.First());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateBufferDeclare/double pointer")]
		public void CreateBufferDeclare_Test_003()
		{
			var function = new Param()
			{
				Name = "Function"
			};
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType",
				PointerNum = 2
			};
			var builder = new SourceStubBufferDeclareCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateBufferDeclare", function, argument);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("DataType** Function_Argument[STUB_BUFFER_SIZE];", result.First());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateBufferForOutputDeclare")]
		public void CreateBufferForOutputDeclare_Test_001()
		{
			var function = new Param()
			{
				Name = "Function"
			};
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType",
				PointerNum = 0,
				Mode = Param.AccessMode.Out
			};
			var builder = new SourceStubBufferDeclareCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateBufferForOutputDeclare", function, argument);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("DataType Function_Argument_value;", result.First());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateBufferForOutputDeclare/pointer")]
		public void CreateBufferForOutputDeclare_Test_002()
		{
			var function = new Param()
			{
				Name = "Function"
			};
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType",
				PointerNum = 1,
				Mode = Param.AccessMode.Out
			};
			var builder = new SourceStubBufferDeclareCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateBufferForOutputDeclare", function, argument);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("DataType Function_Argument_value[STUB_BUFFER_SIZE];", result.First());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateBufferForOutputDeclare/double pointer")]
		public void CreateBufferForOutputDeclare_Test_003()
		{
			var function = new Param()
			{
				Name = "Function"
			};
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType",
				PointerNum = 2,
				Mode = Param.AccessMode.Out
			};
			var builder = new SourceStubBufferDeclareCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateBufferForOutputDeclare", function, argument);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("DataType Function_Argument_value[STUB_BUFFER_SIZE][STUB_BUFFER_SIZE];", result.First());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateBufferForOutputDeclare/not output")]
		public void CreateBufferForOutputDeclare_Test_004()
		{
			var function = new Param()
			{
				Name = "Function"
			};
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType",
				PointerNum = 2,
				Mode = Param.AccessMode.Both
			};
			var builder = new SourceStubBufferDeclareCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateBufferForOutputDeclare", function, argument);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateBufferForOutputDeclare/not output")]
		public void CreateBufferForOutputDeclare_Test_005()
		{
			var function = new Param()
			{
				Name = "Function"
			};
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType",
				PointerNum = 2,
				Mode = Param.AccessMode.In
			};
			var builder = new SourceStubBufferDeclareCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateBufferForOutputDeclare", function, argument);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateBufferForOutputDeclare/not output")]
		public void CreateBufferForOutputDeclare_Test_006()
		{
			var function = new Param()
			{
				Name = "Function"
			};
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType",
				PointerNum = 2,
				Mode = Param.AccessMode.None
			};
			var builder = new SourceStubBufferDeclareCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateBufferForOutputDeclare", function, argument);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateBufferForOutputDeclare")]
		public void CreateReturnValueBufferDeclare_Test_001()
		{
			var function = new Param()
			{
				Name = "Function",
				DataType = "DataType"
			};
			var builder = new SourceStubBufferDeclareCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateReturnValueBufferDeclare", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("DataType Function_ret_val[STUB_BUFFER_SIZE];", result.First());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateBufferForOutputDeclare/pointer")]
		public void CreateReturnValueBufferDeclare_Test_002()
		{
			var function = new Param()
			{
				Name = "Function",
				DataType = "DataType",
				PointerNum = 1
			};
			var builder = new SourceStubBufferDeclareCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateReturnValueBufferDeclare", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("DataType* Function_ret_val[STUB_BUFFER_SIZE];", result.First());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateBufferForOutputDeclare/double pointer")]
		public void CreateReturnValueBufferDeclare_Test_003()
		{
			var function = new Param()
			{
				Name = "Function",
				DataType = "DataType",
				PointerNum = 2
			};
			var builder = new SourceStubBufferDeclareCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateReturnValueBufferDeclare", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("DataType** Function_ret_val[STUB_BUFFER_SIZE];", result.First());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateBufferForOutputDeclare/void")]
		public void CreateReturnValueBufferDeclare_Test_004()
		{
			var function = new Param()
			{
				Name = "Function",
				DataType = "void",
				PointerNum = 2
			};
			var builder = new SourceStubBufferDeclareCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateReturnValueBufferDeclare", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateBufferForOutputDeclare/VOID")]
		public void CreateReturnValueBufferDeclare_Test_005()
		{
			var function = new Param()
			{
				Name = "Function",
				DataType = "VOID",
				PointerNum = 2
			};
			var builder = new SourceStubBufferDeclareCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateReturnValueBufferDeclare", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		[TestCategory("public")]
		[Description("CreateCode")]
		public void CreateCode_Test_001()
		{
			var function = new Param()
			{
				Name = "Function",
				DataType = "DataType",
			};
			var builder = new SourceStubBufferDeclareCodeBuilder();
			builder.CreateCode(function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(2, result.Count());
			Assert.AreEqual("int Function_called_count = 0;", result.ElementAt(0));
			Assert.AreEqual("DataType Function_ret_val[STUB_BUFFER_SIZE];", result.ElementAt(1));
		}

		[TestMethod]
		[TestCategory("public")]
		[Description("CreateCode")]
		public void CreateCode_Test_002()
		{
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "ArgType",
				Mode = Param.AccessMode.In
			};
			var function = new Param()
			{
				Name = "Function",
				DataType = "DataType",
			};
			function.Parameters = new List<Param>() { argument };
			var builder = new SourceStubBufferDeclareCodeBuilder();
			builder.CreateCode(function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(3, result.Count());
			Assert.AreEqual("int Function_called_count = 0;", result.ElementAt(0));
			Assert.AreEqual("ArgType Function_Argument[STUB_BUFFER_SIZE];", result.ElementAt(1));
			Assert.AreEqual("DataType Function_ret_val[STUB_BUFFER_SIZE];", result.ElementAt(2));
		}

		[TestMethod]
		[TestCategory("public")]
		[Description("CreateCode/not parameter")]
		public void CreateCode_Test_003()
		{
			int codeSrc = 0;
			var builder = new SourceStubBufferDeclareCodeBuilder();
			builder.CreateCode(codeSrc);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		[TestCategory("public")]
		[Description("CreateCode/null")]
		[ExpectedException(typeof(ArgumentNullException))]
		public void CreateCode_Test_004()
		{
			var builder = new SourceStubBufferDeclareCodeBuilder();
			builder.CreateCode(null);
		}
	}
}
