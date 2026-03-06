using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyLabelTypeHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(LabelType concreteLabelType, LabelType genericLabelType)
        {
            concreteLabelType.LabelTypeId = genericLabelType.LabelTypeId;
            concreteLabelType.Text = genericLabelType.Text;
            concreteLabelType.LegacyFacilityOrigin = genericLabelType.LegacyFacilityOrigin;
            concreteLabelType.LegacyImported = genericLabelType.LegacyImported;
        }
    }
}