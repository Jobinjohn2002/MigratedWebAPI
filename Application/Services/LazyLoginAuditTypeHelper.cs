using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyLoginAuditTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(LoginAuditType concreteLoginAuditType, LoginAuditType genericLoginAuditType)
        {
					
			concreteLoginAuditType.LoginAuditTypeId = genericLoginAuditType.LoginAuditTypeId;			
			concreteLoginAuditType.Text = genericLoginAuditType.Text;
		}
	}
}
		