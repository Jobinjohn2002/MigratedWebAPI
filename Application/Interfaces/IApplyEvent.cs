using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IApplyEvent
    /// </summary>
    public interface IApplyEvent : IDisposable
    {
        List<TurnaroundEventComplete> ApplyEvents(List<ApplyTurnaroundEventDetails> eventsToApply, List<ScanAssetDataContract> dataContracts, ScanDetails scanDetails, bool notificationsHandledExternally);

        void Setup(SynergyTrakData data);

        void Setup(ProcessNotificationsDlgt processNotificationsDlgt, int userId, short facilityId, int stationTypeId, int? stationId = null,
                          short? quarantineReasonId = null, bool keepBatchTagTogetherRequested = false, byte? failureTypeId = null);
    }
}
