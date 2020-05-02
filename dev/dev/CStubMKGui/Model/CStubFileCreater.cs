﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CStubMKGui.Model
{
    /// <summary>
    /// Create source file to create C language source file.
    /// </summary>
    public class CStubFileCreater : ISourceFileCreater
    {
        #region Constructors and the finalizer
        /// <summary>
        /// Default constructor.
        /// </summary>
        public CStubFileCreater() {}
        #endregion

        #region Other methods and private properties in calling order
        /// <summary>
        /// Create source file of stub in C language style.
        /// </summary>
        /// <param name="outputPath">Path to output source file.</param>
        /// <param name="parameters">Parameters to create stub.</param>
        public virtual void Create(string outputPath, IEnumerable<Param> parameters)
        {
            this.CreateStub(outputPath, parameters);
        }

        protected virtual void CreateStub(string outputPath, IEnumerable<Param> parameters)
        {
            var sourceFileCreaters = new List<ISourceFileCreater>
            {
                new StubSourceFileCreater(),
                new StubHeaderFileCreater()
            };
            this.CreateStub(outputPath, sourceFileCreaters, parameters);
        }

        protected virtual void CreateStub(string outputPath, IEnumerable<ISourceFileCreater> createres, IEnumerable<Param> parameters)
        {
            foreach (var creater in createres)
            {
                creater.Create(outputPath, parameters);
            }
        }
        #endregion
    }
}
