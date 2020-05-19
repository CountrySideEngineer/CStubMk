using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CStubMKGui.Model
{
    public abstract class AExcelParser : AParser
    {
        private const int langRowIndex = 1;
        private const int langColIndex = 2;
        private const int versionRowIndex = 2;
        private const int versionColIndex = 2;
        private const string langC = "C";
        private const string langCpp = "CPP";
        private const string funcDefSheetName = "FunctionDefinition";

        #region FactoryMethod.
        /// <summary>
        /// Create parser to parse function definition in microsoft excel file.
        /// </summary>
        /// <param name="funcDefPath">Path to excel file target function defined.</param>
        /// <returns>Parser to parse excel.</returns>
        /// <exception cref="ArgumentNullException">The worksheet is null.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:ローカライズされるパラメーターとしてリテラルを渡さない", Justification = "<保留中>")]
        public static AParser GetParser(string funcDefPath)
        {
            try
            {
                using (var fileStream = new FileStream(funcDefPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var workBook = new XLWorkbook(fileStream, XLEventTracking.Disabled);//Read only
                    var workSheet = workBook.Worksheet(funcDefSheetName);
                    return AExcelParser.GetParser(workSheet);
                }
            }
            catch (Exception ex)
            when ((ex is ArgumentNullException) || (ex is FileNotFoundException))
            {
                Console.WriteLine("指定されたファイル、または関数を定義しているシートが見つかりません。");
                throw;
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("サポートしていない言語が指定されました。");
                throw;
            }
        }

        /// <summary>
        /// Create parser to parse function definition in microsoft excel file.
        /// </summary>
        /// <param name="worksheet">Worksheet object which contains function defined.</param>
        /// <returns>Parser to parse excel.</returns>
        /// <exception cref="ArgumentNullException">The worksheet is null.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:ローカライズされるパラメーターとしてリテラルを渡さない", Justification = "<保留中>")]
        protected static AParser GetParser(IXLWorksheet worksheet)
        {
            var lang = GetLang(worksheet);
            if (lang.Equals(AExcelParser.langC, StringComparison.Ordinal))
            {
                return new CExcelParser();
            }
            else
            {
                throw new NotSupportedException(nameof(worksheet));
            }
        }

        /// <summary>
        /// Get programming language set in worksheet.
        /// </summary>
        /// <param name="workSheet">Worksheet object which contains function defined.</param>
        /// <returns>Programming language the sheet assumes.</returns>
        /// <exception cref="ArgumentNullException">The worksheet is null.</exception>
        protected static string GetLang(IXLWorksheet workSheet)
        {
            return AExcelParser.GetCellString(workSheet, AExcelParser.langRowIndex, AExcelParser.langColIndex);
        }

        /// <summary>
        /// Get version of the worksheet.
        /// </summary>
        /// <param name="workSheet">Worksheet object which contains function defined.</param>
        /// <returns>Version of the sheet.</returns>
        /// <exception cref="ArgumentNullException">The worksheet is null.</exception>
        protected static string GetVersion(IXLWorksheet workSheet)
        {
            return AExcelParser.GetCellString(workSheet, versionRowIndex, versionColIndex);
        }

        /// <summary>
        /// Get cell value in string
        /// </summary>
        /// <param name="workSheet">Worksheet object which contains function defined.</param>
        /// <param name="rowIndex">Row index to get.</param>
        /// <param name="colIndex">Col index to get.</param>
        /// <returns>Cell value in string.</returns>
        /// <exception cref="ArgumentNullException">The worksheet is null.</exception>
        protected static string GetCellString(IXLWorksheet workSheet, int rowIndex, int colIndex)
        {
            if (null == workSheet)
            {
                throw new ArgumentNullException(nameof(workSheet));
            }
            else
            {
                var cellString = workSheet.Cell(rowIndex, colIndex).GetString();
                return cellString;
            }
        }
        #endregion

    }

}
