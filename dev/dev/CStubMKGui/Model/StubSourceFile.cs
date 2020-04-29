using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CStubMKGui.Model
{
    public class StubSourceFile : AStubFile
    {
        #region Constructors and the finalizer
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="director">Director object to create code of stub.</param>
        public StubSourceFile(StubDirectorForCStyle director)
        {
            this.FileName = "Stub.c";
            this.Director = director;
        }
        #endregion

        #region Other methods and private properties in calling order

        protected override IEnumerable<ICodeBuilder> GetCodeBuilders()
        {
            var builders = new List<ICodeBuilder>
            {
                new SourceStubBufferDeclareCodeBuilder(),
                new SourceStubEntryPointCodeBuilder(),
                new SourceStubBodyCodeBuilder()
            };
            return builders;
        }
        #endregion
    }
}
