using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyHisOrderHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(HisOrder concreteHisOrder, HisOrder genericHisOrder)
        {
					
			concreteHisOrder.HisOrderId = genericHisOrder.HisOrderId;			
			concreteHisOrder.OrderRef = genericHisOrder.OrderRef;			
			concreteHisOrder.DeliveryPointName = genericHisOrder.DeliveryPointName;			
			concreteHisOrder.MatchedDeliveryPointId = genericHisOrder.MatchedDeliveryPointId;			
			concreteHisOrder.CustomerDefinitionId = genericHisOrder.CustomerDefinitionId;			
			concreteHisOrder.ProcedureDate = genericHisOrder.ProcedureDate;			
			concreteHisOrder.ProcedureCode = genericHisOrder.ProcedureCode;			
			concreteHisOrder.ProcedureName = genericHisOrder.ProcedureName;			
			concreteHisOrder.MatchedProcedureTypeId = genericHisOrder.MatchedProcedureTypeId;			
			concreteHisOrder.SurgeonCode = genericHisOrder.SurgeonCode;			
			concreteHisOrder.SurgeonName = genericHisOrder.SurgeonName;			
			concreteHisOrder.MatchedSurgeonId = genericHisOrder.MatchedSurgeonId;			
			concreteHisOrder.OrderShipped = genericHisOrder.OrderShipped;			
			concreteHisOrder.CancelledByUserId = genericHisOrder.CancelledByUserId;			
			concreteHisOrder.CancelledByDate = genericHisOrder.CancelledByDate;			
			concreteHisOrder.CreatedByUserId = genericHisOrder.CreatedByUserId;			
			concreteHisOrder.CreatedDate = genericHisOrder.CreatedDate;			
			concreteHisOrder.ModifiedDate = genericHisOrder.ModifiedDate;			
			concreteHisOrder.ModifiedByUserId = genericHisOrder.ModifiedByUserId;			
			concreteHisOrder.DeliveryDate = genericHisOrder.DeliveryDate;
		}
	}
}
		