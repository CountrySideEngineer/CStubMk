using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser;
using Parser.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionParser_utest
{
	//[TestClass]
	public partial class FunctionParser_UnitTest
	{

		[TestMethod]
		[TestCategory("ParseVariableNode")]
		public void ParseVariableNode_Test_002_001()
		{
			List<string> codes = new List<string>
			{
				"dataType1 arg1",
				"dataType2 arg2",
			};
			FunctionParser parser = new FunctionParser();
			PrivateObject parserPrivate = new PrivateObject(parser);
			IEnumerable<Variable> variables = (IEnumerable<Variable>)parserPrivate.Invoke("ParseVariableNode", codes);

			Assert.AreEqual(2, variables.Count());
			Assert.AreEqual("dataType1", variables.ElementAt(0).DataType);
			Assert.AreEqual("arg1", variables.ElementAt(0).Name);
			Assert.AreEqual("dataType2", variables.ElementAt(1).DataType);
			Assert.AreEqual("arg2", variables.ElementAt(1).Name);
		}
	}
}
