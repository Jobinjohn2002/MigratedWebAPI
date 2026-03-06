using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyTurnaroundAssignedHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(TurnaroundAssigned concreteTurnaroundAssigned,
                                     TurnaroundAssigned genericTurnaroundAssigned)
        {
            concreteTurnaroundAssigned.TurnaroundAssignedId = genericTurnaroundAssigned.TurnaroundAssignedId;
            concreteTurnaroundAssigned.TurnaroundParentId = genericTurnaroundAssigned.TurnaroundParentId;
            concreteTurnaroundAssigned.TurnaroundChildId = genericTurnaroundAssigned.TurnaroundChildId;
            concreteTurnaroundAssigned.LegacyFacilityOrigin = genericTurnaroundAssigned.LegacyFacilityOrigin;
            concreteTurnaroundAssigned.LegacyImported = genericTurnaroundAssigned.LegacyImported;
        }
    }
}