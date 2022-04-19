using Microsoft.VisualStudio.TestTools.UnitTesting;
using CStubMKGui.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CStubMKGui.Model.Tests
{
    /// <summary>
    /// Stub class of StubDirectorForCStyle for unit test of StubSourceFile.
    /// </summary>
    public class StubDirectorForCStyleMockForTest : StubDirectorForCStyle
    {
        public static int BuffSize = 100;
        public int GetDefinePartCalledCount;
        public string[] GetDefinePartRetVal = new string[BuffSize];

        public int GetStubInitMethodCalledCount;
        public string[] GetStubInitMethodRetVal = new string[BuffSize];
        public override string GetStubInitMethod()
        {
            var RetVal = GetStubInitMethodRetVal[GetStubInitMethodCalledCount];
            GetStubInitMethodCalledCount++;
            return RetVal;
        }
        public void GetStubInitMethodInit()
        {
            for (int index = 0; index < BuffSize; index++)
            {
                GetStubInitMethodRetVal[index] = string.Empty;
            }
            GetStubInitMethodCalledCount = 0;
        }

        public int GetMethodHeaderCalledCount;
        public string[] GetMethodHeaderRetVal = new string[BuffSize];
        public override string GetMethodHeader()
        {
            var retVal = this.GetMethodHeaderRetVal[GetMethodHeaderCalledCount];
            GetMethodHeaderCalledCount++;
            return retVal;
        }
        public void GetMethodHeaderInit()
        {
            for (int index = 0; index < BuffSize; index++)
            {
                this.GetMethodHeaderRetVal[index] = string.Empty;
            }
        }

        public int GetBufferSectionCalledCount;
        public string[] GetBufferSectionRetVal = new string[BuffSize];
        public override string GetBufferSection()
        {
            var retVal = GetBufferSectionRetVal[GetBufferSectionCalledCount];
            GetBufferSectionCalledCount++;
            return retVal;
        }
        public void GetBufferSectionInit()
        {
            for (int index = 0; index < BuffSize; index++)
            {
                GetBufferSectionRetVal[index] = string.Empty;
            }
            GetBufferSectionCalledCount = 0;
        }

        public int StubBodySectionCalledCount;
        public string[] StubBodySectionRetVal = new string[BuffSize];
        public override string StubBodySection()
        {
            var retVal = StubBodySectionRetVal[StubBodySectionCalledCount];
            StubBodySectionCalledCount++;
            return retVal;
        }
        public void StubBodySectionInit()
        {
            for (int index = 0; index < BuffSize; index++)
            {
                StubBodySectionRetVal[index] = string.Empty;
            }
            StubBodySectionCalledCount = 0;
        }

        public int GetStartPartCalledCount;
        public string[] GetStartPartRetVal = new string[BuffSize];
        public override string GetStartPart()
        {
            var retVal = GetStartPartRetVal[GetStartPartCalledCount];
            GetStartPartCalledCount++;
            return retVal;
        }
        public void GetStartPartInit()
        {
            for (int index = 0; index < BuffSize; index++)
            {
                GetStartPartRetVal[index] = string.Empty;
            }
            GetStartPartCalledCount = 0;
        }

        public void StubDirectorForCStyleInit()
        {
            this.GetStubInitMethodInit();
            this.GetMethodHeaderInit();
            this.GetBufferSectionInit();
            this.StubBodySectionInit();
            this.GetStartPartInit();
        }
    }

    /// <summary>
    /// Stub class of StreamWriter for unit test of StubSourceFile class.
    /// </summary>
    public class StreamWriteMock : StreamWriter
    {
        public static int BuffSize = 100;
        public int StreamWriteMockCalledCount;
        public string[] ConstructorArg1 = new string[BuffSize];
        public bool[] ConstructorArg2 = new bool[BuffSize];
        public Encoding[] ConstructorArg3 = new Encoding[BuffSize];

        public StreamWriteMock(string path, bool append, Encoding encoding) : base(path, append, encoding)
        {
            this.ConstructorArg1[StreamWriteMockCalledCount] = path;
            this.ConstructorArg2[StreamWriteMockCalledCount] = append;
            this.ConstructorArg3[StreamWriteMockCalledCount] = encoding;

            StreamWriteMockCalledCount++;
        }
        public void StreamWriteMockInit()
        {
            for (int index = 0; index < BuffSize; index++)
            {
                this.ConstructorArg1[index] = string.Empty;
                this.ConstructorArg2[index] = false;
                this.ConstructorArg3[index] = null;
            }

            StreamWriteMockCalledCount = 0;
        }

        public int WriteLineCalledCount;
        public string[] WriteLineArg1 = new string[BuffSize];
        public override void WriteLine(string value)
        {
            this.WriteLineArg1[WriteLineCalledCount] = value;
            WriteLineCalledCount++;
        }
        public void WriteLineInit()
        {
            for (int index = 0; index < BuffSize; index++)
            {
                WriteLineArg1[index] = string.Empty;
            }
            WriteLineCalledCount = 0;
        }

        public int WriteCalledCount;
        public string[] WriteArg1 = new string[BuffSize];
        public override void Write(string value)
        {
            this.WriteArg1[this.WriteCalledCount] = value;
            this.WriteCalledCount++;
        }
        public void WriteInit()
        {
            for (int index = 0; index < BuffSize; index++)
            {
                this.WriteArg1[index] = string.Empty;
            }
            this.WriteCalledCount = 0;
        }
        public void StreamWriteMockInitInit()
        {
            this.StreamWriteMockInit();
            this.WriteLineInit();
            this.WriteLineInit();
        }
    }

    [TestClass()]
    public class StubSourceFileTests
    {
        [TestMethod()]
        [TestCategory("StubSourceFile")]
        [TestCategory("Model")]
        [Description("Unit test of Constructor of StubSourceFile")]
        public void StubSourceFileTest_001()
        {
            var director = new StubDirectorForCStyleMockForTest();
            var stubSource = new StubSourceFile(director);

            Assert.AreEqual("Stub.c", stubSource.FileName);
            Assert.AreEqual(director, stubSource.Director);
        }

        [TestMethod()]
        [TestCategory("StubSourceFile")]
        [TestCategory("Model")]
        [Description("CreateFile->RunCreateFileSequence")]
        public void StubSourceFileTest_CreateFile_001()
        {
            Param param1 = new Param
            {
                Name = "Param1",
                DataType = "DataType1"
            };
            var parameters = new List<Param>
            {
                param1
            };
            var director = new StubDirectorForCStyleMockForTest();
            director.StubDirectorForCStyleInit();
            director.GetStartPartRetVal[0] = "GetStartPart";
            director.GetMethodHeaderRetVal[0] = "GetMethodHeader";
            director.GetBufferSectionRetVal[0] = "GetBufferSection";
            director.StubBodySectionRetVal[0] = "StubBodySection";
            director.GetStubInitMethodRetVal[0] = "GetStubInitMethod";
            var stubSourceFile = new StubSourceFile(director);
            using var writer = new StreamWriteMock("./sample.txt", false, Encoding.GetEncoding("UTF-8"));
            stubSourceFile.CreateFile(writer, parameters);

            Assert.AreEqual(3, writer.WriteLineCalledCount);
            Assert.AreEqual(5, writer.WriteCalledCount);
            Assert.AreEqual("#include <stdio.h>", writer.WriteLineArg1[0]);
            Assert.AreEqual("", writer.WriteLineArg1[1]);
            Assert.AreEqual("GetStartPart", writer.WriteArg1[0]);
            Assert.AreEqual("", writer.WriteLineArg1[2]);
            Assert.AreEqual("GetMethodHeader", writer.WriteArg1[1]);
            Assert.AreEqual("GetBufferSection", writer.WriteArg1[2]);
            Assert.AreEqual("StubBodySection", writer.WriteArg1[3]);
            Assert.AreEqual("GetStubInitMethod", writer.WriteArg1[4]);
        }

        [TestMethod()]
        [TestCategory("StubSourceFile")]
        [TestCategory("Model")]
        [Description("CreateFile->RunCreateFileSequence")]
        public void StubSourceFileTest_CreateFile_002()
        {
            Param param1 = new Param
            {
                Name = "Param1",
                DataType = "DataType1"
            };
            Param param2 = new Param
            {
                Name = "Param2",
                DataType = "DataType2"
            };
            var parameters = new List<Param>
            {
                param1,
                param2
            };
            var director = new StubDirectorForCStyleMockForTest();
            director.StubDirectorForCStyleInit();
            director.GetStartPartRetVal[0] = "GetStartPart1";
            director.GetMethodHeaderRetVal[0] = "GetMethodHeader1";
            director.GetBufferSectionRetVal[0] = "GetBufferSection1";
            director.StubBodySectionRetVal[0] = "StubBodySection1";
            director.GetStubInitMethodRetVal[0] = "GetStubInitMethod1";

            director.GetMethodHeaderRetVal[1] = "GetMethodHeader2";
            director.GetBufferSectionRetVal[1] = "GetBufferSection2";
            director.StubBodySectionRetVal[1] = "StubBodySection2";
            director.GetStubInitMethodRetVal[1] = "GetStubInitMethod2";

            var stubSourceFile = new StubSourceFile(director);
            using var writer = new StreamWriteMock("./sample.txt", false, Encoding.GetEncoding("UTF-8"));
            stubSourceFile.CreateFile(writer, parameters);
            Assert.AreEqual(3, writer.WriteLineCalledCount);
            Assert.AreEqual(9, writer.WriteCalledCount);
            Assert.AreEqual("#include <stdio.h>", writer.WriteLineArg1[0]);
            Assert.AreEqual("", writer.WriteLineArg1[1]);
            Assert.AreEqual("GetStartPart1", writer.WriteArg1[0]);
            Assert.AreEqual("", writer.WriteLineArg1[2]);
            Assert.AreEqual("GetMethodHeader1", writer.WriteArg1[1]);
            Assert.AreEqual("GetBufferSection1", writer.WriteArg1[2]);
            Assert.AreEqual("StubBodySection1", writer.WriteArg1[3]);
            Assert.AreEqual("GetStubInitMethod1", writer.WriteArg1[4]);
            Assert.AreEqual("GetMethodHeader2", writer.WriteArg1[5]);
            Assert.AreEqual("GetBufferSection2", writer.WriteArg1[6]);
            Assert.AreEqual("StubBodySection2", writer.WriteArg1[7]);
            Assert.AreEqual("GetStubInitMethod2", writer.WriteArg1[8]);
        }

        [TestMethod()]
        [TestCategory("StubSourceFile")]
        [TestCategory("Model")]
        [Description("CreateFile->RunCreateFileSequence")]
        public void StubSourceFileTest_CreateFile_003()
        {
            Param param1 = new Param
            {
                Name = "Param1",
                DataType = "DataType1"
            };
            Param param2 = new Param
            {
                Name = "Param2",
                DataType = "DataType2"
            };
            var parameters = new List<Param>
            {
                param1,
                param2
            };
            var director = new StubDirectorForCStyleMockForTest();
            director.StubDirectorForCStyleInit();
            director.GetDefinePartRetVal[0] = "GetDefinePart";
            director.GetMethodHeaderRetVal[0] = "GetMethodHeader1";
            director.GetMethodHeaderRetVal[1] = "GetMethodHeader2";
            director.GetStubInitMethodRetVal[0] = "GetStubInitMethod1";
            director.GetStubInitMethodRetVal[1] = "GetStubInitMethod2";

            var stubSourceFile = new StubSourceFile(director);
            using var writer = new StreamWriteMock("./sample.txt", false, Encoding.GetEncoding("UTF-8"));
            try
            {
                stubSourceFile.CreateFile(writer, null);
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {
                Assert.AreEqual(0, writer.WriteLineCalledCount);
                Assert.AreEqual(0, writer.WriteCalledCount);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        [TestCategory("StubSourceFile")]
        [TestCategory("Model")]
        [Description("CreateFile->RunCreateFileSequence")]
        public void StubSourceFileTest_CreateFile_004()
        {
            Param param1 = new Param
            {
                Name = "Param1",
                DataType = "DataType1"
            };
            Param param2 = new Param
            {
                Name = "Param2",
                DataType = "DataType2"
            };
            var parameters = new List<Param>
            {
                param1,
                param2
            };
            var director = new StubDirectorForCStyleMockForTest();
            director.StubDirectorForCStyleInit();
            director.GetDefinePartRetVal[0] = "GetDefinePart";
            director.GetMethodHeaderRetVal[0] = "GetMethodHeader1";
            director.GetMethodHeaderRetVal[1] = "GetMethodHeader2";
            director.GetStubInitMethodRetVal[0] = "GetStubInitMethod1";
            director.GetStubInitMethodRetVal[1] = "GetStubInitMethod2";

            var stubSourceFile = new StubSourceFile(director);
            StreamWriteMock writer = null;
            try
            {
                stubSourceFile.CreateFile(writer, parameters);
                Assert.Fail();
            }
            catch (ArgumentNullException)
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