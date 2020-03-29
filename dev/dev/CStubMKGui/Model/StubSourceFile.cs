using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CStubMKGui.Model
{
    public class StubSourceFile : AStubFile
    {
        #region Constructors and the finalizer
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="director">Director object to create code of stub.</param>
        public StubSourceFile(StubDirectorForCStyle director)
        {
            this.FileName = "Stub.c";
            this.Director = director;
        }
        #endregion

        #region Other methods and private properties in calling order
        /// <summary>
        /// Sequence to create stub file.
        /// </summary>
        /// <param name="stream">Stream to output stub data.</param>
        /// <param name="parameters">Informations for stub.</param>
        /// <exception cref="ArgumentNullException">
        /// Argument <para>stream</para> and/or <para>parameters</para> are null.
        /// </exception>
        protected override void RunCreateFileSequence(TextWriter stream, IEnumerable<Param> parameters)
        {
            if (null == parameters) 
            {
                throw new ArgumentNullException(nameof(parameters));
            } 
            else if (null == stream)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            else
            {
                this.IncludePart(stream);
                this.DefinePart(stream);
                foreach (var param in parameters)
                {
                    this.Director.Parameter = param;
                    this.CreateFunctionStub(stream);
                    stream.WriteLine(); //Insert an empty line between stub method.
                }
            }

        }

        /// <summary>
        /// Output "include" part of source code.
        /// </summary>
        /// <param name="stream">Stream to output stub data.</param>
        /// <exception cref="ArgumentNullException">Argument <para>stream</para> is null.</exception>
        protected virtual void IncludePart(TextWriter stream)
        {
            if (null == stream)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            else
            {
                stream.WriteLine("#include <stdio.h>");
                stream.WriteLine("");
            }
        }

        /// <summary>
        /// Create code to define macro.
        /// </summary>
        /// <param name="stream">Stream to output stub data.</param>
        /// <exception cref="ArgumentNullException">Argument <para>stream</para> is null.</exception>
        protected virtual void DefinePart(TextWriter stream)
        {
            if (null == stream)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            else
            {
                stream.Write(this.Director.GetDefinePart());
                stream.WriteLine("");
            }
        }

        /// <summary>
        /// Output stub of function.
        /// </summary>
        /// <param name="stream">Stream to output stub data.</param>
        /// <exception cref="ArgumentNullException">Argument <para>stream</para> is null.</exception>
        protected virtual void CreateFunctionStub(TextWriter stream)
        {
            if (null == stream)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            else
            {
                this.StubHeader(stream);
                this.BufferDeclare(stream);
                this.StubBody(stream);
                this.StubInitPart(stream);
            }
        }

        /// <summary>
        /// Output declaration of buffer used to latch, store, argument 
        /// </summary>
        /// <param name="stream">Stream to output stub data.</param>
        /// <exception cref="ArgumentNullException">Argument <para>stream</para> is null.</exception>
        protected virtual void BufferDeclare(TextWriter stream)
        {
            if (null == stream)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            else
            {
                stream.Write(this.Director.GetStubBufferDeclare());
            }
        }

        /// <summary>
        /// Output body of stub.
        /// </summary>
        /// <param name="stream">Stream to output stub data.</param>
        /// <exception cref="ArgumentNullException">Argument <para>stream</para> is null.</exception>
        protected virtual void StubBody(TextWriter stream)
        {
            if (null == stream)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            else
            {
                stream.Write(this.Director.GetStubMethod());
            }
        }

        /// <summary>
        /// Output method to initialize buffer of stub.
        /// </summary>
        /// <param name="stream">Stream to output stub data.</param>
        /// <exception cref="ArgumentNullException">Argument <para>stream</para> is null.</exception>
        protected virtual void StubInitPart(TextWriter stream)
        {
            if (null == stream)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            else
            {
                stream.Write(this.Director.GetStubInitMethod());
            }
        }
        #endregion
    }
}
