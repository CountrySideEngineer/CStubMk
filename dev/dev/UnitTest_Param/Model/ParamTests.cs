using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
            Assert.AreEqual(Param.AccessMode.None, param.Mode);
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

        [TestMethod()]
        [TestCategory("Param")]
        [Description("Property:Getter/Setter")]
        public void ParamTest_GetterSetter_008()
        {
            var param = new Param();

            param.Mode = Param.AccessMode.In;

            Assert.AreEqual(Param.AccessMode.In, param.Mode);
        }

        [TestMethod()]
        [TestCategory("Param")]
        [Description("Property:Getter/Setter")]
        public void ParamTest_GetterSetter_009()
        {
            var param = new Param();

            param.Mode = Param.AccessMode.Out;

            Assert.AreEqual(Param.AccessMode.Out, param.Mode);
        }

        [TestMethod()]
        [TestCategory("Param")]
        [Description("Property:Getter/Setter")]
        public void ParamTest_GetterSetter_010()
        {
            var param = new Param();

            param.Mode = Param.AccessMode.Both;

            Assert.AreEqual(Param.AccessMode.Both, param.Mode);
        }

        [TestMethod()]
        [TestCategory("Param")]
        [Description("Method:ToMode")]
        public void ParamTest_ToMode_001()
        {
            var mode = "in";
            var accessMode = Param.ToMode(mode);

            Assert.AreEqual(Param.AccessMode.In, accessMode);
        }

        [TestMethod()]
        [TestCategory("Param")]
        [Description("Method:ToMode")]
        public void ParamTest_ToMode_002()
        {
            var mode = "IN";
            var accessMode = Param.ToMode(mode);

            Assert.AreEqual(Param.AccessMode.In, accessMode);
        }

        [TestMethod()]
        [TestCategory("Param")]
        [Description("Method:ToMode")]
        public void ParamTest_ToMode_003()
        {
            var mode = "out";
            var accessMode = Param.ToMode(mode);

            Assert.AreEqual(Param.AccessMode.Out, accessMode);
        }

        [TestMethod()]
        [TestCategory("Param")]
        [Description("Method:ToMode")]
        public void ParamTest_ToMode_004()
        {
            var mode = "OUT";
            var accessMode = Param.ToMode(mode);

            Assert.AreEqual(Param.AccessMode.Out, accessMode);
        }

        [TestMethod()]
        [TestCategory("Param")]
        [Description("Method:ToMode")]
        public void ParamTest_ToMode_005()
        {
            var mode = "both";
            var accessMode = Param.ToMode(mode);

            Assert.AreEqual(Param.AccessMode.Both, accessMode);
        }

        [TestMethod()]
        [TestCategory("Param")]
        [Description("Method:ToMode")]
        public void ParamTest_ToMode_006()
        {
            var mode = "BOTH";
            var accessMode = Param.ToMode(mode);

            Assert.AreEqual(Param.AccessMode.Both, accessMode);
        }

        [TestMethod()]
        [TestCategory("Param")]
        [Description("Method:ToMode")]
        public void ParamTest_ToMode_007()
        {
            var mode = "unknown";
            try
            {
                Param.ToMode(mode);
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}