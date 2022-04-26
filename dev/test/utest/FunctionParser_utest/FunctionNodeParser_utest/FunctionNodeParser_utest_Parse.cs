using FunctionParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionNodeParser_utest
{
	//[TestClass]
	public partial class FunctionNodeParser_utest
	{
		[TestMethod]
		[TestCategory("FunctionNodeParse")]
		[TestCategory("Parse")]
		public void Parse_test_001()
		{
			string code = "int func(int data1)";
			FunctionNodeParser parser = new FunctionNodeParser();
			IEnumerable<Parameter> parameters = parser.Parse(code);

			Assert.AreEqual(1, parameters.Count());

			Function function = (Function)parameters.ElementAt(0);
			Assert.AreEqual("int", function.DataType);
			Assert.AreEqual("func", function.Name);
			Assert.AreEqual(0, function.PointerNum);

			IEnumerable<Parameter> arguments = function.Arguments;
			Assert.AreEqual(1, arguments.Count());

			Variable argument = (Variable)arguments.ElementAt(0);
			Assert.AreEqual("int", argument.DataType);
			Assert.AreEqual("data1", argument.Name);
			Assert.AreEqual(0, argument.PointerNum);
		}

		[TestMethod]
		[TestCategory("FunctionNodeParse")]
		[TestCategory("Parse")]
		public void Parse_test_002()
		{
			string code = "int func(int data1);";
			FunctionNodeParser parser = new FunctionNodeParser();
			IEnumerable<Parameter> parameters = parser.Parse(code);

			Assert.AreEqual(1, parameters.Count());

			Function function = (Function)parameters.ElementAt(0);
			Assert.AreEqual("int", function.DataType);
			Assert.AreEqual("func", function.Name);
			Assert.AreEqual(0, function.PointerNum);

			IEnumerable<Parameter> arguments = function.Arguments;
			Assert.AreEqual(1, arguments.Count());

			Variable argument = (Variable)arguments.ElementAt(0);
			Assert.AreEqual("int", argument.DataType);
			Assert.AreEqual("data1", argument.Name);
			Assert.AreEqual(0, argument.PointerNum);
		}

		[TestMethod]
		[TestCategory("FunctionNodeParse")]
		[TestCategory("Parse")]
		public void Parse_test_003()
		{
			string code = "int func1(int data1);";
			code += Environment.NewLine;
			code += "short func2(int data_1_1, int* data_1_2)";
			FunctionNodeParser parser = new FunctionNodeParser();
			IEnumerable<Parameter> parameters = parser.Parse(code);

			Assert.AreEqual(2, parameters.Count());

			Function function = (Function)parameters.ElementAt(0);
			Assert.AreEqual("int", function.DataType);
			Assert.AreEqual("func1", function.Name);
			Assert.AreEqual(0, function.PointerNum);

			IEnumerable<Parameter> arguments = function.Arguments;
			Assert.AreEqual(1, arguments.Count());

			Variable argument = (Variable)arguments.ElementAt(0);
			Assert.AreEqual("int", argument.DataType);
			Assert.AreEqual("data1", argument.Name);
			Assert.AreEqual(0, argument.PointerNum);

			function = (Function)parameters.ElementAt(1);
			Assert.AreEqual("short", function.DataType);
			Assert.AreEqual("func2", function.Name);
			Assert.AreEqual(0, function.PointerNum);

			arguments = function.Arguments;
			Assert.AreEqual(2, arguments.Count());

			argument = (Variable)arguments.ElementAt(0);
			Assert.AreEqual("int", argument.DataType);
			Assert.AreEqual("data_1_1", argument.Name);
			Assert.AreEqual(0, argument.PointerNum);

			argument = (Variable)arguments.ElementAt(1);
			Assert.AreEqual("int", argument.DataType);
			Assert.AreEqual("data_1_2", argument.Name);
			Assert.AreEqual(1, argument.PointerNum);
		}

		[TestMethod]
		[TestCategory("FunctionNodeParse")]
		[TestCategory("Parse")]
		public void Parse_test_004()
		{
			string code = "int func1(int data1);";
			code += Environment.NewLine;
			code += "short func2(int data_1_1, int* data_1_2);";
			FunctionNodeParser parser = new FunctionNodeParser();
			IEnumerable<Parameter> parameters = parser.Parse(code);

			Assert.AreEqual(2, parameters.Count());

			Function function = (Function)parameters.ElementAt(0);
			Assert.AreEqual("int", function.DataType);
			Assert.AreEqual("func1", function.Name);
			Assert.AreEqual(0, function.PointerNum);

			IEnumerable<Parameter> arguments = function.Arguments;
			Assert.AreEqual(1, arguments.Count());

			Variable argument = (Variable)arguments.ElementAt(0);
			Assert.AreEqual("int", argument.DataType);
			Assert.AreEqual("data1", argument.Name);
			Assert.AreEqual(0, argument.PointerNum);

			function = (Function)parameters.ElementAt(1);
			Assert.AreEqual("short", function.DataType);
			Assert.AreEqual("func2", function.Name);
			Assert.AreEqual(0, function.PointerNum);

			arguments = function.Arguments;
			Assert.AreEqual(2, arguments.Count());

			argument = (Variable)arguments.ElementAt(0);
			Assert.AreEqual("int", argument.DataType);
			Assert.AreEqual("data_1_1", argument.Name);
			Assert.AreEqual(0, argument.PointerNum);

			argument = (Variable)arguments.ElementAt(1);
			Assert.AreEqual("int", argument.DataType);
			Assert.AreEqual("data_1_2", argument.Name);
			Assert.AreEqual(1, argument.PointerNum);
		}

		[TestMethod]
		[TestCategory("FunctionNodeParse")]
		[TestCategory("Parse")]
		public void Parse_test_005()
		{
			string code = "int func1(int data1);";
			code += Environment.NewLine;
			code += "short func2(" +
				Environment.NewLine + "\t" +
				"int data_1_1," +
				Environment.NewLine + "\t" +
				"int* data_1_2" +
				Environment.NewLine + "\t" +
				");" +
				Environment.NewLine + "\t";

		FunctionNodeParser parser = new FunctionNodeParser();
			IEnumerable<Parameter> parameters = parser.Parse(code);

			Assert.AreEqual(2, parameters.Count());

			Function function = (Function)parameters.ElementAt(0);
			Assert.AreEqual("int", function.DataType);
			Assert.AreEqual("func1", function.Name);
			Assert.AreEqual(0, function.PointerNum);

			IEnumerable<Parameter> arguments = function.Arguments;
			Assert.AreEqual(1, arguments.Count());

			Variable argument = (Variable)arguments.ElementAt(0);
			Assert.AreEqual("int", argument.DataType);
			Assert.AreEqual("data1", argument.Name);
			Assert.AreEqual(0, argument.PointerNum);

			function = (Function)parameters.ElementAt(1);
			Assert.AreEqual("short", function.DataType);
			Assert.AreEqual("func2", function.Name);
			Assert.AreEqual(0, function.PointerNum);

			arguments = function.Arguments;
			Assert.AreEqual(2, arguments.Count());

			argument = (Variable)arguments.ElementAt(0);
			Assert.AreEqual("int", argument.DataType);
			Assert.AreEqual("data_1_1", argument.Name);
			Assert.AreEqual(0, argument.PointerNum);

			argument = (Variable)arguments.ElementAt(1);
			Assert.AreEqual("int", argument.DataType);
			Assert.AreEqual("data_1_2", argument.Name);
			Assert.AreEqual(1, argument.PointerNum);
		}
	}
}
