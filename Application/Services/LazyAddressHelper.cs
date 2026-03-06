using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyAddressHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(Address concreteAddress, Address genericAddress)
        {
            concreteAddress.AddressId = genericAddress.AddressId;
            concreteAddress.Address1 = genericAddress.Address1;
            concreteAddress.Address2 = genericAddress.Address2;
            concreteAddress.Address3 = genericAddress.Address3;
            concreteAddress.City = genericAddress.City;
            concreteAddress.Postcode = genericAddress.Postcode;
            concreteAddress.ContactEmail = genericAddress.ContactEmail;
            concreteAddress.Telephone = genericAddress.Telephone;
            concreteAddress.LegacyFacilityOrigin = genericAddress.LegacyFacilityOrigin;
            concreteAddress.LegacyImported = genericAddress.LegacyImported;
        }
    }
}