using SynergyApplicationFrameworkApi.Application.DTOs.Scan;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// ISynergyTrakHelper
    /// </summary>
    public interface ISynergyTrakHelper
    {
        void Scan(ScanDetails scanDetails, ScanAssetDataContract scanDC);

        List<DeliveryNoteTurnaroundDataContract> AreAllLoanSetDispatched(List<long> turnaroundExternalIds, int trolleyturnaroundId);

        SynergyTrakData SynergyTrakData { get; set; }

        bool ValidateWorkFlowStep(ScanAssetDataContract scanDC, int eventType);

        void CreateNewTurnaround(ScanAssetDataContract scanDC, ScanDetails scanDetails, ContainerInstance containerInstance);
    }
}
