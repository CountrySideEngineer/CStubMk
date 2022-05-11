using CodeTemplate.Template;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser.SDK.Model;
using System;
using System.Diagnostics;

namespace CodeTemplate_test
{
	[TestClass]
	public class CodeTemplate_test
	{
		[TestMethod]
		[TestCategory("CodeTemplate")]
		[TestCategory("SourceStubTemplate")]
		public void TestMethod1()
		{
			var function = new Function()
			{
				DataType = "int",
				Name = "Function"
			};
			var template = new SourceStubTemplate()
			{
				TargetFunc = function
			};
			string code = template.TransformText();
			Debug.Write(code);
		}
	}
}
