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
        public void GetStubBufferDeclareTest_001()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType"
            };
            var param2 = new Param
            {
                Name = "SampleParam1",
                DataType = "DataType"
            };
            var director = new StubDirectorForCStyle(param1);
            var buffDeclare = director.GetStubBufferDeclare(param2);

            Assert.AreEqual("DataType SampleParam_SampleParam1[STUB_BUFF_SIZE]", buffDeclare);
        }

        [TestMethod()]
        public void GetStubInitMethodTest_001()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType",
            };
            var director = new StubDirectorForCStyle(param1);
            var stubInitMethod = director.GetStubInitMethod();

            var stubInitMethodExpect = "void SampleParam_init()\r\n";
            stubInitMethodExpect += "{\r\n";
            stubInitMethodExpect += "\tint id = 0;\r\n";
            stubInitMethodExpect += "\t\r\n";
            stubInitMethodExpect += "\tfor (id = 0; id < STUB_BUFF_SIZE; id++) {\r\n";
            stubInitMethodExpect += "\t\tSampleParam_ret_val[id] = 0;\r\n";
            stubInitMethodExpect += "\t}\r\n";
            stubInitMethodExpect += "\tSampleParam_called_count = 1;";
            stubInitMethodExpect += "}\r\n";

        }

        [TestMethod()]
        public void GetMethodDefTest_001()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType",
            };
            var director = new StubDirectorForCStyle(param1);
            var commonFormat = director.GetMethodDef();

            Assert.AreEqual("DataType SampleParam", commonFormat);
        }

        [TestMethod()]
        public void GetArgDefTest_001()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType",
            };
            var param2 = new Param
            {
                Name = "SampleParamArg",
                DataType = "ArgDataType",
            };
            param1.Parameters = new List<Param>
            {
                param2
            };
            var director = new StubDirectorForCStyle(param1);
            var argDef = director.GetArgDef();

            Assert.AreEqual("\tArgDataType SampleParamArg", argDef);
        }

        [TestMethod()]
        public void GetArgDefTest_002()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType",
            };
            var param2 = new Param
            {
                Name = "SampleParamArg1",
                DataType = "ArgDataType",
            };
            var param3 = new Param
            {
                Name = "SampleParamArg2",
                DataType = "ArgDataType",
            };
            param1.Parameters = new List<Param>
            {
                param2,
                param3
            };
            var director = new StubDirectorForCStyle(param1);
            var argDef = director.GetArgDef();

            Assert.AreEqual("\tArgDataType SampleParamArg1,\r\n\tArgDataType SampleParamArg2", argDef);
        }

        [TestMethod()]
        public void GetArgLatchPartTest_001()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType",
            };
            var param2 = new Param
            {
                Name = "SampleParamArg",
                DataType = "ArgDataType",
            };
            var director = new StubDirectorForCStyle(param1);
            var argLatchPart = director.GetArgLatchPart(param2);

            Assert.AreEqual("SampleParam_SampleParamArg[SampleParam_called_count] = SampleParamArg;",
                argLatchPart);
        }

        [TestMethod()]
        public void GetArgLatchPartTest_002()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType",
            };
            try
            {
                var director = new StubDirectorForCStyle(param1);
                director.GetArgLatchPart(null);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null. (Parameter 'argument')", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void GetArgLatchPartTest_003()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType",
            };
            var param2 = new Param
            {
                Name = "SampleParamArg",
                DataType = "ArgDataType",
            };
            param1.Parameters = new List<Param>
            {
                param2
            };
            var director = new StubDirectorForCStyle(param1);
            var argLatchPart = director.GetArgLatchPart();

            Assert.AreEqual("\tSampleParam_SampleParamArg[SampleParam_called_count] = SampleParamArg;\r\n",
                argLatchPart);
        }

        [TestMethod()]
        public void GetArgLatchPartTest_004()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType",
            };
            var param2 = new Param
            {
                Name = "SampleParamArg1",
                DataType = "ArgDataType",
            };
            var param3 = new Param
            {
                Name = "SampleParamArg2",
                DataType = "ArgDataType",
            };
            param1.Parameters = new List<Param>
            {
                param2,
                param3
            };
            var director = new StubDirectorForCStyle(param1);
            var argLatchPart = director.GetArgLatchPart();

            Assert.AreEqual("\tSampleParam_SampleParamArg1[SampleParam_called_count] = SampleParamArg1;\r\n\tSampleParam_SampleParamArg2[SampleParam_called_count] = SampleParamArg2;\r\n",
                argLatchPart);
        }

        [TestMethod()]
        public void GetArgInitEntryPointTest_001()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType",
            };
            var director = new StubDirectorForCStyle(param1);
            var entryPoint = director.GetArgInitEntryPoint();

            Assert.AreEqual("void SampleParam_init()", entryPoint);
        }

        [TestMethod()]
        public void GetStubInitMethodExternTest_001()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType",
            };
            var director = new StubDirectorForCStyle(param1);
            var stubInitMethodExtern = director.GetStubInitMethodExtern();

            Assert.AreEqual("extern void SampleParam_init();", stubInitMethodExtern);
        }

        [TestMethod()]
        public void GetArgInitPartTest_001()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType",
            };
            var param2 = new Param
            {
                Name = "SampleParamArg",
                DataType = "ArgDataType",
            };
            var director = new StubDirectorForCStyle(param1);
            var argInitPart = director.GetArgInitPart(param2);

            Assert.AreEqual("SampleParam_SampleParamArg[id] = 0;", argInitPart);
        }

        [TestMethod()]
        public void GetArgInitPartTest_002()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType",
            };
            var param2 = new Param
            {
                Name = "SampleParamArg",
                DataType = "ArgDataType",
                PointerNum = 1
            };
            var director = new StubDirectorForCStyle(param1);
            var argInitPart = director.GetArgInitPart(param2);

            Assert.AreEqual("SampleParam_SampleParamArg[id] = null;", argInitPart);
        }

        [TestMethod()]
        public void GetArgInitPartTest_003()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType",
            };
            var director = new StubDirectorForCStyle(param1);
            try
            {
                director.GetArgInitPart(null);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(@"Value cannot be null. (Parameter 'argument')", ex.Message);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void GetArgInitPartTest_004()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType",
            };
            var param2 = new Param
            {
                Name = "SampleParamArg",
                DataType = "ArgDataType",
            };
            param1.Parameters = new List<Param>()
            {
                param2
            };

            var director = new StubDirectorForCStyle(param1);
            var argInitPart = director.GetArgInitPart();

            Assert.AreEqual("\t\tSampleParam_SampleParamArg[id] = 0;\r\n", argInitPart);
        }

        [TestMethod()]
        public void GetArgInitPartTest_005()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType",
            };
            var param2 = new Param
            {
                Name = "SampleParamArg1",
                DataType = "ArgDataType1",
            };
            var param3 = new Param
            {
                Name = "SampleParamArg2",
                DataType = "ArgDataType2",
            };
            param1.Parameters = new List<Param>()
            {
                param2,
                param3
            };

            var director = new StubDirectorForCStyle(param1);
            var argInitPart = director.GetArgInitPart();

            Assert.AreEqual("\t\tSampleParam_SampleParamArg1[id] = 0;\r\n\t\tSampleParam_SampleParamArg2[id] = 0;\r\n",
                argInitPart);
        }

        [TestMethod()]
        public void GetArgInitPartTest_006()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType",
            };
            param1.Parameters = new List<Param>();

            var director = new StubDirectorForCStyle(param1);
            var argInitPart = director.GetArgInitPart();

            Assert.AreEqual("", argInitPart);
        }

        [TestMethod()]
        public void GetReturnLatchPartTest_001()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType",
            };
            var director = new StubDirectorForCStyle(param1);
            var returnLatchPart = director.GetReturnLatchPart();

            Assert.AreEqual("\tDataType ret_val = SampleParam_ret_val[SampleParam_called_count];\r\n",
                returnLatchPart);
        }

        [TestMethod()]
        public void GetReturnLatchPartTest_002()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "void",
            };
            var director = new StubDirectorForCStyle(param1);
            var returnLatchPart = director.GetReturnLatchPart();

            Assert.AreEqual("", returnLatchPart);
        }

        [TestMethod()]
        public void GetReturnPartTest_001()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType",
            };
            var director = new StubDirectorForCStyle(param1);
            var returnPart = director.GetReturnPart();

            Assert.AreEqual("\treturn ret_val;\r\n", returnPart);
        }

        [TestMethod()]
        public void GetReturnPartTest_002()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "void",
            };
            var director = new StubDirectorForCStyle(param1);
            var returnPart = director.GetReturnPart();

            Assert.AreEqual("", returnPart);
        }

        [TestMethod()]
        public void CommonFormatTest_001()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType",
            };
            var director = new StubDirectorForCStyle(param1);
            var cmdFormat = director.CommonFormat(param1);

            Assert.AreEqual("DataType SampleParam", cmdFormat);
        }

        [TestMethod()]
        public void CommonFormatTest_002()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType",
                Prefix = "Prefix"
            };
            var director = new StubDirectorForCStyle(param1);
            var cmdFormat = director.CommonFormat(param1);

            Assert.AreEqual("Prefix DataType SampleParam", cmdFormat);
        }

        [TestMethod()]
        public void CommonFormatTest_003()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType",
                Prefix = "Prefix",
                PointerNum = 1,
            };
            var director = new StubDirectorForCStyle(param1);
            var cmdFormat = director.CommonFormat(param1);

            Assert.AreEqual("Prefix DataType* SampleParam", cmdFormat);
        }

        [TestMethod()]
        public void CommonFormatTest_004()
        {
            var param1 = new Param
            {
                Name = "SampleParam",
                DataType = "DataType",
                Prefix = "Prefix",
                PointerNum = 1,
                Postifx = "Postfix"
            };
            var director = new StubDirectorForCStyle(param1);
            var cmdFormat = director.CommonFormat(param1);

            Assert.AreEqual("Prefix DataType* Postfix SampleParam", cmdFormat);
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