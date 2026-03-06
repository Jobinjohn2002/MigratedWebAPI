using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyDefectResponsibilityHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(DefectResponsibility concreteDefectResponsibility,
                                     DefectResponsibility genericDefectResponsibility)
        {
            concreteDefectResponsibility.DefectResponsibilityId = genericDefectResponsibility.DefectResponsibilityId;
            concreteDefectResponsibility.Text = genericDefectResponsibility.Text;
            concreteDefectResponsibility.Priority = genericDefectResponsibility.Priority;
            concreteDefectResponsibility.Archived = genericDefectResponsibility.Archived;
            concreteDefectResponsibility.LegacyFacilityOrigin = genericDefectResponsibility.LegacyFacilityOrigin;
            concreteDefectResponsibility.LegacyImported = genericDefectResponsibility.LegacyImported;
        }
    }
}