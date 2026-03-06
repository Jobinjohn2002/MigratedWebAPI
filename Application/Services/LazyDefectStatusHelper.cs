using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyDefectStatusHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(DefectStatus concreteDefectStatus, DefectStatus genericDefectStatus)
        {
            concreteDefectStatus.DefectStatusId = genericDefectStatus.DefectStatusId;
            concreteDefectStatus.Text = genericDefectStatus.Text;
            concreteDefectStatus.LegacyFacilityOrigin = genericDefectStatus.LegacyFacilityOrigin;
            concreteDefectStatus.LegacyImported = genericDefectStatus.LegacyImported;
        }
    }
}