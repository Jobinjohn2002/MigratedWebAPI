using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public sealed class MasterDataAdapter : DataAdapterBase, IMasterDataAdapter
    {

        internal MasterDataAdapter(IUnitOfWork efUnitOfWork)
            : base(efUnitOfWork)
        {
            
        }

        #region ISearchDataAdapter Members

        /// <summary>
        /// Gets the omni search results.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        /// <summary>
        /// SearchItems operation
        /// </summary>
        public IList<Master> SearchItems(string searchText, short facilityId, DataFilter filter)
        {
            var masterRepository = new MasterRepository(InstanceFactory.GetInstance<IOperativeRepository<ContainerMaster>>(), InstanceFactory.GetInstance<IOperativeRepository<ItemMaster>>(),
                                      WorkUnit);
            return masterRepository.SearchItems(searchText, facilityId, filter);
        }
        
        #endregion
        
        #region "Master Items"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="masterParameters"></param>
        /// <returns></returns>
        /// <summary>
        /// ReadPagedMasters operation
        /// </summary>
        public IList<MasterData> ReadPagedMasters(MasterParametersData masterParameters, UserCultureData userCultureData)
        {
            try
            {
                var masterRepository = new MasterRepository(InstanceFactory.GetInstance<IOperativeRepository<ContainerMaster>>(), InstanceFactory.GetInstance<IOperativeRepository<ItemMaster>>(),
                                         WorkUnit);
                return masterRepository.ReadPagedMasters(masterParameters, userCultureData);
            }
            catch (Exception)
            {
               
                throw;
            }
        }

        #endregion

        #region "Alerts"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="masterParameters"></param>
        /// <returns></returns>
        /// <summary>
        /// GetAlerts operation
        /// </summary>
        public IList<DashboardItem> GetAlerts(short facilityId)
        {
            var masterRepository = new MasterRepository(InstanceFactory.GetInstance<IOperativeRepository<ContainerMaster>>(), InstanceFactory.GetInstance<IOperativeRepository<ItemMaster>>(),
                InstanceFactory.GetInstance<IOperativeRepository<Defect>>(), InstanceFactory.GetInstance<IOperativeRepository<Customer>>(), WorkUnit);
            return masterRepository.GetAlerts(facilityId);
        }

        #endregion

        #region "Alerts"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="masterParameters"></param>
        /// <returns></returns>
        /// <summary>
        /// GetDashboardSummary operation
        /// </summary>
        public DashboardSummaryData GetDashboardSummary(short facilityId)
        {
            var masterRepository = new MasterRepository(InstanceFactory.GetInstance<IOperativeRepository<ContainerMaster>>(), InstanceFactory.GetInstance<IOperativeRepository<ItemMaster>>(),
                InstanceFactory.GetInstance<IOperativeRepository<Defect>>(), InstanceFactory.GetInstance<IOperativeRepository<Customer>>(), WorkUnit);
            return masterRepository.GetDashboardSummary(facilityId);
        }

        #endregion
    }
}
