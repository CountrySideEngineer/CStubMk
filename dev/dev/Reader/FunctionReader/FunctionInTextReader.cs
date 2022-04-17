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

			throw new NotImplementedException();
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
			string replacedCode = srcCode.Replace("\r\n", "\n").Replace("\n", "");
			char[] deliminators = new char[]
			{
				';'
			};
			IEnumerable<string> codes = replacedCode.Split(deliminators);
			return codes;
		}
	}
}
