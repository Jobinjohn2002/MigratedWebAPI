using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    /// <summary>
    /// OmniSearchRepository
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// OmniSearchRepository
    /// </summary>
    public class OmniSearchRepository
    {
        /// <summary>
        /// Returns the top level summary values for matches against the search text.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="canIncludeArchived"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetOmniSearchSummaryResults operation
        /// </summary>
        public OmniSearchSummary GetOmniSearchSummaryResults(string searchText, short facilityId, bool canIncludeArchived)
        {
            var omni = new OmniSearchSummary();

            using (var context = new OperativeModelContainer())
            {
                foreach (var results in context.admapp_ReadOmniSearchSummary(searchText, facilityId, canIncludeArchived))
                {
                    omni.Users = results.Users;
                    omni.Items = results.Items;
                    omni.Instruments = results.Instruments;
                    omni.Instances = results.Instances;
                    omni.Turnarounds = results.Turnarounds;
                    omni.Customers = results.Customers;
                    omni.DeliveryNotes = results.DeliveryNotes;
                    omni.Defects = results.Defects;
                    omni.Batches = results.BatchNumbers;
                    omni.DeliveryPoints = results.DeliveryPoints;
                    omni.LoanSets = results.LoanSets;
                }

                return omni;
            }
        }

        /// <summary>
        /// Returns the customer search results detail for matches against the search text.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="canIncludeArchived"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetOmniSearchCustomerDetailResults operation
        /// </summary>
        public IList<OmniSearchCustomerDetail> GetOmniSearchCustomerDetailResults(string searchText, short facilityId,bool canIncludeArchived)
        {
            var customer = new List<OmniSearchCustomerDetail>();

            {
                customer.AddRange(context.admapp_ReadOmniSearchCustomerDetail(searchText, facilityId, canIncludeArchived).Select(results => new OmniSearchCustomerDetail(results.CustomerId,
                                                                                                                                                results.CustomerStatusId,
                                                                                                                                                results.CustomerName,
                                                                                                                                                results.Created,
                                                                                                                                                results.Revision,
                                                                                                                                                results.FacilitName,
                                                                                                                                                results.Facilityid,
                                                                                                                                                results.CustomerGroupName,
                                                                                                                                                results.CustomerGroupid, results.IsArchived==1)));
            }

            return customer;
        }

        /// <summary>
        /// Returns the facility search results detail for matches against the search text.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <param name="facilityId"></param>
        /// <param name="canIncludeArchived"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetOmniSearchFacilityDetailResults operation
        /// </summary>
        public IList<OmniSearchFacilityDetail> GetOmniSearchFacilityDetailResults(string searchText, short facilityId, bool canIncludeArchived)
        {
            var facility = new List<OmniSearchFacilityDetail>();

            {
                facility.AddRange(context.admapp_ReadOmniSearchFacilityDetail(searchText, canIncludeArchived).Select(results => new OmniSearchFacilityDetail(
                    results.Facilityid,
                    results.Text, results.IsArchived == 1)
                    ));
            }

            return facility;
        }

        /// <summary>
        /// Returns the defects search results detail for matches against the search text.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetOmniSearchDefectDetailResults operation
        /// </summary>
        public IList<OmniSearchDefectsDetail> GetOmniSearchDefectDetailResults(string searchText, short facilityId)
        {
            var defects = new List<OmniSearchDefectsDetail>();

            {
                defects.AddRange(context.admapp_ReadOmniSearchDefectDetail(searchText, facilityId).Select(results => new OmniSearchDefectsDetail(results.CustomerName,
                                                                                                                                            results.Customerid,
                                                                                                                                            results.CustomerStatusId,
                                                                                                                                            results.DefectClassification,
                                                                                                                                            results.DefectSeverity,
                                                                                                                                            results.DefectStatus,
                                                                                                                                            results.Defectid,
                                                                                                                                            results.DeliveryPointName,
                                                                                                                                            results.DeliveryPointid,
                                                                                                                                            results.LegacyInternalId,
                                                                                                                                            results.LegacyExternalId,
                                                                                                                                            results.Raised,
                                                                                                                                            results.ReportingDepartment,
                                                                                                                                            results.ReporterUserName,
                                                                                                                                            results.ReporterUserPosition,
                                                                                                                                            results.Turnaroundid,
                                                                                                                                            results.TurnaroundExternalId.ToString(),
                                                                                                                                            results.DefectType)));
            }

            return defects;
        }

        /// <summary>
        /// Returns the delivery notes search results detail for matches against the search text.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetOmniSearchDeliveryNoteDetailResults operation
        /// </summary>
        public IList<OmniSearchDeliveryNotesDetail> GetOmniSearchDeliveryNoteDetailResults(string searchText, short facilityId)
        {
            var deliveryNotes = new List<OmniSearchDeliveryNotesDetail>();

            {
                deliveryNotes.AddRange(context.admapp_ReadOmniSearchDeliveryNoteDetail(searchText, facilityId).Select(results => new OmniSearchDeliveryNotesDetail(results.DeliveryNoteid, 0, "",
                                                                                                                                                                results.ExternalId.ToString(),
                                                                                                                                                                results.Facilityid,
                                                                                                                                                                results.FacilityName,
                                                                                                                                                                results.Customerid,
                                                                                                                                                                results.CustomerStatusId,
                                                                                                                                                                results.CustomerName,
                                                                                                                                                                results.DeliveryPointid,
                                                                                                                                                                results.DeliveryPointName,
                                                                                                                                                                results.PrintStatus, results.Printed)));
            }

            return deliveryNotes;
        }

        /// <summary>
        /// Returns the item search results detail for matches against the search text.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="canIncludeArchived"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetOmniSearchItemDetailResults operation
        /// </summary>
        public IList<OmniSearchItemDetail> GetOmniSearchItemDetailResults(string searchText, short facilityId, bool canIncludeArchived)
        {
            var items = new List<OmniSearchItemDetail>();

            {
                items.AddRange(context.admapp_ReadOmniSearchMasterDetail(searchText, facilityId, canIncludeArchived).Select(results => new OmniSearchItemDetail(results.MasterUId,
                                                                                                                                        results.MasterSubtype,
                                                                                                                                        results.Name,
                                                                                                                                        results.LegacyInternalId,
                                                                                                                                        results.ExternalId,
                                                                                                                                        results.Status,
                                                                                                                                        results.SubType,
                                                                                                                                        results.BaseType,
                                                                                                                                        results.NumberOfInstance, results.MasterSubtype, results.CustomerName){IsArchived = results.IsArchived==1}));
            }

            return items;

        }

        /// <summary>
        /// GetOmniSearchInstrumentsDetailResults operation
        /// </summary>
        public IList<OmniSearchItemDetail> GetOmniSearchInstrumentsDetailResults(string searchText, short facilityId,bool canIncludeArchived)
        {
            var items = new List<OmniSearchItemDetail>();

            {
                items.AddRange(context.admapp_ReadOmniSearchItemDetail(searchText, facilityId, canIncludeArchived).Select(results => new OmniSearchItemDetail(results.ItemMasterId,
                                                                                                                                        0,
                                                                                                                                        results.Name,
                                                                                                                                        null,
                                                                                                                                        results.ExternalId,
                                                                                                                                        null,
                                                                                                                                        results.SubType,
                                                                                                                                        results.BaseType,
                                                                                                                                        null, 0, null
                                                                                                                                        ) {IsArchived = results.IsArchived ==1 }));
            }

            return items;

        }

        /// <summary>
        /// Returns the instance search results detail for matches against the search text.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="canIncludeArchived"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetOmniSearchInstanceDetailResults operation
        /// </summary>
        public IList<OmniSearchInstanceDetail> GetOmniSearchInstanceDetailResults(string searchText, short facilityId, bool canIncludeArchived)
        {
            var instances = new List<OmniSearchInstanceDetail>();

            {
                instances.AddRange(context.admapp_ReadOmniSearchInstanceDetail(searchText, facilityId, canIncludeArchived).Select(results => new OmniSearchInstanceDetail(results.Instanceid,
                                                                                                                                                results.DeliveryPoint,
                                                                                                                                                results.CustomerStatusId,
                                                                                                                                                results.Customer,
                                                                                                                                                results.LegacyId,
                                                                                                                                                results.LegacyExternalId,
                                                                                                                                                results.ContainerInstancePrimaryId.ToString(),
                                                                                                                                                results.SuperType, results.IsArchived == 1)));
            }

            return instances;
        }

        /// <summary>
        /// Returns the turnaround search results detail for matches against the search text.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="canIncludeArchived"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetOmniSearchTurnaroundDetailResults operation
        /// </summary>
        public IList<OmniSearchTurnaroundDetail> GetOmniSearchTurnaroundDetailResults(string searchText, short facilityId, bool canIncludeArchived)
        {
            var turnarounds = new List<OmniSearchTurnaroundDetail>();

            {
                turnarounds.AddRange(context.admapp_ReadOmniSearchTurnaroundDetail(searchText, facilityId, canIncludeArchived).Select(results => new OmniSearchTurnaroundDetail(
                    results.Turnaroundid,
                    results.CreatedDate,
                    results.ServiceRequirementid,
                    results.ServicerequirementName,
                    results.DeliveryPointid,
                    results.DeliveryPointName,
                    results.Customerid,
                    results.CustomerStatusId,
                    results.CustomerName,
                    results.ItemName,
                    results.DeliveryNoteid,
                    results.Expiry,
                    results.LegacyInternalId,
                    results.ExternalId.GetValueOrDefault(),
                    results.IsArchived == 1
                    )//,string lastEvent,DateTime? lastEventDate
                    ));
            }

            return turnarounds.OrderBy(t => t.Expiry).ToList();
        }

        /// <summary>
        /// Returns the turnaround search results detail for matches against the search text.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="canIncludeArchived"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetOmniSearchUserDetailResults operation
        /// </summary>
        public IList<OmniSearchUserDetail> GetOmniSearchUserDetailResults(string searchText, short facilityId, bool canIncludeArchived)
        {
            var users = new List<OmniSearchUserDetail>();

            {
                users.AddRange(context.admapp_ReadOmniSearchUserDetail(searchText, facilityId, canIncludeArchived).Select(results => new OmniSearchUserDetail(results.Userid,
                                                                                                                                    results.FirstName,
                                                                                                                                    results.Surname,
                                                                                                                                    results.ExternalID,
                                                                                                                                    results.EmailAddress,
                                                                                                                                    results.Created,
                                                                                                                                    results.IsLockedOut,
                                                                                                                                    results.IsExpired, results.Username) { Archived = results.Archived }));
            }

            return users;
        }

        /// <summary>
        /// Returns the batch search results detail for matches against the search text.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="canIncludeArchived"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetOmniSearchBatchDetailResults operation
        /// </summary>
        public IList<OmniSearchBatchDetail> GetOmniSearchBatchDetailResults(string searchText, short facilityId, bool canIncludeArchived)
        {
            var batches = new List<OmniSearchBatchDetail>();

            {
                batches.AddRange(context.admapp_ReadOmniSearchBatchDetail(searchText, facilityId, canIncludeArchived).Select(results => new OmniSearchBatchDetail(results.BatchId,
                                                                                                                                    results.ExternalId,
                                                                                                                                    results.CycleTypeName,
                                                                                                                                    results.Created,
                                                                                                                                    results.IsArchived == 1
                                                                                                                                   )));
            }

            return batches;
        }

        /// <summary>
        /// Returns the delivery point search results detail for matches against the search text.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="canIncludeArchived"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetOmniSearchDeliveryPointDetailResults operation
        /// </summary>
        public IList<OmniSearchDeliveryPointDetail> GetOmniSearchDeliveryPointDetailResults(string searchText, short facilityId, bool canIncludeArchived)
        {
            var deliveryPoints = new List<OmniSearchDeliveryPointDetail>();

            {
                deliveryPoints.AddRange(context.admapp_ReadOmniSearchDeliveryPointDetail(searchText, facilityId, canIncludeArchived).Select(results => new OmniSearchDeliveryPointDetail(results.DeliveryPointId,
                                                                                                                                    results.Name, results.CustomerName) { IsArchived = results.IsArchived == 1 }));
            }

            return deliveryPoints;
        }

        /// <summary>
        /// Returns the loanset search results detail for matches against the search text.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="canIncludeArchived"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetOmniSearchLoanSetsDetailResults operation
        /// </summary>
        public IList<OmniSearchLoanSetsDetail> GetOmniSearchLoanSetsDetailResults(string searchText, short facilityId, bool canIncludeArchived)
        {
            var loanSets = new List<OmniSearchLoanSetsDetail>();
            {
                loanSets.AddRange(context.admapp_ReadOmniSearchLoanSetsDetail(searchText, facilityId, canIncludeArchived).Select(results => new OmniSearchLoanSetsDetail(results.LoanSetId, results.ExternalId, results.DeliveryDate,
                                                                                                                                    results.NoOfTrays.GetValueOrDefault(0), results.LoanSupplier, results.Consignment, results.DateRequired, results.ReturnDate, (LoanSetStatusTypeIdentifier)results.StatusId)));
            }

            return loanSets;
        }

        /// <summary>
        /// ValidateOmniSearchForCount operation
        /// </summary>
        public int ValidateOmniSearchForCount(string searchText, short facilityId, bool canIncludeArchived, string itemType)
        {
            int itemCount = 0;
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("@SearchText", searchText);
                dictionary.Add("@FacilityId", facilityId);
                dictionary.Add("@CanIncludeArchived", canIncludeArchived);
                dictionary.Add("@ItemType", itemType);

                var datacommand = DataCommandFactory.CreateCommand(context, CommandType.StoredProcedure, "admapp_ReadOmniSearchSummaryForCount", dictionary);
                var result = datacommand.ExecuteScalar();

                itemCount = Int16.Parse(result.ToString());
            }
            return itemCount;
        }
    }
}
