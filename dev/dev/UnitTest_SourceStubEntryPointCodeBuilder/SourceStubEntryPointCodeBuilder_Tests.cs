using System;
using System.Collections.Generic;
using System.Linq;
using CStubMKGui.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest_SourceStubEntryPointCodeBuilder_Test
{
	[TestClass]
	public class SourceStubEntryPointCodeBuilder_Tests
	{
		[TestMethod]
		[TestCategory("Protected")]
		[Description("GetArgumentDeclare/no pointer")]
		public void GetArgumentDeclare_Test_001()
		{
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType"
			};
			var builder = new SourceStubEntryPointCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			var result = (string)privateBuilder.Invoke("GetArgumentDeclare", argument);

			Assert.AreEqual("DataType Argument", result);

		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("GetArgumentDeclare/pointer")]
		public void GetArgumentDeclare_Test_002()
		{
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType",
				PointerNum = 1
			};
			var builder = new SourceStubEntryPointCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			var result = (string)privateBuilder.Invoke("GetArgumentDeclare", argument);

			Assert.AreEqual("DataType* Argument", result);
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("GetArgumentDeclare/double pointer")]
		public void GetArgumentDeclare_Test_003()
		{
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType",
				PointerNum = 2
			};
			var builder = new SourceStubEntryPointCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			var result = (string)privateBuilder.Invoke("GetArgumentDeclare", argument);

			Assert.AreEqual("DataType** Argument", result);
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("GetArgumentDeclare/prefix")]
		public void GetArgumentDeclare_Test_004()
		{
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType",
				Prefix = "prefix"
			};
			var builder = new SourceStubEntryPointCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			var result = (string)privateBuilder.Invoke("GetArgumentDeclare", argument);

			Assert.AreEqual("prefix DataType Argument", result);
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("GetArgumentDeclare/postfix")]
		public void GetArgumentDeclare_Test_005()
		{
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType",
				Postifx = "postfix"
			};
			var builder = new SourceStubEntryPointCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			var result = (string)privateBuilder.Invoke("GetArgumentDeclare", argument);

			Assert.AreEqual("DataType postfix Argument", result);
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("GetArgumentDeclare/pointer and postfix")]
		public void GetArgumentDeclare_Test_006()
		{
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType",
				PointerNum = 1,
				Postifx = "postfix"
			};
			var builder = new SourceStubEntryPointCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			var result = (string)privateBuilder.Invoke("GetArgumentDeclare", argument);

			Assert.AreEqual("DataType* postfix Argument", result);
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateArgumentDeclare/one argument")]
		public void CreateArgumentDeclare_Test_001()
		{
			var argument = new Param()
			{
				Name = "Argument",
				DataType = "DataType"
			};
			var function = new Param()
			{
				Parameters = new List<Param>() { argument }
			};
			var builder = new SourceStubEntryPointCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateArgumentDeclare", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("\tDataType Argument", result.ElementAt(0));
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateArgumentDeclare/two argument")]
		public void CreateArgumentDeclare_Test_002()
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
				Parameters = new List<Param>()
					{
						argument1,
						argument2
					}
			};
			var builder = new SourceStubEntryPointCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateArgumentDeclare", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(2, result.Count());
			Assert.AreEqual("\tDataType1 Argument1", result.ElementAt(0));
			Assert.AreEqual("\t, DataType2 Argument2", result.ElementAt(1));
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateArgumentDeclare/no argument(NULL)")]
		public void CreateArgumentDeclare_Test_003()
		{
			var function = new Param();
			var builder = new SourceStubEntryPointCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateArgumentDeclare", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateArgumentDeclare/no argument(NOT NULL)")]
		public void CreateArgumentDeclare_Test_004()
		{
			var function = new Param()
			{
				Parameters = new List<Param>()
			};
			var builder = new SourceStubEntryPointCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateArgumentDeclare", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateEntryPoint")]
		public void CreateEntryPoint_Test_001()
		{
			var function = new Param()
			{
				DataType = "DataType",
				Name = "Function"
			};
			var builder = new SourceStubEntryPointCodeBuilder();
			var privateBuilder = new PrivateObject(builder);
			privateBuilder.Invoke("CreateEntryPoint", function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(1, result.Count());
			Assert.AreEqual("DataType Function", result.ElementAt(0));
		}

		[TestMethod]
		[TestCategory("CreateCode")]
		[Description("CreateCode/One argument")]
		public void CreateCode_Test_001()
		{
			var argument = new Param()
			{
				DataType = "ArgDataType",
				Name = "Arg1"
			};
			var function = new Param()
			{
				DataType = "DataType",
				Name = "Function",
				Parameters = new List<Param> { argument }
			};
			var builder = new SourceStubEntryPointCodeBuilder();
			builder.CreateCode(function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(4, result.Count());
			Assert.AreEqual("DataType Function", result.ElementAt(0));
			Assert.AreEqual("(", result.ElementAt(1));
			Assert.AreEqual("\tArgDataType Arg1", result.ElementAt(2));
			Assert.AreEqual(")", result.ElementAt(3));
		}

		[TestMethod]
		[TestCategory("CreateCode")]
		[Description("CreateCode/two arguments")]
		public void CreateCode_Test_002()
		{
			var argument1 = new Param()
			{
				DataType = "ArgDataType",
				Name = "Arg1"
			};
			var argument2 = new Param()
			{
				DataType = "ArgDataType",
				Name = "Arg2"
			};
			var function = new Param()
			{
				DataType = "DataType",
				Name = "Function",
				Parameters = new List<Param> { argument1, argument2 }
			};
			var builder = new SourceStubEntryPointCodeBuilder();
			builder.CreateCode(function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(5, result.Count());
			Assert.AreEqual("DataType Function", result.ElementAt(0));
			Assert.AreEqual("(", result.ElementAt(1));
			Assert.AreEqual("\tArgDataType Arg1", result.ElementAt(2));
			Assert.AreEqual("\t, ArgDataType Arg2", result.ElementAt(3));
			Assert.AreEqual(")", result.ElementAt(4));
		}

		[TestMethod]
		[TestCategory("CreateCode")]
		[Description("CreateCode/three arguments")]
		public void CreateCode_Test_003()
		{
			var argument1 = new Param()
			{
				DataType = "ArgDataType",
				Name = "Arg1"
			};
			var argument2 = new Param()
			{
				DataType = "ArgDataType",
				Name = "Arg2"
			};
			var argument3 = new Param()
			{
				DataType = "ArgDataType",
				Name = "Arg3"
			};
			var function = new Param()
			{
				DataType = "DataType",
				Name = "Function",
				Parameters = new List<Param> { argument1, argument2, argument3 }
			};
			var builder = new SourceStubEntryPointCodeBuilder();
			builder.CreateCode(function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(6, result.Count());
			Assert.AreEqual("DataType Function", result.ElementAt(0));
			Assert.AreEqual("(", result.ElementAt(1));
			Assert.AreEqual("\tArgDataType Arg1", result.ElementAt(2));
			Assert.AreEqual("\t, ArgDataType Arg2", result.ElementAt(3));
			Assert.AreEqual("\t, ArgDataType Arg3", result.ElementAt(4));
			Assert.AreEqual(")", result.ElementAt(5));
		}

		[TestMethod]
		[TestCategory("CreateCode")]
		[Description("CreateCode/no argument")]
		public void CreateCode_Test_004()
		{
			var function = new Param()
			{
				DataType = "DataType",
				Name = "Function"
			};
			var builder = new SourceStubEntryPointCodeBuilder();
			builder.CreateCode(function);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(3, result.Count());
			Assert.AreEqual("DataType Function", result.ElementAt(0));
			Assert.AreEqual("(", result.ElementAt(1));
			Assert.AreEqual(")", result.ElementAt(2));
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateCode/Invalid")]
		public void CreateCode_Test_005()
		{
			int codeSrc = 0;
			var builder = new SourceStubEntryPointCodeBuilder();
			builder.CreateCode((object)codeSrc);
			var result = (IEnumerable<string>)builder.GetResult();

			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		[TestCategory("Protected")]
		[Description("CreateCode/Invalid")]
		[ExpectedException(typeof(ArgumentNullException))]
		public void CreateCode_Test_006()
		{
			int codeSrc = 0;
			var builder = new SourceStubEntryPointCodeBuilder();
			builder.CreateCode(null);
		}
	}
}
;