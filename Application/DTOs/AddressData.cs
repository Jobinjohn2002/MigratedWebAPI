using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class AddressData 
	{
        public AddressData()
        {

        }

        public AddressData(string address1, string address2, string address3, string city, string postcode, string contactEmail, string telephone, int? legacyFacilityOrigin, DateTime? legacyImported)
			: this(0, address1, address2, address3, city, postcode, contactEmail, telephone,legacyFacilityOrigin,legacyImported)
		{
		}
	}
}
		