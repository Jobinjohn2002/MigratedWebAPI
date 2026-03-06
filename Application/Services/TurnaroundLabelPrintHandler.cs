using System;
using System.Collections.Generic;
using SynergyApplicationFrameworkApi.Application.Services;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Turnaround Label Print Handler
    /// </summary>
    /// <summary>
    /// TurnaroundLabelPrintHandler
    /// </summary>
    public class TurnaroundLabelPrintHandler : PrintHandlerBase
    {
        #region ErrorLog

        /// <summary>
        /// ErrorLog operation
        /// </summary>
        public void ErrorLog(string message)
        {
            Synergy.ErrorHandling.EventHandlers.ErrorEventHandler eventHandlers;

            try
            {
                string sLogFormat = DateTime.UtcNow.ToShortDateString() + " " + DateTime.UtcNow.ToLongTimeString() + " ==> ";

                const string sPathName = @"C:\log\";
                eventHandlers = new Synergy.ErrorHandling.EventHandlers.ErrorEventHandler();
                eventHandlers.CreateErrorDirectory(sPathName);

                var dtm = DateTime.UtcNow;

                var sErrorTime = $"{dtm.Day} - {dtm.Month} - {dtm.Year}";

                using (var sw = new StreamWriter(sPathName + "SMSapplication_ErrorLog_" + sErrorTime + ".txt", true))
                {
                    sw.WriteLine(sLogFormat + message);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch
            {
            }
        }

        #endregion

        #region Print

        /// <summary>
        /// Prints the turnaround label.
        /// </summary>
        /// <summary>
        /// Print operation
        /// </summary>
        public override List<PrintDetailsDataContract> Print(bool localPrintingEnabled = false)
        {
            try
            {
                if (PrintDetails == null)
                {
                    ErrorLog(PrintingResources.Display_PrintMessageTurnaroundLabelPrintHandlerText + " " + PrintingResources.Display_PrintMessageConvertFailedText + " - " + DateTime.UtcNow);
                    throw new Exception(PrintingResources.Display_PrintMessageConvertFailedText);
                }

                if (string.IsNullOrEmpty(PrintDetails.PrinterName))
                {
                    ErrorLog(PrintingResources.Display_PrintMessageTurnaroundLabelPrintHandlerText + " " + PrintingResources.Display_PrintMessagePrinterNameText + " - " + DateTime.UtcNow);
                    throw new Exception(PrintingResources.Display_PrintMessagePrinterNameText);
                }

                var turnaround = PrintDetails.PrintableObject as TurnaroundLabelData;
                if (turnaround == null)
                {
                    ErrorLog(PrintingResources.Display_PrintMessageTurnaroundLabelPrintHandlerText + " " + PrintingResources.Display_PrintMessageConvertFailedText + " - " + DateTime.UtcNow);
                    throw new Exception(PrintingResources.Display_PrintMessageConvertFailedText);
                }

                var template = turnaround.LabelDefinitionTemplate;
                var name = turnaround.ItemName;

                var label = new StringBuilder(turnaround.LabelDefinition);

                var words = name.Split(' ');

                var n = 0;

                var sb1 = new StringBuilder(name.Length);
                while (n < words.Length && sb1.Length < 25)
                {
                    sb1.Append(words[n]);
                    sb1.Append(" ");
                    n++;
                }
                var trayName = sb1.ToString().TrimEnd();

                var sb2 = new StringBuilder(name.Length);
                while (n < words.Length && sb2.Length < 25)
                {
                    sb2.Append(words[n]);
                    sb2.Append(" ");
                    n++;
                }

                var trayName1 = sb2.ToString().TrimEnd();

                label.Replace("[BARCODE]", Encode(turnaround.SerialNumber));
                label.Replace("[TRAY ID]", Encode(turnaround.ItemExternalId));

                var pti = "01" + turnaround.Gtin + "17" + turnaround.ExpiryDate.ToString("yyMMdd") + "21" + turnaround.SerialNumber;
                var gs1DateFormat = "yyMMdd";
                label.Replace("[AI01]", Encode(turnaround.Gtin)); // GTIN
                label.Replace("[AI10]", Encode(turnaround.SerialNumber)); // Batch/Log
                label.Replace("[AI11]", Encode(turnaround.PrintDate.ToString(gs1DateFormat))); // Production Date
                label.Replace("[AI17]", Encode(turnaround.ExpiryDate.ToString(gs1DateFormat))); // Expiry Date

                label.Replace("[TURNAROUND]", Encode(turnaround.SerialNumber));
                label.Replace("[INSTANCE]", Encode(turnaround.ItemExternalId));

                label.Replace("[TRAY NAME]", Encode(trayName));
                label.Replace("[TRAY NAME1]", Encode(trayName1));
                label.Replace("[ADDRESS1]", Encode(turnaround.FacilityName));
                label.Replace("[ADDRESS2]", Encode(turnaround.Town + ", " + turnaround.Postcode));
                label.Replace("[MANUFACTURED DATE]", DateTimeConversionHelper.PreferedDateTimeFormat(turnaround.PrintDate, turnaround.ShortDateFormat));
                label.Replace("[EXPIRY DATE]", DateTimeConversionHelper.PreferedDateTimeFormat(turnaround.ExpiryDate, turnaround.ShortDateFormat));
                label.Replace("[TELEPHONE]", Encode(turnaround.Telephone));
                label.Replace("[THEATRE]", Encode(turnaround.DeliveryPointName));
                label.Replace("[CUSTOMER NAME]", Encode(turnaround.CustomerName));
                label.Replace("[GS1]", Encode(turnaround.CustomerGs1));
                label.Replace("[PTI]", Encode(pti));
                label.Replace("[QUANTITY]", Encode(turnaround.Quantity.ToString()));
                label.Replace("[EXCEPTION Code]", Encode(turnaround.Exceptions[0]));

                var j = 0;

                if (turnaround.AdditionalDetails != null)
                {
                    foreach (string ad in turnaround.AdditionalDetails)
                    {
                        label.Replace("[EXCEPTIONS" + j.ToString(CultureInfo.InvariantCulture) + "]", Encode(ad));
                        j++;
                    }
                }

                for (var i = 0; i < 12 - j; i++)
                {
                    if (i <= turnaround.Exceptions.Count - 1)
                    {
                        label.Replace("[EXCEPTIONS" + (0 + j + i).ToString(CultureInfo.InvariantCulture) + "]", Encode(turnaround.Exceptions[i]));
                    }
                    else
                    {
                        label.Replace("[EXCEPTIONS" + (0 + j + i).ToString(CultureInfo.InvariantCulture) + "]", "");
                    }
                }

                for (var i = 0; i < turnaround.Quantity; i++)
                {
                    if (!localPrintingEnabled)
                    {
                        RawPrinterHelper.SendStringToPrinter(PrintDetails.PrinterName, template);
                        RawPrinterHelper.SendStringToPrinter(PrintDetails.PrinterName, label.ToString());
                    }

                    printJobs.Add(new PrintDetailsDataContract() { PrinterName = PrintDetails.PrinterName, PrinterTypeId = (int)PrintDetails.PrintType, StringData = template });
                    printJobs.Add(new PrintDetailsDataContract() { PrinterName = PrintDetails.PrinterName, PrinterTypeId = (int)PrintDetails.PrintType, StringData = label.ToString() });
                }

                ErrorLog(PrintingResources.Display_PrintMessageTurnaroundLabelPrintHandlerText + " " + PrintingResources.Display_PrintMessagePrintText + " - " + DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
                OnPrintCompleted(new RunWorkerCompletedEventArgs(PrintDetails.Quantity, null, false));
            }
            catch (Exception ex)
            {
                ErrorLog(PrintingResources.Display_PrintMessageTurnaroundLabelPrintHandlerText + " " + ex + " - " + DateTime.UtcNow);
                OnPrintCompleted(new RunWorkerCompletedEventArgs(0, ex, false));
            }

            return printJobs;
        }

        /// <summary>
        /// PrintToImage operation
        /// </summary>
        public override Image PrintToImage()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ensures text is sprinted correctly in Chinese when required.
        /// Prevents printing of "?" instead of characters
        /// </summary>
        /// <param name="input">The text to encode.</param>
        /// <returns>The correctly encoded string to be printed on a QA label.</returns>
        /// <summary>
        /// Encode operation
        /// </summary>
        public string Encode(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            string tmp = null;
            byte[] bytes = Encoding.GetEncoding(20936).GetBytes(input);

            foreach (byte b in bytes)
            {
                tmp += Convert.ToChar(b);
            }

            return tmp;
        }

        #endregion

    }
}
