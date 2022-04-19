using CodeTemplate.Template;
using Parser.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWriter.SDK
{
    public interface IWriter
    {
        /// <summary>
        /// Interface to write parameters into files.
        /// </summary>
        /// <param name="path">Path to file to write data.</param>
        /// <param name="parameter">Parameter object to write into file.</param>
        void Write(string path, Parameter parameter, StubCodeTemplateCommonBase template);

        /// <summary>
        /// Interface to write parameters into files.
        /// </summary>
        /// <param name="path">Path to file to write data.</param>
        /// <param name="parameters">Collection of file to write into file.</param>
        void Write(string path, IEnumerable<Parameter> parameters, StubCodeTemplateCommonBase template);
    }
}
