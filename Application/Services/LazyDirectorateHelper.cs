using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyDirectorateHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(Directorate concreteDirectorate, Directorate genericDirectorate)
        {
            concreteDirectorate.DirectorateId = genericDirectorate.DirectorateId;
            concreteDirectorate.AddressId = genericDirectorate.AddressId;
            concreteDirectorate.CustomerDefinitionId = genericDirectorate.CustomerDefinitionId;
            concreteDirectorate.Text = genericDirectorate.Text;
            concreteDirectorate.LegacyId = genericDirectorate.LegacyId;
            concreteDirectorate.LegacyFacilityOrigin = genericDirectorate.LegacyFacilityOrigin;
            concreteDirectorate.LegacyImported = genericDirectorate.LegacyImported;
        }
    }
}