using Parser.SDK.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.SDK.Model
{
	public class Function : Variable
	{
		public Function() :base()
		{
			var arguments = new List<Parameter>();
			arguments.Clear();
			Arguments = arguments;
		}

		/// <summary>
		/// Arguments.
		/// </summary>
		public IEnumerable<Parameter> Arguments { get; set; }

		/// <summary>
		/// Convert to string.
		/// </summary>
		/// <returns>Function in string data type.</returns>
		/// <exception cref="FormatException"></exception>
		/// <remarks>
		/// 本関数では、引数情報のチェックは実施しない。
		/// そのため、引数にポインタ無しのvoid型が指定されていた場合にも、エラーとはしない。
		/// In this method, arguments are not checked.
		/// So, if argument whose data type is "void" and pointer num is 0 will not be error.
		/// </remarks>
		public override string ToString()
		{
			//関数宣言
			string toString = base.ToString();
			toString += "(";
			bool isTop = true;
			try
			{
				foreach (var item in Arguments)
				{
					if (!isTop)
					{
						toString += ", ";
					}
					string itemString = item.ToString();
					toString += itemString;
					isTop = false;
				}
			}
			catch (NullReferenceException)
			{
				/*
				 * It is that the method has no argument.
				 * So the exception can be ignore.
				 */
			}
			toString += ")";

			return toString;
		}

		public override void CopyTo(Parameter dst)
		{
			base.CopyTo(dst);
			if (dst is Function)
			{
				var function = dst as Function;
				function.Arguments = new List<Parameter>(Arguments);
			}
		}

		/// <summary>
		/// Validate parameters.
		/// </summary>
		/// <exception cref="InvalidOperationException"></exception>
		public override void Validate()
		{
			try
			{
				base.Validate();
			}
			catch(ParameterException ex)
			{
				if (ex.Code.Equals(ParserError.INVALID_DATA_TYPE_VOID)) {

					//関数の場合、データ型がvoid、かつ名前が空ではない場合を許容する。
					//そのため、この例外は無視して問題ない。
					//For functions, a case that the data type is void and the name is
					//not empty is acceptable.
					//So there is no problem to ignore the exception.
				}
				else
				{
					throw;
				}
			}

			bool isTop = true;
			foreach (var argItem in Arguments)
			{
				try
				{
					argItem.Validate();
				}
				catch (ParameterException ex)
				{
					if (ex.Code.Equals(ParserError.INVALID_DATA_TYPE_VOID))
					{
						if (isTop)
						{
							//先頭の引数がvoid型の場合は許容する。
							//A case that 1st argument data type is void is acceptable.
						}
						else
						{
							throw;
						}
					}
				}
				isTop = false;
			}
		}
	}
}
