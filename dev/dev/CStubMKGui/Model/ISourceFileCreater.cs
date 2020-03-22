using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
    /// <summary>
    /// Interface of class to create source file.
    /// </summary>
    public interface ISourceFileCreater
    {
        /// <summary>
        /// Interface of method to create source file for test.
        /// </summary>
        /// <param name="outputPath">Path to directory for output files.</param>
        /// <param name="parameters">Parameters used to create files.</param>
        public void Create(String outputPath, IEnumerable<Param> parameters);
    }
}
