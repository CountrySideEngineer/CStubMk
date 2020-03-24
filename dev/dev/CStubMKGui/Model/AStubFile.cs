using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CStubMKGui.Model
{
    public abstract class AStubFile : IStubFile
    {
        /// <summary>
        /// Property of director of Stub.
        /// </summary>
        public StubDirectorForCStyle Director { get; set; }

        /// <summary>
        /// field of file name.
        /// </summary>
        private String fileName;

        /// <summary>
        /// Property of filea name.
        /// </summary>
        protected String FileName {
            get { return this.fileName; }
            set { this.fileName = value; }
        }

        /// <summary>
        /// Method to create stub file.
        /// </summary>
        /// <param name="outputPath">Path to output folder.</param>
        /// <param name="parameters">Parameters of stub file.</param>
        public void CreateFile(String outputPath, IEnumerable<Param> parameters)
        {
            String outputFilePath = outputPath + @"\" + fileName;
            using var fileStream = new StreamWriter(outputFilePath, false, Encoding.GetEncoding("UTF-8"));
            this.RunCreateFileSequence(fileStream, parameters);
        }

        /// <summary>
        /// Pure virtual method running sequence to 
        /// </summary>
        /// <param name="stream">Stream that the stub file output.</param>
        /// <param name="parameters">Parameters of stub file.</param>
        protected abstract void RunCreateFileSequence(TextWriter stream, IEnumerable<Param> parameters);

        /// <summary>
        /// Output stub header part.
        /// </summary>
        /// <param name="stream">Stream to output stub data.</param>
        protected virtual void StubHeader(TextWriter stream)
        {
            Debug.Assert(null != stream);

#pragma warning disable CA1062 // Varable stream is null-checked.
            stream.WriteLine(this.Director.GetMethodHeader());
#pragma warning restore CA1062 // Varable stream is null-checked.
        }

    }
}
