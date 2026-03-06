using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyHubHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(Hub concreteHub, Hub genericHub)
        {
            concreteHub.HubId = genericHub.HubId;
            concreteHub.CustomerDefinitionId = genericHub.CustomerDefinitionId;
            concreteHub.ExternalId = genericHub.ExternalId;
            concreteHub.Text = genericHub.Text;
            concreteHub.LegacyFacilityOrigin = genericHub.LegacyFacilityOrigin;
            concreteHub.LegacyImported = genericHub.LegacyImported;
        }
    }
}