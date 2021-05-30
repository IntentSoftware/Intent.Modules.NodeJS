// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.TypeORM.Entities.Templates.RepositoryTemplate
{
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.TypeScript.Templates;
    using Intent.Templates;
    using Intent.Metadata.Models;
    using Intent.Modelers.Domain.Api;
    using Intent.Module.TypeScript.Domain.Templates.Entity;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules.NodeJS\Intent.Modules.TypeORM.Entities\Templates\RepositoryTemplate\RepositoryTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class RepositoryTemplate : TypeScriptTemplateBase<Intent.Modelers.Domain.Api.ClassModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("import { EntityRepository, Repository } from \"typeorm\";\r\n\r\n@EntityRepository(");
            
            #line 14 "C:\Dev\Intent.Modules.NodeJS\Intent.Modules.TypeORM.Entities\Templates\RepositoryTemplate\RepositoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetTypeName(EntityTemplate.TemplateId, Model)));
            
            #line default
            #line hidden
            this.Write(")\r\nexport class ");
            
            #line 15 "C:\Dev\Intent.Modules.NodeJS\Intent.Modules.TypeORM.Entities\Templates\RepositoryTemplate\RepositoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" extends Repository<");
            
            #line 15 "C:\Dev\Intent.Modules.NodeJS\Intent.Modules.TypeORM.Entities\Templates\RepositoryTemplate\RepositoryTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetTypeName(EntityTemplate.TemplateId, Model)));
            
            #line default
            #line hidden
            this.Write("> {}\r\n{\r\n\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
