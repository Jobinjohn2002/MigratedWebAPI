using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyLoginAuditHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(LoginAudit concreteLoginAudit, LoginAudit genericLoginAudit)
        {
					
			concreteLoginAudit.LoginAuditId = genericLoginAudit.LoginAuditId;			
			concreteLoginAudit.UserId = genericLoginAudit.UserId;			
			concreteLoginAudit.UserName = genericLoginAudit.UserName;			
			concreteLoginAudit.LoginDate = genericLoginAudit.LoginDate;			
			concreteLoginAudit.IPAddress = genericLoginAudit.IPAddress;			
			concreteLoginAudit.Source = genericLoginAudit.Source;			
			concreteLoginAudit.AppTypeId = genericLoginAudit.AppTypeId;			
			concreteLoginAudit.LoginAuditTypeId = genericLoginAudit.LoginAuditTypeId;
            concreteLoginAudit.BrowserAgent = genericLoginAudit.BrowserAgent;
        }
	}
}
		