using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace CStubMKGui.Model
{
    public abstract class AStubFile : IStubFile
    {
        /// <summary>
        /// Property of director of Stub.
        /// </summary>
        public StubDirectorForCStyle Director { get; set; }

        /// <summary>
        /// Property of filea name.
        /// </summary>
        public String FileName { get; set; }

        /// <summary>
        /// List of ICodeBuilder to create codes of stub.
        /// </summary>
        /// <returns>List of code.</returns>
        protected abstract IEnumerable<ICodeBuilder> GetCodeBuilders();

        /// <summary>
        /// Method to create stub file.
        /// </summary>
        /// <param name="outputPath">Path to output folder.</param>
        /// <param name="parameters">Parameters of stub file.</param>
        public virtual void CreateFile(String outputPath, IEnumerable<Param> parameters)
        {
            String outputFilePath = outputPath + @"\" + FileName;
            using var fileStream = new StreamWriter(outputFilePath, false, Encoding.GetEncoding("UTF-8"));
            this.CreateFile(fileStream, parameters);
        }

        /// <summary>
        /// Method to create stub file.
        /// </summary>
        /// <param name="writer">Output stream to write code of stub.</param>
        /// <param name="parameters">Parameters of stub file.</param>
        protected virtual void CreateFile(TextWriter writer, IEnumerable<Param> parameters)
        {
            var codes = this.CreateCodes(parameters);
            this.TextWrite(writer, codes);
        }

        /// <summary>
        /// Write codes from Params into text file.
        /// </summary>
        /// <param name="writer">Text stream to output the codes.</param>
        /// <param name="codes">Codes to be Written into text.</param>
        protected virtual void TextWrite(TextWriter writer, IEnumerable<string> codes)
        {
            foreach (var code in codes )
            {
                writer.WriteLine(code);
            }
        }

        /// <summary>
        /// Create codes from parameters.
        /// </summary>
        /// <param name="parameters">Parameters for stub codes.</param>
        /// <returns>Codes of stub.</returns>
        protected IEnumerable<string> CreateCodes(IEnumerable<Param> parameters)
        {
            IEnumerable<string> codes = null;
            foreach (var parameter in parameters)
            {
                var tempCodes = this.CreateCodes(this.GetCodeBuilders(), parameter);
                if (null == codes)
                {
                    codes = tempCodes;
                }
                else
                {
                    codes = codes.Concat(tempCodes);
                }
            }
            return codes;
        }

        /// <summary>
        /// Creates code from builders and parameter.
        /// </summary>
        /// <param name="builders">Builders to create code.</param>
        /// <param name="parameter">Parameters for stub code.</param>
        /// <returns>Codes of stub.</returns>
        protected IEnumerable<string> CreateCodes(IEnumerable<ICodeBuilder> builders, Param parameter)
        {
            IEnumerable<string> codes = null;
            foreach (var builder in builders)
            {
                var tempCodes = this.CreateCodes(builder, parameter);
                if (null == codes)
                {
                    codes = tempCodes;
                }
                else
                {
                    codes = codes.Concat(tempCodes);
                }
            }
            return codes;
        }

        /// <summary>
        /// Creaets codes from Param objects by builder.
        /// </summary>
        /// <param name="builder">Builder to creat codes</param>
        /// <param name="parameter">Parameters for codes.</param>
        /// <returns>Enumerator of code.</returns>
        protected IEnumerable<string> CreateCodes(ICodeBuilder builder, Param parameter)
        {
            var director = new SourceCodeDirector(builder);
            director.Construct(parameter);
            var codes = builder.GetResult();

            return (IEnumerable<string>)codes;
        }
    }
}
