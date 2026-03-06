using SynergyApplicationFrameworkApi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IOOATrolleyDispatchHelper
    /// </summary>
    public interface IOOATrolleyDispatchHelper
    {
        bool DoesOutOfAutoclaveEventNeedToBeApplied(short facilityId, long turnaroundExternalId);
        TrolleyDispatchTrolleyDataContract PassItemOutOfAutoclave(TrolleyDispatchTrolleyDataContract dataContract, TrolleyDispatchScanTurnaroundScanDetails scanDetails, Turnaround turnaround, ISynergyTrakHelper synergyTrakHelper);
    }
}
