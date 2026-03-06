using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    public partial class ContainerMasterDefinitionRepository
    {
		/// <summary>
		/// Get operation
		/// </summary>
		public ContainerMasterDefinition Get(int definitionId)
        {
			return Repository.Find(cmd => cmd.ContainerMasterDefinitionId == definitionId).FirstOrDefault();
        }

		/// <summary>
		/// ReadContainerMasterByMasterDefinition operation
		/// </summary>
		public ContainerMaster ReadContainerMasterByMasterDefinition(int masterDefinitionId)
        {
            return
				Repository.Find(cm => cm.ContainerMasterDefinitionId == masterDefinitionId).SelectMany(cm => cm.ContainerMasters).Where(
                    cm => cm.ItemStatusId == (int) ItemStatusTypeIdentifier.Active).OrderByDescending(cm => cm.Revision)
                    .FirstOrDefault();
        }

        /// <summary>
        /// Persist the new revision
        /// </summary>
        /// <param name="masterDefinition"></param>
        /// <summary>
        /// UpdateMasterDefinition operation
        /// </summary>
        public void UpdateMasterDefinition(ContainerMasterDefinition masterDefinition)
        {
            var context = (OperativeModelContainer)Repository.UnitOfWork.Context;
            context.SynergyUpdate(masterDefinition);
            context.SynergySaveChanges();
        }
       
    }
}