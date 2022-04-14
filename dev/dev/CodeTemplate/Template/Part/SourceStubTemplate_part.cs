using Parser.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTemplate.Template
{
	public partial class SourceStubTemplate
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public SourceStubTemplate() : base()
		{
			TargetFunc = null;
		}

		/// <summary>
		/// Generate code to declare buffers.
		/// </summary>
		/// <returns>Code to declare buffers.</returns>
		public string GenerateBufferDeclareCode()
		{
			try
			{
				var template = new StubBufferDeclarationTemplate();
				string code = GenerateCode(template);
				return code;
			}
			catch (NullReferenceException)
			{
				throw;
			}
		}

		/// <summary>
		/// Generate method code to initialize 
		/// </summary>
		/// <returns>Codes of method to initialize buffers.</returns>
		public string GenerateBufferInitCode()
		{
			try
			{
				var template = new StubBufferInitTemplate();
				string code = GenerateCode(template);
				return code;
			}
			catch (Exception)
			{

				throw;
			}
		}

		/// <summary>
		/// Generate stub body.
		/// </summary>
		/// <returns>Codes of stub method body.</returns>
		/// <exception cref="NullReferenceException"></exception>
		public string GenerateStubCode()
		{
			try
			{
				var template = new StubSourceBodyTemplate();
				string code = GenerateCode(template);
				return code;
			}
			catch (NullReferenceException)
			{
				throw;
			}
		}

		/// <summary>
		/// Generate code using template.
		/// </summary>
		/// <param name="template">Code template file.</param>
		/// <returns>Generated code.</returns>
		/// <exception cref="NullReferenceException"></exception>
		protected virtual string GenerateCode(StubCodeTemplateCommonBase template)
		{
			try
			{
				template.TargetFunc = TargetFunc;
				string code = template.TransformText();
				return code;
			}
			catch (NullReferenceException)
			{
				throw;
			}
		}
	}
}
