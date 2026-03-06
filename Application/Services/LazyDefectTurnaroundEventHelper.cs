using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyDefectTurnaroundEventHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(DefectTurnaroundEvent concreteDefectTurnaroundEvent,
                                     DefectTurnaroundEvent genericDefectTurnaroundEvent)
        {
            concreteDefectTurnaroundEvent.DefectTurnaroundEventId = genericDefectTurnaroundEvent.DefectTurnaroundEventId;
            concreteDefectTurnaroundEvent.DefectId = genericDefectTurnaroundEvent.DefectId;
            concreteDefectTurnaroundEvent.TurnaroundEventId = genericDefectTurnaroundEvent.TurnaroundEventId;
            concreteDefectTurnaroundEvent.LegacyFacilityOrigin = genericDefectTurnaroundEvent.LegacyFacilityOrigin;
            concreteDefectTurnaroundEvent.LegacyImported = genericDefectTurnaroundEvent.LegacyImported;
        }
    }
}