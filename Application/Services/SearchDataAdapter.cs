using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public sealed class SearchDataAdapter : DataAdapterBase, ISearchDataAdapter
    {

        internal SearchDataAdapter(IUnitOfWork efUnitOfWork)
            : base(efUnitOfWork)
        {
           
        }

        #region ISearchDataAdapter Members

        /// <summary>
        /// Gets the omni search results.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <param name="facilityId"></param>
        /// <param name="canIncludeArchived"></param>
        /// <returns></returns>
        /// <summary>
        /// GetOmniSearchResults operation
        /// </summary>
        public IOmniSearchSummary GetOmniSearchResults(string searchText, short facilityId, bool canIncludeArchived)
        {
            try
            {
                var summaryRepository = new OmniSearchRepository();
                return summaryRepository.GetOmniSearchSummaryResults(searchText, facilityId, canIncludeArchived);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Gets the omni search detail.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <param name="facilityId"></param>
        /// <param name="searchType">Type of the search.</param>
        /// <param name="canIncludeArchived"></param>
        /// <returns></returns>
        /// <summary>
        /// GetOmniSearchDetail operation
        /// </summary>
        public IOmniSearch GetOmniSearchDetail(string searchText, short facilityId, OmniSearchType searchType, bool canIncludeArchived)
        {
            try
            {
                var omniSearch = new OmniSearch();
                var summaryRepository = new OmniSearchRepository();
                omniSearch.Customers = new List<IOmniSearchCustomerDetail>();

                switch (searchType)
                {
                    case OmniSearchType.Customers:
                        omniSearch.Customers = summaryRepository.GetOmniSearchCustomerDetailResults(searchText, facilityId, canIncludeArchived).ToList< IOmniSearchCustomerDetail>();
                        break;
                    case OmniSearchType.Defects:
                        omniSearch.Defects = summaryRepository.GetOmniSearchDefectDetailResults(searchText, facilityId).ToList<IOmniSearchDefectsDetail>();
                        break;
                    case OmniSearchType.DeliveryNotes:
                        omniSearch.DeliveryNotes = summaryRepository.GetOmniSearchDeliveryNoteDetailResults(searchText, facilityId).ToList<IOmniSearchDeliveryNotesDetail>();
                        break;
                    case OmniSearchType.Items:
                        omniSearch.Items = summaryRepository.GetOmniSearchItemDetailResults(searchText, facilityId, canIncludeArchived).ToList<IOmniSearchItemDetail>();
                        break;
                    case OmniSearchType.Instruments:
                        omniSearch.Instruments = summaryRepository.GetOmniSearchInstrumentsDetailResults(searchText, facilityId, canIncludeArchived).ToList<IOmniSearchItemDetail>();
                        break;
                    case OmniSearchType.Instances:
                        omniSearch.Instances = summaryRepository.GetOmniSearchInstanceDetailResults(searchText, facilityId, canIncludeArchived).ToList<IOmniSearchInstanceDetail>();
                        break;
                    case OmniSearchType.Turnarounds:
                        omniSearch.Turnarounds = summaryRepository.GetOmniSearchTurnaroundDetailResults(searchText, facilityId, canIncludeArchived).ToList<IOmniSearchTurnaroundDetail>();
                        break;
                    case OmniSearchType.Users:
                        omniSearch.Users = summaryRepository.GetOmniSearchUserDetailResults(searchText, facilityId, canIncludeArchived).ToList<IOmniSearchUserDetail>();
                        break;
                    case OmniSearchType.Batches:
                        omniSearch.Batches = summaryRepository.GetOmniSearchBatchDetailResults(searchText, facilityId, canIncludeArchived).ToList<IOmniSearchBatchDetail>();
                        break;
                    case OmniSearchType.DeliveryPoints:
                        omniSearch.DeliveryPoints = summaryRepository.GetOmniSearchDeliveryPointDetailResults(searchText, facilityId, canIncludeArchived).ToList<IOmniSearchDeliveryPointDetail>();
                        break;

                    case OmniSearchType.LoanSets:
                        omniSearch.LoanSets = summaryRepository.GetOmniSearchLoanSetsDetailResults(searchText, facilityId, canIncludeArchived).ToList<IOmniSearchLoanSetsDetail>();
                        break;
                }

                return omniSearch;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// ValidateOmniSearchForCount operation
        /// </summary>
        public int ValidateOmniSearchForCount(string searchText, short facilityId, bool canIncludeArchived, string itemType)
        {
            try
            {
                var summaryRepository = new OmniSearchRepository();
                return summaryRepository.ValidateOmniSearchForCount(searchText, facilityId, canIncludeArchived, itemType);
            }
            catch (Exception)
            {
               
                throw;
            }
        }

        #endregion
    }
}