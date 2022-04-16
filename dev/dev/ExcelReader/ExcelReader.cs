using ClosedXML.Excel;
using ExcelReader.Exception;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelReader
{
    public class ExcelReader
    {
        /// <summary>
        /// Excel file stream to read.
        /// </summary>
        protected Stream _excelStream;

        /// <summary>
        /// Current access workbook.
        /// </summary>
        protected IXLWorkbook _currentBook;

        /// <summary>
        /// Sheet name to read.
        /// </summary>
        public string SheetName { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <remarks>Un-accessable.</remarks>
        protected ExcelReader()
		{
            _excelStream = null;
            SheetName = string.Empty;
		}

        /// <summary>
        /// Constructor with argument.
        /// </summary>
        /// <param name="stream">Excel file stream.</param>
        public ExcelReader(Stream stream)
		{
            _excelStream = stream;
		}

        /// <summary>
        /// Find first cell which contains "item" value in a table 
        /// </summary>
        /// <param name="item">Item to find.</param>
        /// <returns>A cell position which contains item as Range object.</returns>
        /// <exception cref="ExcelReaderException">An exception occurred while reading excel sheet.</exception>
        public virtual Range FindFirstItem(string item)
		{
            try
			{
                var workBook = new XLWorkbook(_excelStream);
                var workSheet = workBook.Worksheet(SheetName);
                var itemCell = workSheet.CellsUsed()
                    .Where(_ => (0 == string.Compare(_.GetString(), item)))
                    .FirstOrDefault();
                var range = new Range()
                {
                    StartRow = Convert.ToUInt64(itemCell.Address.RowNumber),
                    StartColumn = Convert.ToUInt64(itemCell.Address.ColumnNumber)
                };
                return range;
			}
            catch (System.Exception ex)
            when ((ex is NullReferenceException) || (ex is ArgumentException))
			{
                var exception = new ExcelReaderException("Error while work sheet scan.", ex);
                throw exception;
			}
		}

        /// <summary>
        /// Find first cell range which contains "item" in the range.
        /// </summary>
        /// <param name="item">Item to find.</param>
        /// <param name="range">Range to scan.</param>
        /// <returns>A cell position which contains item as Range object.</returns>
        /// <exception cref="ExcelReaderException">An exception occurred while reading excel sheet.</exception>
        public virtual Range FindFirstItem(string item, Range range)
		{
            try
            {
                var workBook = new XLWorkbook(_excelStream);
                var workSheet = workBook.Worksheet(SheetName);
                var itemCell = workSheet.CellsUsed()
                    .Where(_ => (0 == string.Compare(_.GetString(), item)) &&
                    (range.StartRow <= Convert.ToUInt64(_.Address.RowNumber)) && 
                    ((Convert.ToUInt64(_.Address.RowNumber) <= (range.StartRow + range.RowCount - 1))) &&
                    (range.StartColumn <= Convert.ToUInt64(_.Address.ColumnNumber)) &&
                    ((Convert.ToUInt64(_.Address.ColumnNumber) <= (range.StartColumn + range.ColumnCount - 1))))
                    .FirstOrDefault();
                var itemRange = new Range()
                {
                    StartRow = Convert.ToUInt64(itemCell.Address.RowNumber),
                    StartColumn = Convert.ToUInt64(itemCell.Address.ColumnNumber)
                };
                return itemRange;
            }
            catch (System.Exception ex)
            when ((ex is NullReferenceException) || (ex is ArgumentException))
            {
                var exception = new ExcelReaderException("Error while work sheet scan.", ex);
                throw exception;
            }
        }

        /// <summary>
        /// Find first cell in a column specified by argument range.
        /// </summary>
        /// <param name="item">Item to find.</param>
        /// <param name="range">Range to scan.</param>
        /// <returns>A cell position which contains item as Range object.</returns>
        /// <exception cref="ExcelReaderException">An exception occurred while reading excel sheet.</exception>
        public virtual Range FindFirstItemInColumn(string item, Range range)
		{
            try
            {
                var workBook = new XLWorkbook(_excelStream);
                var workSheet = workBook.Worksheet(SheetName);
                var itemCell = workSheet.CellsUsed()
                    .Where(_ => (0 == string.Compare(_.GetString(), item)) &&
                    (range.StartRow <= Convert.ToUInt64(_.Address.RowNumber)) &&
                    ((Convert.ToUInt64(_.Address.RowNumber) <= (range.StartRow + range.RowCount - 1))) &&
                    (Convert.ToUInt64(_.Address.ColumnNumber) == range.StartColumn))
                    .FirstOrDefault();
                var itemRange = new Range()
                {
                    StartRow = Convert.ToUInt64(itemCell.Address.RowNumber),
                    StartColumn = Convert.ToUInt64(itemCell.Address.ColumnNumber)
                };
                return itemRange;
            }
            catch (System.Exception ex)
            when ((ex is NullReferenceException) || (ex is ArgumentException))
            {
                var exception = new ExcelReaderException("Error while work sheet scan.", ex);
                throw exception;
            }
        }

        /// <summary>
        /// Find first cell in a column specified by argument range.
        /// </summary>
        /// <param name="item">Item to find.</param>
        /// <param name="range">Range to scan.</param>
        /// <returns>A cell position which contains item as Range object.</returns>
        /// <exception cref="ExcelReaderException">An exception occurred while reading excel sheet.</exception>
        public virtual Range FindFirstitemInRow(string item, Range range)
        {
            try
            {
                var workBook = new XLWorkbook(_excelStream);
                var workSheet = workBook.Worksheet(SheetName);
                var itemCell = workSheet.CellsUsed()
                    .Where(_ => (0 == string.Compare(_.GetString(), item)) &&
                    (Convert.ToUInt64(_.Address.RowNumber) == range.StartRow) &&
                    (range.StartColumn <= Convert.ToUInt64(_.Address.ColumnNumber)) &&
                    ((Convert.ToUInt64(_.Address.ColumnNumber) <= (range.StartColumn + range.ColumnCount - 1))))
                    .FirstOrDefault();
                var itemRange = new Range()
                {
                    StartRow = Convert.ToUInt64(itemCell.Address.RowNumber),
                    StartColumn = Convert.ToUInt64(itemCell.Address.ColumnNumber)
                };
                return itemRange;
            }
            catch (System.Exception ex)
            when ((ex is NullReferenceException) || (ex is ArgumentException))
            {
                var exception = new ExcelReaderException("Error while work sheet scan.", ex);
                throw exception;
            }
        }

        /// <summary>
        /// Find cell contains item.
        /// </summary>
        /// <param name="item">Item to find.</param>
        /// <returns>Collection of Range object wihch contains item.</returns>
        /// <exception cref="ExcelReaderException">An exception occurred while reading excel sheet.</exception>
        public virtual IEnumerable<Range> FindItem(string item)
		{
            try
            {
                var workBook = new XLWorkbook(_excelStream);
                var workSheet = workBook.Worksheet(SheetName);
                var itemCells = workSheet.CellsUsed()
                    .Where(_ => (0 == string.Compare(_.GetString(), item)));
                if (0 == itemCells.Count())
				{
                    throw new ExcelReaderException("No cells can find.");
				}
                var rangeList = new List<Range>();
                foreach (var itemCell in itemCells)
				{
                    var itemRange = new Range()
                    {
                        StartRow = Convert.ToUInt64(itemCell.Address.RowNumber),
                        StartColumn = Convert.ToUInt64(itemCell.Address.ColumnNumber)
                    };
                    rangeList.Add(itemRange);
                }
                return rangeList;
            }
            catch (System.Exception ex)
            when ((ex is NullReferenceException) || (ex is ArgumentException))
            {
                var exception = new ExcelReaderException("Error while finding item in a sheet.", ex);
                throw exception;
            }
        }

        /// <summary>
        /// Read row.
        /// </summary>
        /// <param name="range">Range to read.</param>
        /// <returns>Collection of row items</returns>
        /// <exception cref="ExcelReaderException">Exception occurred while reading excel file.</exception>
        public virtual IEnumerable<string> ReadRow(Range range)
		{
            try
            {
                var workBook = new XLWorkbook(_excelStream);
                var workSheet = workBook.Worksheet(SheetName);
                var cells = workSheet.CellsUsed()
                    .Where(_ => (Convert.ToUInt64(_.Address.RowNumber) == range.StartRow) &&
                    (range.StartColumn <= Convert.ToUInt64(_.Address.ColumnNumber)) &&
                    ((Convert.ToUInt64(_.Address.ColumnNumber) <= (range.StartColumn + range.ColumnCount - 1))));
                var items = new List<string>();
                foreach (var cell in cells)
				{
                    items.Add(cell.GetString());
				}
                return items;
            }
            catch (System.Exception ex)
            when ((ex is NullReferenceException) || (ex is ArgumentException))
            {
                var exception = new ExcelReaderException("Error while reading row", ex);
                throw exception;
            }
        }

        /// <summary>
        /// Read column
        /// </summary>
        /// <param name="range">Range to read</param>
        /// <returns>Collection of column items.</returns>
        /// <exception cref="ExcelReaderException">An exception occurred while reading excel sheet.</exception>
        public virtual IEnumerable<string> ReadColumn(Range range)
		{
            try
            {
                var workBook = new XLWorkbook(_excelStream);
                var workSheet = workBook.Worksheet(SheetName);
                var cells = workSheet.CellsUsed()
                    .Where(_ => (range.StartRow <= Convert.ToUInt64(_.Address.RowNumber)) &&
                    ((Convert.ToUInt64(_.Address.RowNumber) <= (range.StartRow + range.RowCount - 1))) &&
                    (range.StartColumn == Convert.ToUInt64(_.Address.ColumnNumber)));
                var items = new List<string>();
                foreach (var cell in cells)
                {
                    items.Add(cell.GetString());
                }
                return items;
            }
            catch (System.Exception ex)
            when ((ex is NullReferenceException) || (ex is ArgumentException))
            {
                var exception = new ExcelReaderException("Error while reading column.", ex);
                throw exception;
            }
        }

        /// <summary>
        /// Get range of row in used.
        /// </summary>
        /// <param name="range">Reference to Range object to set the result.</param>
        /// <exception cref="ExcelReaderException">An exception occurred while reading excel sheet.</exception>
        public virtual void GetRowRange(ref Range range)
		{
            try
            {
                var workBook = new XLWorkbook(_excelStream);
                var workSheet = workBook.Worksheet(SheetName);

                var firstUsedCell = workSheet.FirstRowUsed();
                var lastUsedCell = workSheet.LastRowUsed();

                range.StartRow = Convert.ToUInt64(firstUsedCell.RowNumber());
                range.RowCount = Convert.ToUInt64(lastUsedCell.RowNumber()) - range.StartColumn + 1;
            }
            catch (System.Exception ex)
            when ((ex is NullReferenceException) || (ex is ArgumentException))
            {
                var exception = new ExcelReaderException("Error while reading column.", ex);
                throw exception;
            }
        }

        /// <summary>
        /// Get range of column in used.
        /// </summary>
        /// <param name="range">Reference to Range object to set the result.</param>
        /// <exception cref="ExcelReaderException">An exception occurred while reading excel sheet.</exception>
        public virtual void GetColumnRange(ref Range range)
		{
            try
            {
                var workBook = new XLWorkbook(_excelStream);
                var workSheet = workBook.Worksheet(SheetName);

                var firstUsedCell = workSheet.FirstColumnUsed();
                var lastUsedCell = workSheet.LastColumnUsed();

                range.StartColumn = Convert.ToUInt64(firstUsedCell.ColumnNumber());
                range.ColumnCount = Convert.ToUInt64(lastUsedCell.ColumnNumber()) - range.StartColumn + 1;

            }
            catch (System.Exception ex)
            when ((ex is NullReferenceException) || (ex is ArgumentException))
            {
                var exception = new ExcelReaderException("Error while reading column.", ex);
                throw exception;
            }
        }
    }
}
