// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.NestJS.Core.Templates.AppModule
{
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.TypeScript.Templates;
    using Intent.Templates;
    using Intent.Metadata.Models;
    using Intent.Modules.TypeScript.Weaving.Decorators;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules.NodeJS\Intent.Modules.NestJS.Core\Templates\AppModule\AppModuleTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class AppModuleTemplate : TypeScriptTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("import { Module } from \'@nestjs/common\';\r\n\r\n");
            
            #line 13 "C:\Dev\Intent.Modules.NodeJS\Intent.Modules.NestJS.Core\Templates\AppModule\AppModuleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.IntentMergeDecorator()));
            
            #line default
            #line hidden
            this.Write("\r\n@Module({\r\n  imports: [");
            
            #line 15 "C:\Dev\Intent.Modules.NodeJS\Intent.Modules.NestJS.Core\Templates\AppModule\AppModuleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetModuleImports()));
            
            #line default
            #line hidden
            this.Write("],\r\n  controllers: [");
            
            #line 16 "C:\Dev\Intent.Modules.NodeJS\Intent.Modules.NestJS.Core\Templates\AppModule\AppModuleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetControllers()));
            
            #line default
            #line hidden
            this.Write("],\r\n  providers: [");
            
            #line 17 "C:\Dev\Intent.Modules.NodeJS\Intent.Modules.NestJS.Core\Templates\AppModule\AppModuleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetProviders()));
            
            #line default
            #line hidden
            this.Write("]\r\n})\r\nexport class ");
            
            #line 19 "C:\Dev\Intent.Modules.NodeJS\Intent.Modules.NestJS.Core\Templates\AppModule\AppModuleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" { }");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
