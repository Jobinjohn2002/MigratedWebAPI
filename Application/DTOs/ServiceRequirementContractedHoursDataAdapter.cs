using System;
using System.Linq;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class ServiceRequirementContractedHoursDataAdapter : DataAdapterBase, IServiceRequirementContractedHoursDataAdapter
	{	   
      	/// <summary>
      	/// ArchiveServiceRequirementContractedHours operation
      	/// </summary>
      	public  void ArchiveServiceRequirementContractedHours(int serviceRequirementContractedHoursId, int userId)
		{		 
		     throw new NotImplementedException();
		}

        /// <summary>
        /// GetByServiceRequirementId operation
        /// </summary>
        public IQueryable<ServiceRequirementContractedHours> GetByServiceRequirementId(int serviceRequirementId)
        {
            try
            {
                var serviceRequirementContractedHoursRepository = ServiceRequirementContractedHoursRepository.New(WorkUnit);
                return serviceRequirementContractedHoursRepository.GetByServiceRequirementId(serviceRequirementId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
	}
}
		