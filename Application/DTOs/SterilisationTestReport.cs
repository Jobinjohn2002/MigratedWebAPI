using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class SterilisationTestReport
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use SterilisationTestReportFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public SterilisationTestReport()
        {
            this.BatchSterilisationTestReport = new HashSet<BatchSterilisationTestReport>();
            this.TestReportTemperature = new HashSet<TestReportTemperature>();
            this.SterilisationTestReportAuditHistory = new HashSet<SterilisationTestReportAuditHistory>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets SterilisationTestReportId
        /// </summary>
        public int SterilisationTestReportId { get; set; }
        /// <summary>
        /// Gets or sets ReportType
        /// </summary>
        public byte ReportType { get; set; }
        public System.DateTime ReportDate { get; set; }
        /// <summary>
        /// Gets or sets SerialNumber
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// Gets or sets SterilisationTestReportStatusId
        /// </summary>
        public int SterilisationTestReportStatusId { get; set; }
        /// <summary>
        /// Gets or sets PreOperationalChecks
        /// </summary>
        public Nullable<bool> PreOperationalChecks { get; set; }
        /// <summary>
        /// Gets or sets WeeklySafetyChecks
        /// </summary>
        public Nullable<bool> WeeklySafetyChecks { get; set; }
        /// <summary>
        /// Gets or sets DateCorrectOnAutoclave
        /// </summary>
        public Nullable<bool> DateCorrectOnAutoclave { get; set; }
        /// <summary>
        /// Gets or sets DateCorrectOnSynergyTrak
        /// </summary>
        public Nullable<bool> DateCorrectOnSynergyTrak { get; set; }
        public System.DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public int CreatedUserId { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        /// <summary>
        /// Gets or sets ModifiedUserId
        /// </summary>
        public Nullable<int> ModifiedUserId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets MachineId
        /// </summary>
        public int MachineId { get; set; }
        /// <summary>
        /// Gets or sets PinRequestReasonId
        /// </summary>
        public Nullable<int> PinRequestReasonId { get; set; }
        /// <summary>
        /// Gets or sets CompletedUserId
        /// </summary>
        public Nullable<int> CompletedUserId { get; set; }
        public Nullable<System.DateTime> CompletedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets BatchSterilisationTestReport
        /// </summary>
        public virtual ICollection<BatchSterilisationTestReport> BatchSterilisationTestReport { get; set; }
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// Gets or sets User1
        /// </summary>
        public virtual User User1 { get; set; }
        /// <summary>
        /// Gets or sets SterilisationTestReportStatus
        /// </summary>
        public virtual SterilisationTestReportStatus SterilisationTestReportStatus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets TestReportTemperature
        /// </summary>
        public virtual ICollection<TestReportTemperature> TestReportTemperature { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SterilisationTestReportAuditHistory
        /// </summary>
        public virtual ICollection<SterilisationTestReportAuditHistory> SterilisationTestReportAuditHistory { get; set; }
        /// <summary>
        /// Gets or sets Machine
        /// </summary>
        public virtual Machine Machine { get; set; }
        /// <summary>
        /// Gets or sets PinRequestReason
        /// </summary>
        public virtual PinRequestReason PinRequestReason { get; set; }
        /// <summary>
        /// Gets or sets User_1
        /// </summary>
        public virtual User User_1 { get; set; }
    }
}
