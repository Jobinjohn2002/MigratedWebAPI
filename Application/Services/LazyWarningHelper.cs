using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyWarningHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(Warning concreteWarning, Warning genericWarning)
        {
            concreteWarning.WarningId = genericWarning.WarningId;
            concreteWarning.ContainerMasterId = genericWarning.ContainerMasterId;
            concreteWarning.ItemMasterId = genericWarning.ItemMasterId;
            concreteWarning.Text = genericWarning.Text;
            concreteWarning.MaximumTurnarounds = genericWarning.MaximumTurnarounds;
            concreteWarning.MaximumDays = genericWarning.MaximumDays;
            concreteWarning.TurnaroundLeadIn = genericWarning.TurnaroundLeadIn;
            concreteWarning.WarningOnly = genericWarning.WarningOnly;
            concreteWarning.Created = genericWarning.Created;
            concreteWarning.LegacyFacilityOrigin = genericWarning.LegacyFacilityOrigin;
            concreteWarning.LegacyImported = genericWarning.LegacyImported;
        }
    }
}