using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class ContractDataAdapter : DataAdapterBase, IContractDataAdapter
	{	   
      	/// <summary>
      	/// ArchiveContract operation
      	/// </summary>
      	public  void ArchiveContract(int contractId, int userId)
		{		 
		     throw new NotImplementedException();
		}
	}
}
		