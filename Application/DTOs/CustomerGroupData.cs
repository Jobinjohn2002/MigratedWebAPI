using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
	public partial class CustomerGroupData
	{
		public CustomerGroupData()
		{ }

		public CustomerGroupData(ICustomerGroup genericObj, IList<CustomerData> customers)
			: this(genericObj)
		{
			Customers = customers;
		}
		/// <summary>
		/// Gets or sets Customers
		/// </summary>
		public IList<CustomerData> Customers { get; set; }
		/// <summary>
		/// Gets or sets Address
		/// </summary>
		public AddressData Address { get; set; }

	}
}