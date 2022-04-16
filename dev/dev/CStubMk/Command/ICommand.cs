using CStubMk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CStubMk.Command
{
	public interface ICommand
	{
		void Execute(InputInfo input);
	}
}
