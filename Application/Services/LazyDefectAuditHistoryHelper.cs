using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyDefectAuditHistoryHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(DefectAuditHistory concreteDefectAuditHistory,
                                     DefectAuditHistory genericDefectAuditHistory)
        {
            concreteDefectAuditHistory.DefectAuditHistoryId = genericDefectAuditHistory.DefectAuditHistoryId;
            concreteDefectAuditHistory.DefectId = genericDefectAuditHistory.DefectId;
            concreteDefectAuditHistory.CreatedUserId = genericDefectAuditHistory.CreatedUserId;
            concreteDefectAuditHistory.Created = genericDefectAuditHistory.Created;
            concreteDefectAuditHistory.Field = genericDefectAuditHistory.Field;
            concreteDefectAuditHistory.FromValue = genericDefectAuditHistory.FromValue;
            concreteDefectAuditHistory.ToValue = genericDefectAuditHistory.ToValue;
            concreteDefectAuditHistory.LegacyFacilityOrigin = genericDefectAuditHistory.LegacyFacilityOrigin;
            concreteDefectAuditHistory.LegacyImported = genericDefectAuditHistory.LegacyImported;
        }
    }
}