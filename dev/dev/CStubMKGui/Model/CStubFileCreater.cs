using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CStubMKGui.Model
{
	using System.Diagnostics;
	using template;
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
        public virtual void Create(string outputPath, IEnumerable<Param> parameters)
        {
            var template = new SourceStubTemplate(parameters);
            var content = template.TransformText();

            Debug.WriteLine(content);

            var headerTemplate = new HeaderStubTemplate(parameters);
            content = headerTemplate.TransformText();

            Debug.WriteLine(content);

        }

        /// <summary>
        /// Run sequence to create stub files.
        /// </summary>
        /// <param name="outputPath">Path to output source file.</param>
        /// <param name="parameters">Parameters to create stub.</param>
        protected virtual void CreateStub(string outputPath, IEnumerable<Param> parameters)
        {
            var sourceFileCreaters = new List<ISourceFileCreater>
            {
                new StubSourceFileCreater(),
                new StubHeaderFileCreater()
            };
            this.CreateStub(outputPath, sourceFileCreaters, parameters);
        }

        /// <summary>
        /// Run sequence to create stub files by running "Create" method 
        /// </summary>
        /// <param name="outputPath">Path to output source file.</param>
        /// <param name="createres">List of creaters to create stub source and header file.</param>
        /// <param name="parameters">Parameters to create stub.</param>
        protected virtual void CreateStub(string outputPath, IEnumerable<ISourceFileCreater> createres, IEnumerable<Param> parameters)
        {
            foreach (var creater in createres)
            {
                creater.Create(outputPath, parameters);
            }
        }
        #endregion
    }
}
