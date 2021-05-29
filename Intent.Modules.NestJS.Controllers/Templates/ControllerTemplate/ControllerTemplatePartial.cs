using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Engine;
using Intent.Metadata.WebApi.Api;
using Intent.Modelers.Services.Api;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.Types.Api;
using Intent.Modules.Common.TypeScript.Templates;
using Intent.Modules.NestJS.Controllers.Templates.DtoModel;
using Intent.Modules.NestJS.Core.Events;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;
using Intent.Utils;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.TypeScript.Templates.TypescriptTemplatePartial", Version = "1.0")]

namespace Intent.Modules.NestJS.Controllers.Templates.ControllerTemplate
{
    public interface IControllerTemplateDecorator
    {

    }

    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class ControllerTemplate : TypeScriptTemplateBase<Intent.Modelers.Services.Api.ServiceModel>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Intent.NodeJS.NestJS.Controllers.ControllerTemplate";

        [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
        public ControllerTemplate(IOutputTarget outputTarget, Intent.Modelers.Services.Api.ServiceModel model) : base(TemplateId, outputTarget, model)
        {
            AddTypeSource(DtoModelTemplate.TemplateId);
        }

        public string ServiceClassName => GetTypeName(ServiceTemplate.ServiceTemplate.TemplateId, Model);

        public string GetReturnType(OperationModel operation)
        {
            return operation.ReturnType != null ? GetTypeName(operation.ReturnType) : "void";
        }

        public string GetParameters(OperationModel operation)
        {
            return string.Join(", ", operation.Parameters.Select(p => $"{p.Name.ToCamelCase()}"));
        }

        public override void BeforeTemplateExecution()
        {
            ExecutionContext.EventDispatcher.Publish(new NestJsControllerCreatedEvent(null, TemplateId, Model.Id));
        }

        [IntentManaged(Mode.Merge, Body = Mode.Ignore, Signature = Mode.Fully)]
        public override ITemplateFileConfig GetTemplateFileConfig()
        {
            return new TypeScriptFileConfig(
                className: $"{Model.Name.RemoveSuffix("Service", "Controller")}Controller",
                fileName: $"{Model.Name.RemoveSuffix("Service", "Controller").ToKebabCase()}.controller"
            );
        }

        private string GetOperationAnnotations(OperationModel o)
        {
            var attributes = new List<string>();
            attributes.Add(GetHttpVerbAndPath(o));
            return string.Join(@"
        ", attributes);
        }

        private string GetOperationParameters(OperationModel operation)
        {
            var parameters = new List<string>();
            parameters.Add("@Req() req: Request");
            var verb = GetHttpVerb(operation);
            switch (verb)
            {
                case HttpVerb.POST:
                case HttpVerb.PUT:
                    parameters.AddRange(operation.Parameters.Select(x => $"{GetParameterBindingAttribute(operation, x)}{x.Name}: {GetTypeName(x.TypeReference)}"));
                    break;
                case HttpVerb.GET:
                case HttpVerb.DELETE:
                    if (operation.Parameters.Any(x => x.TypeReference.Element.SpecializationTypeId != TypeDefinitionModel.SpecializationTypeId &&
                                                      x.GetParameterSettings().Source().IsDefault()))
                    {
                        Logging.Log.Warning($@"Intent.NestJS.Controllers: [{Model.Name}.{operation.Name}] Passing objects into HTTP {GetHttpVerb(operation)} operations is not well supported by this module.
    We recommend using a POST or PUT verb");
                        // Log warning
                    }
                    parameters.AddRange(operation.Parameters.Select(x => $"{GetParameterBindingAttribute(operation, x)}{x.Name}: {GetTypeName(x.TypeReference)}"));
                    break;
                default:
                    throw new NotSupportedException($"{verb} not supported");
            }

            return string.Join(", ", parameters);
        }

        private string GetHttpVerbAndPath(OperationModel o)
        {
            var decoratorName = GetHttpVerb(o).ToString().ToLower().ToPascalCase();
            return $"@{ImportType(decoratorName, "@nestjs/common")}(\"{GetPath(o) ?? ""}\")";
        }

        private string GetPath(OperationModel operation)
        {
            var path = operation.GetHttpSettings().Route();
            return !string.IsNullOrWhiteSpace(path) ? path.Replace("{", ":").Replace("}", "") : null;
        }

        private string GetParameterBindingAttribute(OperationModel operation, ParameterModel parameter)
        {
            if (parameter.GetParameterSettings().Source().IsDefault())
            {
                var typeInfo = GetTypeInfo(parameter.TypeReference);
                if (parameter.TypeReference.Element.SpecializationTypeId == DTOModel.SpecializationTypeId)
                {
                    return $"@{ImportType("Body", "@nestjs/common")}() ";
                }
                else if (operation.GetHttpSettings().Route().Contains($"{{{parameter.Name}}}") || operation.GetHttpSettings().Route().Contains($":{parameter.Name}"))
                {
                    return $"@{ImportType("Param", "@nestjs/common")}('{parameter.Name}') ";
                }
                else
                {
                    return $"@{ImportType("Query", "@nestjs/common")}('{parameter.Name}') ";
                }
            }

            if (parameter.GetParameterSettings().Source().IsFromBody())
            {
                return $"@{ImportType("Body", "@nestjs/common")}() ";
            }
            if (parameter.GetParameterSettings().Source().IsFromHeader())
            {
                return $"@{ImportType("Headers", "@nestjs/common")}('{parameter.Name}') ";
            }
            if (parameter.GetParameterSettings().Source().IsFromQuery())
            {
                return $"@{ImportType("Query", "@nestjs/common")}('{parameter.Name}') ";
            }
            if (parameter.GetParameterSettings().Source().IsFromRoute())
            {
                return $"@{ImportType("Param", "@nestjs/common")}('{parameter.Name}') ";
            }

            return "";
        }

        private HttpVerb GetHttpVerb(OperationModel operation)
        {
            var verb = operation.GetHttpSettings().Verb();
            return Enum.TryParse(verb.Value, out HttpVerb verbEnum) ? verbEnum : HttpVerb.POST;
        }

        public enum HttpVerb
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}