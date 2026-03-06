using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyStoragePointHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(StoragePoint concreteStoragePoint, StoragePoint genericStoragePoint)
        {
            concreteStoragePoint.StoragePointId = genericStoragePoint.StoragePointId;
            concreteStoragePoint.CustomerDefinitionId = genericStoragePoint.CustomerDefinitionId;
            concreteStoragePoint.Text = genericStoragePoint.Text;
            concreteStoragePoint.LegacyId = genericStoragePoint.LegacyId;
            concreteStoragePoint.LegacyFacilityOrigin = genericStoragePoint.LegacyFacilityOrigin;
            concreteStoragePoint.LegacyImported = genericStoragePoint.LegacyImported;
            concreteStoragePoint.AdditionalDetails = genericStoragePoint.AdditionalDetails;

        }
    }
}