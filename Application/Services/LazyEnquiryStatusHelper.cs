using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyEnquiryStatusHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(EnquiryStatus concreteEnquiryStatus, EnquiryStatus genericEnquiryStatus)
        {
					
			concreteEnquiryStatus.EnquiryStatusID = genericEnquiryStatus.EnquiryStatusID;			
			concreteEnquiryStatus.Text = genericEnquiryStatus.Text;
		}
	}
}
		