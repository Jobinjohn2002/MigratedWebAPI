using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyCommunicationTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(CommunicationType concreteCommunicationType, CommunicationType genericCommunicationType)
        {
					
			concreteCommunicationType.CommunicationTypeId = genericCommunicationType.CommunicationTypeId;			
			concreteCommunicationType.Text = genericCommunicationType.Text;
		}
	}
}
		