using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            this.CreateSourceFile(outputPath, parameters);
            this.CreateHeaderFile(outputPath, parameters);
        }

        /// <summary>
        /// Create source file of stub in C language style.
        /// </summary>
        /// <param name="outputPath">Path to directory to output source file.</param>
        /// <param name="parameters">Parameters to create stub.</param>
        protected void CreateSourceFile(string outputPath, IEnumerable<Param> parameters)
        {
            var codes = this.CreateSourceCode(parameters);
            this.WriteSourceCodes(outputPath, codes);
        }

        /// <summary>
        /// Create list of codes to write to source code file.
        /// </summary>
        /// <param name="parameters">Parameters to output soruce file.</param>
        /// <returns>List fo codes to write to source.</returns>
        protected IEnumerable<string> CreateSourceCode(IEnumerable<Param> parameters)
        {
            var creater = new CLangSourceStubCodeCreater();
            var codes = this.CreateCodes(creater, parameters);

            return codes;
        }

        protected void CreateHeaderFile(string outputPath, IEnumerable<Param> parameters)
        {
            var codes = this.CreateHeaderCode(parameters);
            this.WriteHeaderCodes(outputPath, codes);
        }

        protected IEnumerable<string> CreateHeaderCode(IEnumerable<Param> parameters)
        {
            var creater = new CLangHeaderStubCodeCreater();
            var codes = this.CreateCodes(creater, parameters);

            return codes;
        }

        /// <summary>
        /// Create list of codes to write to source code file.
        /// </summary>
        /// <param name="codeCreater">ICodeCreater concrete object to create code.</param>
        /// <param name="parameters">Parameters to output soruce file.</param>
        /// <returns>List fo codes to write to source.</returns>
        protected virtual IEnumerable<string> CreateCodes(ICodeCreater codeCreater, IEnumerable<Param> parameters)
        {
            var codes = codeCreater.Create(parameters);
            return codes;
        }

        /// <summary>
        /// Write codes into file or directory specified by argument outputPath.
        /// </summary>
        /// <param name="outputPath">Path to directory or file to output codes.</param>
        /// <param name="codes"></param>
        protected virtual void WriteSourceCodes(string outputPath, IEnumerable<string> codes)
        {
            var codeWrtier = new CLangSourceStubCodeWriter(outputPath);
            this.WriteCodes(codeWrtier, codes);
        }

        protected virtual void WriteHeaderCodes(string outputPath, IEnumerable<string> codes)
        {
            var codeWrtier = new CLangHeaderStubCodeWriter(outputPath);
            this.WriteCodes(codeWrtier, codes);
        }

        /// <summary>
        /// Write codes into file or directory specified by argument outputPath.
        /// </summary>
        /// <param name="codeWriter">ICodeWriter concrete object to write codes into files.</param>
        /// <param name="codes">List of codes to write into a file.</param>
        protected virtual void WriteCodes(ICodeWriter codeWriter, IEnumerable<string> codes)
        {
            codeWriter.WriteCode(codes);
        }
        #endregion
    }
}
