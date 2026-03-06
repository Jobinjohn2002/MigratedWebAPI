using System.Linq;
using SynergyApplicationFrameworkApi.Application.DTOs; //Fix for model move
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class ContractRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public Contract Get(int contractId)
        {
            return Repository.Find(contract => contract.ContractId == contractId).FirstOrDefault();
        }
	}
}