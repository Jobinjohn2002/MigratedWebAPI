using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyUserPasswordHistoryHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(UserPasswordHistory concreteUserPasswordHistory, UserPasswordHistory genericUserPasswordHistory)
        {
					
			concreteUserPasswordHistory.UserPasswordHistoryId = genericUserPasswordHistory.UserPasswordHistoryId;			
			concreteUserPasswordHistory.Password = genericUserPasswordHistory.Password;			
			concreteUserPasswordHistory.Salt = genericUserPasswordHistory.Salt;			
			concreteUserPasswordHistory.Iterations = genericUserPasswordHistory.Iterations;			
			concreteUserPasswordHistory.CreatedDate = genericUserPasswordHistory.CreatedDate;			
			concreteUserPasswordHistory.UserId = genericUserPasswordHistory.UserId;
		}
	}
}
		