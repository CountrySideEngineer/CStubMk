using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
    public class CStubMk : IStubMk
    {
        #region Public properties
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
