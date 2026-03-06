using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum KnownPermission : int
    {
        Undefined = 0,

        #region Original
        [EnumMember]
        AdminUser = 1,
        [EnumMember]
        FinanceUser = 2,
        [EnumMember]
        SynergyCustomerUser = 3,
        [EnumMember]
        ReadInvoice = 5,
        [EnumMember]
        UpdateInvoiceStatus = 8,
        [EnumMember]
        CreateProvisionalInvoice = 9,
        [EnumMember]
        Administrator = 10,
        [EnumMember]
        AdminAdministrator = 11,
        [EnumMember]
        FinanceAdministrator = 12,
        [EnumMember]
        SynergyCustomerAdministrator = 13,
        [EnumMember]
        ReadContent = 15,
        [EnumMember]
        ReadCustomer = 16,
        [EnumMember]
        ReadDeliveryPoint = 17,
        [EnumMember]
        ReportingUser = 19,
        [EnumMember]
        ReportingAdministrator = 20,
        [EnumMember]
        ReadCurrentUser = 21,
        [EnumMember]
        UpdateCurrentUser = 22,
        [EnumMember]
        UpdateCurrentUserPassword = 23,
        [EnumMember]
        CollectTrolley = 24,
        [EnumMember]
        DeliverTrolley = 25,
        [EnumMember]
        LoadTrolley = 26,
        [EnumMember]
        MakeTrolleyAvailable = 27,
        [EnumMember]
        CreateStoragePoint = 28,
        [EnumMember]
        ReadStoragePoint = 29,
        [EnumMember]
        UpdateStoragePoint = 30,
        [EnumMember]
        ReadOmniSearchSummary = 31,
        [EnumMember]
        CreateEnquiry = 32,
        [EnumMember]
        ReadEnquiry = 33,
        [EnumMember]
        PrintEnquiry = 34,
        [EnumMember]
        ReadItem = 35,
        [EnumMember]
        PrintItem = 36,
        [EnumMember]
        CreateFastTrackRequest = 37,
        [EnumMember]
        ReadFastTrackRequest = 38,
        [EnumMember]
        PrintFastTrackRequest = 39,
        [EnumMember]
        ReadDefect = 41,
        [EnumMember]
        PrintDefect = 42,
        [EnumMember]
        CreateLoanSetRecord = 43,
        [EnumMember]
        ReadLoanSetRecord = 44,
        [EnumMember]
        PrintLoanSetRecord = 45,
        [EnumMember]
        CreateChangeControlNote = 46,
        [EnumMember]
        ReadChangeControlNote = 47,
        [EnumMember]
        PrintChangeControlNote = 48,
        [EnumMember]
        ReadCustomerDefect = 49,
        [EnumMember]
        CreateDeliveryNote = 51,
        [EnumMember]
        UpdateQuarantineReason = 52,
        [EnumMember]
        ReadReport = 53,
        [EnumMember]
        ReadStation = 54,
        [EnumMember]
        ReadTurnaround = 55,
        [EnumMember]
        ReadTurnaroundEvent = 56,
        [EnumMember]
        ValidateStation = 57,
        [EnumMember]
        ReadDeliveryNote = 58,
        [EnumMember]
        ReadCustomerAdditionalCost = 59,
        [EnumMember]
        ArchiveCustomerAdditionalCost = 61,
        [EnumMember]
        ArchiveCustomer = 63,
        [EnumMember]
        ReadCustomerGroup = 64,
        [EnumMember]
        ArchiveCustomerGroup = 65,
        [EnumMember]
        ReadDirectorate = 68,
        [EnumMember]
        ArchiveFacility = 70,
        [EnumMember]
        ReadFacility = 71,
        [EnumMember]
        ArchiveIndexationFactor = 73,
        [EnumMember]
        ReadIndexationFactor = 75,
        [EnumMember]
        ReadIndexationFactorDetail = 76,
        [EnumMember]
        ArchiveIndexationFactorDetail = 78,
        [EnumMember]
        ArchiveItemPriceAdjustment = 82,
        [EnumMember]
        ReadItemPriceAdjustment = 83,
        [EnumMember]
        ReadLocationWorkingHours = 85,
        [EnumMember]
        ArchivePriceCategory = 86,
        [EnumMember]
        ReadPriceCategory = 88,
        [EnumMember]
        ReadPriceCategoryGroup = 90,
        [EnumMember]
        ArchivePriceCategoryGroup = 91,
        [EnumMember]
        ReadInvoiceSchedule = 92,
        [EnumMember]
        ArchiveServiceRequirement = 94,
        [EnumMember]
        ReadServiceRequirement = 96,
        [EnumMember]
        ToDo = 98,
        [EnumMember]
        ScanIntoAutoclave = 99,
        [EnumMember]
        OperativeUser = 100,
        [EnumMember]
        ReadAlert = 101,
        [EnumMember]
        ReadItemType = 190,
        [EnumMember]
        ReadStationType = 191,
        [EnumMember]
        ArchiveDeliveryPoint = 192,
        [EnumMember]
        ReadPrinter = 193,
        [EnumMember]
        ReadFacilityNote = 194,
        [EnumMember]
        ReadAdminStats = 195,
        [EnumMember]
        ReadRecentlyViewed = 196,
        [EnumMember]
        ReadMachine = 197,
        [EnumMember]
        ReadFacilityMenu = 198,
        [EnumMember]
        ArchiveFacilityNote = 202,
        [EnumMember]
        ArchivePrinter = 203,
        [EnumMember]
        ArchiveItem = 204,
        [EnumMember]
        ReadItemNote = 205,
        [EnumMember]
        ArchiveItemNote = 207,
        [EnumMember]
        ArchiveMachine = 208,
        [EnumMember]
        ReadMachineMenu = 209,
        [EnumMember]
        ArchiveBatch = 211,
        [EnumMember]
        ReadBatch = 212,
        [EnumMember]
        ReadMachineEvent = 213,
        [EnumMember]
        ReadMachineType = 214,
        [EnumMember]
        ArchiveTurnaround = 215,
        [EnumMember]
        ReadDefectAuditHistory = 216,
        [EnumMember]
        ReadOmniSearchResults = 218,
        [EnumMember]
        ArchiveMachineStation = 220,
        [EnumMember]
        ReadWarning = 224,
        [EnumMember]
        ArchiveWarning = 226,
        [EnumMember]
        ReadTurnaroundNote = 227,
        [EnumMember]
        PrintTurnaround = 228,
        [EnumMember]
        ReadUser = 230,
        [EnumMember]
        PrintUser = 231,
        [EnumMember]
        OperativeAdministrator = 236,
        [EnumMember]
        ArchiveInvoice = 237,
        [EnumMember]
        EmailInvoice = 238,
        [EnumMember]
        ReadComponents = 239,
        [EnumMember]
        ReadCostingModel = 243,
        [EnumMember]
        CreateUpdateTurnaround = 246,
        [EnumMember]
        CreateInstance = 247,
        [EnumMember]
        UpdateInstance = 248,
        [EnumMember]
        ReadInstance = 249,
        [EnumMember]
        PrintInstance = 250,
        [EnumMember]
        ArchiveStation = 252,
        [EnumMember]
        ArchiveInstance = 253,
        [EnumMember]
        ArchiveUser = 254,
        [EnumMember]
        UpdateComponent = 255,
        [EnumMember]
        CreateComponent = 256,
        [EnumMember]
        UpdateFacilityThatCustomerPartOf = 337,

        #endregion

        #region Create
        [EnumMember]
        CreateCustomerAdditionalCost = 257,
        [EnumMember]
        CreateCustomer = 258,
        [EnumMember]
        CreateCustomerDefect = 259,
        [EnumMember]
        CreateCustomerGroup = 260,
        [EnumMember]
        CreateComponents = 261,
        [EnumMember]
        CreateCostingModel = 262,
        [EnumMember]
        CreateDeliveryPoint = 263,
        [EnumMember]
        CreateDirectorate = 264,
        [EnumMember]
        CreateDefect = 265,
        [EnumMember]
        CreateFacility = 266,
        [EnumMember]
        CreateFacilityNote = 267,
        [EnumMember]
        CreateFacilityItemType = 268,
        [EnumMember]
        CreateIndexationFactor = 269,
        [EnumMember]
        CreateIndexationFactorDetail = 270,
        [EnumMember]
        CreateInvoice = 271,
        [EnumMember]
        CreateInvoiceSchedule = 272,
        [EnumMember]
        CreateItem = 273,
        [EnumMember]
        CreateItemNote = 274,
        [EnumMember]
        CreateItemPriceAdjustment = 275,
        [EnumMember]
        CreateLocationWorkingHours = 276,
        [EnumMember]
        CreateMachine = 277,
        [EnumMember]
        CreateMachineStation = 278,
        [EnumMember]
        CreatePriceCategory = 279,
        [EnumMember]
        CreatePriceCategoryGroup = 280,
        [EnumMember]
        CreatePrinter = 281,
        [EnumMember]
        CreateStation = 282,
        [EnumMember]
        CreateStationPrinter = 283,
        [EnumMember]
        CreateStationDeliveryPoint = 284,
        [EnumMember]
        CreateServiceRequirement = 285,
        [EnumMember]
        CreateTurnaround = 286,
        [EnumMember]
        CreateUser = 287,
        [EnumMember]
        CreateUserFacility = 288,
        [EnumMember]
        CreateWarning = 289,

        #endregion

        #region Update
        [EnumMember]
        UpdateCustomerAdditionalCost = 290,
        [EnumMember]
        UpdateCustomer = 291,
        [EnumMember]
        UpdateCustomerDefect = 292,
        [EnumMember]
        UpdateCustomerGroup = 293,
        [EnumMember]
        UpdateComponents = 294,
        [EnumMember]
        UpdateCostingModel = 295,
        [EnumMember]
        UpdateDeliveryPoint = 296,
        [EnumMember]
        UpdateDirectorate = 297,
        [EnumMember]
        UpdateDefect = 298,
        [EnumMember]
        UpdateFacility = 299,
        [EnumMember]
        UpdateFacilityNote = 300,
        [EnumMember]
        UpdateFacilityItemType = 301,
        [EnumMember]
        UpdateIndexationFactor = 302,
        [EnumMember]
        UpdateIndexationFactorDetail = 303,
        [EnumMember]
        UpdateInvoice = 304,
        [EnumMember]
        UpdateInvoiceSchedule = 305,
        [EnumMember]
        UpdateItem = 306,
        [EnumMember]
        UpdateItemNote = 307,
        [EnumMember]
        UpdateItemPriceAdjustment = 308,
        [EnumMember]
        UpdateLocationWorkingHours = 309,
        [EnumMember]
        UpdateMachine = 310,
        [EnumMember]
        UpdateMachineStation = 311,
        [EnumMember]
        UpdatePriceCategory = 312,
        [EnumMember]
        UpdatePriceCategoryGroup = 313,
        [EnumMember]
        UpdatePrinter = 314,
        [EnumMember]
        UpdateStation = 315,
        [EnumMember]
        UpdateStationPrinter = 316,
        [EnumMember]
        UpdateStationDeliveryPoint = 317,
        [EnumMember]
        UpdateServiceRequirement = 318,
        [EnumMember]
        UpdateTurnaround = 319,
        [EnumMember]
        UpdateUser = 320,
        [EnumMember]
        UpdateUserFacility = 321,
        [EnumMember]
        UpdateWarning = 322,
        [EnumMember]
        ReadContainerMasterPrice = 323,
        [EnumMember]
        UpdateContainerMasterPrice = 324,
        [EnumMember]
        ReadCostingModelItemType = 325,
        [EnumMember]
        UpdateCostingModelItemType = 326,
        [EnumMember]
        ReadItemMasterPrice = 327,
        [EnumMember]
        UpdateItemMasterPrice = 328,
        [EnumMember]
        ArchiveDirectorate = 329,
        [EnumMember]
        ResetPassword = 336,
        [EnumMember]
        UpdateCustomerOnStop = 338,

        #endregion

        #region FDA
        [EnumMember]
        ResetPin = 341,
        [EnumMember]
        ChangePin = 342,
        [EnumMember]
        ViewFdaComplianceReason = 343,
        [EnumMember]
        EditFdaComplianceReason = 344,
        #endregion

        #region Sterile

        [EnumMember]
        CreateCondemnList = 500,
        [EnumMember]
        CondemnInstances = 501,
        [EnumMember]
        CondemnComponent = 502,
        [EnumMember]
        CreateOrder = 503,
        [EnumMember]
        ViewOrder = 504,
        [EnumMember]
        SearchOrder = 505,
        [EnumMember]
        UpdateOrder = 506,
        [EnumMember]
        UpdateOrderStatus = 507,
        [EnumMember]
        UpdateDefaultOrder = 508,
        [EnumMember]
        ViewPigeonhole = 509,
        [EnumMember]
        CreatePigeonhole = 510,
        [EnumMember]
        UpdatePigeonhole = 511,
        [EnumMember]
        ArchivePigeonhole = 512,
        [EnumMember]
        SterileProduction = 513,
        [EnumMember]
        CreateMultipleInstance = 514,
        [EnumMember]
        InstanceWarnings = 515,
        [EnumMember]
        EmailDeliveryNoteDetails = 516,
        [EnumMember]
        ViewComponentDisposablesInStock = 517,
        [EnumMember]
        ViewComponentDisposablesTurnaroundsInStock = 518,
        [EnumMember]
        ViewContainerDisposablesProductionDetails = 519,
        [EnumMember]
        ViewContainerDisposablesTurnaroundsInProduction = 520,
        [EnumMember]
        ViewContainerDisposablesOrders = 521,
        [EnumMember]
        RemoveDeliveryNote = 522,
        [EnumMember]
        SendToReinspection = 523,
        [EnumMember]
        ViewInstances = 524,
        [EnumMember]
        SterileLinen = -100,

        #endregion

        [EnumMember]
        ViewFacilityWallboard = 348,

        [EnumMember]
        ViewDebugInformation = 352,

        [EnumMember]
        ViewAllContainerMasterInstances = 603,

        [EnumMember]
        [Description("Can view facility workflow")]
        ViewFacilityWorkflow = 700,

        [EnumMember]
        [Description("Can manage facility workflow")]
        ManageFacilityWorkflow = 701,

        #region Control Station
        [EnumMember]
        ControlStationPrintUser = 1010,
        [EnumMember]
        ControlStationPrintStation = 1011,
        [EnumMember]
        ControlStationPrintLocation = 1012,
        #endregion

        #region Weighing
        [EnumMember]
        WeighingUser = 1020,
        [EnumMember]
        WeighingApprover = 1021,
        #endregion

        #region Store Station
        [EnumMember]
        StoreStationStockManagement = 1050,
        [EnumMember]
        StoreStationOrderManagement = 1051,
        [EnumMember]
        StoreStationShipping = 1052,
        [EnumMember]
        StoreStationStocktake = 1053,
        #endregion

        [EnumMember]
        ViewSurgicalProcedure = 1100,
        [EnumMember]
        CreateSurgicalProcedure = 1101,
        [EnumMember]
        LoadFromUsagePoint = 1104,

        #region Endoscopy

        [EnumMember]
        EndoscopyFeature = 1200,

        #endregion

        #region Maintenance

        [EnumMember]
        ViewMaintenanceReports = 1300,
        [EnumMember]
        CreateMaintenanceReports = 1301,
        [EnumMember]
        AdministerMaintenanceReports = 1302,

        #endregion

        [EnumMember]
        ViewArrivals = 1700,

        #region API Permissions

        [EnumMember]
        [Description("Has access to the SynergyTrak APIs")]
        ApiUser = 10000,

        [EnumMember]
        [Description("Can consume the read Order APIs of the Ordering module")]
        ApiReadOrder = 10010,
        
        [EnumMember]
        [Description("Can consume the write Order APIs (Create, Update, Cancel) of the Ordering module")]
        ApiWriteOrder = 10011,
        
        [EnumMember]
        [Description("Can consume the read Order Template APIs of the Ordering module")]
        ApiReadOrderTemplate = 10021,
        
        [EnumMember]
        [Description("Can consume the write Order Template APIs (Create, Update, Cancel) of the Ordering module")]
        ApiWriteOrderTemplate = 10022,

        [EnumMember]
        [Description("Can consume the read Product APIs of the Product Catalogue module")]
        ApiReadProduct = 10030,

        [EnumMember]
        [Description("Can consume the read Maintenance Report APIs of the Maintenance module")]
        ApiReadMaintenanceReport = 10040,

        [EnumMember]
        [Description("Can consume the write Maintenance Report APIs of the Maintenance module")]
        ApiWriteMaintenanceReport = 10041,

        [EnumMember]
        [Description("Can consume the read Location APIs of the Hospital Locations module")]
        ApiReadLocation = 10050,

        [EnumMember]
        [Description("Can use the HIS Ordering integration APIs")]
        ApiHISOrdering = 10051,

        [EnumMember]
        [Description("Can consume the read Asset APIs of the Product Catalogue module")]
        ApiReadAsset = 10060,

        [EnumMember]
        [Description("Can consume the read Surgical Procedure APIs")]
        ApiReadSurgicalProcedure = 10070,

        [EnumMember]
        [Description("Can consume the write Surgical Procedure APIs")]
        ApiWriteSurgicalProcedure = 10071,

        [EnumMember]
        [Description("Can consume the File Download APIs")]
        ApiReadFiles = 10100,

        [EnumMember]
        [Description("Can consume the read turnaround detail api of the Azure module")]
        ApiReadTurnaroundDetails = 11000,

        [EnumMember]
        [Description("Has Access to the Master Loaner APIs")]
        ApiCatalogueUser = 12000,

        [EnumMember]
        [Description("Can consume the read Master Loaner Product APIs")]
        ApiCatalogueReadProduct = 12010,

        [EnumMember]
        [Description("Can consume the write Master Loaner Product APIs")]
        ApiCatalogueWriteProduct = 12011,

        [EnumMember]
        [Description("Can consume the read Master Loaner Vendor APIs")]
        ApiCatalogueReadVendor = 12020,

        [EnumMember]
        [Description("Can consume the write Master Loaner Vendor APIs")]
        ApiCatalogueWriteVendor = 12021,

        [EnumMember]
        [Description("Can consume the read Loan Set APIs")]
        ApiCatalogueReadLoanSet = 12030,

        [EnumMember]
        [Description("Can consume the write Loan Set APIs")]
        ApiCatalogueWriteLoanset = 12031,

        [EnumMember]
        [Description("Can consume the delete Loan Set APIs")]
        ApiCatalogueArchiveLoanSet = 12032,

        [EnumMember]
        [Description("Can consume the PEGA integration APIs")]
        ApiPegaIntegrationUser = 13000,

        [EnumMember]
        [Description("Can consume the IMS APIs")]
        APIImsMaintenanceUser = 14000,        
        
        [EnumMember]
        [Description("Can consume the IMS Tray Specification APIs")]
        ApiIMSTraySpec = 14100,               
        #endregion
    }
}