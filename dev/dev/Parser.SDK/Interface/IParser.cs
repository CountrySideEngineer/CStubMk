using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reader.SDK.Model;
using Parser.SDK.Model;

namespace Parser.SDK.Interface
{
	public interface IParser
	{
		/// <summary>
		/// Interface to method to parser the function definition into Parameter object.
		/// </summary>
		/// <param name="paramInfos">Collection of ParameterInformation contains source of data.</param>
		/// <returns>Collection of parameter parsed by method.</returns>
		IEnumerable<Parameter> Parse(IEnumerable<ParameterInformation> paramInfos);

		/// <summary>
		/// Interface to method to parser the function definition into Parameter object.
		/// </summary>
		/// <param name="paramInfo">ParameterInformation contains of data.</param>
		/// <returns>Parameter object parsed by method.</returns>
		Parameter Parse(ParameterInformation paramInfo);
	}
}
