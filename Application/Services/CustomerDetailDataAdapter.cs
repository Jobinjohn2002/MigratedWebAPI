using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public sealed class CustomerDetailDataAdapter : DataAdapterBase, ICustomerDetailDataAdapter
    {

        internal CustomerDetailDataAdapter(IUnitOfWork efUnitOfWork)
            : base(efUnitOfWork)
        {
            
        }

        /// <summary>
        /// GetChargeListByCustomerDefinitionId operation
        /// </summary>
        public IList<IChargeListSummary> GetChargeListByCustomerDefinitionId(int CustomerDefinitionId)
        {
            try
            {
                var summaryRepository = new CustomerDetailRepository();
                return summaryRepository.GetChargeListByCustomerDefinitionId(CustomerDefinitionId).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// ReadCustomerIndexationByCategory operation
        /// </summary>
        public IList<ICustomerIndexationSummary> ReadCustomerIndexationByCategory(int CustomerDefinitionId)
        {
            try
            {
                var summaryRepository = new CustomerDetailRepository();
                return summaryRepository.ReadCustomerIndexationByCategory(CustomerDefinitionId).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// ReadCustomerIndexationByCategoryDetail operation
        /// </summary>
        public IList<ICustomerIndexationDetailSummary> ReadCustomerIndexationByCategoryDetail(int CustomerDefinitionId, byte IndexationCategoryId)
        {
            try
            {
                var summaryRepository = new CustomerDetailRepository();
                return summaryRepository.ReadCustomerIndexationByCategoryDetail(CustomerDefinitionId, IndexationCategoryId).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// ReadSingleUseItemByCustomerDefinitionId operation
        /// </summary>
        public IList<ISingleUseItemSummary> ReadSingleUseItemByCustomerDefinitionId(int CustomerDefinitionId)
        {
            try
            {
                var summaryRepository = new CustomerDetailRepository();
                return summaryRepository.ReadSingleUseItemByCustomerDefinitionId(CustomerDefinitionId).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// ReadSingleUseItemByContainerMasterId operation
        /// </summary>
        public IList<ISingleUseItemByContainerMasterSummary> ReadSingleUseItemByContainerMasterId(int ContainerMasterId)
        {
            try
            {
                var summaryRepository = new CustomerDetailRepository();
                return summaryRepository.ReadSingleUseItemByContainerMasterId(ContainerMasterId).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// CountDeliverableContainersByCustomerAndSearchText operation
        /// </summary>
        public int CountDeliverableContainersByCustomerAndSearchText(int customerDefinitionId, string searchText)
        {
            try
            {
                var summaryRepository = new CustomerDetailRepository();
                return summaryRepository.CountDeliverableContainersByCustomerAndSearchText(customerDefinitionId, searchText);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// UpdateContainerMasterPrice operation
        /// </summary>
        public bool UpdateContainerMasterPrice(int? containermasterid, int? pricecategorydefinitionid, decimal? manualpricecategorycharge, decimal? manualsingleuseitemcharge)
        {
            try
            {
                var summaryRepository = new CustomerDetailRepository();
                return summaryRepository.UpdateContainerMasterPrice(containermasterid, pricecategorydefinitionid, manualpricecategorycharge, manualsingleuseitemcharge);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
