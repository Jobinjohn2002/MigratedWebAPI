using System;
using System.Linq;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class CustomerCostingModelRepository
    {
        /// <summary>
        /// Get operation
        /// </summary>
        public CustomerCostingModel Get(int indexId)
        {
            return Repository.Find(ccm => ccm.IndexId == indexId).FirstOrDefault();
        }

        /// <summary>
        /// GetByCustomerUid operation
        /// </summary>
        public CustomerCostingModel GetByCustomerUid(Guid customerUid)
        {
            return Repository.Find(ccm => ccm.CustomerUid == customerUid).FirstOrDefault();
        }

        /// <summary>
        /// GetByCustomerCostingModelId operation
        /// </summary>
        public CustomerCostingModel GetByCustomerCostingModelId(Guid customerCostingModelUid)
        {
            return Repository.Find(ccm => ccm.CustomerCostingModelUid == customerCostingModelUid).FirstOrDefault();
        }
    }
}