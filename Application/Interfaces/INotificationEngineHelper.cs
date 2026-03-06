using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// INotificationEngineHelper
    /// </summary>
    public interface INotificationEngineHelper
    {
        List<CommunicationTypeIdentifier> ProcessNotifications(ScanAssetDataContract scanDC, ScanDetails scanDetails, ITurnaroundEvent turnaroundEvent);
        List<CommunicationTypeIdentifier> ProcessNotifications(ScanAssetDataContract scanDC, ScanDetails scanDetails, int turnaroundEventId);
    }
}
