using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyDefectSeverityHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(DefectSeverity concreteDefectSeverity,
                                     DefectSeverity genericDefectSeverity)
        {
            concreteDefectSeverity.DefectSeverityId = genericDefectSeverity.DefectSeverityId;
            concreteDefectSeverity.Text = genericDefectSeverity.Text;
            concreteDefectSeverity.LegacyFacilityOrigin = genericDefectSeverity.LegacyFacilityOrigin;
            concreteDefectSeverity.LegacyImported = genericDefectSeverity.LegacyImported;
        }
    }
}