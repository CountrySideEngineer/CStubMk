using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ClosedXML.Excel;
using System.Linq;
using System.IO;

namespace CStubMKGui.Model
{
    /// <summary>
    /// Parse excel file into Param object.
    /// </summary>
    public class CExcelParser : AExcelParser
    {
        #region Function definition parameters.
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
        /// <summary>
        /// Name of sheet the param, ex name of method, data type, and those of argument, are set.
        /// </summary>
        protected readonly String FunctionDefinitionSheet = "FunctionDefinition";

        /// <summary>
        /// Row index of the data of method is starting to be set.
        /// </summary>
        protected readonly int FuncDefStartRowIndex = 5;

        /// <summary>
        /// Column index the parameter of method is starting.
        /// </summary>
        protected readonly int FuncDefStartColIndex = 2;

        /// <summary>
        /// Column index the argument of method is starting.
        /// </summary>
        protected readonly int ArgDefStartColIndex = 6;

        /// <summary>
        /// Column index of a part, function and argument.
        /// </summary>
        enum TableColIndex {
            Name = 0,
            DataType,
            Prefix,
            PostFix,
            Mode,
            Max,
        };
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません
        #endregion

        /// <summary>
        /// Parse excel file to parameters of function written in the file.
        /// </summary>
        /// <param name="functionDefinition">Path of file the function information.</param>
        /// <returns>Parameters for function.</returns>
        public override IEnumerable<Param> Parse(String functionDefinition)
        {
            using (var fileStream = new StreamReader(functionDefinition))
            {
                var workBook = new XLWorkbook(functionDefinition);
                var workSheet = workBook.Worksheet("FunctionDefinition");
                return this.ExtractSequence(workSheet);
            }
        }


        /// <summary>
        /// Run a sequence to extract parameters of method and that of argument.
        /// </summary>
        /// <param name="workSheet">Worksheet of the table.</param>
        /// <returns>Parameters of method extracted from the work sheet.</returns>
        protected virtual IEnumerable<Param> ExtractSequence(IXLWorksheet workSheet)
        {
            if (null == workSheet)
            {
                throw new ArgumentNullException(nameof(workSheet));
            }
            else
            {
                int startRowIndex = FuncDefStartRowIndex;
                int lastRowIndex = workSheet.LastRowUsed().RowNumber();
                var parameters = new List<Param>();
                while (startRowIndex <= lastRowIndex)
                {
                    int nextStartRow = 0;
                    try
                    {
                        nextStartRow = this.FindNextItem(workSheet, startRowIndex, FuncDefStartColIndex);
                    }
                    catch (Exception ex)
                    when ((ex is InvalidOperationException) || (ex is NullReferenceException))
                    {
                        nextStartRow = (lastRowIndex + 1);
                    }
                    Param param = this.ExtractMethod(workSheet, startRowIndex, (nextStartRow - startRowIndex));
                    parameters.Add(param);

                    startRowIndex = nextStartRow;
                }
                return parameters;
            }
        }

        /// <summary>
        /// Extract method parameters.
        /// </summary>
        /// <param name="workSheet">Worksheet of the table.</param>
        /// <param name="startRowIndex">Row index to start extracting.</param>
        /// <param name="argNum">The number of argument.</param>
        /// <returns>Param object contains the parameters to define a method.</returns>
        protected virtual Param ExtractMethod(IXLWorksheet workSheet, int startRowIndex, int argNum)
        {
            var param = this.ExtractMethod(workSheet, startRowIndex);
            var parameters = new List<Param>();
            for (int index = 0; index < argNum; index++)
            {
                var argument = this.ExtractArgument(workSheet, (startRowIndex + index));
                parameters.Add(argument);
            }
            param.Parameters = parameters;
            return param;
        }

        /// <summary>
        /// Extract parameters to define method.
        /// </summary>
        /// <param name="workSheet">Worksheet of the table.</param>
        /// <param name="startRowIndex">Index of row to start extract method definition.</param>
        /// <returns>Param object contains method definition</returns>
        /// <exception cref="ArgumentNullException">The argument workSheet is null.</exception>
        protected virtual Param ExtractMethod(IXLWorksheet workSheet, int startRowIndex)
        {
            return this.ExtractParam(workSheet, startRowIndex, FuncDefStartColIndex);
        }

        /// <summary>
        /// Extract parameters of argument.
        /// </summary>
        /// <param name="workSheet">Worksheet of the table.</param>
        /// <param name="startRowIndex">Index of row to start extract argument definition.</param>
        /// <returns>Param object contains argument definition</returns>
        /// <exception cref="ArgumentNullException">The argument workSheet is null.</exception>
        protected virtual Param ExtractArgument(IXLWorksheet workSheet, int startRowIndex)
        {
            return this.ExtractParam(workSheet, startRowIndex, ArgDefStartColIndex);
        }

        /// <summary>
        /// Extract parameters from table <para>worksheet</para> starting with <para>startRowIndex</para> and <para>startColIndex</para>.
        /// </summary>
        /// <param name="workSheet">Worksheet of the table.</param>
        /// <param name="startRowIndx">Index of row to start extract parameters.</param>
        /// <param name="startColIndex">Index of column to start extract parameters.</param>
        /// <returns>Param object contains extracted parameters.</returns>
        /// <exception cref="ArgumentNullException">The argument workSheet is null.</exception>
        /// <exception cref="InvalidOperationException">The data in sheet is invalid.</exception>
        protected virtual Param ExtractParam(IXLWorksheet workSheet, int startRowIndx, int startColIndex)
        {
            if (null == workSheet)
            {
                throw new ArgumentNullException(nameof(workSheet));
            }
            else
            {
                var name = workSheet.Cell(startRowIndx, startColIndex + (int)TableColIndex.Name).GetString();
                var dataType = workSheet.Cell(startRowIndx, startColIndex + (int)TableColIndex.DataType).GetString();
                var prefix = workSheet.Cell(startRowIndx, startColIndex + (int)TableColIndex.Prefix).GetString();
                var postfix = workSheet.Cell(startRowIndx, startColIndex + (int)TableColIndex.PostFix).GetString();
                var mode = workSheet.Cell(startRowIndx, startColIndex + (int)TableColIndex.Mode).GetString();
                var pointerNum = this.RemovePointer(ref dataType);
                var accessMode = Param.AccessMode.None;
                try
                {
                    accessMode = Param.ToMode(mode);
                }
                catch (InvalidOperationException)
                {

                    Debug.WriteLine($"Invvaid mode : Set as None");
                }
                var param = new Param
                {
                    Name = name,
                    DataType = dataType,
                    Prefix = prefix,
                    Postifx = postfix,
                    PointerNum = (Byte)pointerNum,
                    Mode = accessMode
                };
                return param;
            }
        }

        /// <summary>
        /// Remove pointer mark, "*", from string showing data type.
        /// </summary>
        /// <param name="dataType">Data type string</param>
        /// <returns>The number of sign removed from argument.</returns>
        protected virtual int RemovePointer(ref String dataType)
        {
            if (null == dataType)
            {
                throw new ArgumentNullException(nameof(dataType));
            }
            else
            {
                int pointerNum = 0;
                int dataTypeLen = dataType.Length;
                for (int readIndex = 0; readIndex < dataTypeLen; readIndex++)
                {
                    String readChar = dataType.Substring(dataTypeLen - 1 - readIndex, 1);
                    if (("*").Equals(readChar, StringComparison.Ordinal))
                    {
                        pointerNum++;
                    }
                }
                dataType = dataType.Substring(0, dataTypeLen - pointerNum);
                return pointerNum;
            }
        }

        /// <summary>
        /// Find next item row index.
        /// </summary>
        /// <param name="workSheet">Worksheet of the table.</param>
        /// <param name="startRowIndex">Index of row to start scan.</param>
        /// <param name="colIndex">Index of column to scan.</param>
        /// <returns>Row index of next item found.</returns>
        /// <exception cref="InvalidOperationException">Can not find next item.</exception>
        /// <exception cref="NullReferenceException">Call not find next item.</exception>
        protected virtual int FindNextItem(IXLWorksheet workSheet, int startRowIndex, int colIndex)
        {
            if (null == workSheet)
            {
                throw new ArgumentNullException(nameof(workSheet));
            }
            else
            {
                try
                {
                    var columns = workSheet.Columns(colIndex, colIndex);
                    var lastRowIndex = workSheet.LastRowUsed().RowNumber();
                    IEnumerable<IXLCell> cells = columns.Cells()
                        .Where(_ =>
                            (startRowIndex < _.Address.RowNumber) &&
                            (_.Address.RowNumber <= lastRowIndex) &&
                            ((!(string.IsNullOrEmpty(_.GetString()))) && (!string.IsNullOrWhiteSpace(_.GetString())))
                            );
                    int minRowNum = cells.Min(_ => _.Address.RowNumber);
                    return minRowNum;
                }
                catch (Exception ex)
                when ((ex is InvalidOperationException) || (ex is NullReferenceException))
                {
                    /*
                     * Can not find next item in a column.
                     * It is that the cell whose row number is startRowIndex is the last item cell.
                     */
                    throw;
                }
            }
        }
    }
}
