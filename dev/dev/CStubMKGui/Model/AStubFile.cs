using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CStubMKGui.Model
{
    public abstract class AStubFile : IStubFile
    {
        public StubDirectorForCStyle Director { get; set; }
        protected String fileName;

        public void CreateFile(String outputPath, IEnumerable<Param> parameters)
        {
            String outputFilePath = outputPath + @"\" + fileName;
            using var fileStream = new StreamWriter(outputFilePath, false, Encoding.GetEncoding("UTF-8"));
            this.RunCreateFileSequence(fileStream, parameters);
        }

        protected abstract void RunCreateFileSequence(TextWriter stream, IEnumerable<Param> parameters);

        /// <summary>
        /// Output stub header part.
        /// </summary>
        /// <param name="stream">Stream to output stub data.</param>
        protected virtual void StubHeader(TextWriter stream)
        {
            stream.WriteLine(this.Director.GetMethodHeader());
        }

    }
}
