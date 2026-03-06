using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use UserFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public User()
        {
            this.PutAwayImmediateSubmit = false;
            this.Alert = new HashSet<Alert>();
            this.Charge = new HashSet<Charge>();
            this.Charge1 = new HashSet<Charge>();
            this.ChargeList = new HashSet<ChargeList>();
            this.ChargeList1 = new HashSet<ChargeList>();
            this.CustomerDefect = new HashSet<CustomerDefect>();
            this.CustomerDefectInformation = new HashSet<CustomerDefectInformation>();
            this.CustomerGroup = new HashSet<CustomerGroup>();
            this.CustomerGroup1 = new HashSet<CustomerGroup>();
            this.Defect = new HashSet<Defect>();
            this.Defect1 = new HashSet<Defect>();
            this.Defect2 = new HashSet<Defect>();
            this.Defect3 = new HashSet<Defect>();
            this.Defect4 = new HashSet<Defect>();
            this.DefectAuditHistory = new HashSet<DefectAuditHistory>();
            this.DeliveryNote = new HashSet<DeliveryNote>();
            this.DeliveryPoint = new HashSet<DeliveryPoint>();
            this.FacilityNote = new HashSet<FacilityNote>();
            this.FacilityNote1 = new HashSet<FacilityNote>();
            this.FailedBatch = new HashSet<FailedBatch>();
            this.FastTrackRequest = new HashSet<FastTrackRequest>();
            this.Indexation = new HashSet<Indexation>();
            this.Indexation1 = new HashSet<Indexation>();
            this.InvoiceStatusAuditHistory = new HashSet<InvoiceStatusAuditHistory>();
            this.ItemMaster = new HashSet<ItemMaster>();
            this.ItemType = new HashSet<ItemType>();
            this.Machine = new HashSet<Machine>();
            this.MachineEvent = new HashSet<MachineEvent>();
            this.PriceCategory = new HashSet<PriceCategory>();
            this.PriceCategory1 = new HashSet<PriceCategory>();
            this.PriceCategoryGroup = new HashSet<PriceCategoryGroup>();
            this.PriceCategoryGroup1 = new HashSet<PriceCategoryGroup>();
            this.Printer = new HashSet<Printer>();
            this.ServiceRequirement = new HashSet<ServiceRequirement>();
            this.ServiceRequirement1 = new HashSet<ServiceRequirement>();
            this.Station = new HashSet<Station>();
            this.Turnaround = new HashSet<Turnaround>();
            this.TurnaroundEvent = new HashSet<TurnaroundEvent>();
            this.User1 = new HashSet<User>();
            this.User11 = new HashSet<User>();
            this.UserComplexity = new HashSet<UserComplexity>();
            this.UserFacility = new HashSet<UserFacility>();
            this.UserPrinter = new HashSet<UserPrinter>();
            this.UserReport = new HashSet<UserReport>();
            this.UserRole = new HashSet<UserRole>();
            this.Facilities = new HashSet<Facility>();
            this.Facility = new HashSet<Facility>();
            this.UserDeliveryPoints = new HashSet<UserDeliveryPoint>();
            this.LabourBands = new HashSet<LabourBand>();
            this.LabourBands1 = new HashSet<LabourBand>();
            this.ContainerMasters = new HashSet<ContainerMaster>();
            this.ContainerMaster = new HashSet<ContainerMaster>();
            this.Customer = new HashSet<Customer>();
            this.ContainerMasterPriceAdjustment = new HashSet<ContainerMasterPriceAdjustment>();
            this.UserItemAudit = new HashSet<UserItemAudit>();
            this.UserPermission = new HashSet<UserPermission>();
            this.LoanSetAuditHistory = new HashSet<LoanSetAuditHistory>();
            this.MaintenanceReport = new HashSet<MaintenanceReport>();
            this.MaintenanceReport1 = new HashSet<MaintenanceReport>();
            this.MaintenanceReportAuditHistory = new HashSet<MaintenanceReportAuditHistory>();
            this.Vendor = new HashSet<Vendor>();
            this.VendorRepairCost = new HashSet<VendorRepairCost>();
            this.ItemMasterAlias = new HashSet<ItemMasterAlias>();
            this.ItemMasterAlias1 = new HashSet<ItemMasterAlias>();
            this.ItemMasterDefinitionGroup = new HashSet<ItemMasterDefinitionGroup>();
            this.ItemMasterDefinitionGroup1 = new HashSet<ItemMasterDefinitionGroup>();
            this.Enquiry = new HashSet<Enquiry>();
            this.SterilisationTestReport = new HashSet<SterilisationTestReport>();
            this.SterilisationTestReport1 = new HashSet<SterilisationTestReport>();
            this.SterilisationTestReportAuditHistory = new HashSet<SterilisationTestReportAuditHistory>();
            this.Order = new HashSet<Order>();
            this.BiologicalIndicatorTest = new HashSet<BiologicalIndicatorTest>();
            this.BiologicalIndicatorTest1 = new HashSet<BiologicalIndicatorTest>();
            this.SterilisationTestReport_1 = new HashSet<SterilisationTestReport>();
            this.CycleParameter = new HashSet<CycleParameter>();
            this.CycleParameter1 = new HashSet<CycleParameter>();
            this.SterilisationExpiryTime = new HashSet<SterilisationExpiryTime>();
            this.SterilisationExpiryTime1 = new HashSet<SterilisationExpiryTime>();
            this.StockTransaction = new HashSet<StockTransaction>();
            this.MaintenanceReportInstrumentDetail = new HashSet<MaintenanceReportInstrumentDetail>();
            this.OrderStatusHistory = new HashSet<OrderStatusHistory>();
            this.MaintenanceReportInstrumentDetail_1 = new HashSet<MaintenanceReportInstrumentDetail>();
            this.Location = new HashSet<Location>();
            this.Location1 = new HashSet<Location>();
            this.CustomerDefinition = new HashSet<CustomerDefinition>();
            this.TenancyCustomValue = new HashSet<TenancyCustomValue>();
            this.TenancyCustomValue1 = new HashSet<TenancyCustomValue>();
            this.OrderTemplate = new HashSet<OrderTemplate>();
            this.LoanSetProcessAcceptance = new HashSet<LoanSetProcessAcceptance>();
            this.CatalogueEditors = new HashSet<CatalogueEditor>();
            this.Order_1 = new HashSet<Order>();
            this.ChangeControlNote = new HashSet<ChangeControlNote>();
            this.MultiFacilityProcessHandShake = new HashSet<MultiFacilityProcessHandShake>();
            this.MultiFacilityProcessHandShake1 = new HashSet<MultiFacilityProcessHandShake>();
            this.MultiFacilityProcessing = new HashSet<MultiFacilityProcessing>();
            this.MultiFacilityProcessing1 = new HashSet<MultiFacilityProcessing>();
            this.CustomerSetting = new HashSet<CustomerSetting>();
            this.DeniedTurnaroundEvent = new HashSet<DeniedTurnaroundEvent>();
            this.Facility1 = new HashSet<Facility>();
            this.FacilitySetting = new HashSet<FacilitySetting>();
            this.FailedScan = new HashSet<FailedScan>();
            this.SystemSetting = new HashSet<SystemSetting>();
            this.TenancySetting = new HashSet<TenancySetting>();
            this.Task = new HashSet<Task>();
            this.Task1 = new HashSet<Task>();
            this.Batch = new HashSet<Batch>();
            this.Batch1 = new HashSet<Batch>();
            this.Batch2 = new HashSet<Batch>();
            this.Batch3 = new HashSet<Batch>();
            this.UserClockingEvent = new HashSet<UserClockingEvent>();
            this.UserClockingEvent1 = new HashSet<UserClockingEvent>();
            this.BatchDecontaminationTask = new HashSet<BatchDecontaminationTask>();
            this.NotificationRules = new HashSet<NotificationRule>();
            this.NotificationRules1 = new HashSet<NotificationRule>();
            this.ContainerInstanceLabelAudit = new HashSet<ContainerInstanceLabelAudit>();
            this.StocktakeHistory = new HashSet<StocktakeHistory>();
            this.SurgicalProcedureTurnaround = new HashSet<SurgicalProcedureTurnaround>();
            this.SurgicalProcedureTurnaround1 = new HashSet<SurgicalProcedureTurnaround>();
            this.SurgicalProcedureType = new HashSet<SurgicalProcedureType>();
            this.SurgicalProcedureType1 = new HashSet<SurgicalProcedureType>();
            this.UserPasswordHistories = new HashSet<UserPasswordHistory>();
            this.FavouriteReport = new HashSet<FavouriteReport>();
            this.Surgeon = new HashSet<Surgeon>();
            this.Surgeon1 = new HashSet<Surgeon>();
            this.SurgicalProcedure = new HashSet<SurgicalProcedure>();
            this.SurgicalProcedure1 = new HashSet<SurgicalProcedure>();
            this.SurgicalProcedure2 = new HashSet<SurgicalProcedure>();
            this.ItemInstanceHistory = new HashSet<ItemInstanceHistory>();
            this.AuditRule = new HashSet<AuditRule>();
            this.SingleInstrumentAudit = new HashSet<SingleInstrumentAudit>();
            this.HisOrder = new HashSet<HisOrder>();
            this.HisOrder1 = new HashSet<HisOrder>();
            this.HisOrder2 = new HashSet<HisOrder>();
            this.HisOrderLine = new HashSet<HisOrderLine>();
            this.HisOrderLine1 = new HashSet<HisOrderLine>();
            this.MachineDetergent = new HashSet<MachineDetergent>();
            this.TurnaroundNote = new HashSet<TurnaroundNote>();
            this.UserClockingEvent2 = new HashSet<UserClockingEvent>();
            this.ContainerMasterDefinitionMaintenanceCapacity = new HashSet<ContainerMasterDefinitionMaintenanceCapacity>();
            this.ContainerInstance = new HashSet<ContainerInstance>();
            this.ContainerInstance1 = new HashSet<ContainerInstance>();
            this.ContainerInstance2 = new HashSet<ContainerInstance>();
            this.ItemException = new HashSet<ItemException>();
            this.ItemException1 = new HashSet<ItemException>();
            this.ItemExceptionReason = new HashSet<ItemExceptionReason>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets ArchivedUserId
        /// </summary>
        public Nullable<int> ArchivedUserId { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public int CreatedUserId { get; set; }
        /// <summary>
        /// Gets or sets UserCategoryId
        /// </summary>
        public byte UserCategoryId { get; set; }
        /// <summary>
        /// Gets or sets FirstName
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets Surname
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Gets or sets Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets UserName
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets EmailAddress
        /// </summary>
        public string EmailAddress { get; set; }
        public System.DateTime Created { get; set; }
        public Nullable<System.DateTime> Archived { get; set; }
        /// <summary>
        /// Gets or sets IsApproved
        /// </summary>
        public bool IsApproved { get; set; }
        /// <summary>
        /// Gets or sets IsExpired
        /// </summary>
        public bool IsExpired { get; set; }
        /// <summary>
        /// Gets or sets IsLockedOut
        /// </summary>
        public bool IsLockedOut { get; set; }
        /// <summary>
        /// Gets or sets IsOnline
        /// </summary>
        public bool IsOnline { get; set; }
        public System.DateTime LastActivity { get; set; }
        public System.DateTime LastLockout { get; set; }
        public System.DateTime LastLogin { get; set; }
        public System.DateTime LastPasswordChange { get; set; }
        /// <summary>
        /// Gets or sets PasswordQuestion
        /// </summary>
        public string PasswordQuestion { get; set; }
        /// <summary>
        /// Gets or sets IndependentQualityAssuranceCheck
        /// </summary>
        public bool IndependentQualityAssuranceCheck { get; set; }
        /// <summary>
        /// Gets or sets ProviderName
        /// </summary>
        public string ProviderName { get; set; }
        /// <summary>
        /// Gets or sets Comment
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Gets or sets LegacyId
        /// </summary>
        public Nullable<int> LegacyId { get; set; }
        /// <summary>
        /// Gets or sets LegacyFacilityOrigin
        /// </summary>
        public Nullable<int> LegacyFacilityOrigin { get; set; }
        public Nullable<System.DateTime> LegacyImported { get; set; }
        public System.Guid SystemId { get; set; }
        /// <summary>
        /// Gets or sets Position
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// Gets or sets Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets Telephone
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// Gets or sets IsProtected
        /// </summary>
        public Nullable<bool> IsProtected { get; set; }
        /// <summary>
        /// Gets or sets CustomerGroupId
        /// </summary>
        public Nullable<int> CustomerGroupId { get; set; }
        /// <summary>
        /// Gets or sets Pin
        /// </summary>
        public string Pin { get; set; }
        /// <summary>
        /// Gets or sets PinAttempts
        /// </summary>
        public int PinAttempts { get; set; }
        public System.DateTime LastPinChange { get; set; }
        /// <summary>
        /// Gets or sets IsPinExpired
        /// </summary>
        public Nullable<bool> IsPinExpired { get; set; }
        /// <summary>
        /// Gets or sets TenancyId
        /// </summary>
        public int TenancyId { get; set; }
        /// <summary>
        /// Gets or sets DateTimeFormatId
        /// </summary>
        public int DateTimeFormatId { get; set; }
        /// <summary>
        /// Gets or sets TimeZoneId
        /// </summary>
        public short TimeZoneId { get; set; }
        /// <summary>
        /// Gets or sets CurrentClockedInStationId
        /// </summary>
        public Nullable<int> CurrentClockedInStationId { get; set; }
        /// <summary>
        /// Gets or sets CurrentClockedInLocationId
        /// </summary>
        public Nullable<int> CurrentClockedInLocationId { get; set; }
        /// <summary>
        /// Gets or sets CultureId
        /// </summary>
        public Nullable<int> CultureId { get; set; }
        /// <summary>
        /// Gets or sets EmployeeId
        /// </summary>
        public string EmployeeId { get; set; }
        /// <summary>
        /// Gets or sets PutAwayImmediateSubmit
        /// </summary>
        public bool PutAwayImmediateSubmit { get; set; }
        /// <summary>
        /// Gets or sets UserPasswordHistoryId
        /// </summary>
        public Nullable<int> UserPasswordHistoryId { get; set; }
        /// <summary>
        /// Gets or sets IsSoftLockedOut
        /// </summary>
        public bool IsSoftLockedOut { get; set; }
        public Nullable<System.DateTime> SoftLockOutDate { get; set; }
        /// <summary>
        /// Gets or sets PasswordAttempts
        /// </summary>
        public short PasswordAttempts { get; set; }
        /// <summary>
        /// Gets or sets UserAccountTypeId
        /// </summary>
        public int UserAccountTypeId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Alert
        /// </summary>
        public virtual ICollection<Alert> Alert { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Charge
        /// </summary>
        public virtual ICollection<Charge> Charge { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Charge1
        /// </summary>
        public virtual ICollection<Charge> Charge1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ChargeList
        /// </summary>
        public virtual ICollection<ChargeList> ChargeList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ChargeList1
        /// </summary>
        public virtual ICollection<ChargeList> ChargeList1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets CustomerDefect
        /// </summary>
        public virtual ICollection<CustomerDefect> CustomerDefect { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets CustomerDefectInformation
        /// </summary>
        public virtual ICollection<CustomerDefectInformation> CustomerDefectInformation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets CustomerGroup
        /// </summary>
        public virtual ICollection<CustomerGroup> CustomerGroup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets CustomerGroup1
        /// </summary>
        public virtual ICollection<CustomerGroup> CustomerGroup1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Defect
        /// </summary>
        public virtual ICollection<Defect> Defect { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Defect1
        /// </summary>
        public virtual ICollection<Defect> Defect1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Defect2
        /// </summary>
        public virtual ICollection<Defect> Defect2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Defect3
        /// </summary>
        public virtual ICollection<Defect> Defect3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Defect4
        /// </summary>
        public virtual ICollection<Defect> Defect4 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets DefectAuditHistory
        /// </summary>
        public virtual ICollection<DefectAuditHistory> DefectAuditHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets DeliveryNote
        /// </summary>
        public virtual ICollection<DeliveryNote> DeliveryNote { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public virtual ICollection<DeliveryPoint> DeliveryPoint { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets FacilityNote
        /// </summary>
        public virtual ICollection<FacilityNote> FacilityNote { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets FacilityNote1
        /// </summary>
        public virtual ICollection<FacilityNote> FacilityNote1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets FailedBatch
        /// </summary>
        public virtual ICollection<FailedBatch> FailedBatch { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets FastTrackRequest
        /// </summary>
        public virtual ICollection<FastTrackRequest> FastTrackRequest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Indexation
        /// </summary>
        public virtual ICollection<Indexation> Indexation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Indexation1
        /// </summary>
        public virtual ICollection<Indexation> Indexation1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets InvoiceStatusAuditHistory
        /// </summary>
        public virtual ICollection<InvoiceStatusAuditHistory> InvoiceStatusAuditHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ItemMaster
        /// </summary>
        public virtual ICollection<ItemMaster> ItemMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public virtual ICollection<ItemType> ItemType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Machine
        /// </summary>
        public virtual ICollection<Machine> Machine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets MachineEvent
        /// </summary>
        public virtual ICollection<MachineEvent> MachineEvent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets PriceCategory
        /// </summary>
        public virtual ICollection<PriceCategory> PriceCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets PriceCategory1
        /// </summary>
        public virtual ICollection<PriceCategory> PriceCategory1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets PriceCategoryGroup
        /// </summary>
        public virtual ICollection<PriceCategoryGroup> PriceCategoryGroup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets PriceCategoryGroup1
        /// </summary>
        public virtual ICollection<PriceCategoryGroup> PriceCategoryGroup1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Printer
        /// </summary>
        public virtual ICollection<Printer> Printer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ServiceRequirement
        /// </summary>
        public virtual ICollection<ServiceRequirement> ServiceRequirement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ServiceRequirement1
        /// </summary>
        public virtual ICollection<ServiceRequirement> ServiceRequirement1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Station
        /// </summary>
        public virtual ICollection<Station> Station { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Turnaround
        /// </summary>
        public virtual ICollection<Turnaround> Turnaround { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets TurnaroundEvent
        /// </summary>
        public virtual ICollection<TurnaroundEvent> TurnaroundEvent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets User1
        /// </summary>
        public virtual ICollection<User> User1 { get; set; }
        /// <summary>
        /// Gets or sets User2
        /// </summary>
        public virtual User User2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets User11
        /// </summary>
        public virtual ICollection<User> User11 { get; set; }
        /// <summary>
        /// Gets or sets User3
        /// </summary>
        public virtual User User3 { get; set; }
        /// <summary>
        /// Gets or sets UserCategory
        /// </summary>
        public virtual UserCategory UserCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets UserComplexity
        /// </summary>
        public virtual ICollection<UserComplexity> UserComplexity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets UserFacility
        /// </summary>
        public virtual ICollection<UserFacility> UserFacility { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets UserPrinter
        /// </summary>
        public virtual ICollection<UserPrinter> UserPrinter { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets UserReport
        /// </summary>
        public virtual ICollection<UserReport> UserReport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets UserRole
        /// </summary>
        public virtual ICollection<UserRole> UserRole { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Facilities
        /// </summary>
        public virtual ICollection<Facility> Facilities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Facility
        /// </summary>
        public virtual ICollection<Facility> Facility { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets UserDeliveryPoints
        /// </summary>
        public virtual ICollection<UserDeliveryPoint> UserDeliveryPoints { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets LabourBands
        /// </summary>
        public virtual ICollection<LabourBand> LabourBands { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets LabourBands1
        /// </summary>
        public virtual ICollection<LabourBand> LabourBands1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ContainerMasters
        /// </summary>
        public virtual ICollection<ContainerMaster> ContainerMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ContainerMaster
        /// </summary>
        public virtual ICollection<ContainerMaster> ContainerMaster { get; set; }
        /// <summary>
        /// Gets or sets CustomerGroup2
        /// </summary>
        public virtual CustomerGroup CustomerGroup2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        public virtual ICollection<Customer> Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ContainerMasterPriceAdjustment
        /// </summary>
        public virtual ICollection<ContainerMasterPriceAdjustment> ContainerMasterPriceAdjustment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets UserItemAudit
        /// </summary>
        public virtual ICollection<UserItemAudit> UserItemAudit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets UserPermission
        /// </summary>
        public virtual ICollection<UserPermission> UserPermission { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets LoanSetAuditHistory
        /// </summary>
        public virtual ICollection<LoanSetAuditHistory> LoanSetAuditHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets MaintenanceReport
        /// </summary>
        public virtual ICollection<MaintenanceReport> MaintenanceReport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets MaintenanceReport1
        /// </summary>
        public virtual ICollection<MaintenanceReport> MaintenanceReport1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets MaintenanceReportAuditHistory
        /// </summary>
        public virtual ICollection<MaintenanceReportAuditHistory> MaintenanceReportAuditHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Vendor
        /// </summary>
        public virtual ICollection<Vendor> Vendor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets VendorRepairCost
        /// </summary>
        public virtual ICollection<VendorRepairCost> VendorRepairCost { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ItemMasterAlias
        /// </summary>
        public virtual ICollection<ItemMasterAlias> ItemMasterAlias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ItemMasterAlias1
        /// </summary>
        public virtual ICollection<ItemMasterAlias> ItemMasterAlias1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ItemMasterDefinitionGroup
        /// </summary>
        public virtual ICollection<ItemMasterDefinitionGroup> ItemMasterDefinitionGroup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ItemMasterDefinitionGroup1
        /// </summary>
        public virtual ICollection<ItemMasterDefinitionGroup> ItemMasterDefinitionGroup1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Enquiry
        /// </summary>
        public virtual ICollection<Enquiry> Enquiry { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SterilisationTestReport
        /// </summary>
        public virtual ICollection<SterilisationTestReport> SterilisationTestReport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SterilisationTestReport1
        /// </summary>
        public virtual ICollection<SterilisationTestReport> SterilisationTestReport1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SterilisationTestReportAuditHistory
        /// </summary>
        public virtual ICollection<SterilisationTestReportAuditHistory> SterilisationTestReportAuditHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Order
        /// </summary>
        public virtual ICollection<Order> Order { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets BiologicalIndicatorTest
        /// </summary>
        public virtual ICollection<BiologicalIndicatorTest> BiologicalIndicatorTest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets BiologicalIndicatorTest1
        /// </summary>
        public virtual ICollection<BiologicalIndicatorTest> BiologicalIndicatorTest1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SterilisationTestReport_1
        /// </summary>
        public virtual ICollection<SterilisationTestReport> SterilisationTestReport_1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets CycleParameter
        /// </summary>
        public virtual ICollection<CycleParameter> CycleParameter { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets CycleParameter1
        /// </summary>
        public virtual ICollection<CycleParameter> CycleParameter1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SterilisationExpiryTime
        /// </summary>
        public virtual ICollection<SterilisationExpiryTime> SterilisationExpiryTime { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SterilisationExpiryTime1
        /// </summary>
        public virtual ICollection<SterilisationExpiryTime> SterilisationExpiryTime1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets StockTransaction
        /// </summary>
        public virtual ICollection<StockTransaction> StockTransaction { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets MaintenanceReportInstrumentDetail
        /// </summary>
        public virtual ICollection<MaintenanceReportInstrumentDetail> MaintenanceReportInstrumentDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets OrderStatusHistory
        /// </summary>
        public virtual ICollection<OrderStatusHistory> OrderStatusHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets MaintenanceReportInstrumentDetail_1
        /// </summary>
        public virtual ICollection<MaintenanceReportInstrumentDetail> MaintenanceReportInstrumentDetail_1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Location
        /// </summary>
        public virtual ICollection<Location> Location { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Location1
        /// </summary>
        public virtual ICollection<Location> Location1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets CustomerDefinition
        /// </summary>
        public virtual ICollection<CustomerDefinition> CustomerDefinition { get; set; }
        /// <summary>
        /// Gets or sets Tenancy
        /// </summary>
        public virtual Tenancy Tenancy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets TenancyCustomValue
        /// </summary>
        public virtual ICollection<TenancyCustomValue> TenancyCustomValue { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets TenancyCustomValue1
        /// </summary>
        public virtual ICollection<TenancyCustomValue> TenancyCustomValue1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets OrderTemplate
        /// </summary>
        public virtual ICollection<OrderTemplate> OrderTemplate { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets LoanSetProcessAcceptance
        /// </summary>
        public virtual ICollection<LoanSetProcessAcceptance> LoanSetProcessAcceptance { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets CatalogueEditors
        /// </summary>
        public virtual ICollection<CatalogueEditor> CatalogueEditors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Order_1
        /// </summary>
        public virtual ICollection<Order> Order_1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ChangeControlNote
        /// </summary>
        public virtual ICollection<ChangeControlNote> ChangeControlNote { get; set; }
        /// <summary>
        /// Gets or sets DateTimeFormat
        /// </summary>
        public virtual DateTimeFormat DateTimeFormat { get; set; }
        /// <summary>
        /// Gets or sets TimeZone
        /// </summary>
        public virtual TimeZone TimeZone { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets MultiFacilityProcessHandShake
        /// </summary>
        public virtual ICollection<MultiFacilityProcessHandShake> MultiFacilityProcessHandShake { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets MultiFacilityProcessHandShake1
        /// </summary>
        public virtual ICollection<MultiFacilityProcessHandShake> MultiFacilityProcessHandShake1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets MultiFacilityProcessing
        /// </summary>
        public virtual ICollection<MultiFacilityProcessing> MultiFacilityProcessing { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets MultiFacilityProcessing1
        /// </summary>
        public virtual ICollection<MultiFacilityProcessing> MultiFacilityProcessing1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets CustomerSetting
        /// </summary>
        public virtual ICollection<CustomerSetting> CustomerSetting { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets DeniedTurnaroundEvent
        /// </summary>
        public virtual ICollection<DeniedTurnaroundEvent> DeniedTurnaroundEvent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Facility1
        /// </summary>
        public virtual ICollection<Facility> Facility1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets FacilitySetting
        /// </summary>
        public virtual ICollection<FacilitySetting> FacilitySetting { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets FailedScan
        /// </summary>
        public virtual ICollection<FailedScan> FailedScan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SystemSetting
        /// </summary>
        public virtual ICollection<SystemSetting> SystemSetting { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets TenancySetting
        /// </summary>
        public virtual ICollection<TenancySetting> TenancySetting { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Task
        /// </summary>
        public virtual ICollection<Task> Task { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Task1
        /// </summary>
        public virtual ICollection<Task> Task1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Batch
        /// </summary>
        public virtual ICollection<Batch> Batch { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Batch1
        /// </summary>
        public virtual ICollection<Batch> Batch1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Batch2
        /// </summary>
        public virtual ICollection<Batch> Batch2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Batch3
        /// </summary>
        public virtual ICollection<Batch> Batch3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets UserClockingEvent
        /// </summary>
        public virtual ICollection<UserClockingEvent> UserClockingEvent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets UserClockingEvent1
        /// </summary>
        public virtual ICollection<UserClockingEvent> UserClockingEvent1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets BatchDecontaminationTask
        /// </summary>
        public virtual ICollection<BatchDecontaminationTask> BatchDecontaminationTask { get; set; }
        /// <summary>
        /// Gets or sets Culture
        /// </summary>
        public virtual Culture Culture { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets NotificationRules
        /// </summary>
        public virtual ICollection<NotificationRule> NotificationRules { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets NotificationRules1
        /// </summary>
        public virtual ICollection<NotificationRule> NotificationRules1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ContainerInstanceLabelAudit
        /// </summary>
        public virtual ICollection<ContainerInstanceLabelAudit> ContainerInstanceLabelAudit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets StocktakeHistory
        /// </summary>
        public virtual ICollection<StocktakeHistory> StocktakeHistory { get; set; }
        /// <summary>
        /// Gets or sets UserPasswordHistory
        /// </summary>
        public virtual UserPasswordHistory UserPasswordHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SurgicalProcedureTurnaround
        /// </summary>
        public virtual ICollection<SurgicalProcedureTurnaround> SurgicalProcedureTurnaround { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SurgicalProcedureTurnaround1
        /// </summary>
        public virtual ICollection<SurgicalProcedureTurnaround> SurgicalProcedureTurnaround1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SurgicalProcedureType
        /// </summary>
        public virtual ICollection<SurgicalProcedureType> SurgicalProcedureType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SurgicalProcedureType1
        /// </summary>
        public virtual ICollection<SurgicalProcedureType> SurgicalProcedureType1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets UserPasswordHistories
        /// </summary>
        public virtual ICollection<UserPasswordHistory> UserPasswordHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets FavouriteReport
        /// </summary>
        public virtual ICollection<FavouriteReport> FavouriteReport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Surgeon
        /// </summary>
        public virtual ICollection<Surgeon> Surgeon { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Surgeon1
        /// </summary>
        public virtual ICollection<Surgeon> Surgeon1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SurgicalProcedure
        /// </summary>
        public virtual ICollection<SurgicalProcedure> SurgicalProcedure { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SurgicalProcedure1
        /// </summary>
        public virtual ICollection<SurgicalProcedure> SurgicalProcedure1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SurgicalProcedure2
        /// </summary>
        public virtual ICollection<SurgicalProcedure> SurgicalProcedure2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ItemInstanceHistory
        /// </summary>
        public virtual ICollection<ItemInstanceHistory> ItemInstanceHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets AuditRule
        /// </summary>
        public virtual ICollection<AuditRule> AuditRule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SingleInstrumentAudit
        /// </summary>
        public virtual ICollection<SingleInstrumentAudit> SingleInstrumentAudit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets HisOrder
        /// </summary>
        public virtual ICollection<HisOrder> HisOrder { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets HisOrder1
        /// </summary>
        public virtual ICollection<HisOrder> HisOrder1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets HisOrder2
        /// </summary>
        public virtual ICollection<HisOrder> HisOrder2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets HisOrderLine
        /// </summary>
        public virtual ICollection<HisOrderLine> HisOrderLine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets HisOrderLine1
        /// </summary>
        public virtual ICollection<HisOrderLine> HisOrderLine1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets MachineDetergent
        /// </summary>
        public virtual ICollection<MachineDetergent> MachineDetergent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets TurnaroundNote
        /// </summary>
        public virtual ICollection<TurnaroundNote> TurnaroundNote { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets UserClockingEvent2
        /// </summary>
        public virtual ICollection<UserClockingEvent> UserClockingEvent2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionMaintenanceCapacity
        /// </summary>
        public virtual ICollection<ContainerMasterDefinitionMaintenanceCapacity> ContainerMasterDefinitionMaintenanceCapacity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ContainerInstance
        /// </summary>
        public virtual ICollection<ContainerInstance> ContainerInstance { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ContainerInstance1
        /// </summary>
        public virtual ICollection<ContainerInstance> ContainerInstance1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ContainerInstance2
        /// </summary>
        public virtual ICollection<ContainerInstance> ContainerInstance2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ItemException
        /// </summary>
        public virtual ICollection<ItemException> ItemException { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ItemException1
        /// </summary>
        public virtual ICollection<ItemException> ItemException1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ItemExceptionReason
        /// </summary>
        public virtual ICollection<ItemExceptionReason> ItemExceptionReason { get; set; }
    }
}
