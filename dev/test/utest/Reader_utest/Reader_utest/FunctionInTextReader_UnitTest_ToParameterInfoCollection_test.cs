using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reader.FunctionReader;
using Reader.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader_utest
{
	//[TestClass]
	public partial class FunctionInTextReader_UnitTest
	{
		[TestMethod]
		[TestCategory("FunctionInTextReader")]
		[TestCategory("ToParameterInfoCollection")]
		public void ToParameterInfoCollection_Test_001()
		{
			var codes = new List<string>()
			{
				"code_001",
			};
			var reader = new FunctionInTextReader();
			var privateReader = new PrivateObject(reader);
			var paramInfos = (IEnumerable<ParameterInformation>)privateReader.Invoke("ToParameterInformation", codes);

			Assert.AreEqual(1, paramInfos.Count());
			Assert.AreEqual("code_001", paramInfos.ElementAt(0).Code);
		}

		[TestMethod]
		[TestCategory("FunctionInTextReader")]
		[TestCategory("ToParameterInfoCollection")]
		public void ToParameterInfoCollection_Test_002()
		{
			var codes = new List<string>()
			{
				"code_001", "code_002"
			};
			var reader = new FunctionInTextReader();
			var privateReader = new PrivateObject(reader);
			var paramInfos = (IEnumerable<ParameterInformation>)privateReader.Invoke("ToParameterInformation", codes);

			Assert.AreEqual(2, paramInfos.Count());
			Assert.AreEqual("code_001", paramInfos.ElementAt(0).Code);
			Assert.AreEqual("code_002", paramInfos.ElementAt(1).Code);
		}
	}
}
