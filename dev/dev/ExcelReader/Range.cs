using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelReader
{
	public class Range
	{
		/// <summary>
		/// Row number the range starts.
		/// </summary>
		public ulong StartRow { get; set; }

		/// <summary>
		/// Column number the range starts.
		/// </summary>
		public ulong StartColumn { get; set; }

		/// <summary>
		/// The number of row in the range.
		/// </summary>
		public ulong RowCount { get; set; }

		/// <summary>
		/// The number of column in the range.
		/// </summary>
		public ulong ColumnCount { get; set; }

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Range()
		{
			StartRow = 0;
			StartColumn = 0;
			RowCount = 0;
			ColumnCount = 0;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="src">Copy source object</param>
		public Range(Range src)
		{
			StartRow = src.StartRow;
			StartColumn = src.StartColumn;
			RowCount = src.RowCount;
			ColumnCount = src.ColumnCount;
		}

		public bool Equals(Range src)
		{
			bool equals = false;
			try
			{
				if ((StartRow == src.StartRow) &&
					(StartColumn == src.StartColumn) &&
					(RowCount == src.RowCount) &&
					(ColumnCount == src.ColumnCount))
				{
					equals = true;
				}
				else
				{
					equals = false;
				}
			}
			catch (System.Exception)
			{
				equals = false;
			}
			return equals;
		}
	}
}
