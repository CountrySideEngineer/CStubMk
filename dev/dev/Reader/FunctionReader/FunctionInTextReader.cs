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
	public class FunctionInTextReader : AFunctionReader
	{
		/// <summary>
		/// Read function definition from a file.
		/// </summary>
		/// <param name="path">Path to file to read.</param>
		/// <returns>
		/// Collection of ParameterInformation object which contains the data of method,
		/// defition and file name.
		/// </returns>
		/// <exception cref="ReaderException">Exception detected while reading excel file.</exception>
		public override IEnumerable<ParameterInformation> Read(string path)
		{
			try
			{
				string allCode = GetAllCode(path);
				IEnumerable<string> codes = ToCodes(allCode);
				IEnumerable<ParameterInformation> paramterInformations = ToParameterInformation(codes);

				return paramterInformations;
			}
			catch (ReaderException)
			{
				throw;
			}
		}

		/// <summary>
		/// Read all content in a file specified by path.
		/// </summary>
		/// <param name="path">Path to file to read.</param>
		/// <returns>All content in a file.</returns>
		protected virtual string GetAllCode(string path)
		{
			try
			{
				string allCode = string.Empty;
				using (var reader = new StreamReader(path, System.Text.Encoding.GetEncoding("shift_jis")))
				{
					allCode = reader.ReadToEnd();
				}
				return allCode;
			}
			catch (IOException ex)
			{
				var exception = new ReaderException("The file can not open.", ex);
				throw ex;
			}
		}

		/// <summary>
		/// Convert text data argument srcCode to collection of string.
		/// </summary>
		/// <param name="srcCode">Code to convert.</param>
		/// <returns>Collection of string code.</returns>
		protected virtual IEnumerable<string> ToCodes(string srcCode)
		{
			//改行を削除
			string replacedCode = srcCode.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "");
			char[] deliminators = new char[]
			{
				';'
			};
			IEnumerable<string> splittedCode = replacedCode.Split(deliminators);
			/*
			 * The item at tail of splittedCode will be empty.
			 * If an item is empty or all white space, it rasie an exception.
			 * To avoid it, all item in the collection should not be empty.
			 * So, remove the empty item from the list.
			 */
			IEnumerable<string> codes = 
				splittedCode.Where(_ => (!string.IsNullOrEmpty(_)) && (!string.IsNullOrWhiteSpace(_)));
			return codes;
		}

		/// <summary>
		/// Convert collectoin of text code into collection of ParameterInformation object.
		/// </summary>
		/// <param name="codes">Collection of code.</param>
		/// <returns>Collection of ParameterInformation object.</returns>
		protected virtual IEnumerable<ParameterInformation> ToParameterInformation(IEnumerable<string> codes)
		{
			var collection = new List<ParameterInformation>();
			foreach (var code in codes)
			{
				ParameterInformation item = ToParameterInformation(code);
				collection.Add(item);
			}
			return collection;
		}

		/// <summary>
		/// Convert text code into collection of ParameterInformatin object.
		/// </summary>
		/// <param name="code">Code to convert.</param>
		/// <returns>ParameterInformation object converted from code.</returns>
		protected virtual ParameterInformation ToParameterInformation(string code)
		{
			var parameterInfo = new ParameterInformation()
			{
				Code = code,
				File = string.Empty
			};
			return parameterInfo;
		}
	}
}
