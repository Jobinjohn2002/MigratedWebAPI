using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
	public partial class DeliveryNoteData
	{
		public DeliveryNoteData(IDeliveryNote genericObj, string deliveryPointName, int customerId, string customerName)
			: this(genericObj)
		{
			DeliveryPointName = deliveryPointName;
			CustomerId = customerId;
			CustomerName = customerName;
		}

		#region extra Members
		/// <summary>
		/// Gets or sets DeliveryPointName
		/// </summary>
		public string DeliveryPointName { get; set; }
		/// <summary>
		/// Gets or sets CustomerId
		/// </summary>
		public int CustomerId { get; set; }
		/// <summary>
		/// Gets or sets CustomerName
		/// </summary>
		public string CustomerName { get; set; }
		/// <summary>
		/// Gets or sets FacilityName
		/// </summary>
		public string FacilityName { get; set; }
		/// <summary>
		/// Gets or sets CreatedByUserName
		/// </summary>
		public string CreatedByUserName { get; set; }
		#endregion
	}
}