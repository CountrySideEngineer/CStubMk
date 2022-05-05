using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.SDK.Exception
{
	public static class ParserError
	{
		public const UInt32 INVALID_DATA_TYPE = 0x10000001;
		public const UInt32 DATA_TYPE_EMPTY = 0x10000002;
		public const UInt32 INVALID_DATA_TYPE_VOID = 0x10000003;
		public const UInt32 INVALID_NAME = 0x10000004;
		public const UInt32 NAME_EMPTY = 0x10000005;
		public const UInt32 INVALID_POINER_LEVEL = 0x10000006;
	}
}
