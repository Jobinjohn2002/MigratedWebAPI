using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ComponentModel;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public static class Constants
    {
        public static class General
        {
            public static class Serialization
            {
                public const string NamespaceV1 = "http://api.synergytrak.com/V1/Hospital";
                public const string NamespaceV2 = "http://api.synergytrak.com/V2/Hospital";
            }

            public static class Success
            {
                public const string NoContentSeeLocationHeader = "See location header for resource URI";
                public const string NoResults = "The request was successful, no results returned";
                public const string NotModified = "The request had no changes, the resource was not modified";
            }

            public static class Errors
            {
                public const string EmptyBody = "The request body is empty";
                public const string InternalServerError = "An internal server error has occurred";
                public const string SaveFailed = "Failed while saving data";
                public const string InvalidBody = "The request cannot be processed as supplied data failed validation, please review the relevant API documentation";
                /// <summary>
                /// Stops an API request proceeding if an invalid argument has been supplied e.g max result being zero or requesting an asset creation date that is in the future etc.
                /// </summary>
                public const string InvalidArgument = "Invalid Argument Supplied ";
            }
        }

        public static class Asset
        {
            public static class Success
            {
                public const string Get = "The request was successful, see body for asset data";
            }

            public static class Errors
            {
                public const string MissingProductNumber = "Product number not supplied or incomplete";
                public const string MissingAssetNumber = "Asset number not supplied or incomplete";
                public const string NotFound = "An asset with the specified asset number could not be found";
            }
        }

        public static class DeliveryNote
        {
            public static class Success
            {
                public const string Get = "The request was successful, see body for delivery note data";
            }

            public static class Errors
            {
                public const string NotFound = "A delivery note with the specified delivery note number could not be found";
            }
        }

        public static class Maintenance
        {
            public static class Success
            {
                public const string Get = "The request was successful, see body for maintenance data";
            }

            public static class Warning
            {
            }

            public static class Errors
            {
                public const string MissingReportNumber = "Maintenance report number not supplied or incomplete";
                public const string NotFound = "A maintenance report with the specified report number could not be found";
            }
        }

        public static class Order
        {
            public static class Success
            {
                public const string Get = "The request was successful, see body for order data";
                public const string Cancelled = "Order cancelled";
            }

            public static class Warning
            {
                public const string AlreadyCancelled = "The order is already cancelled";
                public const string AlreadyArchived = "The order is already archived";
                public const string AlreadyCancelledOrArchived = "The order is already cancelled or archived";
            }

            public static class Errors
            {
                public const string MissingOrderNumber = "Order number not supplied or incomplete";
                public const string MissingYourReference = "Your reference not supplied";
                public const string MissingHospitalName = "Hospital name not supplied";
                public const string InvalidProduct = "One or more products are invalid";
                public const string InvalidTemplate = "One or more templates are invalid";
                public const string InvalidHospital = "The specified hospital is invalid";
                public const string InvalidLocation = "The specified location is invalid";
                public const string DeliveryDateTooSoon = "The delivery date does not give sufficient notice";
                public const string ProcedureDateBeforeDeliveryDate = "The procedure date is before the delivery date";
                public const string NotFound = "An order with the specified order number could not be found";
                public const string NotFoundBy = "An order with the specified parameters cannot be found, use the unique ORD-XXXXXXX number and API instead";
                public const string MultipleOrdersFound = "There are multiple orders matching your parameters, use the unique ORD-XXXXXXX number and API instead";
                public const string TooLateToCancel = "Too late to cancel order in process";
                public const string TooLatePartDispatched = "Too late to modify, order is part dispatched or multiple orders found, use the unique ORD-XXXXXXX number and API instead";
                public const string BatchNotFound = "An order batch with the specified batch number could not be found";
                public const string Uneditable = "The order has progressed to a status that can no longer be edited";
                public const string NoProductsOrTemplatesSpecified = "The order must contain at least one product or order template";
            }
        }

        public static class HISOrder
        {
            public static class Success
            {
                public const string SuccessMessage = "The request was successful";
            }

            public static class Errors
            {
                public const string InvalidHospital = "The specified hospital is invalid";
                public const string LocationNotSpecified = "The location was not specified";
                public const string YourReferenceNotSpecified = "Your reference was not specified";
                public const string InvalidOrderRequestLine = "The order request had at least one line which was invalid";
                public const string YourReferenceNotRecognised = "The order you requested cannot be found";
                public const string ProcedureDateInThePast = "The procedure date specified was in the past";
                public const string HospitalTooLong = "The specified hospital has too many characters";
                public const string LocationTooLong = "The location specified has too many characters";
                public const string YourReferenceTooLong = "Your reference specified has too many characters";
                public const string SurgeonNameTooLong = "The surgeon name specified has too many characters";
                public const string SurgeonCodeTooLong = "The surgeon code specified has too many characters";
                public const string ProcedureNameTooLong = "The procedure name specified has too many characters";
                public const string ProcedureCodeTooLong = "The procedure code specified has too many characters";
                public const string YourMessageReferenceTooLong = "Your Message Reference specified has too many characters";
                public const string YourMessageReferenceNotSpecified = "Your Message Reference was not specified";
                public const string ProcedureDateIsTooSoon = "The procedure date is too soon";
                public const string DeliveryPointChangeFailure = "The delivery point could not be changed";
                public const string DeliveryPointNoAccess = "User has no access to delivery point";
                public const string YourReferenceInUse = "Your reference is already in use";
                public const string YourMessageReferenceInUse = "The your message reference provided has already been used";
            }
        }

        public static class OrderTemplate
        {
            public static class Success
            {
                public const string Get = "The request was successful, see body for order template data";
            }

            public static class Errors
            {
                public const string MissingTemplateNumber = "Order template number not supplied or incomplete";
                public const string NotFound = "An order template with the specified template number could not be found";
            }
        }

        public static class Product
        {
            public static class Success
            {
                public const string Get = "The request was successful, see body for order product data";
            }

            public static class Errors
            {
                public const string MissingProductNumber = "Product number not supplied or incomplete";
                public const string NotFound = "A product with the specified product number could not be found";
            }
        }

        public static class Turnaround
        {
            public static class Errors
            {
                public const string MissingSerialNumber = "Serial number not supplied or incomplete";
                public const string MissingCreatedDate = "Created date not supplied or incomplete";
                public const string NotFound = "A turnaround with the specified serial number could not be found";
                public const string NoResults = "No results could be found with the specified parameters";

            }
        }

        public static class SurgicalProcedure
        {
            public static class FormatParameters
            {
                public const string Turnaround = "{Turnaround}";
            }

            public static class Success
            {
                public const string Get = "The request was successful.";
            }

            public static class Errors
            {
                public const string NotFound = "The requested surgical procedure could not be found";
                public const string MissingSurgicalProcedureNumber = "Surgical Procedure number not supplied";
                public const string InvalidUsagePoint = "The usage point specified is invalid";
                public const string InvalidHospital = "The hospital specified is invalid";
                public const string InvalidEmailFormat = "The provided user email address is not a valid email format";
                public const string SaveFailed = "An error occured when saving the surgical procedure";
                public const string InvalidStation = "The default station configured for the hospital is invalid";
                public const string TurnaroundInvalid = "The provided turnaround {Turnaround} is invalid";
                public const string TurnaroundRestricted = "The provided turnaround {Turnaround} is valid, but is not accessible due to a delivery point restriction";
                public const string TurnaroundWrongCustomer = "The provided turnaround {Turnaround} is not valid for the provided hospital";
                public const string TurnaroundInvalidItemType = "The provided turnaround {Turnaround} is an item type which cannot be associated to a surgical procedure";
                public const string TurnaroundAlreadyUsed = "The provided turnaround {Turnaround} couldn't be added to the surgical procedure as it is already marked as used on an existing surgical procedure";
                public const string MissingHospital = "Hospital not supplied";
                public const string HospitalNotFound = "Usage Points for the hospital provided were not found";
                public const string MissingSurgicalProcedureTypeName = "Procedure Type Name is required if choosing to supply the Procedure details";
                public const string MissingSurgeonName = "Surgeon Name is required if choosing to supply Surgeon details";
                public const string MissingSurgicalProcedureTypeReference = "Procedure Type Reference is required if choosing to supply the Procedure details";
                public const string MissingSurgeonReference = "Surgeon Reference is required if choosing to supply Surgeon details";
                public const string DuplicateTurnaround = "The same turnaround {Turnaround} was provided more than once. Please ensure each provided turnaround is unique.";
            }

            public static class Warnings
            {
                public const string TurnaroundNotCurrent = "The provided turnaround {Turnaround} could not be moved into stock as a newer turnaround exists";
                public const string InvalidWorkflowForIntoStock = "The provided turnaround {Turnaround} could not be moved into stock due to invalid workflow";
                public const string TurnaroundIntoStockFailed = "The provided turnaround {Turnaround} could not be moved into stock due to an internal server error";
                public const string ExistingProcedureType = "A procedure type with the same reference already exists for a different name. The existing procedure type has been used";
                public const string ExistingSurgeon = "A surgeon with the same reference already exists for a different name. The existing surgeon has been used";
                public const string TurnaroundExtraNotMoved = "The provided turnaround {Turnaround} could not be moved into stock because it is an extra";
                public const string TurnaroundSterileExpiryPriorToProcedureDate = "The sterile expiry of the provided turnaround {Turnaround} is prior to the provided surgical procedure schedule date.";
            }
        }

        public static class Location
        {
            public static class Success
            {
                public const string Get = "The request was successful, see body for location data";
            }
        }

        public static class Headers
        {
            public static class Location
            {
                public const string Name = "Location";
                public const string Description = "Provides a fully qualified Uri to the resource.";
            }
        }

        public static class MasterLoaner
        {
            public static class Success
            {
                public const string Get = "The request was successful, see body for master loaner data";
                public const string Post = "The request was successful";
                public const string Put = "The request was successful";
                public const string Delete = "The request was successful";
            }

            public static class Errors
            {
                public const string DeliveryPointNotFound = "A Delivery point with the specified Id could not be found";
                public const string ProductNotFound = "A Product with the specified Id could not be found";
                public const string RequestNotFound = "A Loan Request with the specified Id could not be found";
                public const string VendorNotFound = "A Vendor with the specified Id could not be found";

                public static class LoansetErrors
                {
                    public const string CaseNumberExistsAlready = "A loan kit request associated to the case id already exists";
                    public const string CaseIdMissing = "A case Id is required and must be between 1-64 characters";
                    public const string CaseDetailsNotFound = "Details for this case id could not be found";
                    public const string CaseIdTenantCodeVendorIdMatchError = "The case Id, tenant code and vendor Id in the URI must match the case Id, tenant code and vendorId in the request body";
                    public const string CustomerMappingNotFound = "A customer could not be matched with the supplied site id. Please ensure a customer external reference id setting is configured in portal";
                    public const string TenantMappingNotFound = "No customers were found under the supplied tenant code. Please ensure that at least one customer is mapped with the supplied external tenant code in portal";
                    public const string DeliveryPointCannotChange = "The delivery point cannot be changed while the loan kit has instances assigned to it";
                    public const string DeliveryPointAccess = "You do not have delivery point access to the specified delivery point, please enable delivery point access for this delivery point";
                    public const string NoProceduresOnRequest = "One or more procedures are required to raise a loan set request";
                    public const string StartTimeBeforeEndTime = "End time must not preceed Start time";
                    public const string SiteNameIdNotFound = "A site name or Id was not found, please supply this as part of the request";
                    public const string TenantCodeMissing = "A tenant code must be supplied";
                    public const string VendorIdNoCustomerFound = "A vendor could not be matched with the supplied vendor Id";
                    public const string CaseStartTimeMustNotBeInThePast = "The requested start DateTime must not be in the past";
                    public const string CaseStartTimePrecedesALoanerProcessedAndDeliveredToCustomer = "The requested case start DateTime precedes that of a case that has already been processed and delivered to a customer";
                    public const string CaseConflictsWithExistingCaseStartTime = "The requested case procedure start DateTime does not leave enough time to reprocess and deliver to a customer that has an existing procedure";
                    public const string DateReceivedDoesNotMeetMinimumRequiredDeliveryAndReProcessingTime = "The requested loaner DateTime DateReceived is too late and does not meet the minimum required time to reprocess and deliver for the declared procedure date";
                    public const string InvalidStatus = "Unknown Status {0} provided";
                    public const string InvalidState = "Unknown State {0} provided";
                }
            }
        }

        public static class User
        {
            public static class Success
            {
                public const string Get = "The request was successful, see body for user data";
            }
        }

        public static class PegaCase
        {
            public static class General
            {
                public const string ZimmerBiometInventory = "ZimmerBiomet Inventory External Request";
            }
            public static class Success
            {
                public const string Archived = "Case successfully archived";
                public const string ArchivedButUnavailable = "Case successfully archived, products have been processed so will temporarily be unavailable.";
                public const string Created = "Case successfully created";
            }
            public static class Errors
            {
                public const string CaseDoesNotExist = "Case could not be found";
                public const string SurgeryDateProcedureDescriptionRequired = "The request must include a surgery date and procedure description";
                public const string DeliveryPointIdNotFound = "The supplied external delivery point id does not match with a delivery point";
                public const string PegaExternalCaseIdLength = "The supplied pega external case id must be 50 characters or less";
                public const string InstanceNotFound = "One or more of the supplied product asset id could not be matched with a container instance";
                public const string TrayCannotBeReprocessedInTime = "The supplied surgery date does not allow trays to be reprocessed in time. Please review the LoanSet_API_Minimum_Tray_Reprocessing_Time_Minutes setting in portal";

                public const string SupplierNotFound = "A unique supplier could not be found.";
                public const string ProcedureNotSupplied = "Procedure details must be supplied to assign products";
                public const string ProductsNotSupplied = "No Products were supplied";

                public const string AssetNotFound = "{0} could not be found;";
                public const string AssetAssignedToAnotherCase = "{0} is already assigned to a Case;";
                public const string AssetNotAvailable = "{0} is not currently in Stock;";
                public const string AssetAlreadyAssigned = "{0} is already assigned to this case";
                public const string AssetAssignedTooLate = "{0} the minimum time required to process this asset onto the case has elapsed;";

                public const string AssetNotAvailableBaseMessage = "One or more asset is not currently in Stock;";
                public const string AssetNotFoundBaseMessage = "One or more assets could not be identified from the supplied asset ids";
                public const string AssetBaseMessage = "One or more assets could not be assigned to the Case: ";

                public const string DefaultStationRequired = "A default station has not been configured. Please review the Default_Station_Id customer setting in portal";

                public const string InvalidNextEvent = "One or more products could not be processed.";
                public const string InvalidInventoryProductStatus = "One or more of the supplied product status was not recognised";
                public const string AssetAlreadyAssignedBase = "The asset is already assigned to this case";
                public const string AssetAssignedTooLateBase = "The minimum time required to process this asset onto the case has elapsed";

                public const string AutoEventConfigurationInvalid = "Please review the Zimmer_Inventory_Case_Quarantine_Events setting in portal and ensure it is correctly configured.";
            }
        }

        public static class IMSMaintenance
        {
            public static class General
            {
                public const string AutomaticEventName = "IMS External Maintenance Request";
                public const string ExternalId = "ExternalId";
            }

            public static class Success
            {

            }
            public static class Errors
            {
                public const string NoAssetsSupplied = "No assets were specified in the request";
                public const string AssetNotFound = "The supplied asset id either could not be matched with an existing asset or access to the asset is not permitted for this user";
                public const string AssetNoCurrentTurnaround = "The requested asset does not have a current turnaround. This is required for the asset to be sent for maintenance.";
                public const string DuplicateAssetsInRequest = "The following asset numbers were duplicated in the request: {0}. Please only send unique asset numbers in the request.";

                public const string MaintenanceReportOpen = "A incomplete maintenance report for this asset and user already exists";
                public const string MaintenanceReportNotFound = "A maintenance report could not be matched with the supplied id";
                public const string MaintenanceReportStatudInvalid = "The Status supplied was not a supported value";

                public const string InstrumentQuantityInvalidPlaceholder = "The quantities of the following maintenance activities are greater than the instrument quantity on the asset: (InstrumentReference - Activity - Quantity(On Request) - Quantity(On Asset))";
                public const string InstrumentQuantityInvalid = "The quantities of the following maintenance activities are greater than the instrument quantity on the asset: {0}";
                public const string NegativeValues = "Please ensure that the 'TotalCost', 'CostPerItem' and 'Quantity' properties in the request are not negative values";
                public const string VendorIdNotConfigured = "Please review the IMS_Maintenance_API_Vendor_Id setting in portal and ensure it is configured correctly.";
                public const string AutoEventConfigurationInvalid = "Please review the IMS_Maintenance_API_Quarantine_Events setting in portal and ensure it is correctly configured.";
                public const string NotEligibleForQuarantine = "Asset is not eligible for quarantine";
                public const string NoCustomersFoundForUser = "No customers associated with this user were found.";
                /// <summary>
                /// Either the customer is not found or it is not defined in the usercustomer table
                /// </summary>
                public const string CustomerNotFound = "A customer could not be found with the supplied ID";

                public const string CourierInvalid = "The courier supplied could not be found.";
            }
        }

        public static class ServiceReport
        {
            public static class General
            {
                public const string ExternalId = "ExternalId";
            }

            public static class Success
            {

            }

            public static class Errors
            {
                public const string TurnaroundInvalid = "The Turnaround could not be found";
                public const string DeliveryPointInvalid = "The Delivery Point could not be found";
                public const string DeliveryPointMultiple = "Multiple Delivery Points found with that name";
                public const string ClassificationInvalid = "The Classification is not valid";
                public const string SeverityInvalid = "The Severity is not valid";
                public const string InvalidDate = "The Incident Date must be a valid date in the past";
                public const string TurnaroundDeliveryPointMismatch = "The turnaround is invalid for the specified Delivery Point";
                
            }
        }
    }
}