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

        #region FactoryMethod.
        /// <summary>
        /// Create parser to parse functino definition.
        /// </summary>
        /// <param name="funcDefPath">Path to function definition file.</param>
        /// <returns>A parser object to parse the file.</returns>
        public static AParser ParserFactory(string funcDefPath)
        {
            return new CExcelParser();
        }
        #endregion
    }
}
