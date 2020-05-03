using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
    /// <summary>
    /// Interface function to create stub file of function or method.
    /// </summary>
    public interface IStubMk
    {
        #region Interface
        /// <summary>
        /// To create stub from information of method to be replaced by stub.
        /// </summary>
        /// <param name="functionDefinition">Path to file the method is declared.</param>
        /// <param name="outputPath">Path to output the stub file.</param>
        public void Create(String functionDefinition, String outputPath);
        #endregion
    }
}
