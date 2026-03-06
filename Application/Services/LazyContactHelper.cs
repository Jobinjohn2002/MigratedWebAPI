using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyContactHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(Contact concreteContact, Contact genericContact)
        {
					
			concreteContact.ContactId = genericContact.ContactId;			
			concreteContact.Name = genericContact.Name;			
			concreteContact.ContactEmail = genericContact.ContactEmail;			
			concreteContact.Telephone = genericContact.Telephone;			
			concreteContact.Mobile = genericContact.Mobile;
		}
	}
}
		