using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model.template
{
	public partial class StubCodeTemplateBase
	{
		#region Public properties
		public IEnumerable<Param> Functions { get; protected set; }
		#endregion

		#region Priate field.
		protected List<Param> _Functions;
		#endregion

		#region Constructor
		public StubCodeTemplateBase(IEnumerable<Param> parameters)
		{
			this.Functions = parameters;
		}

		public void Add(Param parameter)
		{
			if (null != parameter)
			{
				this._Functions.Add(parameter);
			}
		}

		//戻り値有無確認
		public virtual bool IsVariable(Param function)
		{
			bool isValue = false;
			/*
			 *	型がvoid	→	値ではない可能性
			 *		・ポインタの数 = 0	→	値ではない
			 *		・ポインタの数 > 0	→	値(void*)
			 */
			if (0 == string.Compare(function.DataType, "void", true))
			{
				if (0 < function.PointerNum)
				{
					isValue = true;
				}
				else
				{
					isValue = false;
				}
			}
			else
			{
				//非void	→	戻り値あり
				isValue = true;
			}
			return isValue;
		}

		//関数の呼び出し回数のカウンタ
		public virtual string called_count(Param function)
		{
			return $"{function.Name}_called_counter";
		}

		public virtual string return_buff(Param function)
		{
			return $"{function.Name}_return";
		}

		public virtual string buff_name(Param function, Param argument)
		{
			return $"{function.Name}_{argument.Name}";
		}

		public virtual string val_buff_name(Param function, Param argument)
		{
			return $"{function.Name}_{argument.Name}_value";
		}
		#endregion


	}
}
