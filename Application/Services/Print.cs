using SynergyApplicationFrameworkApi.Application.Services;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Print
    /// </summary>
    public class Print : TurnaroundEvents
    {
        #region Constructor
        public Print(SynergyTrakData data) : base(data)
        {

        }

        #endregion

        #region Applying Events
        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.ReprintTrayList)]
        /// <summary>
        /// ReprintTrayList operation
        /// </summary>
        public void ReprintTrayList(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            Parallel.ForEach(_data.ScanDcList, dc => Printing.PrintUtility.PrintTraylist(dc, scanDetails));
            ApplyEvent(TurnAroundEventTypeIdentifier.ReprintTrayList, scanDetails);
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.ReprintInstanceBarcode)]
        /// <summary>
        /// ReprintInstanceBarcodeAndCreateEvent operation
        /// </summary>
        public void ReprintInstanceBarcodeAndCreateEvent(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            ApplyEvent(TurnAroundEventTypeIdentifier.ReprintInstanceBarcode, scanDC, scanDetails);
            Printing.PrintUtility.ReprintInstanceBarcode(scanDC, scanDetails);
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.ReprintLabel)]
        /// <summary>
        /// ReprintLabel operation
        /// </summary>
        public void ReprintLabel(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            ApplyEvent(TurnAroundEventTypeIdentifier.ReprintLabel, scanDC, scanDetails);
            SterileExpiryHelper.UpdateSterileExpiry(scanDC);
            Printing.PrintUtility.CreateTurnaroundLabelUpdateSterileExpiry(scanDC, scanDetails, _data.FacilityId, TurnAroundEventTypeIdentifier.ReprintLabel);

            if (scanDC.Asset.ItemTypeId == (int)ItemTypeIdentifier.NonDispatchedSoftPack || scanDC.Asset.ItemTypeId == (int)ItemTypeIdentifier.NonDispatchedSoftPackNoLabel)
            {
                User user;
                using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                {
                    var userRepository = UserRepository.New(workUnit);
                    user = userRepository.Get(scanDC.UserId);
                }

                var result = Printing.PrintUtility.PrintPackList(scanDC.TurnaroundId.Value, scanDetails.LaserPrinter, scanDetails.IsNetworkPrinting, user.SystemId.ToString());

                if (result.ReportData != null)
                {
                    if (scanDetails.IsNetworkPrinting)
                    {
                        Printing.PrintUtility.PrintPDFReport(result, scanDetails.LaserPrinter);
                    }
                    else
                    {
                        var report = new ReportDataContract
                        {
                            Data = result.ReportData,
                            TurnaroundId = scanDC.TurnaroundId.Value
                        };

                        scanDC.Reports.Add(report);
                    }
                }
            }
        }

        #endregion
    }
}
