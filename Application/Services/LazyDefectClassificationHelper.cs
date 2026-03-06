using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyDefectClassificationHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(DefectClassification concreteDefectClassification,
                                     DefectClassification genericDefectClassification)
        {
            concreteDefectClassification.DefectClassificationId = genericDefectClassification.DefectClassificationId;
            concreteDefectClassification.Text = genericDefectClassification.Text;
            concreteDefectClassification.LegacyFacilityOrigin = genericDefectClassification.LegacyFacilityOrigin;
            concreteDefectClassification.LegacyImported = genericDefectClassification.LegacyImported;
        }
    }
}