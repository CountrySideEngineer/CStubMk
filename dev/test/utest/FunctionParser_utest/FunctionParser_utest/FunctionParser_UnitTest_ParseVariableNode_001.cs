using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Parser;
using Parser.SDK.Model;
using System.Collections.Generic;
using System.Linq;

namespace FunctionParser_utest
{
	//[TestClass]
	public partial class FunctionParser_UnitTest
	{
		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_001()
		{
			string code = "int name";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 0);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_002()
		{
			string code = "int *name";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 1);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_003()
		{
			string code = "int* name";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 1);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_004()
		{
			string code = "int **name";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 2);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_005()
		{
			string code = "int** name";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 2);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_006()
		{
			string code = "const int* name";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 1);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_007()
		{
			string code = " int * \rname";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 1);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_008()
		{
			string code = " int * \nname";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 1);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_009()
		{
			string code = " int * \nname";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 1);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_010()
		{
			string code = " int * \r\nname";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 1);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_011()
		{
			string code = "\nint * name";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 1);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_012()
		{
			string code = "int\n* name";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 1);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_013()
		{
			string code = "int * \nname";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 1);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_014()
		{
			string code = "int * name\n";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 1);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_015()
		{
			string code = "\rint * name";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 1);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_016()
		{
			string code = "int\r* name";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 1);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_017()
		{
			string code = "int*\rname";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 1);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_018()
		{
			string code = "int*name\r";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 1);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_019()
		{
			string code = "\tint*name";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 1);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_020()
		{
			string code = "int\t*name";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 1);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_021()
		{
			string code = "int *\tname";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 1);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_022()
		{
			string code = "int *name\t";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 1);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_023()
		{
			string code = "int *name\t";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 1);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_024()
		{
			string code = "\r\nint *name";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 1);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_025()
		{
			string code = "int\r\n*name";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 1);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_026()
		{
			string code = "int * \r\nname";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "int");
			Assert.AreEqual(variable.Name, "name");
			Assert.AreEqual(variable.PointerNum, 1);
		}

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_001_027()
		{
			string code = "void";
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			Variable variable = (Variable)parserPrivate.Invoke("ParseVariableNode", code);

			Assert.AreEqual(variable.DataType, "void");
			Assert.IsTrue(string.IsNullOrEmpty(variable.Name));
			Assert.AreEqual(variable.PointerNum, 0);
		}
	}
}
