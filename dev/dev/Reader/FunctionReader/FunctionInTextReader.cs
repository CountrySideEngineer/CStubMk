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
		public override IEnumerable<ParameterInformation> Read(string path)
		{
			string allCode = GetAllCode(path);
			IEnumerable<string> codes = ToCodes(allCode);
			IEnumerable<ParameterInformation> paramterInformations = ToParameterInformation(codes);

			return paramterInformations;
		}

		protected virtual string GetAllCode(string path)
		{
			string allCode = string.Empty;
			using (var reader = new StreamReader(path, System.Text.Encoding.GetEncoding("shift_jis")))
			{
				allCode = reader.ReadToEnd();
			}
			return allCode;
		}

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
