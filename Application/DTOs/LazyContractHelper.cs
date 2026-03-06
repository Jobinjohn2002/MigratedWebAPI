using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class LazyContractHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(Contract concreteContract, Contract genericContract)
        {
					
			concreteContract.ContractId = genericContract.ContractId;			
			concreteContract.VendorId = genericContract.VendorId;
            concreteContract.CustomerDefinitionId = genericContract.CustomerDefinitionId;			
			concreteContract.Text = genericContract.Text;			
			concreteContract.Created = genericContract.Created;			
			concreteContract.StartDate = genericContract.StartDate;			
			concreteContract.EndDate = genericContract.EndDate;			
			concreteContract.CreatedUserId = genericContract.CreatedUserId;
		}
	}
}
		