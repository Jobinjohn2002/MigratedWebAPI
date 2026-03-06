using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public sealed partial class ContainerContentDataAdapter : DataAdapterBase, IContainerContentDataAdapter
    {
        #region IContainerContentDataAdapter Members

        /// <summary>
        /// ArchiveContainerContent operation
        /// </summary>
        public void ArchiveContainerContent(int containerId, int userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ReadContainerContentsByContainerMaster operation
        /// </summary>
        public IQueryable<IContainerContent> ReadContainerContentsByContainerMaster(int containerMasterId)
        {
            try
            {
                var repository = ContainerContentRepository.New(WorkUnit);
                return repository.ReadContainerContent(containerMasterId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// ReadItemMasterByContainerContent operation
        /// </summary>
        public ItemMaster ReadItemMasterByContainerContent(int containerContentsId)
        {
            try
            {
                var repository = ContainerContentRepository.New(WorkUnit);
                return repository.ReadItemMasterByContainerContent(containerContentsId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// SearchItemsByMaster operation
        /// </summary>
        public IEnumerable<Master> SearchItemsByMaster(string searchText, int masterId, short facilityId)
        {
            try
            {
                var repository = ContainerContentRepository.New(WorkUnit);
                return repository.SearchItemsByMaster(searchText, masterId, facilityId);           
            }
            catch (Exception)
            {
                

                throw;
            }
        }

        #endregion
    }
}