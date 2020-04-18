using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CStubMKGui.Model
{
    /// <summary>
    /// Create code of stub in C language.
    /// </summary>
    public class StubSourceDirectorForCStyle : StubDirectorForCStyle
    {
        #region Constructors and the finalizer
        /// <summary>
        /// Default constructor.
        /// </summary>
        public StubSourceDirectorForCStyle() : base() { }

        /// <summary>
        /// Constructor with Param object to be used.
        /// </summary>
        /// <param name="param">Parameters of stub function.</param>
        public StubSourceDirectorForCStyle(Param param) : base(param) { }
        #endregion
    }
}
