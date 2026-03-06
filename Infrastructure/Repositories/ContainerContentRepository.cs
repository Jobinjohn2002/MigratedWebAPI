using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    public partial class ContainerContentRepository
    {
        /// <summary>
        /// Get operation
        /// </summary>
        public ContainerContent Get(int id)
        {
            return Repository.Find(cc => cc.ContainerContentId == id).FirstOrDefault();
        }

        /// <summary>
        /// ReadContainerContent operation
        /// </summary>
        public IQueryable<ContainerContent> ReadContainerContent(int containerMasterId)
        {
            return Repository.Find(cc => cc.ContainerMasterId == containerMasterId);
        }

        /// <summary>
        /// ReadContainerContentByItemMasterId operation
        /// </summary>
        public ContainerContent ReadContainerContentByItemMasterId(int containerMasterId, int ItemMasterDefinitionId)
        {
            return Repository.Find(cc => cc.ContainerMasterId == containerMasterId && cc.ItemMasterDefinitionId == ItemMasterDefinitionId).FirstOrDefault();
        }

        /// <summary>
        /// ReadItemMasterByContainerContent operation
        /// </summary>
        public ItemMaster ReadItemMasterByContainerContent(int containerContentId)
        {
            var itemMaster =
                Repository.Find(cc => cc.ContainerContentId == containerContentId).Select(
                    cc => cc.ItemMasterDefinition).SelectMany(imd => imd.ItemMaster).Where(im => im.ItemStatusId == (int)ItemStatusTypeIdentifier.Active).FirstOrDefault();

            return itemMaster;
        }

        /// <summary>
        /// SearchItemsByMaster operation
        /// </summary>
        public IEnumerable<Master> SearchItemsByMaster(string searchText, int containerMasterId, short facilityId)
        {
            var items = Repository.Find(cc => cc.ContainerMasterId == containerMasterId && cc.ItemMasterDefinition.ItemMaster.Any(im => im.Text.Contains(searchText)))
                .OrderBy(i=>i.Position)
                .Select(cc => new 
                {
                    ComponentQuntity=cc.Quantity, 
                    item = cc.ItemMasterDefinition.ItemMaster.FirstOrDefault(im => im.ItemStatusId==1)
                }).ToList();
            return items.Where(i => i.item != null).Select(cc => new Master(cc.item) { ComponentQuntity = cc.ComponentQuntity });
        } 
    }
}