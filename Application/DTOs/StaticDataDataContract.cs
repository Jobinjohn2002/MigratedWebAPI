using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Static data that doesn't change very often.
    /// </summary>
    /// <summary>
    /// StaticDataDataContract
    /// </summary>
    public class StaticDataDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public int FacilityId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEventTypes
        /// </summary>
        public List<TurnaroundEventTypeDataContract> TurnaroundEventTypes { get; set; }
        /// <summary>
        /// Gets or sets DefectClassifications
        /// </summary>
        public List<DefectClassificationDataContract> DefectClassifications { get; set; }
        /// <summary>
        /// Gets or sets PinReasons
        /// </summary>
        public List<PinReasonDataContract> PinReasons { get; set; }
        /// <summary>
        /// Gets or sets MachineTypes
        /// </summary>
        public List<MachineTypeDataContract> MachineTypes { get; set; }
        /// <summary>
        /// Gets or sets MachineEventReasons
        /// </summary>
        public List<MachineEventReasonDataContract> MachineEventReasons { get; set; }
        /// <summary>
        /// Gets or sets MachineEventTypes
        /// </summary>
        public List<MachineEventTypeDataContract> MachineEventTypes { get; set; }
        /// <summary>
        /// Gets or sets PackingFailureReasons
        /// </summary>
        public List<DataValueDataContract> PackingFailureReasons { get; set; }
        /// <summary>
        /// Gets or sets QuarantineReasons
        /// </summary>
        public List<DataValueDataContract> QuarantineReasons { get; set; }
        /// <summary>
        /// Gets or sets QAFailureReasons
        /// </summary>
        public List<DataValueDataContract> QAFailureReasons { get; set; }
        /// <summary>
        /// Gets or sets WeighingFailureReasons
        /// </summary>
        public List<DataValueDataContract> WeighingFailureReasons { get; set; }
        /// <summary>
        /// Gets or sets FailureReasons
        /// </summary>
        public List<DataValueDataContract> FailureReasons { get; set; }
        /// <summary>
        /// Gets or sets ItemExceptionReasons
        /// </summary>
        public List<ItemExceptionReasonDataContract> ItemExceptionReasons { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefectReasons
        /// </summary>
        public List<CustomerDefectReasonDataContract> CustomerDefectReasons { get; set; }
        /// <summary>
        /// Gets or sets OrdersOption
        /// </summary>
        public int OrdersOption { get; set; }
        /// <summary>
        /// Gets or sets QAReprintingAtEnquirySetting
        /// </summary>
        public bool QAReprintingAtEnquirySetting { get; set; }
        /// <summary>
        /// Gets or sets AuditExceptionReasons
        /// </summary>
        public List<AuditExceptionReasonDataContract> AuditExceptionReasons { get; set; }
    }
}