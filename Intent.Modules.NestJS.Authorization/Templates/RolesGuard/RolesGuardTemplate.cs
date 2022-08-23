//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:6.0.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Intent.Modules.NestJS.Authorization.Templates.RolesGuard {
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.TypeScript.Templates;
    using Intent.Templates;
    using Intent.Metadata.Models;
    using Intent.Modules.NestJS.Authentication.Templates;
    using System;
    
    
    public partial class RolesGuardTemplate : TypeScriptTemplateBase<object> {
        
        public override string TransformText() {
            this.GenerationEnvironment = null;
            
            #line 11 ""
            this.Write("import { Injectable, CanActivate, ExecutionContext } from \'@nestjs/common\';\r\nimpo" +
                    "rt { Reflector } from \'@nestjs/core\';\r\nimport { ROLES_KEY } from \'../roles.decor" +
                    "ator\';\r\n\r\n@Injectable()\r\nexport class ");
            
            #line default
            #line hidden
            
            #line 16 ""
            this.Write(this.ToStringHelper.ToStringWithCulture( ClassName ));
            
            #line default
            #line hidden
            
            #line 16 ""
            this.Write(" extends ");
            
            #line default
            #line hidden
            
            #line 16 ""
            this.Write(this.ToStringHelper.ToStringWithCulture( this.GetJwtAuthGuardName() ));
            
            #line default
            #line hidden
            
            #line 16 ""
            this.Write(" {\r\n  constructor(reflector: Reflector) {\r\n    super(reflector);\r\n  }\r\n\r\n  async " +
                    "canActivate(context: ExecutionContext): Promise<boolean> {\r\n    const requiredRo" +
                    "les = this.reflector.getAllAndOverride<");
            
            #line default
            #line hidden
            
            #line 22 ""
            this.Write(this.ToStringHelper.ToStringWithCulture( this.GetRoleEnumName() ));
            
            #line default
            #line hidden
            
            #line 22 ""
            this.Write(@"[]>(ROLES_KEY, [
      context.getHandler(),
      context.getClass(),
    ]);

    if (!requiredRoles) {
      return true;
    }

    if (!(await super.canActivate(context))) {
      return false;
    }

    const { user } = context.switchToHttp().getRequest();
    return requiredRoles.some((role) => user.roles?.includes(role));
  }
}");
            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
        
        public override void Initialize() {
            base.Initialize();
        }
    }
}
