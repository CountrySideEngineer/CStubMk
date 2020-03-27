using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
    public abstract class AParser : IParser
    {
        #region Other methods and private properties in calling order
        /// <summary>
        /// Interface to extract information and parameters of stub to creat stub function.
        /// </summary>
        /// <param name="functionDefinition">Path of file the function information.</param>
        /// <returns>Parameters for function.</returns>
        public abstract IEnumerable<Param> Parse(String functionDefinition);
        #endregion
    }
}
