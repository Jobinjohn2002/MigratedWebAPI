using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyCustomerHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(Customer concreteCustomer, Customer genericCustomer)
        {
            concreteCustomer.CustomerId = genericCustomer.CustomerId;
            concreteCustomer.AddressId = genericCustomer.AddressId;
            concreteCustomer.CreatedUserId = genericCustomer.CreatedUserId;
            concreteCustomer.CustomerDefinitionId = genericCustomer.CustomerDefinitionId;
            concreteCustomer.CustomerGroupId = genericCustomer.CustomerGroupId;
            concreteCustomer.CustomerStatusId = genericCustomer.CustomerStatusId;
            concreteCustomer.FacilityId = genericCustomer.FacilityId;
            concreteCustomer.Text = genericCustomer.Text;
            concreteCustomer.Created = genericCustomer.Created;
            concreteCustomer.Revision = genericCustomer.Revision;
            concreteCustomer.GS1Code = genericCustomer.GS1Code;
            concreteCustomer.IndependentQualityAssuranceCheck = genericCustomer.IndependentQualityAssuranceCheck;
            concreteCustomer.TrayListFooter = genericCustomer.TrayListFooter;
            concreteCustomer.DeliveryNoteFooter = genericCustomer.DeliveryNoteFooter;
            concreteCustomer.LegacyId = genericCustomer.LegacyId;
            concreteCustomer.LegacyFacilityOrigin = genericCustomer.LegacyFacilityOrigin;
            concreteCustomer.LegacyImported = genericCustomer.LegacyImported;
            concreteCustomer.Alias = genericCustomer.Alias;
            concreteCustomer.DebtorId = genericCustomer.DebtorId;
            concreteCustomer.PrintTrayListFrontSheet = genericCustomer.PrintTrayListFrontSheet;            
            concreteCustomer.QALabelProductCodeId = genericCustomer.QALabelProductCodeId;
            concreteCustomer.Linear1dBarcodeId = genericCustomer.Linear1dBarcodeId;
            concreteCustomer.Datamatrix2dBarcodeId = genericCustomer.Datamatrix2dBarcodeId;
            concreteCustomer.Notes = genericCustomer.Notes;
            concreteCustomer.CreatePhysicalDeliveryNote = genericCustomer.CreatePhysicalDeliveryNote;
        }
    }
}