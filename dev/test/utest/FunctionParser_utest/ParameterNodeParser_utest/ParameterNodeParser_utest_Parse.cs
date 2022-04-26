using FunctionParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParameterNodeParser_utest
{
	//[TestClass]
	public partial class ParameterNodeParser_utest
	{
		[TestMethod]
		[TestCategory("ParameterNodeParser")]
		[TestCategory("Parse")]
		public void Parse_test_001()
		{
			string code = "int function";
			var parser = new ParameterNodeParser();
			IEnumerable<Parameter> parameter = parser.Parse(code);

			Assert.AreEqual(1, parameter.Count());
			Assert.AreEqual("int", parameter.ElementAt(0).DataType);
			Assert.AreEqual("function", parameter.ElementAt(0).Name);
			Assert.AreEqual(string.Empty, parameter.ElementAt(0).FileName);
		}
	}
}
