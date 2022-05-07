using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader.SDK.Exception
{
	public static class ReaderError
	{
		public const UInt32 INPUT_FILE_NOT_SUPPORTED = 0x20000000;
		public const UInt32 INPUT_FILE_OPEN_FAILED = 0x20000001;
		public const UInt32 INPUT_FILE_FORMAT_INVALID = 0x20000002;
		public const UInt32 ERROR_WHILE_READING = 0x20000003;
	}
}
