using System.Collections.Generic;
using Intent.Modelers.Domain.Api;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Ignore)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.TemplateDecoratorContract", Version = "1.0")]

namespace Intent.Module.TypeScript.Domain.Templates.Entity
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public abstract class EntityDecorator : ITemplateDecorator
    {
        public int Priority { get; protected set; } = 0;

        public virtual string GetBeforeFields() => null;
        public virtual string GetAfterFields() => null;
        public virtual IEnumerable<string> GetClassDecorators() => new string[0];
        public virtual IEnumerable<string> GetFieldDecorators(AttributeModel attribute) => new string[0];
        public virtual IEnumerable<string> GetFieldDecorators(AssociationEndModel associationEnd) => new string[0];

    }
}