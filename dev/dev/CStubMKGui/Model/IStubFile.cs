using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
    /// <summary>
    /// Interface to create stub file.
    /// </summary>
    public interface IStubFile
    {
        /// <summary>
        /// Interface to create stub file.
        /// </summary>
        /// <param name="outputPath">Path to folder to create stub files </param>
        /// <param name="parameters">Information about function to create stub.</param>
        public void CreateFile(String outputPath, IEnumerable<Param> parameters);
    }
}
