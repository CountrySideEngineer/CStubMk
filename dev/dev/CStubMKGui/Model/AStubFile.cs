using System;
using System.Collections.Generic;
using System.Text;

namespace CStubMKGui.Model
{
    public abstract class AStubFile : IStubFile
    {
        public StubDirectorForCStyle Director { get; set; }

        public abstract void CreateFile(string outputPath, IEnumerable<Param> parameters);
    }
}
