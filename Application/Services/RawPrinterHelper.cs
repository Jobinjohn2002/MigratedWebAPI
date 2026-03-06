using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public sealed class RawPrinterHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        /// <remarks></remarks>
        private RawPrinterHelper()
        {
        }

        /// <summary>
        /// Closes the printer.
        /// </summary>
        /// <param name="hPrinter">The h printer.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        /// <summary>
        /// ClosePrinter operation
        /// </summary>
        public static extern bool ClosePrinter(IntPtr hPrinter);

        /// <summary>
        /// Ends the doc printer.
        /// </summary>
        /// <param name="hPrinter">The h printer.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        /// <summary>
        /// EndDocPrinter operation
        /// </summary>
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        /// <summary>
        /// Ends the page printer.
        /// </summary>
        /// <param name="hPrinter">The h printer.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        /// <summary>
        /// EndPagePrinter operation
        /// </summary>
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        /// <summary>
        /// Opens the printer.
        /// </summary>
        /// <param name="szPrinter">The sz printer.</param>
        /// <param name="hPrinter">The h printer.</param>
        /// <param name="pd">The pd.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        /// <summary>
        /// OpenPrinter operation
        /// </summary>
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        /// <summary>
        /// Starts the doc printer.
        /// </summary>
        /// <param name="hPrinter">The h printer.</param>
        /// <param name="level">The level.</param>
        /// <param name="di">The di.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        /// <summary>
        /// StartDocPrinter operation
        /// </summary>
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        /// <summary>
        /// Starts the page printer.
        /// </summary>
        /// <param name="hPrinter">The h printer.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        /// <summary>
        /// StartPagePrinter operation
        /// </summary>
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        /// <summary>
        /// Writes the printer.
        /// </summary>
        /// <param name="hPrinter">The h printer.</param>
        /// <param name="pBytes">The p bytes.</param>
        /// <param name="dwCount">The dw count.</param>
        /// <param name="dwWritten">The dw written.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        /// <summary>
        /// WritePrinter operation
        /// </summary>
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        /// <summary>
        /// Send Bytes To Printer
        /// </summary>
        /// <param name="szPrinterName">Name of the sz printer.</param>
        /// <param name="pBytes">The p bytes.</param>
        /// <param name="dwCount">The dw count.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// SendBytesToPrinter operation
        /// </summary>
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            var hPrinter = new IntPtr(0);
            var di = new DOCINFOA();
            bool bSuccess = false;

            di.pDocName = "My C#.NET RAW Document";
            di.pDataType = "RAW";

            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    if (StartPagePrinter(hPrinter))
                    {
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }

            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        /// <summary>
        /// Send File To Printer
        /// </summary>
        /// <param name="szPrinterName">Name of the sz printer.</param>
        /// <param name="szFileName">Name of the sz file.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// SendFileToPrinter operation
        /// </summary>
        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            var fs = new FileStream(szFileName, FileMode.Open);
            var br = new BinaryReader(fs);
            var bytes = new Byte[fs.Length];
            bool bSuccess = false;
            var pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = Convert.ToInt32(fs.Length);
            bytes = br.ReadBytes(nLength);
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            return bSuccess;
        }

        /// <summary>
        /// Sends the string to printer.
        /// </summary>
        /// <param name="szPrinterName">Name of the sz printer.</param>
        /// <param name="szString">The sz string.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// SendStringToPrinter operation
        /// </summary>
        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;

            dwCount = szString.Length;
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);

            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }

        #region Nested type: DOCINFOA

        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        /// <summary>
        /// DOCINFOA
        /// </summary>
        public class DOCINFOA
        {
            #region Fixed Fields

            /// <summary>
            /// 
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)] public string pDocName;

            /// <summary>
            /// 
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)] public string pOutputFile;

            /// <summary>
            /// 
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)] public string pDataType;

            #endregion Fixed Fields
        }

        #endregion
    }
}