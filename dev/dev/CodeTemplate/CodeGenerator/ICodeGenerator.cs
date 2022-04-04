using Parser.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTemplate.CodeGenerator
{
	public interface ICodeGenerator
	{
		string Generate(Function function, Variable argument);
	}
}
