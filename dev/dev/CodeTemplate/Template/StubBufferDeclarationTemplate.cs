﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン: 16.0.0.0
//  
//     このファイルへの変更は、正しくない動作の原因になる可能性があり、
//     コードが再生成されると失われます。
// </auto-generated>
// ------------------------------------------------------------------------------
namespace CodeTemplate.Template
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "E:\development\CStubMk\dev\dev\CodeTemplate\Template\StubBufferDeclarationTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class StubBufferDeclarationTemplate : StubCodeTemplateCommonBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("//関数の呼び出し回数\r\n");
            
            #line 8 "E:\development\CStubMk\dev\dev\CodeTemplate\Template\StubBufferDeclarationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(FuncCalledCounterBufferDeclareCode));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 9 "E:\development\CStubMk\dev\dev\CodeTemplate\Template\StubBufferDeclarationTemplate.tt"
	if (!(string.IsNullOrEmpty(FuncReturnValueDeclareCode))) {	
            
            #line default
            #line hidden
            this.Write("\r\n//関数の戻り値\r\n");
            
            #line 12 "E:\development\CStubMk\dev\dev\CodeTemplate\Template\StubBufferDeclarationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(FuncReturnValueDeclareCode));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 13 "E:\development\CStubMk\dev\dev\CodeTemplate\Template\StubBufferDeclarationTemplate.tt"
	}	
            
            #line default
            #line hidden
            
            #line 14 "E:\development\CStubMk\dev\dev\CodeTemplate\Template\StubBufferDeclarationTemplate.tt"
	if (!(string.IsNullOrEmpty(ArgBufferDeclareCode))) {	
            
            #line default
            #line hidden
            this.Write("\r\n//引数\r\n");
            
            #line 17 "E:\development\CStubMk\dev\dev\CodeTemplate\Template\StubBufferDeclarationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ArgBufferDeclareCode));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 18 "E:\development\CStubMk\dev\dev\CodeTemplate\Template\StubBufferDeclarationTemplate.tt"
	}	
            
            #line default
            #line hidden
            
            #line 19 "E:\development\CStubMk\dev\dev\CodeTemplate\Template\StubBufferDeclarationTemplate.tt"
	if (!(string.IsNullOrEmpty(FuncReturnValueViaArgBufferDeclareCode))) {	
            
            #line default
            #line hidden
            this.Write("\r\n//ポインタ経由での戻り値\r\n");
            
            #line 22 "E:\development\CStubMk\dev\dev\CodeTemplate\Template\StubBufferDeclarationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(FuncReturnValueViaArgBufferDeclareCode));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 23 "E:\development\CStubMk\dev\dev\CodeTemplate\Template\StubBufferDeclarationTemplate.tt"
	}	
            
            #line default
            #line hidden
            
            #line 24 "E:\development\CStubMk\dev\dev\CodeTemplate\Template\StubBufferDeclarationTemplate.tt"
	if (!(string.IsNullOrEmpty(FuncReturnValueSizeViaArgBufferDeclareCode))) {	
            
            #line default
            #line hidden
            this.Write("\r\n//ポインタ経由での戻り値のサイズ\r\n");
            
            #line 27 "E:\development\CStubMk\dev\dev\CodeTemplate\Template\StubBufferDeclarationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(FuncReturnValueSizeViaArgBufferDeclareCode));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 28 "E:\development\CStubMk\dev\dev\CodeTemplate\Template\StubBufferDeclarationTemplate.tt"
	}	
            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}