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
        public override string GetDefinePart()
        {
            var RetVal = this.GetDefinePartRetVal[GetDefinePartCalledCount];
            this.GetDefinePartCalledCount++;

            return RetVal;
        }
        public void GetDefinePartInit()
        {
            for (int index = 0; index < BuffSize; index++)
            {
                GetDefinePartRetVal[index] = string.Empty;
            }
            GetDefinePartCalledCount = 0;
        }

        public int GetStubBufferDeclareCalledCount;
        public string[] GetStubBufferDeclareRetVal = new string[BuffSize];
        public override string GetStubBufferDeclare()
        {
            var RetVal = this.GetStubBufferDeclareRetVal[GetStubBufferDeclareCalledCount];
            GetStubBufferDeclareCalledCount++;
            return RetVal;
        }
        public void GetStubBufferDeclareInit()
        {
            for (int index = 0; index < BuffSize; index++)
            {
                GetStubBufferDeclareRetVal[index] = string.Empty;
            }
            GetStubBufferDeclareCalledCount = 0;
        }

        public int GetStubMethodCalledCount;
        public string[] GetStubMethodRetVal = new string[BuffSize];
        public override string GetStubMethod()
        {
            var RetVal = this.GetStubMethodRetVal[GetStubMethodCalledCount];
            GetStubMethodCalledCount++;
            return RetVal;
        }
        public void GetStubMethodInit()
        {
            for (int index = 0; index < BuffSize; index++)
            {
                GetStubMethodRetVal[index] = string.Empty;
            }
            GetStubMethodCalledCount = 0;
        }

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

        public void StubDirectorForCStyleInit()
        {
            this.GetDefinePartInit();
            this.GetStubBufferDeclareInit();
            this.GetStubMethodInit();
            this.GetStubInitMethodInit();
            this.GetMethodHeaderInit();
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
            director.GetDefinePartRetVal[0] = "GetDefinePart";
            director.GetStubBufferDeclareRetVal[0] = "GetStubBufferdeclre";
            director.GetStubMethodRetVal[0] = "GetStubMethod";
            director.GetStubInitMethodRetVal[0] = "GetStubInitMethod";
            director.GetMethodHeaderRetVal[0] = "GetMethodHeader";
            var stubSourceFile = new StubSourceFile(director);
            using var writer = new StreamWriteMock("./sample.txt", false, Encoding.GetEncoding("UTF-8"));
            stubSourceFile.CreateFile(writer, parameters);

            Assert.AreEqual(4, writer.WriteLineCalledCount);
            Assert.AreEqual(4, writer.WriteCalledCount);
            Assert.AreEqual("#include <stdio.h>", writer.WriteLineArg1[0]);
            Assert.AreEqual("", writer.WriteLineArg1[1]);
            Assert.AreEqual("GetDefinePart", writer.WriteArg1[0]);
            Assert.AreEqual("", writer.WriteLineArg1[2]);
            Assert.AreEqual("GetMethodHeader", writer.WriteLineArg1[3]);
            Assert.AreEqual("GetStubBufferdeclre", writer.WriteArg1[1]);
            Assert.AreEqual("GetStubMethod", writer.WriteArg1[2]);
            Assert.AreEqual("GetStubInitMethod", writer.WriteArg1[3]);
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
            director.GetDefinePartRetVal[0] = "GetDefinePart";
            director.GetStubBufferDeclareRetVal[0] = "GetStubBufferdeclre";
            director.GetMethodHeaderRetVal[0] = "GetMethodHeader1";
            director.GetMethodHeaderRetVal[1] = "GetMethodHeader2";
            director.GetStubBufferDeclareRetVal[0] = "GetStubBufferDeclre1";
            director.GetStubBufferDeclareRetVal[1] = "GetStubBufferDeclre2";
            director.GetStubMethodRetVal[0] = "GetStubMethod1";
            director.GetStubMethodRetVal[1] = "GetStubMethod2";
            director.GetStubInitMethodRetVal[0] = "GetStubInitMethod1";
            director.GetStubInitMethodRetVal[1] = "GetStubInitMethod2";

            var stubSourceFile = new StubSourceFile(director);
            using var writer = new StreamWriteMock("./sample.txt", false, Encoding.GetEncoding("UTF-8"));
            stubSourceFile.CreateFile(writer, parameters);
            Assert.AreEqual(5, writer.WriteLineCalledCount);
            Assert.AreEqual(7, writer.WriteCalledCount);
            Assert.AreEqual("#include <stdio.h>", writer.WriteLineArg1[0]);
            Assert.AreEqual("", writer.WriteLineArg1[1]);
            Assert.AreEqual("GetDefinePart", writer.WriteArg1[0]);
            Assert.AreEqual("", writer.WriteLineArg1[2]);
            Assert.AreEqual("GetMethodHeader1", writer.WriteLineArg1[3]);
            Assert.AreEqual("GetStubBufferDeclre1", writer.WriteArg1[1]);
            Assert.AreEqual("GetStubMethod1", writer.WriteArg1[2]);
            Assert.AreEqual("GetStubInitMethod1", writer.WriteArg1[3]);
            Assert.AreEqual("GetMethodHeader2", writer.WriteLineArg1[4]);
            Assert.AreEqual("GetStubBufferDeclre2", writer.WriteArg1[4]);
            Assert.AreEqual("GetStubMethod2", writer.WriteArg1[5]);
            Assert.AreEqual("GetStubInitMethod2", writer.WriteArg1[6]);
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
            director.GetStubBufferDeclareRetVal[0] = "GetStubBufferdeclre";
            director.GetMethodHeaderRetVal[0] = "GetMethodHeader1";
            director.GetMethodHeaderRetVal[1] = "GetMethodHeader2";
            director.GetStubBufferDeclareRetVal[0] = "GetStubBufferDeclre1";
            director.GetStubBufferDeclareRetVal[1] = "GetStubBufferDeclre2";
            director.GetStubMethodRetVal[0] = "GetStubMethod1";
            director.GetStubMethodRetVal[1] = "GetStubMethod2";
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
            director.GetStubBufferDeclareRetVal[0] = "GetStubBufferdeclre";
            director.GetMethodHeaderRetVal[0] = "GetMethodHeader1";
            director.GetMethodHeaderRetVal[1] = "GetMethodHeader2";
            director.GetStubBufferDeclareRetVal[0] = "GetStubBufferDeclre1";
            director.GetStubBufferDeclareRetVal[1] = "GetStubBufferDeclre2";
            director.GetStubMethodRetVal[0] = "GetStubMethod1";
            director.GetStubMethodRetVal[1] = "GetStubMethod2";
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