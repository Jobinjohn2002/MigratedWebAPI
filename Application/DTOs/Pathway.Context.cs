using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Core.Objects;
    
    public partial class OperativeModelContainer : DbContext
    {
        public OperativeModelContainer()
            : base("name=OperativeModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        /// <summary>
        /// Gets or sets Address
        /// </summary>
        public virtual DbSet<Address> Address { get; set; }
        /// <summary>
        /// Gets or sets Alert
        /// </summary>
        public virtual DbSet<Alert> Alert { get; set; }
        /// <summary>
        /// Gets or sets AlertType
        /// </summary>
        public virtual DbSet<AlertType> AlertType { get; set; }
        /// <summary>
        /// Gets or sets BatchArchiveReason
        /// </summary>
        public virtual DbSet<BatchArchiveReason> BatchArchiveReason { get; set; }
        /// <summary>
        /// Gets or sets BatchCycle
        /// </summary>
        public virtual DbSet<BatchCycle> BatchCycle { get; set; }
        /// <summary>
        /// Gets or sets BatchFailureReason
        /// </summary>
        public virtual DbSet<BatchFailureReason> BatchFailureReason { get; set; }
        /// <summary>
        /// Gets or sets Category
        /// </summary>
        public virtual DbSet<Category> Category { get; set; }
        /// <summary>
        /// Gets or sets Charge
        /// </summary>
        public virtual DbSet<Charge> Charge { get; set; }
        /// <summary>
        /// Gets or sets ChargeList
        /// </summary>
        public virtual DbSet<ChargeList> ChargeList { get; set; }
        /// <summary>
        /// Gets or sets ChargeListCategory
        /// </summary>
        public virtual DbSet<ChargeListCategory> ChargeListCategory { get; set; }
        /// <summary>
        /// Gets or sets ChargeReoccurring
        /// </summary>
        public virtual DbSet<ChargeReoccurring> ChargeReoccurring { get; set; }
        /// <summary>
        /// Gets or sets Complexity
        /// </summary>
        public virtual DbSet<Complexity> Complexity { get; set; }
        /// <summary>
        /// Gets or sets ContainerContent
        /// </summary>
        public virtual DbSet<ContainerContent> ContainerContent { get; set; }
        /// <summary>
        /// Gets or sets ContainerContentNote
        /// </summary>
        public virtual DbSet<ContainerContentNote> ContainerContentNote { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterDefinition
        /// </summary>
        public virtual DbSet<ContainerMasterDefinition> ContainerMasterDefinition { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterNoteType
        /// </summary>
        public virtual DbSet<ContainerMasterNoteType> ContainerMasterNoteType { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterPrice
        /// </summary>
        public virtual DbSet<ContainerMasterPrice> ContainerMasterPrice { get; set; }
        /// <summary>
        /// Gets or sets ContractedHours
        /// </summary>
        public virtual DbSet<ContractedHours> ContractedHours { get; set; }
        /// <summary>
        /// Gets or sets CostingModel
        /// </summary>
        public virtual DbSet<CostingModel> CostingModel { get; set; }
        /// <summary>
        /// Gets or sets CostingModelItemType
        /// </summary>
        public virtual DbSet<CostingModelItemType> CostingModelItemType { get; set; }
        /// <summary>
        /// Gets or sets CostingModelType
        /// </summary>
        public virtual DbSet<CostingModelType> CostingModelType { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefect
        /// </summary>
        public virtual DbSet<CustomerDefect> CustomerDefect { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefectInformation
        /// </summary>
        public virtual DbSet<CustomerDefectInformation> CustomerDefectInformation { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefectReason
        /// </summary>
        public virtual DbSet<CustomerDefectReason> CustomerDefectReason { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefectStatus
        /// </summary>
        public virtual DbSet<CustomerDefectStatus> CustomerDefectStatus { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefectStatusWorkflow
        /// </summary>
        public virtual DbSet<CustomerDefectStatusWorkflow> CustomerDefectStatusWorkflow { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionGS1
        /// </summary>
        public virtual DbSet<CustomerDefinitionGS1> CustomerDefinitionGS1 { get; set; }
        /// <summary>
        /// Gets or sets CustomerGroup
        /// </summary>
        public virtual DbSet<CustomerGroup> CustomerGroup { get; set; }
        /// <summary>
        /// Gets or sets CustomerStatus
        /// </summary>
        public virtual DbSet<CustomerStatus> CustomerStatus { get; set; }
        /// <summary>
        /// Gets or sets Defect
        /// </summary>
        public virtual DbSet<Defect> Defect { get; set; }
        /// <summary>
        /// Gets or sets DefectAuditHistory
        /// </summary>
        public virtual DbSet<DefectAuditHistory> DefectAuditHistory { get; set; }
        /// <summary>
        /// Gets or sets DefectClassification
        /// </summary>
        public virtual DbSet<DefectClassification> DefectClassification { get; set; }
        /// <summary>
        /// Gets or sets DefectResponsibility
        /// </summary>
        public virtual DbSet<DefectResponsibility> DefectResponsibility { get; set; }
        /// <summary>
        /// Gets or sets DefectSeverity
        /// </summary>
        public virtual DbSet<DefectSeverity> DefectSeverity { get; set; }
        /// <summary>
        /// Gets or sets DefectStatus
        /// </summary>
        public virtual DbSet<DefectStatus> DefectStatus { get; set; }
        /// <summary>
        /// Gets or sets DefectTurnaroundEvent
        /// </summary>
        public virtual DbSet<DefectTurnaroundEvent> DefectTurnaroundEvent { get; set; }
        /// <summary>
        /// Gets or sets DeliveryNote
        /// </summary>
        public virtual DbSet<DeliveryNote> DeliveryNote { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public virtual DbSet<DeliveryPoint> DeliveryPoint { get; set; }
        /// <summary>
        /// Gets or sets DeliveryType
        /// </summary>
        public virtual DbSet<DeliveryType> DeliveryType { get; set; }
        /// <summary>
        /// Gets or sets EventType
        /// </summary>
        public virtual DbSet<EventType> EventType { get; set; }
        /// <summary>
        /// Gets or sets EventTypeCategory
        /// </summary>
        public virtual DbSet<EventTypeCategory> EventTypeCategory { get; set; }
        /// <summary>
        /// Gets or sets ExpiryCalculationType
        /// </summary>
        public virtual DbSet<ExpiryCalculationType> ExpiryCalculationType { get; set; }
        /// <summary>
        /// Gets or sets FacilityItemType
        /// </summary>
        public virtual DbSet<FacilityItemType> FacilityItemType { get; set; }
        /// <summary>
        /// Gets or sets FacilityNote
        /// </summary>
        public virtual DbSet<FacilityNote> FacilityNote { get; set; }
        /// <summary>
        /// Gets or sets FailedBatch
        /// </summary>
        public virtual DbSet<FailedBatch> FailedBatch { get; set; }
        /// <summary>
        /// Gets or sets FailureType
        /// </summary>
        public virtual DbSet<FailureType> FailureType { get; set; }
        /// <summary>
        /// Gets or sets FastTrackRequest
        /// </summary>
        public virtual DbSet<FastTrackRequest> FastTrackRequest { get; set; }
        /// <summary>
        /// Gets or sets Hub
        /// </summary>
        public virtual DbSet<Hub> Hub { get; set; }
        /// <summary>
        /// Gets or sets Indexation
        /// </summary>
        public virtual DbSet<Indexation> Indexation { get; set; }
        /// <summary>
        /// Gets or sets IndexationCategory
        /// </summary>
        public virtual DbSet<IndexationCategory> IndexationCategory { get; set; }
        /// <summary>
        /// Gets or sets IndividualInstrumentTrackingEvent
        /// </summary>
        public virtual DbSet<IndividualInstrumentTrackingEvent> IndividualInstrumentTrackingEvent { get; set; }
        /// <summary>
        /// Gets or sets IndividualInstrumentTrackingEventType
        /// </summary>
        public virtual DbSet<IndividualInstrumentTrackingEventType> IndividualInstrumentTrackingEventType { get; set; }
        /// <summary>
        /// Gets or sets InvoiceStatus
        /// </summary>
        public virtual DbSet<InvoiceStatus> InvoiceStatus { get; set; }
        /// <summary>
        /// Gets or sets InvoiceStatusAuditHistory
        /// </summary>
        public virtual DbSet<InvoiceStatusAuditHistory> InvoiceStatusAuditHistory { get; set; }
        /// <summary>
        /// Gets or sets InvoiceStatusWorkflow
        /// </summary>
        public virtual DbSet<InvoiceStatusWorkflow> InvoiceStatusWorkflow { get; set; }
        /// <summary>
        /// Gets or sets ItemMaster
        /// </summary>
        public virtual DbSet<ItemMaster> ItemMaster { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterDefinition
        /// </summary>
        public virtual DbSet<ItemMasterDefinition> ItemMasterDefinition { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterPrice
        /// </summary>
        public virtual DbSet<ItemMasterPrice> ItemMasterPrice { get; set; }
        /// <summary>
        /// Gets or sets ItemRebuildList
        /// </summary>
        public virtual DbSet<ItemRebuildList> ItemRebuildList { get; set; }
        /// <summary>
        /// Gets or sets ItemStatus
        /// </summary>
        public virtual DbSet<ItemStatus> ItemStatus { get; set; }
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public virtual DbSet<ItemType> ItemType { get; set; }
        /// <summary>
        /// Gets or sets LabelDefinition
        /// </summary>
        public virtual DbSet<LabelDefinition> LabelDefinition { get; set; }
        /// <summary>
        /// Gets or sets LabelType
        /// </summary>
        public virtual DbSet<LabelType> LabelType { get; set; }
        /// <summary>
        /// Gets or sets Machine
        /// </summary>
        public virtual DbSet<Machine> Machine { get; set; }
        /// <summary>
        /// Gets or sets MachineEvent
        /// </summary>
        public virtual DbSet<MachineEvent> MachineEvent { get; set; }
        /// <summary>
        /// Gets or sets MachineEventReason
        /// </summary>
        public virtual DbSet<MachineEventReason> MachineEventReason { get; set; }
        /// <summary>
        /// Gets or sets MachineEventType
        /// </summary>
        public virtual DbSet<MachineEventType> MachineEventType { get; set; }
        /// <summary>
        /// Gets or sets ObjectType
        /// </summary>
        public virtual DbSet<ObjectType> ObjectType { get; set; }
        /// <summary>
        /// Gets or sets Permission
        /// </summary>
        public virtual DbSet<Permission> Permission { get; set; }
        /// <summary>
        /// Gets or sets PriceCategory
        /// </summary>
        public virtual DbSet<PriceCategory> PriceCategory { get; set; }
        /// <summary>
        /// Gets or sets PriceCategoryBatchCycle
        /// </summary>
        public virtual DbSet<PriceCategoryBatchCycle> PriceCategoryBatchCycle { get; set; }
        /// <summary>
        /// Gets or sets PriceCategoryDefinition
        /// </summary>
        public virtual DbSet<PriceCategoryDefinition> PriceCategoryDefinition { get; set; }
        /// <summary>
        /// Gets or sets PriceCategoryGroup
        /// </summary>
        public virtual DbSet<PriceCategoryGroup> PriceCategoryGroup { get; set; }
        /// <summary>
        /// Gets or sets Printer
        /// </summary>
        public virtual DbSet<Printer> Printer { get; set; }
        /// <summary>
        /// Gets or sets PrinterType
        /// </summary>
        public virtual DbSet<PrinterType> PrinterType { get; set; }
        /// <summary>
        /// Gets or sets Report
        /// </summary>
        public virtual DbSet<Report> Report { get; set; }
        /// <summary>
        /// Gets or sets ReportCategory
        /// </summary>
        public virtual DbSet<ReportCategory> ReportCategory { get; set; }
        /// <summary>
        /// Gets or sets RequiredWorkflow
        /// </summary>
        public virtual DbSet<RequiredWorkflow> RequiredWorkflow { get; set; }
        /// <summary>
        /// Gets or sets Role
        /// </summary>
        public virtual DbSet<Role> Role { get; set; }
        /// <summary>
        /// Gets or sets RolePermission
        /// </summary>
        public virtual DbSet<RolePermission> RolePermission { get; set; }
        /// <summary>
        /// Gets or sets SearchTerm
        /// </summary>
        public virtual DbSet<SearchTerm> SearchTerm { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirement
        /// </summary>
        public virtual DbSet<ServiceRequirement> ServiceRequirement { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementDefinition
        /// </summary>
        public virtual DbSet<ServiceRequirementDefinition> ServiceRequirementDefinition { get; set; }
        /// <summary>
        /// Gets or sets Speciality
        /// </summary>
        public virtual DbSet<Speciality> Speciality { get; set; }
        /// <summary>
        /// Gets or sets Station
        /// </summary>
        public virtual DbSet<Station> Station { get; set; }
        /// <summary>
        /// Gets or sets StationPrinter
        /// </summary>
        public virtual DbSet<StationPrinter> StationPrinter { get; set; }
        /// <summary>
        /// Gets or sets StationType
        /// </summary>
        public virtual DbSet<StationType> StationType { get; set; }
        /// <summary>
        /// Gets or sets StationTypeCategory
        /// </summary>
        public virtual DbSet<StationTypeCategory> StationTypeCategory { get; set; }
        /// <summary>
        /// Gets or sets StoragePoint
        /// </summary>
        public virtual DbSet<StoragePoint> StoragePoint { get; set; }
        /// <summary>
        /// Gets or sets Turnaround
        /// </summary>
        public virtual DbSet<Turnaround> Turnaround { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundAssigned
        /// </summary>
        public virtual DbSet<TurnaroundAssigned> TurnaroundAssigned { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEvent
        /// </summary>
        public virtual DbSet<TurnaroundEvent> TurnaroundEvent { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundWH
        /// </summary>
        public virtual DbSet<TurnaroundWH> TurnaroundWH { get; set; }
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual DbSet<User> User { get; set; }
        /// <summary>
        /// Gets or sets UserCategory
        /// </summary>
        public virtual DbSet<UserCategory> UserCategory { get; set; }
        /// <summary>
        /// Gets or sets UserComplexity
        /// </summary>
        public virtual DbSet<UserComplexity> UserComplexity { get; set; }
        /// <summary>
        /// Gets or sets UserFacility
        /// </summary>
        public virtual DbSet<UserFacility> UserFacility { get; set; }
        /// <summary>
        /// Gets or sets UserPrinter
        /// </summary>
        public virtual DbSet<UserPrinter> UserPrinter { get; set; }
        /// <summary>
        /// Gets or sets UserReport
        /// </summary>
        public virtual DbSet<UserReport> UserReport { get; set; }
        /// <summary>
        /// Gets or sets UserRole
        /// </summary>
        public virtual DbSet<UserRole> UserRole { get; set; }
        /// <summary>
        /// Gets or sets Warning
        /// </summary>
        public virtual DbSet<Warning> Warning { get; set; }
        /// <summary>
        /// Gets or sets IndexationType
        /// </summary>
        public virtual DbSet<IndexationType> IndexationType { get; set; }
        /// <summary>
        /// Gets or sets Facility
        /// </summary>
        public virtual DbSet<Facility> Facility { get; set; }
        /// <summary>
        /// Gets or sets UserDeliveryPoint
        /// </summary>
        public virtual DbSet<UserDeliveryPoint> UserDeliveryPoint { get; set; }
        /// <summary>
        /// Gets or sets LabourBands
        /// </summary>
        public virtual DbSet<LabourBand> LabourBands { get; set; }
        /// <summary>
        /// Gets or sets ContainerMaster
        /// </summary>
        public virtual DbSet<ContainerMaster> ContainerMaster { get; set; }
        /// <summary>
        /// Gets or sets Workflow
        /// </summary>
        public virtual DbSet<Workflow> Workflow { get; set; }
        /// <summary>
        /// Gets or sets EventTypeStationType
        /// </summary>
        public virtual DbSet<EventTypeStationType> EventTypeStationType { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterPriceAdjustmentType
        /// </summary>
        public virtual DbSet<ContainerMasterPriceAdjustmentType> ContainerMasterPriceAdjustmentType { get; set; }
        /// <summary>
        /// Gets or sets StationTypeItemType
        /// </summary>
        public virtual DbSet<StationTypeItemType> StationTypeItemType { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEventFailureType
        /// </summary>
        public virtual DbSet<TurnaroundEventFailureType> TurnaroundEventFailureType { get; set; }
        /// <summary>
        /// Gets or sets PriceCategoryGroupItemType
        /// </summary>
        public virtual DbSet<PriceCategoryGroupItemType> PriceCategoryGroupItemType { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementExpiryWindow
        /// </summary>
        public virtual DbSet<ServiceRequirementExpiryWindow> ServiceRequirementExpiryWindow { get; set; }
        /// <summary>
        /// Gets or sets CustomerWorkflow
        /// </summary>
        public virtual DbSet<CustomerWorkflow> CustomerWorkflow { get; set; }
        /// <summary>
        /// Gets or sets FinancialCalendar
        /// </summary>
        public virtual DbSet<FinancialCalendar> FinancialCalendar { get; set; }
        /// <summary>
        /// Gets or sets InvoicePeriod
        /// </summary>
        public virtual DbSet<InvoicePeriod> InvoicePeriod { get; set; }
        /// <summary>
        /// Gets or sets InvoiceSchedule
        /// </summary>
        public virtual DbSet<InvoiceSchedule> InvoiceSchedule { get; set; }
        /// <summary>
        /// Gets or sets QuarantineReason
        /// </summary>
        public virtual DbSet<QuarantineReason> QuarantineReason { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterPriceAdjustment
        /// </summary>
        public virtual DbSet<ContainerMasterPriceAdjustment> ContainerMasterPriceAdjustment { get; set; }
        /// <summary>
        /// Gets or sets Invoice
        /// </summary>
        public virtual DbSet<Invoice> Invoice { get; set; }
        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        public virtual DbSet<Customer> Customer { get; set; }
        /// <summary>
        /// Gets or sets UserItemAudit
        /// </summary>
        public virtual DbSet<UserItemAudit> UserItemAudit { get; set; }
        /// <summary>
        /// Gets or sets UserItemAuditCopyList
        /// </summary>
        public virtual DbSet<UserItemAuditCopyList> UserItemAuditCopyList { get; set; }
        /// <summary>
        /// Gets or sets UserItemAuditType
        /// </summary>
        public virtual DbSet<UserItemAuditType> UserItemAuditType { get; set; }
        /// <summary>
        /// Gets or sets InvoiceLine
        /// </summary>
        public virtual DbSet<InvoiceLine> InvoiceLine { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterPriceFull
        /// </summary>
        public virtual DbSet<ContainerMasterPriceFull> ContainerMasterPriceFull { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementContractedHours
        /// </summary>
        public virtual DbSet<ServiceRequirementContractedHours> ServiceRequirementContractedHours { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementEventType
        /// </summary>
        public virtual DbSet<ServiceRequirementEventType> ServiceRequirementEventType { get; set; }
        /// <summary>
        /// Gets or sets PinRequestReason
        /// </summary>
        public virtual DbSet<PinRequestReason> PinRequestReason { get; set; }
        /// <summary>
        /// Gets or sets UserPermission
        /// </summary>
        public virtual DbSet<UserPermission> UserPermission { get; set; }
        /// <summary>
        /// Gets or sets Masters
        /// </summary>
        public virtual DbSet<Masters> Masters { get; set; }
        /// <summary>
        /// Gets or sets ServiceReports
        /// </summary>
        public virtual DbSet<ServiceReports> ServiceReports { get; set; }
        /// <summary>
        /// Gets or sets Courier
        /// </summary>
        public virtual DbSet<Courier> Courier { get; set; }
        /// <summary>
        /// Gets or sets LoanSet
        /// </summary>
        public virtual DbSet<LoanSet> LoanSet { get; set; }
        /// <summary>
        /// Gets or sets LoanSetAuditHistory
        /// </summary>
        public virtual DbSet<LoanSetAuditHistory> LoanSetAuditHistory { get; set; }
        /// <summary>
        /// Gets or sets LoanSetContents
        /// </summary>
        public virtual DbSet<LoanSetContents> LoanSetContents { get; set; }
        /// <summary>
        /// Gets or sets LoanSetRequiredOn
        /// </summary>
        public virtual DbSet<LoanSetRequiredOn> LoanSetRequiredOn { get; set; }
        /// <summary>
        /// Gets or sets LoanSetStatus
        /// </summary>
        public virtual DbSet<LoanSetStatus> LoanSetStatus { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceReport
        /// </summary>
        public virtual DbSet<MaintenanceReport> MaintenanceReport { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceReportAuditHistory
        /// </summary>
        public virtual DbSet<MaintenanceReportAuditHistory> MaintenanceReportAuditHistory { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceReportStatus
        /// </summary>
        public virtual DbSet<MaintenanceReportStatus> MaintenanceReportStatus { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceType
        /// </summary>
        public virtual DbSet<MaintenanceType> MaintenanceType { get; set; }
        /// <summary>
        /// Gets or sets RepairCategory
        /// </summary>
        public virtual DbSet<RepairCategory> RepairCategory { get; set; }
        /// <summary>
        /// Gets or sets Vendor
        /// </summary>
        public virtual DbSet<Vendor> Vendor { get; set; }
        /// <summary>
        /// Gets or sets VendorFacility
        /// </summary>
        public virtual DbSet<VendorFacility> VendorFacility { get; set; }
        /// <summary>
        /// Gets or sets VendorRepairCost
        /// </summary>
        public virtual DbSet<VendorRepairCost> VendorRepairCost { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterAlias
        /// </summary>
        public virtual DbSet<ItemMasterAlias> ItemMasterAlias { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterDefinitionGroup
        /// </summary>
        public virtual DbSet<ItemMasterDefinitionGroup> ItemMasterDefinitionGroup { get; set; }
        /// <summary>
        /// Gets or sets Contract
        /// </summary>
        public virtual DbSet<Contract> Contract { get; set; }
        /// <summary>
        /// Gets or sets ContractVendorMaintenance
        /// </summary>
        public virtual DbSet<ContractVendorMaintenance> ContractVendorMaintenance { get; set; }
        /// <summary>
        /// Gets or sets VendorContact
        /// </summary>
        public virtual DbSet<VendorContact> VendorContact { get; set; }
        /// <summary>
        /// Gets or sets VendorMaintenanceActivity
        /// </summary>
        public virtual DbSet<VendorMaintenanceActivity> VendorMaintenanceActivity { get; set; }
        /// <summary>
        /// Gets or sets PlannedMaintenanceRule
        /// </summary>
        public virtual DbSet<PlannedMaintenanceRule> PlannedMaintenanceRule { get; set; }
        /// <summary>
        /// Gets or sets Schedule
        /// </summary>
        public virtual DbSet<Schedule> Schedule { get; set; }
        /// <summary>
        /// Gets or sets ClientSettings
        /// </summary>
        public virtual DbSet<ClientSettings> ClientSettings { get; set; }
        /// <summary>
        /// Gets or sets Contact
        /// </summary>
        public virtual DbSet<Contact> Contact { get; set; }
        /// <summary>
        /// Gets or sets Comment
        /// </summary>
        public virtual DbSet<Comment> Comment { get; set; }
        /// <summary>
        /// Gets or sets Enquiry
        /// </summary>
        public virtual DbSet<Enquiry> Enquiry { get; set; }
        /// <summary>
        /// Gets or sets EnquiryStatus
        /// </summary>
        public virtual DbSet<EnquiryStatus> EnquiryStatus { get; set; }
        /// <summary>
        /// Gets or sets FastTrackRequestStatus
        /// </summary>
        public virtual DbSet<FastTrackRequestStatus> FastTrackRequestStatus { get; set; }
        /// <summary>
        /// Gets or sets BatchSterilisationTestReport
        /// </summary>
        public virtual DbSet<BatchSterilisationTestReport> BatchSterilisationTestReport { get; set; }
        /// <summary>
        /// Gets or sets SterilisationTemperature
        /// </summary>
        public virtual DbSet<SterilisationTemperature> SterilisationTemperature { get; set; }
        /// <summary>
        /// Gets or sets SterilisationTestReport
        /// </summary>
        public virtual DbSet<SterilisationTestReport> SterilisationTestReport { get; set; }
        /// <summary>
        /// Gets or sets SterilisationTestReportStatus
        /// </summary>
        public virtual DbSet<SterilisationTestReportStatus> SterilisationTestReportStatus { get; set; }
        /// <summary>
        /// Gets or sets TestReportTemperature
        /// </summary>
        public virtual DbSet<TestReportTemperature> TestReportTemperature { get; set; }
        /// <summary>
        /// Gets or sets SterilisationTestReportAuditHistory
        /// </summary>
        public virtual DbSet<SterilisationTestReportAuditHistory> SterilisationTestReportAuditHistory { get; set; }
        /// <summary>
        /// Gets or sets Order
        /// </summary>
        public virtual DbSet<Order> Order { get; set; }
        /// <summary>
        /// Gets or sets BiologicalIndicatorTest
        /// </summary>
        public virtual DbSet<BiologicalIndicatorTest> BiologicalIndicatorTest { get; set; }
        /// <summary>
        /// Gets or sets BiologicalIndicatorTestStatus
        /// </summary>
        public virtual DbSet<BiologicalIndicatorTestStatus> BiologicalIndicatorTestStatus { get; set; }
        /// <summary>
        /// Gets or sets MachineBatchCycle
        /// </summary>
        public virtual DbSet<MachineBatchCycle> MachineBatchCycle { get; set; }
        /// <summary>
        /// Gets or sets BatchStatus
        /// </summary>
        public virtual DbSet<BatchStatus> BatchStatus { get; set; }
        /// <summary>
        /// Gets or sets CycleParameter
        /// </summary>
        public virtual DbSet<CycleParameter> CycleParameter { get; set; }
        /// <summary>
        /// Gets or sets CycleParameterActivityType
        /// </summary>
        public virtual DbSet<CycleParameterActivityType> CycleParameterActivityType { get; set; }
        /// <summary>
        /// Gets or sets CycleParameterAirRemoval
        /// </summary>
        public virtual DbSet<CycleParameterAirRemoval> CycleParameterAirRemoval { get; set; }
        /// <summary>
        /// Gets or sets CycleParameterChamber
        /// </summary>
        public virtual DbSet<CycleParameterChamber> CycleParameterChamber { get; set; }
        /// <summary>
        /// Gets or sets CycleParameterDetail
        /// </summary>
        public virtual DbSet<CycleParameterDetail> CycleParameterDetail { get; set; }
        /// <summary>
        /// Gets or sets SterilisationExpiryTime
        /// </summary>
        public virtual DbSet<SterilisationExpiryTime> SterilisationExpiryTime { get; set; }
        /// <summary>
        /// Gets or sets LocationType
        /// </summary>
        public virtual DbSet<LocationType> LocationType { get; set; }
        /// <summary>
        /// Gets or sets StockMovement
        /// </summary>
        public virtual DbSet<StockMovement> StockMovement { get; set; }
        /// <summary>
        /// Gets or sets StockTransaction
        /// </summary>
        public virtual DbSet<StockTransaction> StockTransaction { get; set; }
        /// <summary>
        /// Gets or sets StockTransactionType
        /// </summary>
        public virtual DbSet<StockTransactionType> StockTransactionType { get; set; }
        /// <summary>
        /// Gets or sets Leaf
        /// </summary>
        public virtual DbSet<Leaf> Leaf { get; set; }
        /// <summary>
        /// Gets or sets LocationTree
        /// </summary>
        public virtual DbSet<LocationTree> LocationTree { get; set; }
        /// <summary>
        /// Gets or sets Owner
        /// </summary>
        public virtual DbSet<Owner> Owner { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceActivity
        /// </summary>
        public virtual DbSet<MaintenanceActivity> MaintenanceActivity { get; set; }
        /// <summary>
        /// Gets or sets CustomerSetting
        /// </summary>
        public virtual DbSet<CustomerSetting> CustomerSetting { get; set; }
        /// <summary>
        /// Gets or sets SystemSetting
        /// </summary>
        public virtual DbSet<SystemSetting> SystemSetting { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceInstrumentStatus
        /// </summary>
        public virtual DbSet<MaintenanceInstrumentStatus> MaintenanceInstrumentStatus { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceReportInstrumentDetail
        /// </summary>
        public virtual DbSet<MaintenanceReportInstrumentDetail> MaintenanceReportInstrumentDetail { get; set; }
        /// <summary>
        /// Gets or sets OrderStatusHistory
        /// </summary>
        public virtual DbSet<OrderStatusHistory> OrderStatusHistory { get; set; }
        /// <summary>
        /// Gets or sets PlannedMaintenanceFlagSettings
        /// </summary>
        public virtual DbSet<PlannedMaintenanceFlagSettings> PlannedMaintenanceFlagSettings { get; set; }
        /// <summary>
        /// Gets or sets OrderLine
        /// </summary>
        public virtual DbSet<OrderLine> OrderLine { get; set; }
        /// <summary>
        /// Gets or sets OrderLineStatus
        /// </summary>
        public virtual DbSet<OrderLineStatus> OrderLineStatus { get; set; }
        /// <summary>
        /// Gets or sets OrderStatus
        /// </summary>
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        /// <summary>
        /// Gets or sets Location
        /// </summary>
        public virtual DbSet<Location> Location { get; set; }
        /// <summary>
        /// Gets or sets Tree
        /// </summary>
        public virtual DbSet<Tree> Tree { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinition
        /// </summary>
        public virtual DbSet<CustomerDefinition> CustomerDefinition { get; set; }
        /// <summary>
        /// Gets or sets CustomisableTable
        /// </summary>
        public virtual DbSet<CustomisableTable> CustomisableTable { get; set; }
        /// <summary>
        /// Gets or sets Tenancy
        /// </summary>
        public virtual DbSet<Tenancy> Tenancy { get; set; }
        /// <summary>
        /// Gets or sets TenancyCustomValue
        /// </summary>
        public virtual DbSet<TenancyCustomValue> TenancyCustomValue { get; set; }
        /// <summary>
        /// Gets or sets TenancySetting
        /// </summary>
        public virtual DbSet<TenancySetting> TenancySetting { get; set; }
        /// <summary>
        /// Gets or sets FacilitySetting
        /// </summary>
        public virtual DbSet<FacilitySetting> FacilitySetting { get; set; }
        /// <summary>
        /// Gets or sets Directorate
        /// </summary>
        public virtual DbSet<Directorate> Directorate { get; set; }
        /// <summary>
        /// Gets or sets OrderTemplate
        /// </summary>
        public virtual DbSet<OrderTemplate> OrderTemplate { get; set; }
        /// <summary>
        /// Gets or sets OrderTemplateLine
        /// </summary>
        public virtual DbSet<OrderTemplateLine> OrderTemplateLine { get; set; }
        /// <summary>
        /// Gets or sets LoanSetContentProcessParameters
        /// </summary>
        public virtual DbSet<LoanSetContentProcessParameters> LoanSetContentProcessParameters { get; set; }
        /// <summary>
        /// Gets or sets LoanSetProcessAcceptance
        /// </summary>
        public virtual DbSet<LoanSetProcessAcceptance> LoanSetProcessAcceptance { get; set; }
        /// <summary>
        /// Gets or sets ProcessParameters
        /// </summary>
        public virtual DbSet<ProcessParameters> ProcessParameters { get; set; }
        /// <summary>
        /// Gets or sets CurrentTurnaroundEvents
        /// </summary>
        public virtual DbSet<CurrentTurnaroundEvent> CurrentTurnaroundEvents { get; set; }
        /// <summary>
        /// Gets or sets CatalogueEditors
        /// </summary>
        public virtual DbSet<CatalogueEditor> CatalogueEditors { get; set; }
        /// <summary>
        /// Gets or sets ItemInstance
        /// </summary>
        public virtual DbSet<ItemInstance> ItemInstance { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterCosting
        /// </summary>
        public virtual DbSet<ItemMasterCosting> ItemMasterCosting { get; set; }
        /// <summary>
        /// Gets or sets ItemInstanceIdentifier
        /// </summary>
        public virtual DbSet<ItemInstanceIdentifier> ItemInstanceIdentifier { get; set; }
        /// <summary>
        /// Gets or sets ChangeControlNote
        /// </summary>
        public virtual DbSet<ChangeControlNote> ChangeControlNote { get; set; }
        /// <summary>
        /// Gets or sets ReportType
        /// </summary>
        public virtual DbSet<ReportType> ReportType { get; set; }
        /// <summary>
        /// Gets or sets DateTimeFormat
        /// </summary>
        public virtual DbSet<DateTimeFormat> DateTimeFormat { get; set; }
        /// <summary>
        /// Gets or sets Format
        /// </summary>
        public virtual DbSet<Format> Format { get; set; }
        /// <summary>
        /// Gets or sets FormatType
        /// </summary>
        public virtual DbSet<FormatType> FormatType { get; set; }
        /// <summary>
        /// Gets or sets TimeZone
        /// </summary>
        public virtual DbSet<TimeZone> TimeZone { get; set; }
        /// <summary>
        /// Gets or sets MultiFacilityProcessHandShake
        /// </summary>
        public virtual DbSet<MultiFacilityProcessHandShake> MultiFacilityProcessHandShake { get; set; }
        /// <summary>
        /// Gets or sets MultiFacilityProcessing
        /// </summary>
        public virtual DbSet<MultiFacilityProcessing> MultiFacilityProcessing { get; set; }
        /// <summary>
        /// Gets or sets AbandonReason
        /// </summary>
        public virtual DbSet<AbandonReason> AbandonReason { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundFacility
        /// </summary>
        public virtual DbSet<TurnaroundFacility> TurnaroundFacility { get; set; }
        /// <summary>
        /// Gets or sets MultiFacilityProcessStatus
        /// </summary>
        public virtual DbSet<MultiFacilityProcessStatus> MultiFacilityProcessStatus { get; set; }
        /// <summary>
        /// Gets or sets DeniedTurnaroundEvent
        /// </summary>
        public virtual DbSet<DeniedTurnaroundEvent> DeniedTurnaroundEvent { get; set; }
        /// <summary>
        /// Gets or sets DeniedTurnaroundEventReason
        /// </summary>
        public virtual DbSet<DeniedTurnaroundEventReason> DeniedTurnaroundEventReason { get; set; }
        /// <summary>
        /// Gets or sets FailedScan
        /// </summary>
        public virtual DbSet<FailedScan> FailedScan { get; set; }
        /// <summary>
        /// Gets or sets ProcessingMode
        /// </summary>
        public virtual DbSet<ProcessingMode> ProcessingMode { get; set; }
        /// <summary>
        /// Gets or sets ScanType
        /// </summary>
        public virtual DbSet<ScanType> ScanType { get; set; }
        /// <summary>
        /// Gets or sets ClockingEventType
        /// </summary>
        public virtual DbSet<ClockingEventType> ClockingEventType { get; set; }
        /// <summary>
        /// Gets or sets LabourLevel
        /// </summary>
        public virtual DbSet<LabourLevel> LabourLevel { get; set; }
        /// <summary>
        /// Gets or sets Task
        /// </summary>
        public virtual DbSet<Task> Task { get; set; }
        /// <summary>
        /// Gets or sets DecontaminationTaskTime
        /// </summary>
        public virtual DbSet<DecontaminationTaskTime> DecontaminationTaskTime { get; set; }
        /// <summary>
        /// Gets or sets MachineType
        /// </summary>
        public virtual DbSet<MachineType> MachineType { get; set; }
        /// <summary>
        /// Gets or sets CustomStationery
        /// </summary>
        public virtual DbSet<CustomStationery> CustomStationery { get; set; }
        /// <summary>
        /// Gets or sets CustomStationeryLogic
        /// </summary>
        public virtual DbSet<CustomStationeryLogic> CustomStationeryLogic { get; set; }
        /// <summary>
        /// Gets or sets ClockingConfigurationType
        /// </summary>
        public virtual DbSet<ClockingConfigurationType> ClockingConfigurationType { get; set; }
        /// <summary>
        /// Gets or sets Batch
        /// </summary>
        public virtual DbSet<Batch> Batch { get; set; }
        /// <summary>
        /// Gets or sets BatchDecontaminationTask
        /// </summary>
        public virtual DbSet<BatchDecontaminationTask> BatchDecontaminationTask { get; set; }
        /// <summary>
        /// Gets or sets DecontaminationTask
        /// </summary>
        public virtual DbSet<DecontaminationTask> DecontaminationTask { get; set; }
        /// <summary>
        /// Gets or sets UserClockingEvent
        /// </summary>
        public virtual DbSet<UserClockingEvent> UserClockingEvent { get; set; }
        /// <summary>
        /// Gets or sets Translation
        /// </summary>
        public virtual DbSet<Translation> Translation { get; set; }
        /// <summary>
        /// Gets or sets Culture
        /// </summary>
        public virtual DbSet<Culture> Culture { get; set; }
        /// <summary>
        /// Gets or sets MultiFacilityProcessRestrictions
        /// </summary>
        public virtual DbSet<MultiFacilityProcessRestriction> MultiFacilityProcessRestrictions { get; set; }
        /// <summary>
        /// Gets or sets ItemInstanceIdentifierTypes
        /// </summary>
        public virtual DbSet<ItemInstanceIdentifierType> ItemInstanceIdentifierTypes { get; set; }
        /// <summary>
        /// Gets or sets NotificationRules
        /// </summary>
        public virtual DbSet<NotificationRule> NotificationRules { get; set; }
        /// <summary>
        /// Gets or sets NotificationRuleHistories
        /// </summary>
        public virtual DbSet<NotificationRuleHistory> NotificationRuleHistories { get; set; }
        /// <summary>
        /// Gets or sets NotificationRuleOutcomes
        /// </summary>
        public virtual DbSet<NotificationRuleOutcome> NotificationRuleOutcomes { get; set; }
        /// <summary>
        /// Gets or sets OutputTypes
        /// </summary>
        public virtual DbSet<OutputType> OutputTypes { get; set; }
        /// <summary>
        /// Gets or sets CommunicationTypes
        /// </summary>
        public virtual DbSet<CommunicationType> CommunicationTypes { get; set; }
        /// <summary>
        /// Gets or sets NotificationOutputs
        /// </summary>
        public virtual DbSet<NotificationOutput> NotificationOutputs { get; set; }
        /// <summary>
        /// Gets or sets RecipientTypes
        /// </summary>
        public virtual DbSet<RecipientType> RecipientTypes { get; set; }
        /// <summary>
        /// Gets or sets TransferNote
        /// </summary>
        public virtual DbSet<TransferNote> TransferNote { get; set; }
        /// <summary>
        /// Gets or sets TransferNoteLine
        /// </summary>
        public virtual DbSet<TransferNoteLine> TransferNoteLine { get; set; }
        /// <summary>
        /// Gets or sets RetrospectiveEventWhiteList
        /// </summary>
        public virtual DbSet<RetrospectiveEventWhiteList> RetrospectiveEventWhiteList { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceLabelAudit
        /// </summary>
        public virtual DbSet<ContainerInstanceLabelAudit> ContainerInstanceLabelAudit { get; set; }
        /// <summary>
        /// Gets or sets StocktakeActivity
        /// </summary>
        public virtual DbSet<StocktakeActivity> StocktakeActivity { get; set; }
        /// <summary>
        /// Gets or sets StocktakeHistory
        /// </summary>
        public virtual DbSet<StocktakeHistory> StocktakeHistory { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEventWeight
        /// </summary>
        public virtual DbSet<TurnaroundEventWeight> TurnaroundEventWeight { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceWeight
        /// </summary>
        public virtual DbSet<ContainerInstanceWeight> ContainerInstanceWeight { get; set; }
        /// <summary>
        /// Gets or sets DelayedBiTestType
        /// </summary>
        public virtual DbSet<DelayedBiTestType> DelayedBiTestType { get; set; }
        /// <summary>
        /// Gets or sets FavouriteReport
        /// </summary>
        public virtual DbSet<FavouriteReport> FavouriteReport { get; set; }
        /// <summary>
        /// Gets or sets FavouriteReportParameter
        /// </summary>
        public virtual DbSet<FavouriteReportParameter> FavouriteReportParameter { get; set; }
        /// <summary>
        /// Gets or sets UserPasswordHistory
        /// </summary>
        public virtual DbSet<UserPasswordHistory> UserPasswordHistory { get; set; }
        /// <summary>
        /// Gets or sets FavouriteReportParameterValue
        /// </summary>
        public virtual DbSet<FavouriteReportParameterValue> FavouriteReportParameterValue { get; set; }
        /// <summary>
        /// Gets or sets ReportOutputType
        /// </summary>
        public virtual DbSet<ReportOutputType> ReportOutputType { get; set; }
        /// <summary>
        /// Gets or sets AppType
        /// </summary>
        public virtual DbSet<AppType> AppType { get; set; }
        /// <summary>
        /// Gets or sets LoginAudit
        /// </summary>
        public virtual DbSet<LoginAudit> LoginAudit { get; set; }
        /// <summary>
        /// Gets or sets LoginAuditType
        /// </summary>
        public virtual DbSet<LoginAuditType> LoginAuditType { get; set; }
        /// <summary>
        /// Gets or sets Surgeon
        /// </summary>
        public virtual DbSet<Surgeon> Surgeon { get; set; }
        /// <summary>
        /// Gets or sets SurgicalProcedure
        /// </summary>
        public virtual DbSet<SurgicalProcedure> SurgicalProcedure { get; set; }
        /// <summary>
        /// Gets or sets SurgicalProcedureTurnaround
        /// </summary>
        public virtual DbSet<SurgicalProcedureTurnaround> SurgicalProcedureTurnaround { get; set; }
        /// <summary>
        /// Gets or sets SurgicalProcedureType
        /// </summary>
        public virtual DbSet<SurgicalProcedureType> SurgicalProcedureType { get; set; }
        /// <summary>
        /// Gets or sets AuditLineExceptionReason
        /// </summary>
        public virtual DbSet<AuditLineExceptionReason> AuditLineExceptionReason { get; set; }
        /// <summary>
        /// Gets or sets AuditLineStatusType
        /// </summary>
        public virtual DbSet<AuditLineStatusType> AuditLineStatusType { get; set; }
        /// <summary>
        /// Gets or sets AuditResultType
        /// </summary>
        public virtual DbSet<AuditResultType> AuditResultType { get; set; }
        /// <summary>
        /// Gets or sets SingleInstrumentAuditLine
        /// </summary>
        public virtual DbSet<SingleInstrumentAuditLine> SingleInstrumentAuditLine { get; set; }
        /// <summary>
        /// Gets or sets AuditType
        /// </summary>
        public virtual DbSet<AuditType> AuditType { get; set; }
        /// <summary>
        /// Gets or sets ItemInstanceHistory
        /// </summary>
        public virtual DbSet<ItemInstanceHistory> ItemInstanceHistory { get; set; }
        /// <summary>
        /// Gets or sets ItemInstanceHistoryType
        /// </summary>
        public virtual DbSet<ItemInstanceHistoryType> ItemInstanceHistoryType { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionAuditRule
        /// </summary>
        public virtual DbSet<ContainerMasterDefinitionAuditRule> ContainerMasterDefinitionAuditRule { get; set; }
        /// <summary>
        /// Gets or sets FacilityAuditRule
        /// </summary>
        public virtual DbSet<FacilityAuditRule> FacilityAuditRule { get; set; }
        /// <summary>
        /// Gets or sets AuditRule
        /// </summary>
        public virtual DbSet<AuditRule> AuditRule { get; set; }
        /// <summary>
        /// Gets or sets SingleInstrumentAudit
        /// </summary>
        public virtual DbSet<SingleInstrumentAudit> SingleInstrumentAudit { get; set; }
        /// <summary>
        /// Gets or sets HisDataCrossMatching
        /// </summary>
        public virtual DbSet<HisDataCrossMatching> HisDataCrossMatching { get; set; }
        /// <summary>
        /// Gets or sets HisMessage
        /// </summary>
        public virtual DbSet<HisMessage> HisMessage { get; set; }
        /// <summary>
        /// Gets or sets HisOrder
        /// </summary>
        public virtual DbSet<HisOrder> HisOrder { get; set; }
        /// <summary>
        /// Gets or sets HisOrderNote
        /// </summary>
        public virtual DbSet<HisOrderNote> HisOrderNote { get; set; }
        /// <summary>
        /// Gets or sets OrderNote
        /// </summary>
        public virtual DbSet<OrderNote> OrderNote { get; set; }
        /// <summary>
        /// Gets or sets AuditProcessFaultReason
        /// </summary>
        public virtual DbSet<AuditProcessFaultReason> AuditProcessFaultReason { get; set; }
        /// <summary>
        /// Gets or sets SingleInstrumentAuditProcessFault
        /// </summary>
        public virtual DbSet<SingleInstrumentAuditProcessFault> SingleInstrumentAuditProcessFault { get; set; }
        /// <summary>
        /// Gets or sets HisDataCrossMatchType
        /// </summary>
        public virtual DbSet<HisDataCrossMatchType> HisDataCrossMatchType { get; set; }
        /// <summary>
        /// Gets or sets HisOrderLine
        /// </summary>
        public virtual DbSet<HisOrderLine> HisOrderLine { get; set; }
        /// <summary>
        /// Gets or sets DecontaminationTaskItemType
        /// </summary>
        public virtual DbSet<DecontaminationTaskItemType> DecontaminationTaskItemType { get; set; }
        /// <summary>
        /// Gets or sets MachineDetergent
        /// </summary>
        public virtual DbSet<MachineDetergent> MachineDetergent { get; set; }
        /// <summary>
        /// Gets or sets FailureTypeEventType
        /// </summary>
        public virtual DbSet<FailureTypeEventType> FailureTypeEventType { get; set; }
        /// <summary>
        /// Gets or sets FastTrackRequestLine
        /// </summary>
        public virtual DbSet<FastTrackRequestLine> FastTrackRequestLine { get; set; }
        /// <summary>
        /// Gets or sets MachineSetting
        /// </summary>
        public virtual DbSet<MachineSetting> MachineSetting { get; set; }
        /// <summary>
        /// Gets or sets MachineGroup
        /// </summary>
        public virtual DbSet<MachineGroup> MachineGroup { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterNote
        /// </summary>
        public virtual DbSet<ContainerMasterNote> ContainerMasterNote { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundNote
        /// </summary>
        public virtual DbSet<TurnaroundNote> TurnaroundNote { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterNoteStationType
        /// </summary>
        public virtual DbSet<ContainerMasterNoteStationType> ContainerMasterNoteStationType { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundNoteStationType
        /// </summary>
        public virtual DbSet<TurnaroundNoteStationType> TurnaroundNoteStationType { get; set; }
        /// <summary>
        /// Gets or sets CustomerItemType
        /// </summary>
        public virtual DbSet<CustomerItemType> CustomerItemType { get; set; }
        /// <summary>
        /// Gets or sets OwnerReportAccess
        /// </summary>
        public virtual DbSet<OwnerReportAccess> OwnerReportAccess { get; set; }
        /// <summary>
        /// Gets or sets ConfigurableListType
        /// </summary>
        public virtual DbSet<ConfigurableListType> ConfigurableListType { get; set; }
        /// <summary>
        /// Gets or sets ConfigurableListValue
        /// </summary>
        public virtual DbSet<ConfigurableListValue> ConfigurableListValue { get; set; }
        /// <summary>
        /// Gets or sets OwnerConfigurableListValue
        /// </summary>
        public virtual DbSet<OwnerConfigurableListValue> OwnerConfigurableListValue { get; set; }
        /// <summary>
        /// Gets or sets EventTypeGroup
        /// </summary>
        public virtual DbSet<EventTypeGroup> EventTypeGroup { get; set; }
        /// <summary>
        /// Gets or sets FailedWash
        /// </summary>
        public virtual DbSet<FailedWash> FailedWash { get; set; }
        /// <summary>
        /// Gets or sets FailedWashInstrument
        /// </summary>
        public virtual DbSet<FailedWashInstrument> FailedWashInstrument { get; set; }
        /// <summary>
        /// Gets or sets Manufacturer
        /// </summary>
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        /// <summary>
        /// Gets or sets PrintContentType
        /// </summary>
        public virtual DbSet<PrintContentType> PrintContentType { get; set; }
        /// <summary>
        /// Gets or sets PrintHistoryContent
        /// </summary>
        public virtual DbSet<PrintHistoryContent> PrintHistoryContent { get; set; }
        /// <summary>
        /// Gets or sets PrintHistoryBatch
        /// </summary>
        public virtual DbSet<PrintHistoryBatch> PrintHistoryBatch { get; set; }
        /// <summary>
        /// Gets or sets PrintHistoryDeliveryNote
        /// </summary>
        public virtual DbSet<PrintHistoryDeliveryNote> PrintHistoryDeliveryNote { get; set; }
        /// <summary>
        /// Gets or sets PrintHistoryNotificationRule
        /// </summary>
        public virtual DbSet<PrintHistoryNotificationRule> PrintHistoryNotificationRule { get; set; }
        /// <summary>
        /// Gets or sets PrintHistoryTurnaround
        /// </summary>
        public virtual DbSet<PrintHistoryTurnaround> PrintHistoryTurnaround { get; set; }
        /// <summary>
        /// Gets or sets PrintHistoryTurnaroundEvent
        /// </summary>
        public virtual DbSet<PrintHistoryTurnaroundEvent> PrintHistoryTurnaroundEvent { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEventReprint
        /// </summary>
        public virtual DbSet<TurnaroundEventReprint> TurnaroundEventReprint { get; set; }
        /// <summary>
        /// Gets or sets PrintHistory
        /// </summary>
        public virtual DbSet<PrintHistory> PrintHistory { get; set; }
        /// <summary>
        /// Gets or sets Document
        /// </summary>
        public virtual DbSet<Document> Document { get; set; }
        /// <summary>
        /// Gets or sets DocumentAudit
        /// </summary>
        public virtual DbSet<DocumentAudit> DocumentAudit { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceReportSetting
        /// </summary>
        public virtual DbSet<MaintenanceReportSetting> MaintenanceReportSetting { get; set; }
        /// <summary>
        /// Gets or sets OwnerMaintenanceReportSetting
        /// </summary>
        public virtual DbSet<OwnerMaintenanceReportSetting> OwnerMaintenanceReportSetting { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionMaintenanceCapacityType
        /// </summary>
        public virtual DbSet<ContainerMasterDefinitionMaintenanceCapacityType> ContainerMasterDefinitionMaintenanceCapacityType { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionMaintenanceCapacity
        /// </summary>
        public virtual DbSet<ContainerMasterDefinitionMaintenanceCapacity> ContainerMasterDefinitionMaintenanceCapacity { get; set; }
        /// <summary>
        /// Gets or sets ProcessingNote
        /// </summary>
        public virtual DbSet<ProcessingNote> ProcessingNote { get; set; }
        /// <summary>
        /// Gets or sets ProcessingNoteStationType
        /// </summary>
        public virtual DbSet<ProcessingNoteStationType> ProcessingNoteStationType { get; set; }
        /// <summary>
        /// Gets or sets ProcessingNoteType
        /// </summary>
        public virtual DbSet<ProcessingNoteType> ProcessingNoteType { get; set; }
        /// <summary>
        /// Gets or sets UserProductionManagerFilter
        /// </summary>
        public virtual DbSet<UserProductionManagerFilter> UserProductionManagerFilter { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterNoteAudit
        /// </summary>
        public virtual DbSet<ContainerMasterNoteAudit> ContainerMasterNoteAudit { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEventAcknowledgeNote
        /// </summary>
        public virtual DbSet<TurnaroundEventAcknowledgeNote> TurnaroundEventAcknowledgeNote { get; set; }
        /// <summary>
        /// Gets or sets FacilityType
        /// </summary>
        public virtual DbSet<FacilityType> FacilityType { get; set; }
        /// <summary>
        /// Gets or sets Quality
        /// </summary>
        public virtual DbSet<Quality> Quality { get; set; }
        /// <summary>
        /// Gets or sets DefinitionType
        /// </summary>
        public virtual DbSet<DefinitionType> DefinitionType { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterBlueprint
        /// </summary>
        public virtual DbSet<ContainerMasterBlueprint> ContainerMasterBlueprint { get; set; }
        /// <summary>
        /// Gets or sets LoanSetExternalReference
        /// </summary>
        public virtual DbSet<LoanSetExternalReference> LoanSetExternalReference { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterBlueprint
        /// </summary>
        public virtual DbSet<ItemMasterBlueprint> ItemMasterBlueprint { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstance
        /// </summary>
        public virtual DbSet<ContainerInstance> ContainerInstance { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceIdentifier
        /// </summary>
        public virtual DbSet<ContainerInstanceIdentifier> ContainerInstanceIdentifier { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceIdentifierType
        /// </summary>
        public virtual DbSet<ContainerInstanceIdentifierType> ContainerInstanceIdentifierType { get; set; }
        /// <summary>
        /// Gets or sets ItemException
        /// </summary>
        public virtual DbSet<ItemException> ItemException { get; set; }
        /// <summary>
        /// Gets or sets ItemExceptionReason
        /// </summary>
        public virtual DbSet<ItemExceptionReason> ItemExceptionReason { get; set; }
        /// <summary>
        /// Gets or sets ItemEstimatedTimeOfArrival
        /// </summary>
        public virtual DbSet<ItemEstimatedTimeOfArrival> ItemEstimatedTimeOfArrival { get; set; }
        /// <summary>
        /// Gets or sets ItemEstimatedTimeOfArrival_History
        /// </summary>
        public virtual DbSet<ItemEstimatedTimeOfArrival_History> ItemEstimatedTimeOfArrival_History { get; set; }
        /// <summary>
        /// Gets or sets QualityType
        /// </summary>
        public virtual DbSet<QualityType> QualityType { get; set; }
    
        /// <summary>
        /// GetPriorityListItemsForOrdering operation
        /// </summary>
        public virtual ObjectResult<GetPriorityListItemsForOrdering_Result> GetPriorityListItemsForOrdering(Nullable<int> userId, Nullable<bool> completedOrdersOnly)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var completedOrdersOnlyParameter = completedOrdersOnly.HasValue ?
                new ObjectParameter("CompletedOrdersOnly", completedOrdersOnly) :
                new ObjectParameter("CompletedOrdersOnly", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPriorityListItemsForOrdering_Result>("GetPriorityListItemsForOrdering", userIdParameter, completedOrdersOnlyParameter);
        }
    
        /// <summary>
        /// finapp_CreateDeliveryPointLocation operation
        /// </summary>
        public virtual int finapp_CreateDeliveryPointLocation(Nullable<int> customerDefinitionId, Nullable<int> newFacilityId)
        {
            var customerDefinitionIdParameter = customerDefinitionId.HasValue ?
                new ObjectParameter("CustomerDefinitionId", customerDefinitionId) :
                new ObjectParameter("CustomerDefinitionId", typeof(int));
    
            var newFacilityIdParameter = newFacilityId.HasValue ?
                new ObjectParameter("NewFacilityId", newFacilityId) :
                new ObjectParameter("NewFacilityId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("finapp_CreateDeliveryPointLocation", customerDefinitionIdParameter, newFacilityIdParameter);
        }
    
        /// <summary>
        /// GetAllOrdersByAlternateIdOrOrderNumber operation
        /// </summary>
        public virtual ObjectResult<GetAllOrdersByAlternateIdOrOrderNumber_Result> GetAllOrdersByAlternateIdOrOrderNumber(Nullable<int> userId, string searchText)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var searchTextParameter = searchText != null ?
                new ObjectParameter("SearchText", searchText) :
                new ObjectParameter("SearchText", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllOrdersByAlternateIdOrOrderNumber_Result>("GetAllOrdersByAlternateIdOrOrderNumber", userIdParameter, searchTextParameter);
        }
    
        /// <summary>
        /// SearchForItemsByTags operation
        /// </summary>
        public virtual int SearchForItemsByTags(Nullable<short> facilityId, Nullable<bool> excludeBlueprintCopiedInstruments)
        {
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(short));
    
            var excludeBlueprintCopiedInstrumentsParameter = excludeBlueprintCopiedInstruments.HasValue ?
                new ObjectParameter("ExcludeBlueprintCopiedInstruments", excludeBlueprintCopiedInstruments) :
                new ObjectParameter("ExcludeBlueprintCopiedInstruments", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SearchForItemsByTags", facilityIdParameter, excludeBlueprintCopiedInstrumentsParameter);
        }
    
        /// <summary>
        /// ReadActiveTurnaroundsByContainerMaster operation
        /// </summary>
        public virtual ObjectResult<Nullable<int>> ReadActiveTurnaroundsByContainerMaster(Nullable<int> containerMasterId, Nullable<bool> allowUpdateUptoAutoclave)
        {
            var containerMasterIdParameter = containerMasterId.HasValue ?
                new ObjectParameter("ContainerMasterId", containerMasterId) :
                new ObjectParameter("ContainerMasterId", typeof(int));
    
            var allowUpdateUptoAutoclaveParameter = allowUpdateUptoAutoclave.HasValue ?
                new ObjectParameter("AllowUpdateUptoAutoclave", allowUpdateUptoAutoclave) :
                new ObjectParameter("AllowUpdateUptoAutoclave", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("ReadActiveTurnaroundsByContainerMaster", containerMasterIdParameter, allowUpdateUptoAutoclaveParameter);
        }
    
        /// <summary>
        /// UpdateActiveTurnaroundsByContainerMaster operation
        /// </summary>
        public virtual int UpdateActiveTurnaroundsByContainerMaster(Nullable<int> containerMasterId, Nullable<int> userId, Nullable<int> facilityId, Nullable<bool> allowUpdateUptoAutoclave)
        {
            var containerMasterIdParameter = containerMasterId.HasValue ?
                new ObjectParameter("ContainerMasterId", containerMasterId) :
                new ObjectParameter("ContainerMasterId", typeof(int));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(int));
    
            var allowUpdateUptoAutoclaveParameter = allowUpdateUptoAutoclave.HasValue ?
                new ObjectParameter("AllowUpdateUptoAutoclave", allowUpdateUptoAutoclave) :
                new ObjectParameter("AllowUpdateUptoAutoclave", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateActiveTurnaroundsByContainerMaster", containerMasterIdParameter, userIdParameter, facilityIdParameter, allowUpdateUptoAutoclaveParameter);
        }
    
        /// <summary>
        /// DeliveryNotes_LoadDeliveryNoteListByFacility operation
        /// </summary>
        public virtual ObjectResult<DeliveryNotes_LoadDeliveryNotesListByFacility_Result> DeliveryNotes_LoadDeliveryNoteListByFacility(Nullable<int> facilityID, Nullable<int> take)
        {
            var facilityIDParameter = facilityID.HasValue ?
                new ObjectParameter("FacilityID", facilityID) :
                new ObjectParameter("FacilityID", typeof(int));
    
            var takeParameter = take.HasValue ?
                new ObjectParameter("Take", take) :
                new ObjectParameter("Take", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DeliveryNotes_LoadDeliveryNotesListByFacility_Result>("DeliveryNotes_LoadDeliveryNoteListByFacility", facilityIDParameter, takeParameter);
        }
    
        public virtual ObjectResult<Nullable<System.DateTime>> admapp_ReadExpiryReCalculationQuarantine(Nullable<int> turnaroundId, Nullable<int> serviceRequirementId)
        {
            var turnaroundIdParameter = turnaroundId.HasValue ?
                new ObjectParameter("TurnaroundId", turnaroundId) :
                new ObjectParameter("TurnaroundId", typeof(int));
    
            var serviceRequirementIdParameter = serviceRequirementId.HasValue ?
                new ObjectParameter("ServiceRequirementId", serviceRequirementId) :
                new ObjectParameter("ServiceRequirementId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<System.DateTime>>("admapp_ReadExpiryReCalculationQuarantine", turnaroundIdParameter, serviceRequirementIdParameter);
        }
    
        /// <summary>
        /// admapp_ReadOmniSearchBatchDetail operation
        /// </summary>
        public virtual ObjectResult<admapp_ReadOmniSearchBatchDetail_Result> admapp_ReadOmniSearchBatchDetail(string searchText, Nullable<short> facilityId, Nullable<bool> canIncludeArchived)
        {
            var searchTextParameter = searchText != null ?
                new ObjectParameter("SearchText", searchText) :
                new ObjectParameter("SearchText", typeof(string));
    
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(short));
    
            var canIncludeArchivedParameter = canIncludeArchived.HasValue ?
                new ObjectParameter("CanIncludeArchived", canIncludeArchived) :
                new ObjectParameter("CanIncludeArchived", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<admapp_ReadOmniSearchBatchDetail_Result>("admapp_ReadOmniSearchBatchDetail", searchTextParameter, facilityIdParameter, canIncludeArchivedParameter);
        }
    
        /// <summary>
        /// admapp_ReadOmniSearchCustomerDetail operation
        /// </summary>
        public virtual ObjectResult<admapp_ReadOmniSearchCustomerDetail_Result> admapp_ReadOmniSearchCustomerDetail(string searchText, Nullable<short> facilityId, Nullable<bool> canIncludeArchived)
        {
            var searchTextParameter = searchText != null ?
                new ObjectParameter("SearchText", searchText) :
                new ObjectParameter("SearchText", typeof(string));
    
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(short));
    
            var canIncludeArchivedParameter = canIncludeArchived.HasValue ?
                new ObjectParameter("CanIncludeArchived", canIncludeArchived) :
                new ObjectParameter("CanIncludeArchived", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<admapp_ReadOmniSearchCustomerDetail_Result>("admapp_ReadOmniSearchCustomerDetail", searchTextParameter, facilityIdParameter, canIncludeArchivedParameter);
        }
    
        /// <summary>
        /// admapp_ReadOmniSearchDefectDetail operation
        /// </summary>
        public virtual ObjectResult<admapp_ReadOmniSearchDefectDetail_Result> admapp_ReadOmniSearchDefectDetail(string searchText, Nullable<short> facilityId)
        {
            var searchTextParameter = searchText != null ?
                new ObjectParameter("SearchText", searchText) :
                new ObjectParameter("SearchText", typeof(string));
    
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<admapp_ReadOmniSearchDefectDetail_Result>("admapp_ReadOmniSearchDefectDetail", searchTextParameter, facilityIdParameter);
        }
    
        /// <summary>
        /// admapp_ReadOmniSearchDeliveryNoteDetail operation
        /// </summary>
        public virtual ObjectResult<admapp_ReadOmniSearchDeliveryNoteDetail_Result> admapp_ReadOmniSearchDeliveryNoteDetail(string searchText, Nullable<short> facilityId)
        {
            var searchTextParameter = searchText != null ?
                new ObjectParameter("SearchText", searchText) :
                new ObjectParameter("SearchText", typeof(string));
    
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<admapp_ReadOmniSearchDeliveryNoteDetail_Result>("admapp_ReadOmniSearchDeliveryNoteDetail", searchTextParameter, facilityIdParameter);
        }
    
        /// <summary>
        /// admapp_ReadOmniSearchInstanceDetail operation
        /// </summary>
        public virtual ObjectResult<admapp_ReadOmniSearchInstanceDetail_Result> admapp_ReadOmniSearchInstanceDetail(string searchText, Nullable<short> facilityId, Nullable<bool> canIncludeArchived)
        {
            var searchTextParameter = searchText != null ?
                new ObjectParameter("SearchText", searchText) :
                new ObjectParameter("SearchText", typeof(string));
    
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(short));
    
            var canIncludeArchivedParameter = canIncludeArchived.HasValue ?
                new ObjectParameter("CanIncludeArchived", canIncludeArchived) :
                new ObjectParameter("CanIncludeArchived", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<admapp_ReadOmniSearchInstanceDetail_Result>("admapp_ReadOmniSearchInstanceDetail", searchTextParameter, facilityIdParameter, canIncludeArchivedParameter);
        }
    
        /// <summary>
        /// admapp_ReadOmniSearchLoanSetsDetail operation
        /// </summary>
        public virtual ObjectResult<admapp_ReadOmniSearchLoanSetsDetail_Result> admapp_ReadOmniSearchLoanSetsDetail(string searchText, Nullable<short> facilityId, Nullable<bool> canIncludeArchived)
        {
            var searchTextParameter = searchText != null ?
                new ObjectParameter("SearchText", searchText) :
                new ObjectParameter("SearchText", typeof(string));
    
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(short));
    
            var canIncludeArchivedParameter = canIncludeArchived.HasValue ?
                new ObjectParameter("CanIncludeArchived", canIncludeArchived) :
                new ObjectParameter("CanIncludeArchived", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<admapp_ReadOmniSearchLoanSetsDetail_Result>("admapp_ReadOmniSearchLoanSetsDetail", searchTextParameter, facilityIdParameter, canIncludeArchivedParameter);
        }
    
        /// <summary>
        /// admapp_ReadOmniSearchTurnaroundDetail operation
        /// </summary>
        public virtual ObjectResult<admapp_ReadOmniSearchTurnaroundDetail_Result> admapp_ReadOmniSearchTurnaroundDetail(string searchText, Nullable<short> facilityId, Nullable<bool> includeArchived)
        {
            var searchTextParameter = searchText != null ?
                new ObjectParameter("SearchText", searchText) :
                new ObjectParameter("SearchText", typeof(string));
    
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(short));
    
            var includeArchivedParameter = includeArchived.HasValue ?
                new ObjectParameter("IncludeArchived", includeArchived) :
                new ObjectParameter("IncludeArchived", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<admapp_ReadOmniSearchTurnaroundDetail_Result>("admapp_ReadOmniSearchTurnaroundDetail", searchTextParameter, facilityIdParameter, includeArchivedParameter);
        }
    
        /// <summary>
        /// admapp_UpdateContainerInstanceLabels operation
        /// </summary>
        public virtual int admapp_UpdateContainerInstanceLabels(Nullable<int> customerDefinitionId, Nullable<short> qALabelProductCodeId, Nullable<short> linear1dBarcodeId, Nullable<short> datamatrix2dBarcodeId)
        {
            var customerDefinitionIdParameter = customerDefinitionId.HasValue ?
                new ObjectParameter("CustomerDefinitionId", customerDefinitionId) :
                new ObjectParameter("CustomerDefinitionId", typeof(int));
    
            var qALabelProductCodeIdParameter = qALabelProductCodeId.HasValue ?
                new ObjectParameter("QALabelProductCodeId", qALabelProductCodeId) :
                new ObjectParameter("QALabelProductCodeId", typeof(short));
    
            var linear1dBarcodeIdParameter = linear1dBarcodeId.HasValue ?
                new ObjectParameter("Linear1dBarcodeId", linear1dBarcodeId) :
                new ObjectParameter("Linear1dBarcodeId", typeof(short));
    
            var datamatrix2dBarcodeIdParameter = datamatrix2dBarcodeId.HasValue ?
                new ObjectParameter("Datamatrix2dBarcodeId", datamatrix2dBarcodeId) :
                new ObjectParameter("Datamatrix2dBarcodeId", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("admapp_UpdateContainerInstanceLabels", customerDefinitionIdParameter, qALabelProductCodeIdParameter, linear1dBarcodeIdParameter, datamatrix2dBarcodeIdParameter);
        }
    
        /// <summary>
        /// finapp_CreateInvoiceLines operation
        /// </summary>
        public virtual ObjectResult<Nullable<int>> finapp_CreateInvoiceLines(Nullable<int> invoiceid)
        {
            var invoiceidParameter = invoiceid.HasValue ?
                new ObjectParameter("invoiceid", invoiceid) :
                new ObjectParameter("invoiceid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("finapp_CreateInvoiceLines", invoiceidParameter);
        }
    
        /// <summary>
        /// finapp_ReadChargeListByCustomerDefinitionId operation
        /// </summary>
        public virtual ObjectResult<finapp_ReadChargeListByCustomerDefinitionId_Result> finapp_ReadChargeListByCustomerDefinitionId(Nullable<int> customerdefinitionid)
        {
            var customerdefinitionidParameter = customerdefinitionid.HasValue ?
                new ObjectParameter("customerdefinitionid", customerdefinitionid) :
                new ObjectParameter("customerdefinitionid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<finapp_ReadChargeListByCustomerDefinitionId_Result>("finapp_ReadChargeListByCustomerDefinitionId", customerdefinitionidParameter);
        }
    
        /// <summary>
        /// finapp_ReadContainerMasterPrice operation
        /// </summary>
        public virtual ObjectResult<finapp_ReadContainerMasterPrice_Result> finapp_ReadContainerMasterPrice(Nullable<int> containerMasterId)
        {
            var containerMasterIdParameter = containerMasterId.HasValue ?
                new ObjectParameter("ContainerMasterId", containerMasterId) :
                new ObjectParameter("ContainerMasterId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<finapp_ReadContainerMasterPrice_Result>("finapp_ReadContainerMasterPrice", containerMasterIdParameter);
        }
    
        /// <summary>
        /// finapp_ReadCustomerIndexationByCategory operation
        /// </summary>
        public virtual ObjectResult<finapp_ReadCustomerIndexationByCategory_Result> finapp_ReadCustomerIndexationByCategory(Nullable<int> customerdefinitionid)
        {
            var customerdefinitionidParameter = customerdefinitionid.HasValue ?
                new ObjectParameter("customerdefinitionid", customerdefinitionid) :
                new ObjectParameter("customerdefinitionid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<finapp_ReadCustomerIndexationByCategory_Result>("finapp_ReadCustomerIndexationByCategory", customerdefinitionidParameter);
        }
    
        /// <summary>
        /// finapp_ReadCustomerIndexationByCategoryDetail operation
        /// </summary>
        public virtual ObjectResult<finapp_ReadCustomerIndexationByCategoryDetail_Result> finapp_ReadCustomerIndexationByCategoryDetail(Nullable<int> customerdefinitionid, Nullable<byte> indexationcategoryid)
        {
            var customerdefinitionidParameter = customerdefinitionid.HasValue ?
                new ObjectParameter("customerdefinitionid", customerdefinitionid) :
                new ObjectParameter("customerdefinitionid", typeof(int));
    
            var indexationcategoryidParameter = indexationcategoryid.HasValue ?
                new ObjectParameter("indexationcategoryid", indexationcategoryid) :
                new ObjectParameter("indexationcategoryid", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<finapp_ReadCustomerIndexationByCategoryDetail_Result>("finapp_ReadCustomerIndexationByCategoryDetail", customerdefinitionidParameter, indexationcategoryidParameter);
        }
    
        /// <summary>
        /// finapp_UpdateContainerMasterPrice operation
        /// </summary>
        public virtual ObjectResult<finapp_UpdateContainerMasterPrice_Result> finapp_UpdateContainerMasterPrice(Nullable<int> containermasterid, Nullable<int> pricecategorydefinitionid, Nullable<decimal> manualpricecategorycharge, Nullable<decimal> manualsingleuseitemcharge, Nullable<bool> priceCategoryOverride)
        {
            var containermasteridParameter = containermasterid.HasValue ?
                new ObjectParameter("containermasterid", containermasterid) :
                new ObjectParameter("containermasterid", typeof(int));
    
            var pricecategorydefinitionidParameter = pricecategorydefinitionid.HasValue ?
                new ObjectParameter("pricecategorydefinitionid", pricecategorydefinitionid) :
                new ObjectParameter("pricecategorydefinitionid", typeof(int));
    
            var manualpricecategorychargeParameter = manualpricecategorycharge.HasValue ?
                new ObjectParameter("manualpricecategorycharge", manualpricecategorycharge) :
                new ObjectParameter("manualpricecategorycharge", typeof(decimal));
    
            var manualsingleuseitemchargeParameter = manualsingleuseitemcharge.HasValue ?
                new ObjectParameter("manualsingleuseitemcharge", manualsingleuseitemcharge) :
                new ObjectParameter("manualsingleuseitemcharge", typeof(decimal));
    
            var priceCategoryOverrideParameter = priceCategoryOverride.HasValue ?
                new ObjectParameter("priceCategoryOverride", priceCategoryOverride) :
                new ObjectParameter("priceCategoryOverride", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<finapp_UpdateContainerMasterPrice_Result>("finapp_UpdateContainerMasterPrice", containermasteridParameter, pricecategorydefinitionidParameter, manualpricecategorychargeParameter, manualsingleuseitemchargeParameter, priceCategoryOverrideParameter);
        }
    
        /// <summary>
        /// Operative_GetBiTests_PriorityList operation
        /// </summary>
        public virtual ObjectResult<Operative_GetBiTests_PriorityList_Result> Operative_GetBiTests_PriorityList(Nullable<int> facilityID)
        {
            var facilityIDParameter = facilityID.HasValue ?
                new ObjectParameter("FacilityID", facilityID) :
                new ObjectParameter("FacilityID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Operative_GetBiTests_PriorityList_Result>("Operative_GetBiTests_PriorityList", facilityIDParameter);
        }
    
        /// <summary>
        /// opsapp_ReadAllUnpassedTurnaroundsByBatch operation
        /// </summary>
        public virtual ObjectResult<Turnaround> opsapp_ReadAllUnpassedTurnaroundsByBatch(Nullable<int> batchid)
        {
            var batchidParameter = batchid.HasValue ?
                new ObjectParameter("batchid", batchid) :
                new ObjectParameter("batchid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Turnaround>("opsapp_ReadAllUnpassedTurnaroundsByBatch", batchidParameter);
        }
    
        /// <summary>
        /// opsapp_ReadAllUnpassedTurnaroundsByBatch operation
        /// </summary>
        public virtual ObjectResult<Turnaround> opsapp_ReadAllUnpassedTurnaroundsByBatch(Nullable<int> batchid, MergeOption mergeOption)
        {
            var batchidParameter = batchid.HasValue ?
                new ObjectParameter("batchid", batchid) :
                new ObjectParameter("batchid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Turnaround>("opsapp_ReadAllUnpassedTurnaroundsByBatch", mergeOption, batchidParameter);
        }
    
        /// <summary>
        /// opsapp_ReadAwaitingEventsByStationType operation
        /// </summary>
        public virtual ObjectResult<opsapp_ReadAwaitingEventsByStationType_Result> opsapp_ReadAwaitingEventsByStationType(Nullable<int> stationTypeId, Nullable<int> stationId, Nullable<int> facilityId)
        {
            var stationTypeIdParameter = stationTypeId.HasValue ?
                new ObjectParameter("StationTypeId", stationTypeId) :
                new ObjectParameter("StationTypeId", typeof(int));
    
            var stationIdParameter = stationId.HasValue ?
                new ObjectParameter("StationId", stationId) :
                new ObjectParameter("StationId", typeof(int));
    
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<opsapp_ReadAwaitingEventsByStationType_Result>("opsapp_ReadAwaitingEventsByStationType", stationTypeIdParameter, stationIdParameter, facilityIdParameter);
        }
    
        /// <summary>
        /// TrolleyDispatch_GetSuggestedTurnarounds operation
        /// </summary>
        public virtual ObjectResult<TrolleyDispatch_GetSuggestedTurnarounds_Result> TrolleyDispatch_GetSuggestedTurnarounds(Nullable<int> facilityId, string nonSterileCurrentEventTypeIDS, string sterileCurrentEventTypeIDS, Nullable<int> customerID, Nullable<int> deliveryPointID)
        {
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(int));
    
            var nonSterileCurrentEventTypeIDSParameter = nonSterileCurrentEventTypeIDS != null ?
                new ObjectParameter("NonSterileCurrentEventTypeIDS", nonSterileCurrentEventTypeIDS) :
                new ObjectParameter("NonSterileCurrentEventTypeIDS", typeof(string));
    
            var sterileCurrentEventTypeIDSParameter = sterileCurrentEventTypeIDS != null ?
                new ObjectParameter("SterileCurrentEventTypeIDS", sterileCurrentEventTypeIDS) :
                new ObjectParameter("SterileCurrentEventTypeIDS", typeof(string));
    
            var customerIDParameter = customerID.HasValue ?
                new ObjectParameter("CustomerID", customerID) :
                new ObjectParameter("CustomerID", typeof(int));
    
            var deliveryPointIDParameter = deliveryPointID.HasValue ?
                new ObjectParameter("DeliveryPointID", deliveryPointID) :
                new ObjectParameter("DeliveryPointID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TrolleyDispatch_GetSuggestedTurnarounds_Result>("TrolleyDispatch_GetSuggestedTurnarounds", facilityIdParameter, nonSterileCurrentEventTypeIDSParameter, sterileCurrentEventTypeIDSParameter, customerIDParameter, deliveryPointIDParameter);
        }
    
        /// <summary>
        /// TrolleyDispatch_GetTrolleyContents operation
        /// </summary>
        public virtual ObjectResult<TrolleyDispatch_GetTrolleyContents_Result> TrolleyDispatch_GetTrolleyContents(Nullable<int> trolleyInstanceId)
        {
            var trolleyInstanceIdParameter = trolleyInstanceId.HasValue ?
                new ObjectParameter("TrolleyInstanceId", trolleyInstanceId) :
                new ObjectParameter("TrolleyInstanceId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TrolleyDispatch_GetTrolleyContents_Result>("TrolleyDispatch_GetTrolleyContents", trolleyInstanceIdParameter);
        }
    
        /// <summary>
        /// TrolleyDispatch_GetTrolleyHubSummary operation
        /// </summary>
        public virtual ObjectResult<TrolleyDispatch_GetTrolleyHubSummary_Result> TrolleyDispatch_GetTrolleyHubSummary(Nullable<int> facilityID)
        {
            var facilityIDParameter = facilityID.HasValue ?
                new ObjectParameter("FacilityID", facilityID) :
                new ObjectParameter("FacilityID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TrolleyDispatch_GetTrolleyHubSummary_Result>("TrolleyDispatch_GetTrolleyHubSummary", facilityIDParameter);
        }
    
        /// <summary>
        /// TrolleyDispatch_GetTrolleySummary operation
        /// </summary>
        public virtual ObjectResult<TrolleyDispatch_GetTrolleySummary_Result> TrolleyDispatch_GetTrolleySummary(string scannedString, Nullable<int> facilityID)
        {
            var scannedStringParameter = scannedString != null ?
                new ObjectParameter("ScannedString", scannedString) :
                new ObjectParameter("ScannedString", typeof(string));
    
            var facilityIDParameter = facilityID.HasValue ?
                new ObjectParameter("FacilityID", facilityID) :
                new ObjectParameter("FacilityID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TrolleyDispatch_GetTrolleySummary_Result>("TrolleyDispatch_GetTrolleySummary", scannedStringParameter, facilityIDParameter);
        }
    
        /// <summary>
        /// admapp_ReadAlerts operation
        /// </summary>
        public virtual ObjectResult<admapp_ReadAlerts_Result> admapp_ReadAlerts(Nullable<short> facilityId)
        {
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<admapp_ReadAlerts_Result>("admapp_ReadAlerts", facilityIdParameter);
        }
    
        /// <summary>
        /// admapp_ReadkeyStatistics operation
        /// </summary>
        public virtual ObjectResult<admapp_ReadkeyStatistics_Result> admapp_ReadkeyStatistics(Nullable<short> facilityId)
        {
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<admapp_ReadkeyStatistics_Result>("admapp_ReadkeyStatistics", facilityIdParameter);
        }
    
        /// <summary>
        /// admapp_ReadOmniSearchDeliveryPointDetail operation
        /// </summary>
        public virtual ObjectResult<admapp_ReadOmniSearchDeliveryPointDetail_Result> admapp_ReadOmniSearchDeliveryPointDetail(string searchText, Nullable<short> facilityId, Nullable<bool> canIncludeArchived)
        {
            var searchTextParameter = searchText != null ?
                new ObjectParameter("SearchText", searchText) :
                new ObjectParameter("SearchText", typeof(string));
    
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(short));
    
            var canIncludeArchivedParameter = canIncludeArchived.HasValue ?
                new ObjectParameter("CanIncludeArchived", canIncludeArchived) :
                new ObjectParameter("CanIncludeArchived", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<admapp_ReadOmniSearchDeliveryPointDetail_Result>("admapp_ReadOmniSearchDeliveryPointDetail", searchTextParameter, facilityIdParameter, canIncludeArchivedParameter);
        }
    
        /// <summary>
        /// admapp_ReadOmniSearchFacilityDetail operation
        /// </summary>
        public virtual ObjectResult<admapp_ReadOmniSearchFacilityDetail_Result> admapp_ReadOmniSearchFacilityDetail(string searchText, Nullable<bool> canIncludeArchived)
        {
            var searchTextParameter = searchText != null ?
                new ObjectParameter("SearchText", searchText) :
                new ObjectParameter("SearchText", typeof(string));
    
            var canIncludeArchivedParameter = canIncludeArchived.HasValue ?
                new ObjectParameter("CanIncludeArchived", canIncludeArchived) :
                new ObjectParameter("CanIncludeArchived", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<admapp_ReadOmniSearchFacilityDetail_Result>("admapp_ReadOmniSearchFacilityDetail", searchTextParameter, canIncludeArchivedParameter);
        }
    
        /// <summary>
        /// admapp_ReadOmniSearchItemDetail operation
        /// </summary>
        public virtual ObjectResult<admapp_ReadOmniSearchItemDetail_Result> admapp_ReadOmniSearchItemDetail(string searchText, Nullable<short> facilityId, Nullable<bool> canIncludeArchived)
        {
            var searchTextParameter = searchText != null ?
                new ObjectParameter("SearchText", searchText) :
                new ObjectParameter("SearchText", typeof(string));
    
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(short));
    
            var canIncludeArchivedParameter = canIncludeArchived.HasValue ?
                new ObjectParameter("CanIncludeArchived", canIncludeArchived) :
                new ObjectParameter("CanIncludeArchived", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<admapp_ReadOmniSearchItemDetail_Result>("admapp_ReadOmniSearchItemDetail", searchTextParameter, facilityIdParameter, canIncludeArchivedParameter);
        }
    
        /// <summary>
        /// admapp_ReadOmniSearchMasterDetail operation
        /// </summary>
        public virtual ObjectResult<admapp_ReadOmniSearchMasterDetail_Result> admapp_ReadOmniSearchMasterDetail(string searchText, Nullable<short> facilityId, Nullable<bool> canIncludeArchived)
        {
            var searchTextParameter = searchText != null ?
                new ObjectParameter("SearchText", searchText) :
                new ObjectParameter("SearchText", typeof(string));
    
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(short));
    
            var canIncludeArchivedParameter = canIncludeArchived.HasValue ?
                new ObjectParameter("CanIncludeArchived", canIncludeArchived) :
                new ObjectParameter("CanIncludeArchived", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<admapp_ReadOmniSearchMasterDetail_Result>("admapp_ReadOmniSearchMasterDetail", searchTextParameter, facilityIdParameter, canIncludeArchivedParameter);
        }
    
        /// <summary>
        /// admapp_ReadOmniSearchUserDetail operation
        /// </summary>
        public virtual ObjectResult<admapp_ReadOmniSearchUserDetail_Result> admapp_ReadOmniSearchUserDetail(string searchText, Nullable<short> facilityId, Nullable<bool> canIncludeArchived)
        {
            var searchTextParameter = searchText != null ?
                new ObjectParameter("SearchText", searchText) :
                new ObjectParameter("SearchText", typeof(string));
    
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(short));
    
            var canIncludeArchivedParameter = canIncludeArchived.HasValue ?
                new ObjectParameter("CanIncludeArchived", canIncludeArchived) :
                new ObjectParameter("CanIncludeArchived", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<admapp_ReadOmniSearchUserDetail_Result>("admapp_ReadOmniSearchUserDetail", searchTextParameter, facilityIdParameter, canIncludeArchivedParameter);
        }
    
        /// <summary>
        /// admapp_ReadPagedItemMasters operation
        /// </summary>
        public virtual ObjectResult<admapp_ReadPagedItemMasters_Result> admapp_ReadPagedItemMasters(Nullable<int> facilityId, string searchText, Nullable<short> itemTypeId, string externalId, string text, string baseItemTypeNameText, string childItemTypeNameText, Nullable<bool> isAscending, string sortColumn, Nullable<int> pageSize, Nullable<int> pageIndex)
        {
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(int));
    
            var searchTextParameter = searchText != null ?
                new ObjectParameter("SearchText", searchText) :
                new ObjectParameter("SearchText", typeof(string));
    
            var itemTypeIdParameter = itemTypeId.HasValue ?
                new ObjectParameter("ItemTypeId", itemTypeId) :
                new ObjectParameter("ItemTypeId", typeof(short));
    
            var externalIdParameter = externalId != null ?
                new ObjectParameter("ExternalId", externalId) :
                new ObjectParameter("ExternalId", typeof(string));
    
            var textParameter = text != null ?
                new ObjectParameter("Text", text) :
                new ObjectParameter("Text", typeof(string));
    
            var baseItemTypeNameTextParameter = baseItemTypeNameText != null ?
                new ObjectParameter("BaseItemTypeNameText", baseItemTypeNameText) :
                new ObjectParameter("BaseItemTypeNameText", typeof(string));
    
            var childItemTypeNameTextParameter = childItemTypeNameText != null ?
                new ObjectParameter("ChildItemTypeNameText", childItemTypeNameText) :
                new ObjectParameter("ChildItemTypeNameText", typeof(string));
    
            var isAscendingParameter = isAscending.HasValue ?
                new ObjectParameter("IsAscending", isAscending) :
                new ObjectParameter("IsAscending", typeof(bool));
    
            var sortColumnParameter = sortColumn != null ?
                new ObjectParameter("SortColumn", sortColumn) :
                new ObjectParameter("SortColumn", typeof(string));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            var pageIndexParameter = pageIndex.HasValue ?
                new ObjectParameter("PageIndex", pageIndex) :
                new ObjectParameter("PageIndex", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<admapp_ReadPagedItemMasters_Result>("admapp_ReadPagedItemMasters", facilityIdParameter, searchTextParameter, itemTypeIdParameter, externalIdParameter, textParameter, baseItemTypeNameTextParameter, childItemTypeNameTextParameter, isAscendingParameter, sortColumnParameter, pageSizeParameter, pageIndexParameter);
        }
    
        /// <summary>
        /// admapp_ReadProductionOverview operation
        /// </summary>
        public virtual ObjectResult<admapp_ReadProductionOverview_Result> admapp_ReadProductionOverview(Nullable<short> facilityId, Nullable<int> customerDefinitionId, Nullable<short> archivedEventTypeId, Nullable<short> alternativeFacilityId)
        {
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(short));
    
            var customerDefinitionIdParameter = customerDefinitionId.HasValue ?
                new ObjectParameter("CustomerDefinitionId", customerDefinitionId) :
                new ObjectParameter("CustomerDefinitionId", typeof(int));
    
            var archivedEventTypeIdParameter = archivedEventTypeId.HasValue ?
                new ObjectParameter("ArchivedEventTypeId", archivedEventTypeId) :
                new ObjectParameter("ArchivedEventTypeId", typeof(short));
    
            var alternativeFacilityIdParameter = alternativeFacilityId.HasValue ?
                new ObjectParameter("AlternativeFacilityId", alternativeFacilityId) :
                new ObjectParameter("AlternativeFacilityId", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<admapp_ReadProductionOverview_Result>("admapp_ReadProductionOverview", facilityIdParameter, customerDefinitionIdParameter, archivedEventTypeIdParameter, alternativeFacilityIdParameter);
        }
    
        /// <summary>
        /// admapp_ReadProductionOverviewByServiceRequirement operation
        /// </summary>
        public virtual ObjectResult<admapp_ReadProductionOverviewByServiceRequirement_Result> admapp_ReadProductionOverviewByServiceRequirement(Nullable<int> facilityId, Nullable<int> customerDefinitionId)
        {
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(int));
    
            var customerDefinitionIdParameter = customerDefinitionId.HasValue ?
                new ObjectParameter("CustomerDefinitionId", customerDefinitionId) :
                new ObjectParameter("CustomerDefinitionId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<admapp_ReadProductionOverviewByServiceRequirement_Result>("admapp_ReadProductionOverviewByServiceRequirement", facilityIdParameter, customerDefinitionIdParameter);
        }
    
        /// <summary>
        /// GetStationeryVersion operation
        /// </summary>
        public virtual ObjectResult<GetStationeryVersion_Result> GetStationeryVersion(string reportType, Nullable<int> customerDefinitionId, Nullable<int> facilityId, Nullable<int> tenancyId)
        {
            var reportTypeParameter = reportType != null ?
                new ObjectParameter("ReportType", reportType) :
                new ObjectParameter("ReportType", typeof(string));
    
            var customerDefinitionIdParameter = customerDefinitionId.HasValue ?
                new ObjectParameter("CustomerDefinitionId", customerDefinitionId) :
                new ObjectParameter("CustomerDefinitionId", typeof(int));
    
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(int));
    
            var tenancyIdParameter = tenancyId.HasValue ?
                new ObjectParameter("TenancyId", tenancyId) :
                new ObjectParameter("TenancyId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStationeryVersion_Result>("GetStationeryVersion", reportTypeParameter, customerDefinitionIdParameter, facilityIdParameter, tenancyIdParameter);
        }
    
        public virtual ObjectResult<Nullable<System.DateTime>> opsapp_ReadExpiryCalculation(Nullable<int> facilityId, Nullable<int> serviceRequirementId, Nullable<int> deliveryPointId)
        {
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(int));
    
            var serviceRequirementIdParameter = serviceRequirementId.HasValue ?
                new ObjectParameter("ServiceRequirementId", serviceRequirementId) :
                new ObjectParameter("ServiceRequirementId", typeof(int));
    
            var deliveryPointIdParameter = deliveryPointId.HasValue ?
                new ObjectParameter("DeliveryPointId", deliveryPointId) :
                new ObjectParameter("DeliveryPointId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<System.DateTime>>("opsapp_ReadExpiryCalculation", facilityIdParameter, serviceRequirementIdParameter, deliveryPointIdParameter);
        }
    
        public virtual ObjectResult<Nullable<System.DateTime>> opsapp_ReadExpiryCalculationWithTurnaround(Nullable<int> turnaroundId, Nullable<int> serviceRequirementId)
        {
            var turnaroundIdParameter = turnaroundId.HasValue ?
                new ObjectParameter("TurnaroundId", turnaroundId) :
                new ObjectParameter("TurnaroundId", typeof(int));
    
            var serviceRequirementIdParameter = serviceRequirementId.HasValue ?
                new ObjectParameter("ServiceRequirementId", serviceRequirementId) :
                new ObjectParameter("ServiceRequirementId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<System.DateTime>>("opsapp_ReadExpiryCalculationWithTurnaround", turnaroundIdParameter, serviceRequirementIdParameter);
        }
    
        public virtual ObjectResult<Nullable<System.DateTime>> opsapp_ReadExpiryReCalculationWithTurnaround(Nullable<int> turnaroundId, Nullable<int> oldServiceRequirementId, Nullable<int> newServiceRequirementId, Nullable<System.DateTime> oldExpiry)
        {
            var turnaroundIdParameter = turnaroundId.HasValue ?
                new ObjectParameter("TurnaroundId", turnaroundId) :
                new ObjectParameter("TurnaroundId", typeof(int));
    
            var oldServiceRequirementIdParameter = oldServiceRequirementId.HasValue ?
                new ObjectParameter("OldServiceRequirementId", oldServiceRequirementId) :
                new ObjectParameter("OldServiceRequirementId", typeof(int));
    
            var newServiceRequirementIdParameter = newServiceRequirementId.HasValue ?
                new ObjectParameter("NewServiceRequirementId", newServiceRequirementId) :
                new ObjectParameter("NewServiceRequirementId", typeof(int));
    
            var oldExpiryParameter = oldExpiry.HasValue ?
                new ObjectParameter("OldExpiry", oldExpiry) :
                new ObjectParameter("OldExpiry", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<System.DateTime>>("opsapp_ReadExpiryReCalculationWithTurnaround", turnaroundIdParameter, oldServiceRequirementIdParameter, newServiceRequirementIdParameter, oldExpiryParameter);
        }
    
        /// <summary>
        /// ReadItemInstancesByFacility operation
        /// </summary>
        public virtual ObjectResult<ReadItemInstancesByFacility_Result> ReadItemInstancesByFacility(Nullable<short> facilityId, Nullable<int> itemMasterDefinitionId, string instanceId, string itemName, string processEvent, string turnaroundExternalId, string containerPrimaryId, string trayName, string status, string sortField, Nullable<bool> isAscending, Nullable<int> pageSize, Nullable<int> pageIndex)
        {
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(short));
    
            var itemMasterDefinitionIdParameter = itemMasterDefinitionId.HasValue ?
                new ObjectParameter("ItemMasterDefinitionId", itemMasterDefinitionId) :
                new ObjectParameter("ItemMasterDefinitionId", typeof(int));
    
            var instanceIdParameter = instanceId != null ?
                new ObjectParameter("InstanceId", instanceId) :
                new ObjectParameter("InstanceId", typeof(string));
    
            var itemNameParameter = itemName != null ?
                new ObjectParameter("ItemName", itemName) :
                new ObjectParameter("ItemName", typeof(string));
    
            var processEventParameter = processEvent != null ?
                new ObjectParameter("ProcessEvent", processEvent) :
                new ObjectParameter("ProcessEvent", typeof(string));
    
            var turnaroundExternalIdParameter = turnaroundExternalId != null ?
                new ObjectParameter("TurnaroundExternalId", turnaroundExternalId) :
                new ObjectParameter("TurnaroundExternalId", typeof(string));
    
            var containerPrimaryIdParameter = containerPrimaryId != null ?
                new ObjectParameter("ContainerPrimaryId", containerPrimaryId) :
                new ObjectParameter("ContainerPrimaryId", typeof(string));
    
            var trayNameParameter = trayName != null ?
                new ObjectParameter("TrayName", trayName) :
                new ObjectParameter("TrayName", typeof(string));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            var sortFieldParameter = sortField != null ?
                new ObjectParameter("SortField", sortField) :
                new ObjectParameter("SortField", typeof(string));
    
            var isAscendingParameter = isAscending.HasValue ?
                new ObjectParameter("IsAscending", isAscending) :
                new ObjectParameter("IsAscending", typeof(bool));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            var pageIndexParameter = pageIndex.HasValue ?
                new ObjectParameter("PageIndex", pageIndex) :
                new ObjectParameter("PageIndex", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReadItemInstancesByFacility_Result>("ReadItemInstancesByFacility", facilityIdParameter, itemMasterDefinitionIdParameter, instanceIdParameter, itemNameParameter, processEventParameter, turnaroundExternalIdParameter, containerPrimaryIdParameter, trayNameParameter, statusParameter, sortFieldParameter, isAscendingParameter, pageSizeParameter, pageIndexParameter);
        }
    
        /// <summary>
        /// admapp_ReadOmniSearchSummary operation
        /// </summary>
        public virtual ObjectResult<admapp_ReadOmniSearchSummary_Result> admapp_ReadOmniSearchSummary(string searchText, Nullable<short> facilityId, Nullable<bool> canIncludeArchived)
        {
            var searchTextParameter = searchText != null ?
                new ObjectParameter("SearchText", searchText) :
                new ObjectParameter("SearchText", typeof(string));
    
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(short));
    
            var canIncludeArchivedParameter = canIncludeArchived.HasValue ?
                new ObjectParameter("CanIncludeArchived", canIncludeArchived) :
                new ObjectParameter("CanIncludeArchived", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<admapp_ReadOmniSearchSummary_Result>("admapp_ReadOmniSearchSummary", searchTextParameter, facilityIdParameter, canIncludeArchivedParameter);
        }
    
        /// <summary>
        /// admapp_ReadPagedItemMastersByFacility_Translated operation
        /// </summary>
        public virtual int admapp_ReadPagedItemMastersByFacility_Translated(Nullable<short> itemTypeId, Nullable<short> facilityId, string externalId, string baseType, string subType, string text, string customerName, Nullable<bool> isAscending, string sortField, Nullable<int> pageSize, Nullable<int> pageIndex)
        {
            var itemTypeIdParameter = itemTypeId.HasValue ?
                new ObjectParameter("ItemTypeId", itemTypeId) :
                new ObjectParameter("ItemTypeId", typeof(short));
    
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(short));
    
            var externalIdParameter = externalId != null ?
                new ObjectParameter("ExternalId", externalId) :
                new ObjectParameter("ExternalId", typeof(string));
    
            var baseTypeParameter = baseType != null ?
                new ObjectParameter("BaseType", baseType) :
                new ObjectParameter("BaseType", typeof(string));
    
            var subTypeParameter = subType != null ?
                new ObjectParameter("SubType", subType) :
                new ObjectParameter("SubType", typeof(string));
    
            var textParameter = text != null ?
                new ObjectParameter("Text", text) :
                new ObjectParameter("Text", typeof(string));
    
            var customerNameParameter = customerName != null ?
                new ObjectParameter("CustomerName", customerName) :
                new ObjectParameter("CustomerName", typeof(string));
    
            var isAscendingParameter = isAscending.HasValue ?
                new ObjectParameter("IsAscending", isAscending) :
                new ObjectParameter("IsAscending", typeof(bool));
    
            var sortFieldParameter = sortField != null ?
                new ObjectParameter("SortField", sortField) :
                new ObjectParameter("SortField", typeof(string));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            var pageIndexParameter = pageIndex.HasValue ?
                new ObjectParameter("PageIndex", pageIndex) :
                new ObjectParameter("PageIndex", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("admapp_ReadPagedItemMastersByFacility_Translated", itemTypeIdParameter, facilityIdParameter, externalIdParameter, baseTypeParameter, subTypeParameter, textParameter, customerNameParameter, isAscendingParameter, sortFieldParameter, pageSizeParameter, pageIndexParameter);
        }
    
        /// <summary>
        /// admapp_CreateDeliveryPointLocation operation
        /// </summary>
        public virtual ObjectResult<Nullable<int>> admapp_CreateDeliveryPointLocation(Nullable<bool> isArchived, Nullable<bool> isStockLocation, Nullable<int> customerDefinitionId, string text, ObjectParameter locationId)
        {
            var isArchivedParameter = isArchived.HasValue ?
                new ObjectParameter("IsArchived", isArchived) :
                new ObjectParameter("IsArchived", typeof(bool));
    
            var isStockLocationParameter = isStockLocation.HasValue ?
                new ObjectParameter("IsStockLocation", isStockLocation) :
                new ObjectParameter("IsStockLocation", typeof(bool));
    
            var customerDefinitionIdParameter = customerDefinitionId.HasValue ?
                new ObjectParameter("CustomerDefinitionId", customerDefinitionId) :
                new ObjectParameter("CustomerDefinitionId", typeof(int));
    
            var textParameter = text != null ?
                new ObjectParameter("Text", text) :
                new ObjectParameter("Text", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("admapp_CreateDeliveryPointLocation", isArchivedParameter, isStockLocationParameter, customerDefinitionIdParameter, textParameter, locationId);
        }
    
        /// <summary>
        /// admapp_UpdateDeliveryPointLocation operation
        /// </summary>
        public virtual ObjectResult<Nullable<int>> admapp_UpdateDeliveryPointLocation(Nullable<int> deliveryPointId, Nullable<bool> isStockLocation, string text, Nullable<int> modifyingUserId, ObjectParameter newLocationId)
        {
            var deliveryPointIdParameter = deliveryPointId.HasValue ?
                new ObjectParameter("DeliveryPointId", deliveryPointId) :
                new ObjectParameter("DeliveryPointId", typeof(int));
    
            var isStockLocationParameter = isStockLocation.HasValue ?
                new ObjectParameter("IsStockLocation", isStockLocation) :
                new ObjectParameter("IsStockLocation", typeof(bool));
    
            var textParameter = text != null ?
                new ObjectParameter("Text", text) :
                new ObjectParameter("Text", typeof(string));
    
            var modifyingUserIdParameter = modifyingUserId.HasValue ?
                new ObjectParameter("ModifyingUserId", modifyingUserId) :
                new ObjectParameter("ModifyingUserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("admapp_UpdateDeliveryPointLocation", deliveryPointIdParameter, isStockLocationParameter, textParameter, modifyingUserIdParameter, newLocationId);
        }
    
        /// <summary>
        /// FavouriteReports_InvalidateFavouriteReportsForId operation
        /// </summary>
        public virtual int FavouriteReports_InvalidateFavouriteReportsForId(Nullable<int> userID, Nullable<int> idType, string value)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            var idTypeParameter = idType.HasValue ?
                new ObjectParameter("IdType", idType) :
                new ObjectParameter("IdType", typeof(int));
    
            var valueParameter = value != null ?
                new ObjectParameter("Value", value) :
                new ObjectParameter("Value", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("FavouriteReports_InvalidateFavouriteReportsForId", userIDParameter, idTypeParameter, valueParameter);
        }
    
        /// <summary>
        /// GetNotificationRuleOutcome operation
        /// </summary>
        public virtual ObjectResult<GetNotificationRuleOutcome_Result> GetNotificationRuleOutcome(Nullable<int> turnaroundEventId)
        {
            var turnaroundEventIdParameter = turnaroundEventId.HasValue ?
                new ObjectParameter("TurnaroundEventId", turnaroundEventId) :
                new ObjectParameter("TurnaroundEventId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetNotificationRuleOutcome_Result>("GetNotificationRuleOutcome", turnaroundEventIdParameter);
        }
    
        /// <summary>
        /// opsapp_GetEndoscopeOverview operation
        /// </summary>
        public virtual ObjectResult<opsapp_GetEndoscopeOverview_Result> opsapp_GetEndoscopeOverview(Nullable<short> facilityId, string maxDryingTimeSettingName, Nullable<int> defaultMaxDryingTimeMins)
        {
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(short));
    
            var maxDryingTimeSettingNameParameter = maxDryingTimeSettingName != null ?
                new ObjectParameter("MaxDryingTimeSettingName", maxDryingTimeSettingName) :
                new ObjectParameter("MaxDryingTimeSettingName", typeof(string));
    
            var defaultMaxDryingTimeMinsParameter = defaultMaxDryingTimeMins.HasValue ?
                new ObjectParameter("DefaultMaxDryingTimeMins", defaultMaxDryingTimeMins) :
                new ObjectParameter("DefaultMaxDryingTimeMins", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<opsapp_GetEndoscopeOverview_Result>("opsapp_GetEndoscopeOverview", facilityIdParameter, maxDryingTimeSettingNameParameter, defaultMaxDryingTimeMinsParameter);
        }
    
        /// <summary>
        /// opsapp_GetEndscopeLocationData operation
        /// </summary>
        public virtual ObjectResult<opsapp_GetEndscopeLocationData_Result> opsapp_GetEndscopeLocationData(Nullable<int> facilityId)
        {
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<opsapp_GetEndscopeLocationData_Result>("opsapp_GetEndscopeLocationData", facilityIdParameter);
        }
    
        /// <summary>
        /// admapp_ReadTurnaroundsByFacilityAndCustomer operation
        /// </summary>
        public virtual ObjectResult<admapp_ReadTurnaroundsByFacilityAndCustomer_Result> admapp_ReadTurnaroundsByFacilityAndCustomer(Nullable<short> facilityId, string customerDefinitionId, Nullable<int> lastProcessEventTypeId, Nullable<int> baseItemTypeId, Nullable<int> serviceRequirementDefinitionId, Nullable<bool> overDue, Nullable<bool> isAscending, string sortField, Nullable<int> pageSize, Nullable<int> pageIndex, string turnaroundExternalId, string containerMasterBaseItemType, string containerMasterItemType, string containerInstancePrimaryId, string containerMasterName, string lastEventName, string lastEventTime, string expiry, string serviceRequirementName, string customerName, string deliveryPointName, string quarantineReasonText, Nullable<bool> isIdentifiable, Nullable<int> userId, string userTimeZone, string facilityName, Nullable<short> alternateFacilityId, Nullable<bool> isProductionOverView, Nullable<bool> useEventContext, Nullable<bool> includeAlternateFacilityItems)
        {
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(short));
    
            var customerDefinitionIdParameter = customerDefinitionId != null ?
                new ObjectParameter("CustomerDefinitionId", customerDefinitionId) :
                new ObjectParameter("CustomerDefinitionId", typeof(string));
    
            var lastProcessEventTypeIdParameter = lastProcessEventTypeId.HasValue ?
                new ObjectParameter("LastProcessEventTypeId", lastProcessEventTypeId) :
                new ObjectParameter("LastProcessEventTypeId", typeof(int));
    
            var baseItemTypeIdParameter = baseItemTypeId.HasValue ?
                new ObjectParameter("BaseItemTypeId", baseItemTypeId) :
                new ObjectParameter("BaseItemTypeId", typeof(int));
    
            var serviceRequirementDefinitionIdParameter = serviceRequirementDefinitionId.HasValue ?
                new ObjectParameter("ServiceRequirementDefinitionId", serviceRequirementDefinitionId) :
                new ObjectParameter("ServiceRequirementDefinitionId", typeof(int));
    
            var overDueParameter = overDue.HasValue ?
                new ObjectParameter("OverDue", overDue) :
                new ObjectParameter("OverDue", typeof(bool));
    
            var isAscendingParameter = isAscending.HasValue ?
                new ObjectParameter("IsAscending", isAscending) :
                new ObjectParameter("IsAscending", typeof(bool));
    
            var sortFieldParameter = sortField != null ?
                new ObjectParameter("SortField", sortField) :
                new ObjectParameter("SortField", typeof(string));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            var pageIndexParameter = pageIndex.HasValue ?
                new ObjectParameter("PageIndex", pageIndex) :
                new ObjectParameter("PageIndex", typeof(int));
    
            var turnaroundExternalIdParameter = turnaroundExternalId != null ?
                new ObjectParameter("TurnaroundExternalId", turnaroundExternalId) :
                new ObjectParameter("TurnaroundExternalId", typeof(string));
    
            var containerMasterBaseItemTypeParameter = containerMasterBaseItemType != null ?
                new ObjectParameter("ContainerMasterBaseItemType", containerMasterBaseItemType) :
                new ObjectParameter("ContainerMasterBaseItemType", typeof(string));
    
            var containerMasterItemTypeParameter = containerMasterItemType != null ?
                new ObjectParameter("ContainerMasterItemType", containerMasterItemType) :
                new ObjectParameter("ContainerMasterItemType", typeof(string));
    
            var containerInstancePrimaryIdParameter = containerInstancePrimaryId != null ?
                new ObjectParameter("ContainerInstancePrimaryId", containerInstancePrimaryId) :
                new ObjectParameter("ContainerInstancePrimaryId", typeof(string));
    
            var containerMasterNameParameter = containerMasterName != null ?
                new ObjectParameter("ContainerMasterName", containerMasterName) :
                new ObjectParameter("ContainerMasterName", typeof(string));
    
            var lastEventNameParameter = lastEventName != null ?
                new ObjectParameter("LastEventName", lastEventName) :
                new ObjectParameter("LastEventName", typeof(string));
    
            var lastEventTimeParameter = lastEventTime != null ?
                new ObjectParameter("LastEventTime", lastEventTime) :
                new ObjectParameter("LastEventTime", typeof(string));
    
            var expiryParameter = expiry != null ?
                new ObjectParameter("Expiry", expiry) :
                new ObjectParameter("Expiry", typeof(string));
    
            var serviceRequirementNameParameter = serviceRequirementName != null ?
                new ObjectParameter("ServiceRequirementName", serviceRequirementName) :
                new ObjectParameter("ServiceRequirementName", typeof(string));
    
            var customerNameParameter = customerName != null ?
                new ObjectParameter("CustomerName", customerName) :
                new ObjectParameter("CustomerName", typeof(string));
    
            var deliveryPointNameParameter = deliveryPointName != null ?
                new ObjectParameter("DeliveryPointName", deliveryPointName) :
                new ObjectParameter("DeliveryPointName", typeof(string));
    
            var quarantineReasonTextParameter = quarantineReasonText != null ?
                new ObjectParameter("QuarantineReasonText", quarantineReasonText) :
                new ObjectParameter("QuarantineReasonText", typeof(string));
    
            var isIdentifiableParameter = isIdentifiable.HasValue ?
                new ObjectParameter("IsIdentifiable", isIdentifiable) :
                new ObjectParameter("IsIdentifiable", typeof(bool));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var userTimeZoneParameter = userTimeZone != null ?
                new ObjectParameter("UserTimeZone", userTimeZone) :
                new ObjectParameter("UserTimeZone", typeof(string));
    
            var facilityNameParameter = facilityName != null ?
                new ObjectParameter("FacilityName", facilityName) :
                new ObjectParameter("FacilityName", typeof(string));
    
            var alternateFacilityIdParameter = alternateFacilityId.HasValue ?
                new ObjectParameter("AlternateFacilityId", alternateFacilityId) :
                new ObjectParameter("AlternateFacilityId", typeof(short));
    
            var isProductionOverViewParameter = isProductionOverView.HasValue ?
                new ObjectParameter("IsProductionOverView", isProductionOverView) :
                new ObjectParameter("IsProductionOverView", typeof(bool));
    
            var useEventContextParameter = useEventContext.HasValue ?
                new ObjectParameter("UseEventContext", useEventContext) :
                new ObjectParameter("UseEventContext", typeof(bool));
    
            var includeAlternateFacilityItemsParameter = includeAlternateFacilityItems.HasValue ?
                new ObjectParameter("IncludeAlternateFacilityItems", includeAlternateFacilityItems) :
                new ObjectParameter("IncludeAlternateFacilityItems", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<admapp_ReadTurnaroundsByFacilityAndCustomer_Result>("admapp_ReadTurnaroundsByFacilityAndCustomer", facilityIdParameter, customerDefinitionIdParameter, lastProcessEventTypeIdParameter, baseItemTypeIdParameter, serviceRequirementDefinitionIdParameter, overDueParameter, isAscendingParameter, sortFieldParameter, pageSizeParameter, pageIndexParameter, turnaroundExternalIdParameter, containerMasterBaseItemTypeParameter, containerMasterItemTypeParameter, containerInstancePrimaryIdParameter, containerMasterNameParameter, lastEventNameParameter, lastEventTimeParameter, expiryParameter, serviceRequirementNameParameter, customerNameParameter, deliveryPointNameParameter, quarantineReasonTextParameter, isIdentifiableParameter, userIdParameter, userTimeZoneParameter, facilityNameParameter, alternateFacilityIdParameter, isProductionOverViewParameter, useEventContextParameter, includeAlternateFacilityItemsParameter);
        }
    
        /// <summary>
        /// GetAllProductionManagerFilterForUserAndFacility operation
        /// </summary>
        public virtual ObjectResult<GetAllProductionManagerFilterForUserAndFacility_Result> GetAllProductionManagerFilterForUserAndFacility(Nullable<int> userId, Nullable<int> facilityId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllProductionManagerFilterForUserAndFacility_Result>("GetAllProductionManagerFilterForUserAndFacility", userIdParameter, facilityIdParameter);
        }
    
        /// <summary>
        /// GetAllProductionManagerFilterForUserAndFacilityDetails operation
        /// </summary>
        public virtual ObjectResult<GetAllProductionManagerFilterForUserAndFacilityDetails_Result> GetAllProductionManagerFilterForUserAndFacilityDetails(Nullable<int> userId, Nullable<int> facilityId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllProductionManagerFilterForUserAndFacilityDetails_Result>("GetAllProductionManagerFilterForUserAndFacilityDetails", userIdParameter, facilityIdParameter);
        }
    
        /// <summary>
        /// GetStockLevelsByContainerMasterDefinition operation
        /// </summary>
        public virtual ObjectResult<GetStockLevelsByContainerMasterDefinition_Result> GetStockLevelsByContainerMasterDefinition(Nullable<int> userId, Nullable<int> deliveryPointId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var deliveryPointIdParameter = deliveryPointId.HasValue ?
                new ObjectParameter("DeliveryPointId", deliveryPointId) :
                new ObjectParameter("DeliveryPointId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStockLevelsByContainerMasterDefinition_Result>("GetStockLevelsByContainerMasterDefinition", userIdParameter, deliveryPointIdParameter);
        }
    
        /// <summary>
        /// opsapp_GetAerData operation
        /// </summary>
        public virtual ObjectResult<opsapp_GetAerData_Result> opsapp_GetAerData(Nullable<System.DateTime> utcNow, Nullable<int> stationId, Nullable<int> machineId)
        {
            var utcNowParameter = utcNow.HasValue ?
                new ObjectParameter("UtcNow", utcNow) :
                new ObjectParameter("UtcNow", typeof(System.DateTime));
    
            var stationIdParameter = stationId.HasValue ?
                new ObjectParameter("StationId", stationId) :
                new ObjectParameter("StationId", typeof(int));
    
            var machineIdParameter = machineId.HasValue ?
                new ObjectParameter("MachineId", machineId) :
                new ObjectParameter("MachineId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<opsapp_GetAerData_Result>("opsapp_GetAerData", utcNowParameter, stationIdParameter, machineIdParameter);
        }
    
        /// <summary>
        /// SIT_CreateAudit operation
        /// </summary>
        public virtual ObjectResult<SIT_CreateAudit_Result> SIT_CreateAudit(Nullable<int> turnaroundEventId)
        {
            var turnaroundEventIdParameter = turnaroundEventId.HasValue ?
                new ObjectParameter("TurnaroundEventId", turnaroundEventId) :
                new ObjectParameter("TurnaroundEventId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SIT_CreateAudit_Result>("SIT_CreateAudit", turnaroundEventIdParameter);
        }
    
        /// <summary>
        /// SIT_HasValidAudit operation
        /// </summary>
        public virtual ObjectResult<Nullable<bool>> SIT_HasValidAudit(Nullable<int> turnaroundId, Nullable<int> facilityId)
        {
            var turnaroundIdParameter = turnaroundId.HasValue ?
                new ObjectParameter("TurnaroundId", turnaroundId) :
                new ObjectParameter("TurnaroundId", typeof(int));
    
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<bool>>("SIT_HasValidAudit", turnaroundIdParameter, facilityIdParameter);
        }
    
        /// <summary>
        /// admapp_ReadTurnaroundsForGraphByFacilityAndCustomer operation
        /// </summary>
        public virtual ObjectResult<admapp_ReadTurnaroundsForGraphByFacilityAndCustomer_Result> admapp_ReadTurnaroundsForGraphByFacilityAndCustomer(Nullable<short> facilityId, string customerDefinitionId, Nullable<int> lastProcessEventTypeId, Nullable<int> baseItemTypeId, Nullable<int> serviceRequirementDefinitionId, Nullable<bool> overDue, string turnaroundExternalId, string containerInstancePrimaryId, string containerMasterName, string lastEventName, string lastEventTime, string expiry, string serviceRequirementName, string customerName, string quarantineReasonText, Nullable<short> alternateFacilityId, string facilityName, Nullable<int> userId, string userTimeZone, Nullable<bool> isProductionOverView, Nullable<bool> isIdentifiable, Nullable<bool> includeAlternateFacilityItems)
        {
            var facilityIdParameter = facilityId.HasValue ?
                new ObjectParameter("FacilityId", facilityId) :
                new ObjectParameter("FacilityId", typeof(short));
    
            var customerDefinitionIdParameter = customerDefinitionId != null ?
                new ObjectParameter("CustomerDefinitionId", customerDefinitionId) :
                new ObjectParameter("CustomerDefinitionId", typeof(string));
    
            var lastProcessEventTypeIdParameter = lastProcessEventTypeId.HasValue ?
                new ObjectParameter("LastProcessEventTypeId", lastProcessEventTypeId) :
                new ObjectParameter("LastProcessEventTypeId", typeof(int));
    
            var baseItemTypeIdParameter = baseItemTypeId.HasValue ?
                new ObjectParameter("BaseItemTypeId", baseItemTypeId) :
                new ObjectParameter("BaseItemTypeId", typeof(int));
    
            var serviceRequirementDefinitionIdParameter = serviceRequirementDefinitionId.HasValue ?
                new ObjectParameter("ServiceRequirementDefinitionId", serviceRequirementDefinitionId) :
                new ObjectParameter("ServiceRequirementDefinitionId", typeof(int));
    
            var overDueParameter = overDue.HasValue ?
                new ObjectParameter("OverDue", overDue) :
                new ObjectParameter("OverDue", typeof(bool));
    
            var turnaroundExternalIdParameter = turnaroundExternalId != null ?
                new ObjectParameter("TurnaroundExternalId", turnaroundExternalId) :
                new ObjectParameter("TurnaroundExternalId", typeof(string));
    
            var containerInstancePrimaryIdParameter = containerInstancePrimaryId != null ?
                new ObjectParameter("ContainerInstancePrimaryId", containerInstancePrimaryId) :
                new ObjectParameter("ContainerInstancePrimaryId", typeof(string));
    
            var containerMasterNameParameter = containerMasterName != null ?
                new ObjectParameter("ContainerMasterName", containerMasterName) :
                new ObjectParameter("ContainerMasterName", typeof(string));
    
            var lastEventNameParameter = lastEventName != null ?
                new ObjectParameter("LastEventName", lastEventName) :
                new ObjectParameter("LastEventName", typeof(string));
    
            var lastEventTimeParameter = lastEventTime != null ?
                new ObjectParameter("LastEventTime", lastEventTime) :
                new ObjectParameter("LastEventTime", typeof(string));
    
            var expiryParameter = expiry != null ?
                new ObjectParameter("Expiry", expiry) :
                new ObjectParameter("Expiry", typeof(string));
    
            var serviceRequirementNameParameter = serviceRequirementName != null ?
                new ObjectParameter("ServiceRequirementName", serviceRequirementName) :
                new ObjectParameter("ServiceRequirementName", typeof(string));
    
            var customerNameParameter = customerName != null ?
                new ObjectParameter("CustomerName", customerName) :
                new ObjectParameter("CustomerName", typeof(string));
    
            var quarantineReasonTextParameter = quarantineReasonText != null ?
                new ObjectParameter("QuarantineReasonText", quarantineReasonText) :
                new ObjectParameter("QuarantineReasonText", typeof(string));
    
            var alternateFacilityIdParameter = alternateFacilityId.HasValue ?
                new ObjectParameter("AlternateFacilityId", alternateFacilityId) :
                new ObjectParameter("AlternateFacilityId", typeof(short));
    
            var facilityNameParameter = facilityName != null ?
                new ObjectParameter("FacilityName", facilityName) :
                new ObjectParameter("FacilityName", typeof(string));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var userTimeZoneParameter = userTimeZone != null ?
                new ObjectParameter("UserTimeZone", userTimeZone) :
                new ObjectParameter("UserTimeZone", typeof(string));
    
            var isProductionOverViewParameter = isProductionOverView.HasValue ?
                new ObjectParameter("IsProductionOverView", isProductionOverView) :
                new ObjectParameter("IsProductionOverView", typeof(bool));
    
            var isIdentifiableParameter = isIdentifiable.HasValue ?
                new ObjectParameter("IsIdentifiable", isIdentifiable) :
                new ObjectParameter("IsIdentifiable", typeof(bool));
    
            var includeAlternateFacilityItemsParameter = includeAlternateFacilityItems.HasValue ?
                new ObjectParameter("IncludeAlternateFacilityItems", includeAlternateFacilityItems) :
                new ObjectParameter("IncludeAlternateFacilityItems", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<admapp_ReadTurnaroundsForGraphByFacilityAndCustomer_Result>("admapp_ReadTurnaroundsForGraphByFacilityAndCustomer", facilityIdParameter, customerDefinitionIdParameter, lastProcessEventTypeIdParameter, baseItemTypeIdParameter, serviceRequirementDefinitionIdParameter, overDueParameter, turnaroundExternalIdParameter, containerInstancePrimaryIdParameter, containerMasterNameParameter, lastEventNameParameter, lastEventTimeParameter, expiryParameter, serviceRequirementNameParameter, customerNameParameter, quarantineReasonTextParameter, alternateFacilityIdParameter, facilityNameParameter, userIdParameter, userTimeZoneParameter, isProductionOverViewParameter, isIdentifiableParameter, includeAlternateFacilityItemsParameter);
        }
    }
}
