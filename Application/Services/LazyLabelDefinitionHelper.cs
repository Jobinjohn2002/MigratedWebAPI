using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyLabelDefinitionHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(LabelDefinition concreteLabelDefinition,
                                     LabelDefinition genericLabelDefinition)
        {
            concreteLabelDefinition.LabelDefinitionId = genericLabelDefinition.LabelDefinitionId;
            concreteLabelDefinition.LabelTypeId = genericLabelDefinition.LabelTypeId;
            concreteLabelDefinition.Name = genericLabelDefinition.Name;
            concreteLabelDefinition.Definition = genericLabelDefinition.Definition;
            concreteLabelDefinition.LegacyFacilityOrigin = genericLabelDefinition.LegacyFacilityOrigin;
            concreteLabelDefinition.LegacyImported = genericLabelDefinition.LegacyImported;
        }
    }
}