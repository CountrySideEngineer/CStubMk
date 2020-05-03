using Microsoft.VisualStudio.TestTools.UnitTesting;
using CStubMKGui.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CStubMKGui.Model.Tests
{
    public class StubFileMock : AStubFile
    {
        public static int BuffSize = 100;
        public int CreateFileCalledCount;
        public string[] CreateFileArg1 = new string[BuffSize];
        public IEnumerable<Param>[] CreateFileArg2 = new IEnumerable<Param>[BuffSize];
        public override void CreateFile(String outputPath, IEnumerable<Param> parameters)
        {
            CreateFileArg1[CreateFileCalledCount] = outputPath;
            CreateFileArg2[CreateFileCalledCount] = parameters;
            CreateFileCalledCount++;
        }

        protected override void RunCreateFileSequence(TextWriter stream, IEnumerable<Param> parameters)
        {
            throw new NotImplementedException();
        }
    }

    public class CStubFileCreaterWrapper : CStubFileCreater
    {
        public virtual void CreateWrap(AStubFile stubFile, String outputPath, IEnumerable<Param> parameters)
        {
            base.Create(stubFile, outputPath, parameters);
        }
    }

    [TestClass()]
    public class CStubFileCreaterTests
    {
        [TestMethod()]
        [TestCategory("CStubFileCreater")]
        [TestCategory("Model")]
        [Description("Unit test of CStubFileCreater class.")]
        public void CreateTest_001()
        {
            var stubFile = new StubFileMock();
            var outputPath = "outputPath";
            var parameters = new List<Param>();
            var stubFileCreater = new CStubFileCreaterWrapper();
            stubFileCreater.CreateWrap(stubFile, outputPath, parameters);

            Assert.AreEqual(1, stubFile.CreateFileCalledCount);
            Assert.AreEqual("outputPath", stubFile.CreateFileArg1[0]);
            Assert.AreEqual(parameters, stubFile.CreateFileArg2[0]);
        }
    }
}