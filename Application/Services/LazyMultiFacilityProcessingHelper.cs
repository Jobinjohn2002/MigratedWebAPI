using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyMultiFacilityProcessingHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(MultiFacilityProcessing concreteMultiFacilityProcessing, IMultiFacilityProcessing genericMultiFacilityProcessing)
        {
            concreteMultiFacilityProcessing.MultiFacilityProcessingId = genericMultiFacilityProcessing.MultiFacilityProcessingId;
            concreteMultiFacilityProcessing.AlternateProcessingFacilityId = genericMultiFacilityProcessing.AlternateProcessingFacilityId;
            concreteMultiFacilityProcessing.AcceptedById = genericMultiFacilityProcessing.AcceptedById;
            concreteMultiFacilityProcessing.AcceptedDate = genericMultiFacilityProcessing.AcceptedDate;
            concreteMultiFacilityProcessing.IsEnabled = genericMultiFacilityProcessing.IsEnabled;
            concreteMultiFacilityProcessing.ModifiedById = genericMultiFacilityProcessing.ModifiedById;
            concreteMultiFacilityProcessing.ModifiedByDate = genericMultiFacilityProcessing.ModifiedByDate;	
		}
    }
}