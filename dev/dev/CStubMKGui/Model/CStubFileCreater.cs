using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
    /// <summary>
    /// Create source file to create C language source file.
    /// </summary>
    public class CStubFileCreater : ISourceFileCreater
    {
        #region Constructors and the finalizer
        /// <summary>
        /// Default constructor.
        /// </summary>
        public CStubFileCreater() {}
        #endregion

        #region Other methods and private properties in calling order
        /// <summary>
        /// Create source file of stub in C language style.
        /// </summary>
        /// <param name="outputPath">Path to output source file.</param>
        /// <param name="parameters">Parameters to create stub.</param>
        public virtual void Create(String outputPath, IEnumerable<Param> parameters)
        {
            this.CreatSource(outputPath, parameters, new StubSourceDirectorForCStyle());
            this.CreatHeader(outputPath, parameters, new StubHeaderDirectorForCStyle());
        }

        protected virtual void CreatSource(String outputPath, IEnumerable<Param> parameters, StubDirectorForCStyle director)
        {
            this.Create(new StubSourceFile(director), outputPath, parameters);
        }

        protected virtual void CreatHeader(String outputPath, IEnumerable<Param> parameters, StubDirectorForCStyle director)
        {
            this.Create(new StubHeaderFile(director), outputPath, parameters);
        }

        /// <summary>
        /// Call sequence to create source files (including header file) of stub.
        /// </summary>
        /// <param name="stubFile">Object to create source file.</param>
        /// <param name="outputPath">Path to output source file.</param>
        /// <param name="parameters">Parameters to create stub.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:パブリック メソッドの引数の検証", Justification = "<保留中>")]
        protected virtual void Create(AStubFile stubFile, String outputPath, IEnumerable<Param> parameters)
        {
            stubFile.CreateFile(outputPath, parameters);
        }
        #endregion
    }
}
