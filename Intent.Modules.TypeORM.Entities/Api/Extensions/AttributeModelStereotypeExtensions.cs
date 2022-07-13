using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modelers.Domain.Api;
using Intent.Modules.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiElementModelExtensions", Version = "1.0")]

namespace Intent.Modules.TypeORM.Entities.Api
{
    public static class AttributeModelStereotypeExtensions
    {
        public static ColumnOptions GetColumnOptions(this AttributeModel model)
        {
            var stereotype = model.GetStereotype("Column Options");
            return stereotype != null ? new ColumnOptions(stereotype) : null;
        }


        public static bool HasColumnOptions(this AttributeModel model)
        {
            return model.HasStereotype("Column Options");
        }

        public static bool TryGetColumnOptions(this AttributeModel model, out ColumnOptions stereotype)
        {
            if (!HasColumnOptions(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new ColumnOptions(model.GetStereotype("Column Options"));
            return true;
        }

        public class ColumnOptions
        {
            private IStereotype _stereotype;

            public ColumnOptions(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public string Type()
            {
                return _stereotype.GetProperty<string>("Type");
            }

            public string AdditionalOptions()
            {
                return _stereotype.GetProperty<string>("Additional Options");
            }

        }

    }
}