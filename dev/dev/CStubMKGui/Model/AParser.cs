using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ClosedXML.Excel;

namespace CStubMKGui.Model
{
    public abstract class AParser : IParser
    {
        private const string ExcelExtension = ".xlsx";


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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:ローカライズされるパラメーターとしてリテラルを渡さない", Justification = "<保留中>")]
        public static AParser ParserFactory(string funcDefPath)
        {
            try
            {
                var extention = Path.GetExtension(funcDefPath);
                if (extention.Equals(ExcelExtension, StringComparison.Ordinal))
                {
                    var parser = AExcelParser.GetParser(funcDefPath);
                    return parser;
                }
                else
                {
                    throw new NotSupportedException(nameof(funcDefPath));
                }
            }
            catch (Exception ex)
            when ((ex is ArgumentNullException) ||
                (ex is FileNotFoundException) ||
                (ex is NotSupportedException))
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion
    }
}
