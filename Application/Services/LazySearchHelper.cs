using SynergyApplicationFrameworkApi.Application.DTOs.Interfaces.Operative.Search;
using SynergyApplicationFrameworkApi.Application.DTOs.Search;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SynergyApplicationFrameworkApi.Application.DTOs;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Lazy Search Helper
    /// </summary>
    /// <remarks></remarks>
    public static class LazySearchHelper
    {
        #region Summary

        /// <summary>
        /// Converts the omni search summary to data.
        /// </summary>
        /// <param name="omniSearchSummary">The omni search summary.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchSummaryToData operation
        /// </summary>
        public static OmniSearchSummaryData? ConvertOmniSearchSummaryToData(IOmniSearchSummary? omniSearchSummary)
        {
            return omniSearchSummary == null
                       ? null
                       : new OmniSearchSummaryData(omniSearchSummary.Users,
                                                   omniSearchSummary.Customers,
                                                   omniSearchSummary.Items,
                                                   omniSearchSummary.Instances,
                                                   omniSearchSummary.Turnarounds,
                                                   omniSearchSummary.DeliveryNotes,
                                                   omniSearchSummary.Defects, omniSearchSummary.Batches,
                                                   omniSearchSummary.DeliveryPoints,
                                                   omniSearchSummary.Instruments,
                                                   omniSearchSummary.LoanSets);
        }

        #endregion

        #region Facility

        /// <summary>
        /// Converts the omni search facility detail to data.
        /// </summary>
        /// <param name="omniSearchFacilityDetail">The omni search facility detail.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchFacilityDetailToData operation
        /// </summary>
        public static OmniSearchFacilityDetailData? ConvertOmniSearchFacilityDetailToData(
            IOmniSearchFacilityDetail? omniSearchFacilityDetail)
        {
            return omniSearchFacilityDetail == null
                       ? null
                       : new OmniSearchFacilityDetailData(omniSearchFacilityDetail.FacilityId,
                                                          omniSearchFacilityDetail.Name, omniSearchFacilityDetail.IsArchived);
        }

        /// <summary>
        /// Converts the omni search facility details to data.
        /// </summary>
        /// <param name="omniSearchFacilityDetails">The omni search facility details.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchFacilityDetailsToData operation
        /// </summary>
        public static IList<OmniSearchFacilityDetailData>? ConvertOmniSearchFacilityDetailsToData(
            IList<IOmniSearchFacilityDetail>? omniSearchFacilityDetails)
        {
            return omniSearchFacilityDetails == null
                       ? null
                       : omniSearchFacilityDetails.Select(ConvertOmniSearchFacilityDetailToData).ToList();
        }

        #endregion

        #region Customer

        /// <summary>
        /// Converts the omni search customer detail to data.
        /// </summary>
        /// <param name="omniSearchCustomerDetail">The omni search customer detail.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchCustomerDetailToData operation
        /// </summary>
        public static OmniSearchCustomerDetailData? ConvertOmniSearchCustomerDetailToData(
            IOmniSearchCustomerDetail? omniSearchCustomerDetail)
        {
            return omniSearchCustomerDetail == null
                       ? null
                       : new OmniSearchCustomerDetailData(omniSearchCustomerDetail.CustomerId,
                                                          omniSearchCustomerDetail.CustomerStatusId,
                                                          omniSearchCustomerDetail.CustomerName,
                                                          omniSearchCustomerDetail.Created,
                                                          omniSearchCustomerDetail.Revision,
                                                          omniSearchCustomerDetail.FacilityName,
                                                          omniSearchCustomerDetail.FacilityId,
                                                          omniSearchCustomerDetail.CustomerGroupName,
                                                          omniSearchCustomerDetail.CustomerGroupId,
                                                          omniSearchCustomerDetail.IsArchived);
        }

        /// <summary>
        /// Converts the omni search customer details to data.
        /// </summary>
        /// <param name="omniSearchCustomerDetails">The omni search customer details.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchCustomerDetailsToData operation
        /// </summary>
        public static IList<OmniSearchCustomerDetailData>? ConvertOmniSearchCustomerDetailsToData(
            IList<IOmniSearchCustomerDetail>? omniSearchCustomerDetails)
        {
            return omniSearchCustomerDetails == null
                       ? null
                       : omniSearchCustomerDetails.Select(ConvertOmniSearchCustomerDetailToData).ToList();
        }

        #endregion

        #region Item

        /// <summary>
        /// Converts the omni search item detail to data.
        /// </summary>
        /// <param name="omniSearchItemDetail">The omni search item detail.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchItemDetailToData operation
        /// </summary>
        public static OmniSearchItemDetailData? ConvertOmniSearchItemDetailToData(
            IOmniSearchItemDetail? omniSearchItemDetail)
        {
            return omniSearchItemDetail == null
                       ? null
                       : new OmniSearchItemDetailData(omniSearchItemDetail.MasterId,
                                                      omniSearchItemDetail.MasterSubtype,
                                                      omniSearchItemDetail.Name,
                                                      omniSearchItemDetail.LegacyInternalId,
                                                      omniSearchItemDetail.LegacyExternalId,
                                                      omniSearchItemDetail.ExternalId,
                                                      omniSearchItemDetail.Status,
                                                      omniSearchItemDetail.ItemType,
                                                      omniSearchItemDetail.BaseType,
                                                      omniSearchItemDetail.NumberOfInstance, omniSearchItemDetail.MasterType, omniSearchItemDetail.CustomerName
                                                      ){IsArchived = omniSearchItemDetail.IsArchived};
        }

        /// <summary>
        /// Converts the omni search item details to data.
        /// </summary>
        /// <param name="omniSearchItemDetails">The omni search item details.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchItemDetailsToData operation
        /// </summary>
        public static IList<OmniSearchItemDetailData>? ConvertOmniSearchItemDetailsToData(
            IList<IOmniSearchItemDetail>? omniSearchItemDetails)
        {
            return omniSearchItemDetails == null
                       ? null
                       : omniSearchItemDetails.Select(ConvertOmniSearchItemDetailToData).ToList();
        }

        #endregion

        #region Instance

        /// <summary>
        /// Converts the omni search instance detail to data.
        /// </summary>
        /// <param name="omniSearchInstanceDetail">The omni search instance detail.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchInstanceDetailToData operation
        /// </summary>
        public static OmniSearchInstanceDetailData? ConvertOmniSearchInstanceDetailToData(
            IOmniSearchInstanceDetail? omniSearchInstanceDetail)
        {
            return omniSearchInstanceDetail == null
                       ? null
                       : new OmniSearchInstanceDetailData(omniSearchInstanceDetail.InstanceId,
                                                          omniSearchInstanceDetail.DeliveryPoint,
                                                          omniSearchInstanceDetail.CustomerStatusId,
                                                          omniSearchInstanceDetail.Customer,
                                                          omniSearchInstanceDetail.LegacyInternalId,
                                                          omniSearchInstanceDetail.LegacyExternalId,
                                                          omniSearchInstanceDetail.ExternalId,
                                                          omniSearchInstanceDetail.SuperType
                                                          ){IsArchived = omniSearchInstanceDetail.IsArchived};
        }

        /// <summary>
        /// Converts the omni search instance details to data.
        /// </summary>
        /// <param name="omniSearchInstanceDetails">The omni search instance details.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchInstanceDetailsToData operation
        /// </summary>
        public static IList<OmniSearchInstanceDetailData>? ConvertOmniSearchInstanceDetailsToData(
            IList<IOmniSearchInstanceDetail>? omniSearchInstanceDetails)
        {
            return omniSearchInstanceDetails == null
                       ? null
                       : omniSearchInstanceDetails.Select(ConvertOmniSearchInstanceDetailToData).ToList();
        }

        #endregion

        #region Turnaround

        /// <summary>
        /// Converts the omni search turnaround detail to data.
        /// </summary>
        /// <param name="omniSearchTurnaroundDetail">The omni search turnaround detail.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchTurnaroundDetailToData operation
        /// </summary>
        public static OmniSearchTurnaroundDetailData? ConvertOmniSearchTurnaroundDetailToData(
            IOmniSearchTurnaroundDetail? omniSearchTurnaroundDetail)
        {
            return omniSearchTurnaroundDetail == null
                       ? null
                       : new OmniSearchTurnaroundDetailData(omniSearchTurnaroundDetail.TurnaroundId,
                                                            omniSearchTurnaroundDetail.CreatedDate,
                                                            omniSearchTurnaroundDetail.ServiceRequirementId,
                                                            omniSearchTurnaroundDetail.ServicerequirementName,
                                                            omniSearchTurnaroundDetail.DeliveryPointId,
                                                            omniSearchTurnaroundDetail.DeliveryPointName,
                                                            omniSearchTurnaroundDetail.CustomerId,
                                                            omniSearchTurnaroundDetail.CustomerStatusId,
                                                            omniSearchTurnaroundDetail.CustomerName,
                                                            omniSearchTurnaroundDetail.ItemName,
                                                            omniSearchTurnaroundDetail.DeliveryNoteId,
                                                            omniSearchTurnaroundDetail.Expiry,
                                                            omniSearchTurnaroundDetail.LegacyInternalId,
                                                            omniSearchTurnaroundDetail.ExternalId,
                                                            omniSearchTurnaroundDetail.Priority){IsArchived = omniSearchTurnaroundDetail.IsArchived};
        }

        /// <summary>
        /// Converts the omni search turnaround details to data.
        /// </summary>
        /// <param name="omniSearchTurnaroundDetails">The omni search turnaround details.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchTurnaroundDetailsToData operation
        /// </summary>
        public static IList<OmniSearchTurnaroundDetailData>? ConvertOmniSearchTurnaroundDetailsToData(
            IList<IOmniSearchTurnaroundDetail>? omniSearchTurnaroundDetails)
        {
            return omniSearchTurnaroundDetails == null
                       ? null
                       : omniSearchTurnaroundDetails.Select(ConvertOmniSearchTurnaroundDetailToData).ToList();
        }

        #endregion

        #region DeliveryNote

        /// <summary>
        /// Converts the omni search delivery notes detail to data.
        /// </summary>
        /// <param name="omniSearchDeliveryNotesDetail">The omni search delivery notes detail.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchDeliveryNotesDetailToData operation
        /// </summary>
        public static OmniSearchDeliveryNotesDetailData? ConvertOmniSearchDeliveryNotesDetailToData(
            IOmniSearchDeliveryNotesDetail? omniSearchDeliveryNotesDetail)
        {
            return omniSearchDeliveryNotesDetail == null
                       ? null
                       : new OmniSearchDeliveryNotesDetailData(omniSearchDeliveryNotesDetail.DeliveryNoteId,
                                                               omniSearchDeliveryNotesDetail.PrintedUserId,
                                                               omniSearchDeliveryNotesDetail.UserName,
                                                               omniSearchDeliveryNotesDetail.ExternalId,
                                                               omniSearchDeliveryNotesDetail.LegacyId,
                                                               omniSearchDeliveryNotesDetail.FacilityId,
                                                               omniSearchDeliveryNotesDetail.FacilityName,
                                                               omniSearchDeliveryNotesDetail.CustomerId,
                                                               omniSearchDeliveryNotesDetail.CustomerStatusId,
                                                               omniSearchDeliveryNotesDetail.CustomerName,
                                                               omniSearchDeliveryNotesDetail.DeliveryPointId,
                                                               omniSearchDeliveryNotesDetail.DeliveryPointName,
                                                               omniSearchDeliveryNotesDetail.PrintStatus,
                                                               omniSearchDeliveryNotesDetail.CreateDate,omniSearchDeliveryNotesDetail.PrintedDate);
        }

        /// <summary>
        /// Converts the omni search delivery notes details to data.
        /// </summary>
        /// <param name="omniSearchDeliveryNotesDetails">The omni search delivery notes details.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchDeliveryNotesDetailsToData operation
        /// </summary>
        public static IList<OmniSearchDeliveryNotesDetailData>? ConvertOmniSearchDeliveryNotesDetailsToData(
            IList<IOmniSearchDeliveryNotesDetail>? omniSearchDeliveryNotesDetails)
        {
            return omniSearchDeliveryNotesDetails == null
                       ? null
                       : omniSearchDeliveryNotesDetails.Select(ConvertOmniSearchDeliveryNotesDetailToData).ToList();
        }

        #endregion

        #region Defect

        /// <summary>
        /// Converts the omni search defect detail data.
        /// </summary>
        /// <param name="omniSearchDefectsDetail">The omni search defects detail.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchDefectDetailData operation
        /// </summary>
        public static OmniSearchDefectsDetailData? ConvertOmniSearchDefectDetailData(
            IOmniSearchDefectsDetail? omniSearchDefectsDetail)
        {
            return omniSearchDefectsDetail == null
                       ? null
                       : new OmniSearchDefectsDetailData(omniSearchDefectsDetail.CustomerName,
                                                         omniSearchDefectsDetail.CustomerId,
                                                         omniSearchDefectsDetail.CustomerStatusId,
                                                         omniSearchDefectsDetail.DefectClassification,
                                                         omniSearchDefectsDetail.DefectSeverity,
                                                         omniSearchDefectsDetail.DefectStatus,
                                                         omniSearchDefectsDetail.DefectId,
                                                         omniSearchDefectsDetail.DeliveryPointName,
                                                         omniSearchDefectsDetail.DeliveryPointId,
                                                         omniSearchDefectsDetail.LegacyInternalId,
                                                         omniSearchDefectsDetail.LegacyExternalId,
                                                         omniSearchDefectsDetail.Raised,
                                                         omniSearchDefectsDetail.ReportingDepartment,
                                                         omniSearchDefectsDetail.ReportingUserName,
                                                         omniSearchDefectsDetail.ReportingUserPosition,
                                                         omniSearchDefectsDetail.TurnaroundId,
                                                         omniSearchDefectsDetail.TurnaroundExternalId,
                                                         omniSearchDefectsDetail.DefectType);
        }

        /// <summary>
        /// Converts the omni search defect details data.
        /// </summary>
        /// <param name="omniSearchDefectsDetails">The omni search defects details.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchDefectDetailsData operation
        /// </summary>
        public static IList<OmniSearchDefectsDetailData>? ConvertOmniSearchDefectDetailsData(
            IList<IOmniSearchDefectsDetail>? omniSearchDefectsDetails)
        {
            return omniSearchDefectsDetails == null
                       ? null
                       : omniSearchDefectsDetails.Select(ConvertOmniSearchDefectDetailData).ToList();
        }

        #endregion

        #region User

        /// <summary>
        /// Converts the omni search user detail data.
        /// </summary>
        /// <param name="omniSearchUserDetail">The omni search user detail.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchUserDetailData operation
        /// </summary>
        public static OmniSearchUserDetailData? ConvertOmniSearchUserDetailData(
            IOmniSearchUserDetail? omniSearchUserDetail)
        {
            return omniSearchUserDetail == null
                       ? null
                       : new OmniSearchUserDetailData(omniSearchUserDetail.UserUid,
                                                      omniSearchUserDetail.FirstName,
                                                      omniSearchUserDetail.Surname,
                                                      omniSearchUserDetail.ExternalId,
                                                      omniSearchUserDetail.EmailAddress,
                                                      omniSearchUserDetail.CreationDate,
                                                      omniSearchUserDetail.IsLockedOut,
                                                      omniSearchUserDetail.IsExpired, omniSearchUserDetail.UserName) { Archived = omniSearchUserDetail.Archived };
        }

        /// <summary>
        /// Converts the omni search user details data.
        /// </summary>
        /// <param name="omniSearchUserDetails">The omni search user details.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchUserDetailsData operation
        /// </summary>
        public static IList<OmniSearchUserDetailData>? ConvertOmniSearchUserDetailsData(
            IList<IOmniSearchUserDetail>? omniSearchUserDetails)
        {
            return omniSearchUserDetails == null
                       ? null
                       : omniSearchUserDetails.Select(ConvertOmniSearchUserDetailData).ToList();
        }

        #endregion

        #region Batches
        /// <summary>
        /// Converts the omni search user detail data.
        /// </summary>
        /// <param name="omniSearchUserDetail">The omni search user detail.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchBatchData operation
        /// </summary>
        public static OmniSearchBatchDetailData? ConvertOmniSearchBatchData(
            IOmniSearchBatchDetail? omniSearchUserDetail)
        {
            return omniSearchUserDetail == null
                       ? null
                       : new OmniSearchBatchDetailData(omniSearchUserDetail.BatchId,
                                                      omniSearchUserDetail.ExternalId,
                                                      omniSearchUserDetail.CycleTypeName,
                                                      omniSearchUserDetail.CreationDate, omniSearchUserDetail.IsArchived) ;
        }
        /// <summary>
        /// Converts the omni search user detail data.
        /// </summary>
        /// <param name="omniSearchDetail">The omni search user detail.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchDeliveryPointData operation
        /// </summary>
        public static OmniSearchDeliveryPointDetailData? ConvertOmniSearchDeliveryPointData(
            IOmniSearchDeliveryPointDetail? omniSearchDetail)
        {
            return omniSearchDetail == null
                       ? null
                       : new OmniSearchDeliveryPointDetailData(omniSearchDetail.DeliveryPointId,
                                                      omniSearchDetail.Name,
                                                      omniSearchDetail.CustomerName) { IsArchived = omniSearchDetail.IsArchived };
        }
        /// <summary>
        /// Converts the omni search user detail data.
        /// </summary>
        /// <param name="omniSearchDetail">The omni search user detail.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchLoanSetsData operation
        /// </summary>
        public static OmniSearchLoanSetsDetailData? ConvertOmniSearchLoanSetsData(
            IOmniSearchLoanSetsDetail? omniSearchDetail)
        {
            return omniSearchDetail == null
                       ? null
                       : new OmniSearchLoanSetsDetailData(omniSearchDetail.LoanSetId,
                                                      omniSearchDetail.ExternalId,
                                                      omniSearchDetail.DeliveryDate,
                                                      omniSearchDetail.NoOfTrays,
                                                      omniSearchDetail.LoanSupplier,
                                                      omniSearchDetail.Consignment,
                                                      omniSearchDetail.NextProcedureDate,
                                                      omniSearchDetail.ReturnDate,
                                                      omniSearchDetail.LoanStatusId);
        }
        /// <summary>
        /// Converts the omni search user details data.
        /// </summary>
        /// <param name="omniSearchUserDetails">The omni search user details.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchBatchDetailsData operation
        /// </summary>
        public static IList<OmniSearchBatchDetailData>? ConvertOmniSearchBatchDetailsData(
            IList<IOmniSearchBatchDetail>? omniSearchUserDetails)
        {
            return omniSearchUserDetails == null
                       ? null
                       : omniSearchUserDetails.Select(ConvertOmniSearchBatchData).ToList();
        }

        /// <summary>
        /// Converts the omni search user details data.
        /// </summary>
        /// <param name="omniSearchDetails">The omni search user details.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchDeliveryPointDetailsData operation
        /// </summary>
        public static IList<OmniSearchDeliveryPointDetailData>? ConvertOmniSearchDeliveryPointDetailsData(
            IList<IOmniSearchDeliveryPointDetail>? omniSearchDetails)
        {
            return omniSearchDetails == null
                       ? null
                       : omniSearchDetails.Select(ConvertOmniSearchDeliveryPointData).ToList();
        }

        /// <summary>
        /// Converts the omni search user details data.
        /// </summary>
        /// <param name="omniSearchDetails">The omni search user details.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchLoanSetsDetailsData operation
        /// </summary>
        public static IList<OmniSearchLoanSetsDetailData>? ConvertOmniSearchLoanSetsDetailsData(
            IList<IOmniSearchLoanSetsDetail>? omniSearchDetails)
        {
            return omniSearchDetails == null
                       ? null
                       : omniSearchDetails.Select(ConvertOmniSearchLoanSetsData).ToList();
        }
        #endregion

        #region OmniSearch

        /// <summary>
        /// Converts the omni search to data.
        /// </summary>
        /// <param name="omniSearch">The omni search.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchToData operation
        /// </summary>
        public static OmniSearchData? ConvertOmniSearchToData(IOmniSearch? omniSearch)
        {
            return omniSearch == null
                       ? null
                       : new OmniSearchData
                             {
                                 Customers = ConvertOmniSearchCustomerDetailsToData(omniSearch.Customers),
                                 Defects = ConvertOmniSearchDefectDetailsData(omniSearch.Defects),
                                 DeliveryNotes = ConvertOmniSearchDeliveryNotesDetailsToData(omniSearch.DeliveryNotes),
                                 Facilities = ConvertOmniSearchFacilityDetailsToData(omniSearch.Facilities),
                                 Instances = ConvertOmniSearchInstanceDetailsToData(omniSearch.Instances),
                                 Items = ConvertOmniSearchItemDetailsToData(omniSearch.Items),
                                 Instruments=ConvertOmniSearchItemDetailsToData(omniSearch.Instruments),
                                 Turnarounds = ConvertOmniSearchTurnaroundDetailsToData(omniSearch.Turnarounds),
                                 Users = ConvertOmniSearchUserDetailsData(omniSearch.Users),
                                 Batches = ConvertOmniSearchBatchDetailsData(omniSearch.Batches),
                                 DeliveryPoints = ConvertOmniSearchDeliveryPointDetailsData(omniSearch.DeliveryPoints),
                                 LoanSets = ConvertOmniSearchLoanSetsDetailsData(omniSearch.LoanSets)
                             };
        }

        #endregion
    }
}