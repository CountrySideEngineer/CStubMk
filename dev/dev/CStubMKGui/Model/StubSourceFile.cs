using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CStubMKGui.Model
{
    public class StubSourceFile : AStubFile
    {
        #region Private fields and constants
        /// <summary>
        /// Stub file name.
        /// </summary>
        protected String fileName = "Stub.c";
        #endregion

        #region Constructors and the finalizer
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="director">Director object to create code of stub.</param>
        public StubSourceFile(StubDirectorForCStyle director)
        {
            this.Director = director;
        }
        #endregion

        #region Other methods and private properties in calling order
        /// <summary>
        /// Create stub file.
        /// </summary>
        /// <param name="outputPath">Path to folder the stub source file is created.</param>
        /// <param name="parameters">Informations for stub.</param>
        public override void CreateFile(String outputPath, IEnumerable<Param> parameters)
        {
            String outputFilePath = outputPath + @"\" + fileName;
            using var fileStream = new StreamWriter(outputFilePath, false, Encoding.GetEncoding("UTF-8"));
            this.RunSequence(fileStream, parameters);
        }

        /// <summary>
        /// Sequence to create stub file.
        /// </summary>
        /// <param name="stream">Stream to output stub data.</param>
        /// <param name="parameters">Informations for stub.</param>
        protected virtual void RunSequence(TextWriter stream, IEnumerable<Param> parameters)
        {
            this.IncludePart(stream);
            foreach (var param in parameters)
            {
                this.Director.Parameter = param;
                this.CreateFunctionStub(stream, param);
                stream.WriteLine(); //Insert an empty line between stub method.
            }
        }

        /// <summary>
        /// Output "include" part of source code.
        /// </summary>
        /// <param name="stream">Stream to output stub data.</param>
        protected virtual void IncludePart(TextWriter stream)
        {
            stream.WriteLine("#include <stdio.h>");
            stream.WriteLine("");
        }

        protected virtual void DefinePart(TextWriter stream)
        {
            stream.Write(this.Director.GetDefinePart());
            stream.WriteLine("");
        }

        /// <summary>
        /// Output stub of function.
        /// </summary>
        /// <param name="stream">Stream to output stub data.</param>
        /// <param name="function">Information of function for stub.</param>
        protected virtual void CreateFunctionStub(TextWriter stream, Param function)
        {
            this.StubHeader(stream);
            this.BufferDeclare(stream);
            this.StubBody(stream);
            this.StubInitPart(stream);
        }

        /// <summary>
        /// Output stub header part.
        /// </summary>
        /// <param name="stream">Stream to output stub data.</param>
        protected virtual void StubHeader(TextWriter stream)
        {
            stream.WriteLine(this.Director.GetMethodHeader());
        }

        /// <summary>
        /// Output declaration of buffer used to latch, store, argument 
        /// </summary>
        /// <param name="stream">Stream to output stub data.</param>
        /// <param name="argumentParams"></param>
        protected virtual void BufferDeclare(TextWriter stream)
        {
            stream.Write(this.Director.GetStubBufferDeclare());
        }

        /// <summary>
        /// Output body of stub.
        /// </summary>
        /// <param name="stream">Stream to output stub data.</param>
        protected virtual void StubBody(TextWriter stream)
        {
            stream.Write(this.Director.GetStubMethod());
        }

        /// <summary>
        /// Output method to initialize buffer of stub.
        /// </summary>
        /// <param name="stream">Stream to output stub data.</param>
        protected virtual void StubInitPart(TextWriter stream)
        {
            stream.Write(this.Director.GetStubInitMethod());
        }
        #endregion
    }
}
