using System.Linq;
using SynergyApplicationFrameworkApi.Application.DTOs; //Fix for model move
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class ServiceRequirementContractedHoursRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public ServiceRequirementContractedHours Get(int serviceRequirementContractedHoursId)
        {
            return Repository.Find(serviceRequirementContractedHours => serviceRequirementContractedHours.ServiceRequirementContractedHoursId == serviceRequirementContractedHoursId).FirstOrDefault();
        }

        /// <summary>
        /// GetByServiceRequirementId operation
        /// </summary>
        public IQueryable<ServiceRequirementContractedHours> GetByServiceRequirementId(int serviceRequirementId)
        {
            return Repository.Find(serviceRequirementContractedHours => serviceRequirementContractedHours.ServiceRequirementId == serviceRequirementId).AsQueryable();
        }
	}
}