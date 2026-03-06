using System.Linq;
using SynergyApplicationFrameworkApi.Application.DTOs; //Fix for model move
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class CostingModelTypeRepository
	{
        /// <summary>
        /// Get operation
        /// </summary>
        public CostingModelType Get(int costingModelTypeId)
        {
            return Repository.Find(costingModelType => costingModelType.CostingModelTypeId == costingModelTypeId).FirstOrDefault();
        }
	}
}