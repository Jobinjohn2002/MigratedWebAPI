using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyFacilityHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(Facility concreteFacility, Facility genericFacility)
        {
            concreteFacility.FacilityId = genericFacility.FacilityId;
            concreteFacility.AddressId = genericFacility.AddressId;
            concreteFacility.ArchivedUserId = genericFacility.ArchivedUserId;
            concreteFacility.Text = genericFacility.Text;
            concreteFacility.EmailAddress = genericFacility.EmailAddress;
            concreteFacility.Archived = genericFacility.Archived;
            concreteFacility.UTCOffset = genericFacility.UTCOffset;
            concreteFacility.DLSOffset = genericFacility.DLSOffset;
            concreteFacility.SubjectText = genericFacility.SubjectText;
            concreteFacility.BodyText = genericFacility.BodyText;
            concreteFacility.LegacyFacilityOrigin = genericFacility.LegacyFacilityOrigin;
            concreteFacility.LegacyImported = genericFacility.LegacyImported;
            concreteFacility.ItemAliasEnabled = genericFacility.ItemAliasEnabled;
            concreteFacility.OwnerId = genericFacility.OwnerId;
            concreteFacility.FacilityCatalogueEnabled = genericFacility.FacilityCatalogueEnabled;
            concreteFacility.TenancyCatalogueEnabled = genericFacility.TenancyCatalogueEnabled;
            concreteFacility.GlobalCatalogueEnabled = genericFacility.GlobalCatalogueEnabled;
            concreteFacility.ProcessingModeId = genericFacility.ProcessingModeId == 0 ? (short) ProcessingModeIdentifier.BestPractice : genericFacility.ProcessingModeId;
            concreteFacility.ModifiedByUserId = genericFacility.ModifiedByUserId;
            concreteFacility.ModifiedDate = genericFacility.ModifiedDate;
            concreteFacility.PreWashToleranceKg = genericFacility.PreWashToleranceKg;
            concreteFacility.PostWashToleranceKg = genericFacility.PostWashToleranceKg;
            concreteFacility.MatchReferenceWeights = genericFacility.MatchReferenceWeights;
            concreteFacility.FacilityTypeId = genericFacility.FacilityTypeId;
        }
    }
}
