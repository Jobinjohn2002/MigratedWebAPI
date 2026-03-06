using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// PrintPdfHelper
    /// </summary>
    public class PrintPdfHelper
    {
        /// <summary>
        /// PrintPDF operation
        /// </summary>
        public bool PrintPDF(string printerName, string pdfFileName)
        {
            return PrintPDF(1, printerName, pdfFileName);
        }

        /// <summary>
        /// Prints the PDF.
        /// </summary>
        /// <param name="numberOfCopies">The number of copies.</param>
        /// <param name="printerName">Name of the printer. Eg \\server_name\printer_name</param>
        /// <param name="pdfFileName">Name of the PDF file.</param>
        /// <summary>
        /// PrintPDF operation
        /// </summary>
        public bool PrintPDF(int numberOfCopies, string printerName, string pdfFileName)
        {
            Process process = null;
            string ghostScriptPath = Properties.Resources.GhostScriptInstallPath;

            try
            {
                var startInfo = new ProcessStartInfo
                {
                    Arguments = " -dPrinted -dBATCH -dNOPAUSE -dNOSAFER -dNORANGEPAGESIZE -q -dNumCopies=" + Convert.ToString(numberOfCopies) + " -sDEVICE=ljet4 -sOutputFile=\"\\\\spool\\" + printerName.Trim() + "\" \"" + pdfFileName + "\" ",
                    FileName = ghostScriptPath,
                    UseShellExecute = false,

                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                };

                process = Process.Start(startInfo);

                if (process != null)
                {
                    process.WaitForExit(30000);
                }
            }
            finally
            {
                if (process != null && process.HasExited == false)
                {
                    process.Kill();
                }
            }

            if (process == null)
            {
                return false;
            }

            return process.ExitCode == 0;
        }
    }
}
