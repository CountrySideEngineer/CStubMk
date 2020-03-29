using Microsoft.VisualStudio.TestTools.UnitTesting;
using CStubMKGui.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model.Tests
{
    [TestClass()]
    public class ParamTests
    {
        [TestMethod()]
        [TestCategory("Param")]
        [Description("Constructor")]
        public void ParamTest_001()
        {
            var param = new Param();

            Assert.AreEqual("", param.Name);
            Assert.AreEqual("", param.Description);
            Assert.AreEqual("", param.DataType);
            Assert.AreEqual("", param.Prefix);
            Assert.AreEqual("", param.Postifx);
            Assert.AreEqual(0, param.PointerNum);
            Assert.IsNull(param.Parameters);
        }

        [TestMethod()]
        [TestCategory("Param")]
        [Description("Property:Getter/Setter")]
        public void ParamTest_GetterSetter_001()
        {
            var param = new Param();

            param.Name = "prop Name";

            Assert.AreEqual("prop Name", param.Name);
        }

        [TestMethod()]
        [TestCategory("Param")]
        [Description("Property:Getter/Setter")]
        public void ParamTest_GetterSetter_002()
        {
            var param = new Param();

            param.Description = "prop Description";

            Assert.AreEqual("prop Description", param.Description);
        }

        [TestMethod()]
        [TestCategory("Param")]
        [Description("Property:Getter/Setter")]
        public void ParamTest_GetterSetter_003()
        {
            var param = new Param();

            param.DataType = "prop DataType";

            Assert.AreEqual("prop DataType", param.DataType);
        }

        [TestMethod()]
        [TestCategory("Param")]
        [Description("Property:Getter/Setter")]
        public void ParamTest_GetterSetter_004()
        {
            var param = new Param();

            param.Prefix = "prop Prefix";

            Assert.AreEqual("prop Prefix", param.Prefix);
        }

        [TestMethod()]
        [TestCategory("Param")]
        [Description("Property:Getter/Setter")]
        public void ParamTest_GetterSetter_005()
        {
            var param = new Param();

            param.Postifx = "prop Postifx";

            Assert.AreEqual("prop Postifx", param.Postifx);
        }

        [TestMethod()]
        [TestCategory("Param")]
        [Description("Property:Getter/Setter")]
        public void ParamTest_GetterSetter_006()
        {
            var param = new Param();

            param.PointerNum = 1;

            Assert.AreEqual(1, param.PointerNum);
        }

        [TestMethod()]
        [TestCategory("Param")]
        [Description("Property:Getter/Setter")]
        public void ParamTest_GetterSetter_007()
        {
            var param = new Param();

            param.Parameters = new List<Param>();

            Assert.IsNotNull(param.Parameters);
        }
    }
}