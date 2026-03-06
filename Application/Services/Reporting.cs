using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class Reporting
    {
        /// <summary>
        /// GenerateDeliveryNotePdf operation
        /// </summary>
        public static string GenerateDeliveryNotePdf(DeliveryNotePrintDataContract dc, int tenancyId, int facilityId, int customerDefinitionId,
            ReportTypeIdentifier reportTypeIdentifier, Tuple<string, string>[] parameters, ScanAssetDataContract scanDC = null)
        {
            using (var operativeWorkUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var printEventHandler = EventHandlerFactory.GetPrintEventHandler(operativeWorkUnit);
                var reportName = printEventHandler.GetStationeryVersion(reportTypeIdentifier, customerDefinitionId, facilityId, tenancyId);

                dc.ReportData = CreatePDFReport(reportName.ReportPath, parameters, string.Empty, false, scanDC, reportName.NumberOfCopies);
                dc.NumberOfCopies = reportName.NumberOfCopies.GetValueOrDefault() > 0
                    ? reportName.NumberOfCopies.GetValueOrDefault()
                    : 1;

                return reportName.ReportPath;
            }
        }

        public static byte[] CreatePDFReport(string reportName, Tuple<string, string>[] parameters, string printerName, bool isNetworkPrinting, ScanAssetDataContract scanDC = null, int? printCount = 1)
        {
            try
            {
                InstanceFactory.GetInstance<ILog>().Info(string.Format("CreatePDFReport Name: {0}", reportName));
                var report = new Microsoft.Reporting.WebForms.ServerReport();

                var reportParameters = new List<Microsoft.Reporting.WebForms.ReportParameter>();

                foreach (Tuple<string, string> param in parameters)
                {
                    reportParameters.Add(new Microsoft.Reporting.WebForms.ReportParameter(param.Item1, param.Item2));
                }

                report.ReportServerUrl = new Uri(SystemSettings.ReportApplicationBaseUrl, UriKind.Absolute);
                report.ReportPath = SystemSettings.SystemReportPath + reportName;
                report.ReportServerCredentials = new ReportServerCredentials(SystemSettings.ReportServiceLogonUser, SystemSettings.ReportServerPassword, SystemSettings.ReportServiceLogonDomain);
                report.SetParameters(reportParameters);
                report.Refresh();

                Microsoft.Reporting.WebForms.Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;

                var bytes = report.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                if (isNetworkPrinting)
                {
                    for (int i = 0; i < printCount; i++)
                    {
                        Printing.PrintUtility.ProcessPrint(bytes, printerName, reportName);
                    }
                }
                else if (scanDC != null)
                {
                    if (scanDC.Reports == null)
                    {
                        scanDC.Reports = new List<ReportDataContract>();
                    }

                    scanDC.Reports.Add(new ReportDataContract { Data = bytes, TurnaroundId = scanDC.TurnaroundId.Value, NumberOfCopies = printCount });
                }

                return bytes;
            }
            catch (Exception ex)
            {
                InstanceFactory.GetInstance<ILog>().Exception(ex, $"CreatePDFReport-Error Name: {reportName}.");

                return new byte[0];
            }
        }
    }
}