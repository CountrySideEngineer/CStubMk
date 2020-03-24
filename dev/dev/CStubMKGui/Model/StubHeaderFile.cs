using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CStubMKGui.Model
{
    public class StubHeaderFile : AStubFile
    {
        #region Constructors and the finalizer
        /// <summary>
        /// Constructor with director object.
        /// </summary>
        /// <param name="director">Director object to create header of stub.</param>
        public StubHeaderFile(StubDirectorForCStyle director)
        {
            this.FileName = "Stub.h";
            this.Director = director;
        }
        #endregion

        #region Other methods and private properties in calling order
        /// <summary>
        /// Run sequence to create stub header file.
        /// </summary>
        /// <param name="stream">Stream to output stub declaration part.</param>
        /// <param name="parameters">Informations for stub.</param>
        protected override void RunCreateFileSequence(TextWriter stream, IEnumerable<Param> parameters)
        {
            this.DefineHeaderMacro(stream);
            this.DeclareExternCppStart(stream);
            foreach (var param in parameters)
            {
                this.Director.Parameter = param;
                this.CreateStubDeclare(stream);
                stream.WriteLine(); //Insert an empty line between stub method.
            }
            this.DeclareExternCppEnd(stream);
            this.EndIfMacro(stream);
        }

        /// <summary>
        /// Output "define" part to prevent from duplicate including.
        /// </summary>
        /// <param name="stream">Stream to output stub declaration part.</param>
        protected void DefineHeaderMacro(TextWriter stream)
        {
            stream.WriteLine("#ifndef _STUB_H_");
            stream.WriteLine("#define _STUB_H_");
            stream.WriteLine("");
        }

        /// <summary>
        /// Output code to make the header file readable in CPP language.
        /// </summary>
        /// <param name="stream">Stream to output stub declaration part.</param>
        protected void DeclareExternCppStart(TextWriter stream)
        {
            stream.WriteLine("#ifdef __cplusplus");
            stream.WriteLine(@"extern ""C"" {");
            stream.WriteLine("#endif  /* __cplusplus */");
            stream.WriteLine("");
        }

        /// <summary>
        /// Output stub declare part.
        /// </summary>
        /// <param name="stream">Stream to output stub declaration part.</param>
        protected void CreateStubDeclare(TextWriter stream)
        {
            //関数ヘッダー
            this.StubHeader(stream);
            this.BufferExtern(stream);
            this.BufferInitExtern(stream);
            stream.WriteLine("");
        }

        /// <summary>
        /// Output code for extern declare buffer of stub.
        /// </summary>
        /// <param name="stream">Stream to output stub declaration part.</param>
        protected void BufferExtern(TextWriter stream)
        {
            stream.Write(this.Director.GetStubBufferExternDeclare());
        }

        /// <summary>
        /// Output code for extern declare method to initialize buffer of stub.
        /// </summary>
        /// <param name="stream">Stream to output stub declaration part.</param>
        protected void BufferInitExtern(TextWriter stream)
        {
            stream.Write(this.Director.GetStubInitMethodExtern());
        }

        /// <summary>
        /// Output end of code to make the header file readable in CPP language.
        /// </summary>
        /// <param name="stream">Stream to output stub declaration part.</param>
        protected void DeclareExternCppEnd(TextWriter stream)
        {
            stream.WriteLine("#ifdef __cplusplus");
            stream.WriteLine("}");
            stream.WriteLine("#endif  /* __cplusplus */");
        }

        /// <summary>
        /// Output "end of define" part to prevent from duplicate including.
        /// </summary>
        /// <param name="stream">Stream to output stub declaration part.</param>
        protected void EndIfMacro(TextWriter stream)
        {
            stream.WriteLine("#endif /* _STUB_H_ */");
        }
        #endregion
    }
}
