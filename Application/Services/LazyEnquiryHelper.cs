using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyEnquiryHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(Enquiry concreteEnquiry, Enquiry genericEnquiry)
        {
					
			concreteEnquiry.EnquiryId = genericEnquiry.EnquiryId;			
			concreteEnquiry.ExternalId = genericEnquiry.ExternalId;			
			concreteEnquiry.Subject = genericEnquiry.Subject;			
			concreteEnquiry.Message = genericEnquiry.Message;			
			concreteEnquiry.CreatedByUserId = genericEnquiry.CreatedByUserId;			
			concreteEnquiry.CreatedDate = genericEnquiry.CreatedDate;			
			concreteEnquiry.EnquiryStatusId = genericEnquiry.EnquiryStatusId;
		}
	}
}
		