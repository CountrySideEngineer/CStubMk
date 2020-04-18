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
        /// Property of filea name.
        /// </summary>
        public String FileName { get; set; }

        /// <summary>
        /// Method to create stub file.
        /// </summary>
        /// <param name="outputPath">Path to output folder.</param>
        /// <param name="parameters">Parameters of stub file.</param>
        public virtual void CreateFile(String outputPath, IEnumerable<Param> parameters)
        {
            String outputFilePath = outputPath + @"\" + FileName;
            using var fileStream = new StreamWriter(outputFilePath, false, Encoding.GetEncoding("UTF-8"));
            this.CreateFile(fileStream, parameters);
        }

        /// <summary>
        /// Method to create stub file.
        /// </summary>
        /// <param name="writer">Output stream to write code of stub.</param>
        /// <param name="parameters">Parameters of stub file.</param>
        public virtual void CreateFile(TextWriter writer, IEnumerable<Param> parameters)
        {
            this.RunCreateFileSequence(writer, parameters);
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
            stream.Write(this.Director.GetMethodHeader());
#pragma warning restore CA1062 // Varable stream is null-checked.
        }

    }
}
