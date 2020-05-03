using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
    public class CStubMk : IStubMk
    {
        #region Public properties
        /// <summary>
        /// Create Stub file.
        /// </summary>
        /// <param name="functionDefinition">Path to file the definition of method is written.</param>
        /// <param name="outputPath">Path to folder to output the stub file.</param>
        public void Create(String functionDefinition, String outputPath)
        {
            var parser = AParser.ParserFactory(functionDefinition);
            var parameters = parser.Parse(functionDefinition);
            var creater = new CStubFileCreater();
            creater.Create(outputPath, parameters);
        }
        #endregion
    }
}
