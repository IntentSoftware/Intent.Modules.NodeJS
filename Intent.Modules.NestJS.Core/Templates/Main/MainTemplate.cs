// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.NestJS.Core.Templates.Main
{
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.TypeScript.Templates;
    using Intent.Templates;
    using Intent.Metadata.Models;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules.NodeJS\Intent.Modules.NestJS.Core\Templates\Main\MainTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class MainTemplate : TypeScriptTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("import { NestFactory } from \'@nestjs/core\';\r\nimport { DocumentBuilder, SwaggerMod" +
                    "ule } from \'@nestjs/swagger\';\r\n\r\nasync function bootstrap() {\r\n  const app = awa" +
                    "it NestFactory.create(");
            
            #line 14 "C:\Dev\Intent.Modules.NodeJS\Intent.Modules.NestJS.Core\Templates\Main\MainTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(AppModuleClass));
            
            #line default
            #line hidden
            
            #line 14 "C:\Dev\Intent.Modules.NodeJS\Intent.Modules.NestJS.Core\Templates\Main\MainTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetApplicationOptions()));
            
            #line default
            #line hidden
            this.Write(");");
            
            #line 14 "C:\Dev\Intent.Modules.NodeJS\Intent.Modules.NestJS.Core\Templates\Main\MainTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetGlobalPipes()));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n  const config = new DocumentBuilder()\r\n    .setTitle(\'");
            
            #line 17 "C:\Dev\Intent.Modules.NodeJS\Intent.Modules.NestJS.Core\Templates\Main\MainTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(OutputTarget.Application.Name));
            
            #line default
            #line hidden
            this.Write("\')\r\n    .setDescription(\'");
            
            #line 18 "C:\Dev\Intent.Modules.NodeJS\Intent.Modules.NestJS.Core\Templates\Main\MainTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(OutputTarget.Application.Description));
            
            #line default
            #line hidden
            this.Write("\')\r\n    .setVersion(\'1.0\')\r\n");
            
            #line 20 "C:\Dev\Intent.Modules.NodeJS\Intent.Modules.NestJS.Core\Templates\Main\MainTemplate.tt"
 foreach (var option in _swaggerDocumentBuilderOptions) { 
            
            #line default
            #line hidden
            this.Write("    ");
            
            #line 21 "C:\Dev\Intent.Modules.NodeJS\Intent.Modules.NestJS.Core\Templates\Main\MainTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(option));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 22 "C:\Dev\Intent.Modules.NodeJS\Intent.Modules.NestJS.Core\Templates\Main\MainTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("    .build();\r\n  const document = SwaggerModule.createDocument(app, config);\r\n  S" +
                    "waggerModule.setup(\'swagger\', app, document);\r\n\r\n  await app.listen(3000);\r\n}\r\nb" +
                    "ootstrap();");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
