using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// ServiceRequirementItemTypeDataAdapter
    /// </summary>
    public class ServiceRequirementItemTypeDataAdapter : DataAdapterBase, IServiceRequirementItemTypeDataAdapter
    {
        internal ServiceRequirementItemTypeDataAdapter(IUnitOfWork efUnitOfWork)
            : base(efUnitOfWork)
        {
            
        }
        
        #region IServiceRequirementItemTypeDataAdapter Members

        /// <summary>
        /// Update operation
        /// </summary>
        public bool Update(int serviceRequirementId, IList<short> types)
        {
            var serviceRequirementRepository = ServiceRequirementRepository.New(WorkUnit);
            var serviceRequirementItemTypeRepository = new ServiceRequirementItemTypeRepository();
            var associateditemtypes = serviceRequirementRepository.GetServiceRequirementItemTypeByServiceRequirement(serviceRequirementId);
            using (var transaction = new TransactionScope())
            {
                foreach (var type in associateditemtypes)
                {
                    serviceRequirementItemTypeRepository.Delete(serviceRequirementId, type.ItemTypeId);
                }

                foreach (short newtypeid in types)
                {
                    serviceRequirementItemTypeRepository.Add(serviceRequirementId, newtypeid);
                }

                transaction.Complete();
                return true;
            }
        }

        #endregion
    }
}
