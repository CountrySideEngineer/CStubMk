using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CommandLine;
using System.Diagnostics;
using CStubMk.Command;
using CStubMk.Model;

namespace CStubMk
{
	public class Program
	{
		static void Main(string[] args)
		{
			var fOption = new Option<string>(
				name: "-f",
				description: "A file function to create stub functions.");
			var oOption = new Option<string>(
				"-o",
				"Path to directory to output the stub source and header files.");
			var rootCommand = new RootCommand
			{
				fOption, oOption
			};
			var stubCommand = new System.CommandLine.Command("stub")
			{
				fOption, oOption
			};
			string inputFilePath = string.Empty;
			string outputDirPath = string.Empty;
			Action<string, string> handle = Exec;

			stubCommand.SetHandler(handle, fOption, oOption);
			rootCommand.AddCommand(stubCommand);
			rootCommand.Description = "CStubMk, an application to create stub method.";
			//rootCommand.SetHandler(handle, fOption, oOption);

			int result = rootCommand.Invoke(args);
		}

		static void Exec(string filePath, string dirPath)
		{
			try
			{
				var inputInfo = new InputInfo()
				{
					TargetFilePath = filePath,
					OuptutDirPath = dirPath
				};
				var command = new StubCommand();
				command.Execute(inputInfo);
			}
			catch (Exception ex)
			{
				Console.Write($"[ERROR] - {ex.Message}\n");
			}
		}

	}
}
