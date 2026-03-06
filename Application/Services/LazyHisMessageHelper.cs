using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyHisMessageHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(HisMessage concreteHisMessage, HisMessage genericHisMessage)
        {
					
			concreteHisMessage.HisMessageId = genericHisMessage.HisMessageId;			
			concreteHisMessage.URL = genericHisMessage.URL;			
			concreteHisMessage.RequestDate = genericHisMessage.RequestDate;			
			concreteHisMessage.IPAddress = genericHisMessage.IPAddress;			
			concreteHisMessage.HospitalId = genericHisMessage.HospitalId;			
			concreteHisMessage.UserId = genericHisMessage.UserId;			
			concreteHisMessage.YourReference = genericHisMessage.YourReference;			
			concreteHisMessage.RequestHeaders = genericHisMessage.RequestHeaders;			
			concreteHisMessage.RequestContent = genericHisMessage.RequestContent;			
			concreteHisMessage.ResponseCode = genericHisMessage.ResponseCode;			
			concreteHisMessage.ResponseMessage = genericHisMessage.ResponseMessage;			
			concreteHisMessage.ResponseHeaders = genericHisMessage.ResponseHeaders;			
			concreteHisMessage.YourMessageReference = genericHisMessage.YourMessageReference;
		}
	}
}
		