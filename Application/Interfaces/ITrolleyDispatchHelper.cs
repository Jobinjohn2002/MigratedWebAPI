using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// ITrolleyDispatchHelper
    /// </summary>
    public interface ITrolleyDispatchHelper : IDisposable
    {
        TrolleyDispatchTrolleyDataContract GetTrolleyContents(ScanDetails scanDetails, bool validateTrolleyWorkflow);
        TrolleyDispatchContainerDataContract ConvertTrolleyContentsDataModelToDataContractModel(TrolleyDispatch_GetTrolleyContents_Result trolleyItem);
        TrolleyDispatchHubSummaryDataContract GetDispatchHubSummary(int facilityId);
        IList<TrolleyDispatch_GetTrolleySummary_Result> GetTrolleySummary(string externalId, int facilityId);
        TrolleyDispatchDeliveryNoteDataContract DispatchTrolley(DeliveryNoteScanDetails scanDetails);
        TrolleyDispatchDeliveryNoteBatchDataContract DispatchTrolleys(DeliveryNoteBatchScanDetails scanDetails);
        TrolleyDispatchTrolleyDataContract ValidateTurnaroundCanBeProcessedOntoTrolley( ContainerInstance trolley, TrolleyDispatchTrolleyDataContract dataContract, TrolleyDispatchScanTurnaroundScanDetails scanDetails, long trayTurnaroundExternalId, out int deliveryPointId, out int facilityId);
        TrolleyDispatchTrolleyDataContract StartTrolley(ContainerInstance trolley, TrolleyDispatchTrolleyDataContract dataContract, TrolleyDispatchScanTurnaroundScanDetails scanDetails, int facilityId, int deliveryPointId, ref int? trolleyTurnaroundId);
        TrolleyDispatchTrolleyDataContract AddTurnaroundToTrolley(ContainerInstance trolley, TrolleyDispatchScanTurnaroundScanDetails scanDetails, int facilityId, int deliveryPointId, bool isOutOfAutoclave, Turnaround turnaround);
        TrolleyDispatchTrolleyDataContract RemoveTurnaroundFromTrolley(TrolleyDispatchScanTurnaroundScanDetails scanDetails);
        List<TrolleyDispatchContainerDataContract> GetSuggestedTurnarounds(int facilityId, ContainerInstance trolley, bool isOutOfAutoclave);
    }
}
