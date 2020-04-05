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
            GetMethodHeaderCalledCount = 0;
        }

        public int GetStubBufferExternDeclareCalledCount;
        public string[] GetStubBufferExternDeclareRetVal = new string[BuffSize];
        public override string GetStubBufferExternDeclare()
        {
            var retVal = this.GetStubBufferExternDeclareRetVal[GetStubBufferExternDeclareCalledCount];
            GetStubBufferExternDeclareCalledCount++;
            return retVal;
        }
        public void GetStubBufferExternDeclareInit()
        {
            for (int index = 0; index < BuffSize; index++)
            {
                GetStubBufferExternDeclareRetVal[index] = string.Empty;
            }
            GetStubBufferExternDeclareCalledCount = 0;
        }

        public int GetStubInitMethodExternCalledCount;
        public string[] GetStubInitMethodExternRetVal = new string[BuffSize];
        public override string GetStubInitMethodExtern()
        {
            var retVal = GetStubInitMethodExternRetVal[GetStubInitMethodExternCalledCount];
            GetStubInitMethodExternCalledCount++;

            return retVal;
        }
        public void GetStubInitMethodExternInit()
        {
            for (int index = 0; index < BuffSize; index++)
            {
                GetStubBufferDeclareRetVal[index] = string.Empty;
            }
            GetStubBufferDeclareCalledCount = 0;

        }

        public void StubDirectorForCStyleInit()
        {
            this.GetDefinePartInit();
            this.GetStubBufferDeclareInit();
            this.GetStubMethodInit();
            this.GetStubInitMethodInit();
            this.GetMethodHeaderInit();
            this.GetStubBufferExternDeclareInit();
            this.GetStubInitMethodExternInit();
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
    public class StubHeaderFileTests
    {
        [TestMethod()]
        [TestCategory("StubHeaderFile")]
        [TestCategory("Model")]
        [Description("Unit test of Constructor of StubHeaderFile")]
        public void StubSourceFileTest_001()
        {
            var director = new StubDirectorForCStyleMockForTest();
            var stubSource = new StubHeaderFile(director);

            Assert.AreEqual("Stub.h", stubSource.FileName);
            Assert.AreEqual(director, stubSource.Director);
        }

        [TestMethod()]
        [TestCategory("StubHeaderFile")]
        [TestCategory("Model")]
        [Description("CreateFile->RunCreateFileSequence")]
        public void StubHeaderFileTest_CreateFile_001()
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
            director.GetMethodHeaderRetVal[0] = "GetMethodHeader";
            director.GetStubBufferExternDeclareRetVal[0] = "GetStubBufferExternDeclare";
            director.GetStubInitMethodExternRetVal[0] = "GetStubInitMethodExtern";
            var stubHeaderFile = new StubHeaderFile(director);
            using var writer = new StreamWriteMock("./sample.txt", false, Encoding.GetEncoding("UTF-8"));
            stubHeaderFile.CreateFile(writer, parameters);

            Assert.AreEqual(13, writer.WriteLineCalledCount);
            Assert.AreEqual(2, writer.WriteCalledCount);
            Assert.AreEqual("#ifndef _STUB_H_", writer.WriteLineArg1[0]);
            Assert.AreEqual("#define _STUB_H_", writer.WriteLineArg1[1]);
            Assert.AreEqual("", writer.WriteLineArg1[2]);
            Assert.AreEqual("#ifdef __cplusplus", writer.WriteLineArg1[3]);
            Assert.AreEqual(@"extern ""C"" {", writer.WriteLineArg1[4]);
            Assert.AreEqual("#endif  /* __cplusplus */", writer.WriteLineArg1[5]);
            Assert.AreEqual("", writer.WriteLineArg1[6]);
            Assert.AreEqual("GetMethodHeader", writer.WriteLineArg1[7]);
            Assert.AreEqual("GetStubBufferExternDeclare", writer.WriteArg1[0]);
            Assert.AreEqual("GetStubInitMethodExtern", writer.WriteArg1[1]);
            Assert.AreEqual("", writer.WriteLineArg1[8]);
            Assert.AreEqual("#ifdef __cplusplus", writer.WriteLineArg1[9]);
            Assert.AreEqual("}", writer.WriteLineArg1[10]);
            Assert.AreEqual("#endif  /* __cplusplus */", writer.WriteLineArg1[11]);
            Assert.AreEqual("#endif /* _STUB_H_ */", writer.WriteLineArg1[12]);

            Assert.AreEqual(1, director.GetMethodHeaderCalledCount);
            Assert.AreEqual(1, director.GetStubBufferExternDeclareCalledCount);
            Assert.AreEqual(1, director.GetStubInitMethodExternCalledCount);
        }

        [TestMethod()]
        [TestCategory("StubHeaderFile")]
        [TestCategory("Model")]
        [Description("CreateFile->RunCreateFileSequence")]
        public void StubHeaderFileTest_CreateFile_002()
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
            director.GetMethodHeaderRetVal[0] = "GetMethodHeader1";
            director.GetStubBufferExternDeclareRetVal[0] = "GetStubBufferExternDeclare1";
            director.GetStubInitMethodExternRetVal[0] = "GetStubInitMethodExtern1";
            director.GetMethodHeaderRetVal[1] = "GetMethodHeader2";
            director.GetStubBufferExternDeclareRetVal[1] = "GetStubBufferExternDeclare2";
            director.GetStubInitMethodExternRetVal[1] = "GetStubInitMethodExtern2";
            var stubHeaderFile = new StubHeaderFile(director);
            using var writer = new StreamWriteMock("./sample.txt", false, Encoding.GetEncoding("UTF-8"));
            stubHeaderFile.CreateFile(writer, parameters);

            Assert.AreEqual(15, writer.WriteLineCalledCount);
            Assert.AreEqual(4, writer.WriteCalledCount);
            Assert.AreEqual("#ifndef _STUB_H_", writer.WriteLineArg1[0]);
            Assert.AreEqual("#define _STUB_H_", writer.WriteLineArg1[1]);
            Assert.AreEqual("", writer.WriteLineArg1[2]);
            Assert.AreEqual("#ifdef __cplusplus", writer.WriteLineArg1[3]);
            Assert.AreEqual(@"extern ""C"" {", writer.WriteLineArg1[4]);
            Assert.AreEqual("#endif  /* __cplusplus */", writer.WriteLineArg1[5]);
            Assert.AreEqual("", writer.WriteLineArg1[6]);
            Assert.AreEqual("GetMethodHeader1", writer.WriteLineArg1[7]);
            Assert.AreEqual("GetStubBufferExternDeclare1", writer.WriteArg1[0]);
            Assert.AreEqual("GetStubInitMethodExtern1", writer.WriteArg1[1]);
            Assert.AreEqual("", writer.WriteLineArg1[8]);
            Assert.AreEqual("GetMethodHeader2", writer.WriteLineArg1[9]);
            Assert.AreEqual("GetStubBufferExternDeclare2", writer.WriteArg1[2]);
            Assert.AreEqual("GetStubInitMethodExtern2", writer.WriteArg1[3]);
            Assert.AreEqual("", writer.WriteLineArg1[10]);
            Assert.AreEqual("#ifdef __cplusplus", writer.WriteLineArg1[11]);
            Assert.AreEqual("}", writer.WriteLineArg1[12]);
            Assert.AreEqual("#endif  /* __cplusplus */", writer.WriteLineArg1[13]);
            Assert.AreEqual("#endif /* _STUB_H_ */", writer.WriteLineArg1[14]);

            Assert.AreEqual(2, director.GetMethodHeaderCalledCount);
            Assert.AreEqual(2, director.GetStubBufferExternDeclareCalledCount);
            Assert.AreEqual(2, director.GetStubInitMethodExternCalledCount);
        }
    }
}