using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
    /// <summary>
    /// Interface class of parser to parse function definition.
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Interface to extract information and parameters of stub to creat stub function.
        /// </summary>
        /// <param name="functionDefinition">Path of file the function information.</param>
        /// <returns>Parameters for function.</returns>
        public IEnumerable<Param> Parse(String functionDefinition);
    }
}
