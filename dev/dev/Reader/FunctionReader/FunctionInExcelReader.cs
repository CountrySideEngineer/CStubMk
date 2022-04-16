using ExcelReader.Exception;
using Reader.SDK.Exception;
using Reader.SDK.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader.FunctionReader
{
	public class FunctionInExcelReader : AFunctionReader
	{
		/// <summary>
		/// Sheet name to read.
		/// </summary>
		protected string _sheetName = "FunctionDefinition";

		/// <summary>
		/// Default constructor.
		/// </summary>
		public FunctionInExcelReader() { }

		/// <summary>
		/// Read function definitions from a file.
		/// </summary>
		/// <param name="path">Path to file to read.</param>
		/// <returns>
		/// Collection of ParameterInformation object which contains the data of method,
		/// defition and file name.</returns>
		/// <exception cref="ReaderException">Exception detected while reading excel file.</exception>
		public override IEnumerable<ParameterInformation> Read(string path)
		{
			try
			{
				using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					var paramInfos = ReadFunctionDefinitions(stream);
					return paramInfos;
				}

			}
			catch (IOException ex)
			{
				var exception = new ReaderException("The file can not open.", ex);
				throw exception;
			}
		}

		/// <summary>
		/// Read function defintion from stream.
		/// </summary>
		/// <param name="stream">Stream to read from.</param>
		/// <returns>
		/// Collection of ParameterInformation object which contains the data of method,
		/// defition and file name.</returns>
		/// <exception cref="ReaderException">Exception detected while reading excel file.</exception>
		protected virtual IEnumerable<ParameterInformation> ReadFunctionDefinitions(Stream stream)
		{
			try
			{
				var excelReader = new ExcelReader.ExcelReader(stream)
				{
					SheetName = _sheetName
				};
				var tableRange = new ExcelReader.Range()
				{
					StartColumn = 3,
					ColumnCount = 3
				};
				excelReader.GetRowRange(ref tableRange);
				tableRange.StartRow = 3;
				IEnumerable<ParameterInformation> paramInfos = ReadFunctinoDefinitions(excelReader, tableRange);
				return paramInfos;
			}
			catch (Exception ex)
			when (ex is ExcelReaderException)
			{
				var exception = 
					new ReaderException(
						$"An exception detected while getting a table range in {_sheetName}",
						ex);
				throw exception;
			}
		}

		/// <summary>
		/// Read function definitions from a file.
		/// </summary>
		/// <param name="reader">ExcelReader object</param>
		/// <param name="range">Range to read.</param>
		/// <returns>
		/// Collection of ParameterInformation object which contains the data of method,
		/// defition and file name.
		/// </returns>
		/// <exception cref="ReaderException">Exception detected while reading excel file.</exception>
		protected virtual IEnumerable<ParameterInformation> ReadFunctinoDefinitions(
			ExcelReader.ExcelReader reader, 
			ExcelReader.Range range)
		{
			try
			{
				var paramInfos = new List<ParameterInformation>();
				for (UInt64 rowIndex = 0; rowIndex < range.RowCount; rowIndex++)
				{
					try
					{
						var rowRange = new ExcelReader.Range(range)
						{
							StartRow = range.StartRow + rowIndex
						};
						ParameterInformation paramInfo = ReadFunctionDefinition(reader, rowRange);
						paramInfos.Add(paramInfo);
					}
					catch (FormatException)
					{
						DEBUG($"SKIP the row {range.StartRow + rowIndex} (\"Definition\" or \"FileName\" is empty.)");
					}
					catch (ArgumentOutOfRangeException)
					{
						DEBUG($"No data has been set to ({range.StartRow + rowIndex}, {range.StartColumn}), SKIP!");
					}
				}
				return paramInfos;
			}
			catch (Exception ex)
			when ((ex is NullReferenceException) ||
				(ex is ArgumentOutOfRangeException) ||
				(ex is ExcelReaderException))
			{
				var exception = new ReaderException($"An exception detected while reading {_sheetName}", ex);
				throw exception;
			}
		}

		/// <summary>
		/// Read function defintion code and file name the function is implemented.
		/// </summary>
		/// <param name="reader">ExcelReader object to read the function data.</param>
		/// <param name="range">Range to read.</param>
		/// <returns>ParameterInformation object which contains the read function information.</returns>
		/// <exception cref="NullReferenceException">No data has been set in the excel file.</exception>
		/// <exception cref="ArgumentOutOfRangeException">No data has been set.</exception>
		/// <exception cref="FormatException">"FunctionDefinition" cell or "FileName" has been empty.</exception>
		/// <exception cref="ExcelReaderException">
		/// An exception occurred while reading excel file.
		/// The detail information about it has been set in "innerException" property.
		/// </exception>
		protected virtual ParameterInformation ReadFunctionDefinition(
			ExcelReader.ExcelReader reader,
			ExcelReader.Range range)
		{
			try
			{
				IEnumerable<string> items = reader.ReadRow(range);
				string methodDef = items.ElementAt(0);  //Definition of method.
				string fileName = items.ElementAt(1);   //File name the method is implemented.

				if ((string.IsNullOrEmpty(methodDef) || (string.IsNullOrWhiteSpace(methodDef))) ||
					((string.IsNullOrEmpty(fileName)) || (string.IsNullOrWhiteSpace(fileName))))
				{
					throw new FormatException();
				}

				var info = new ParameterInformation
				{
					Code = methodDef,
					File = fileName
				};
				return info;
			}
			catch (ArgumentOutOfRangeException)
			{
				throw;
			}
			catch (ExcelReaderException)
			{
				throw;
			}
		}
	}
}
