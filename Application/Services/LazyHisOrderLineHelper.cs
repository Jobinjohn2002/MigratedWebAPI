using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyHisOrderLineHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(HisOrderLine concreteHisOrderLine, HisOrderLine genericHisOrderLine)
        {
					
			concreteHisOrderLine.HisOrderLineId = genericHisOrderLine.HisOrderLineId;			
			concreteHisOrderLine.HisOrderId = genericHisOrderLine.HisOrderId;			
			concreteHisOrderLine.HisResourceCode = genericHisOrderLine.HisResourceCode;			
			concreteHisOrderLine.HisResourceName = genericHisOrderLine.HisResourceName;			
			concreteHisOrderLine.Matched = genericHisOrderLine.Matched;			
			concreteHisOrderLine.HisDataCrossMatchingId = genericHisOrderLine.HisDataCrossMatchingId;			
			concreteHisOrderLine.OrderPlaced = genericHisOrderLine.OrderPlaced;			
			concreteHisOrderLine.CreatedByUserId = genericHisOrderLine.CreatedByUserId;			
			concreteHisOrderLine.CreatedDate = genericHisOrderLine.CreatedDate;			
			concreteHisOrderLine.ArchivedByUserId = genericHisOrderLine.ArchivedByUserId;			
			concreteHisOrderLine.ArchivedDate = genericHisOrderLine.ArchivedDate;
		}
	}
}
		