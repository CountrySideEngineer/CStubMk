﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader.FunctionReader
{
	public class ReaderFactory
	{
		protected static string TextExtention = ".txt";
		protected static string ExcelExtention = ".xlsx";

		public static AFunctionReader Factory(string inputFile)
		{
			if (!(System.IO.File.Exists(inputFile)))
			{
				throw new ArgumentException();
			}

			AFunctionReader reader = null;
			string extension = System.IO.Path.GetExtension(inputFile).ToLower();
			if (extension.Equals(ExcelExtention))
			{
				reader = new FunctionInExcelReader();
			}
			else if (extension.Equals(TextExtention))
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
