using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader.FunctionReader
{
	public class ReaderFactory
	{
		public static AFunctionReader Factory(string inputFile)
		{
			if (!(System.IO.File.Exists(inputFile)))
			{
				throw new ArgumentException();
			}

			AFunctionReader reader = null;
			string extension = System.IO.Path.GetExtension(inputFile).ToLower();
			if (extension.Equals(".xlsx"))
			{
				reader = new FunctionInExcelReader();
			}
			else if (extension.Equals(".txt"))
			{
				reader = new FunctionInTextReader();
			}
			else
			{
				throw new NotSupportedException();
			}
			return reader;
		}
	}
}
