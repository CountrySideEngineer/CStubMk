using Microsoft.VisualStudio.TestTools.UnitTesting;
using CStubMKGui.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model.Tests
{
    [TestClass()]
    public class StubDirectorForCStyleTests
    {
        [TestMethod()]
        [Description("Constructor of StubDirectorForCStyle")]
        public void StubDirectorForCStyleTest_001()
        {
            var director = new StubDirectorForCStyle();

            Assert.IsNull(director.Parameter);
        }

        [TestMethod()]
        [Description("Constructor of StubDirectorForCStyle")]
        public void StubDirectorForCStyleTest_002()
        {
            var param = new Param
            {
                Name = "SampleParam"
            };
            var director = new StubDirectorForCStyle(param);

            Assert.IsNotNull(director.Parameter);
            Assert.AreEqual("SampleParam", director.Parameter.Name);
        }

        [TestMethod()]
        [Description("Constructor of StubDirectorForCStyle")]
        public void GetDefinePartTest_001()
        {
            var director = new StubDirectorForCStyle();

            Assert.AreEqual("#define STUB_BUFF_SIZE\t\t\t\t(100)\r\n", director.GetDefinePart());
        }

        [TestMethod()]
        public void GetMethodHeaderTest()
        {
            var param = new Param
            {
                Name = "SampleParam"
            };
            var director = new StubDirectorForCStyle(param);
            var header = director.GetMethodHeader();

            Assert.AreEqual("/*--------------------------------*/\r\n/*----                        ----*/\r\n/*---- Start SampleParam stub ----*/\r\n/*----                        ----*/\r\n/*--------------------------------*/\r\n",
                header);
        }

        [TestMethod()]
        public void GetStubBufferDeclareTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetStubBufferDeclareTest_002()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType"
            };
            var param2 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType"
            };
            var director = new StubDirectorForCStyle(param1);
            var buffDeclare = director.GetStubBufferDeclare(param2);

            Assert.AreEqual("DataType SampleParam[100]", buffDeclare);
        }

        [TestMethod()]
        public void GetStubBufferExternDeclareTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetBufferExternDeclareTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCalledCountDeclareTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetStubMethodTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCodeLineTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetStubInitMethodTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetMethodDefTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetArgDefTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetArgLatchPartTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetArgLatchPartTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetArgInitEntryPointTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetStubInitMethodExternTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetArgInitPartTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetArgInitPartTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetReturnLatchPartTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetReturnPartTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CommonFormatTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetArgBuffNameTest()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType"
            };
            var param2 = new Param
            {
                Name = "SampleData",
                DataType = "DataType"
            };
            var director = new StubDirectorForCStyle(param1);
            var buffName = director.GetArgBuffName(param2);

            Assert.AreEqual("SampleParam_SampleData", buffName);
        }

        [TestMethod()]
        [Description("GetDataTypeDest:Not pointer")]
        public void GetDataTypeTest_001()
        {
            var param = new Param
            {
                Name = "SampleArg",
                DataType = "DataType",
                PointerNum = 0
            };
            var director = new StubDirectorForCStyle(param);
            var getDataType = director.GetDataType(param);

            Assert.AreEqual("DataType", getDataType);
        }

        [TestMethod()]
        [Description("GetDataTypeDest:Single pointer")]
        public void GetDataTypeTest_002()
        {
            var param = new Param
            {
                Name = "SampleArg",
                DataType = "DataType",
                PointerNum = 1
            };
            var director = new StubDirectorForCStyle(param);
            var getDataType = director.GetDataType(param);

            Assert.AreEqual("DataType*", getDataType);
        }

        [TestMethod()]
        [Description("GetDataTypeDest:double pointer")]
        public void GetDataTypeTest_003()
        {
            var param = new Param
            {
                Name = "SampleArg",
                DataType = "DataType",
                PointerNum = 2
            };
            var director = new StubDirectorForCStyle(param);
            var getDataType = director.GetDataType(param);

            Assert.AreEqual("DataType**", getDataType);
        }

        [TestMethod()]
        public void GetRetValBuffNameTest()
        {
            var param = new Param
            {
                Name = "SampleParam"
            };
            var director = new StubDirectorForCStyle(param);
            var retValName = director.GetRetValBuffName();

            Assert.AreEqual("SampleParam_ret_val", retValName);
        }

        [TestMethod()]
        public void GetMethodCalledCounterNameTest()
        {
            var param = new Param
            {
                Name = "SampleParam"
            };
            var director = new StubDirectorForCStyle(param);
            var calledCountName = director.GetMethodCalledCounterName();

            Assert.AreEqual("SampleParam_called_count", calledCountName);
        }
    }
}