using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    public partial class ServiceRequirementRepository
    {
        /// <summary>
        /// Get operation
        /// </summary>
        public ServiceRequirement Get(Guid uid)
        {
            return Repository.Find(sr => sr.ServiceRequirementUid == uid).FirstOrDefault();
        }

        /// <summary>
        /// GetAllServiceRequirementsByCustomerUid operation
        /// </summary>
        public IQueryable<ServiceRequirement> GetAllServiceRequirementsByCustomerUid(Guid customerUid)
        {
            return Repository.All();
        }
    }
}