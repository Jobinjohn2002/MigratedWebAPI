using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Provides functionality for easily creating and printing PDF files
    /// </summary>
    /// <summary>
    /// PdfHelper
    /// </summary>
    public class PdfHelper
    {
        private PdfGenerateConfig _config;

        public PdfHelper(PageSize pageSize, PageOrientation pageOrientation, int margin)
        {
            _config = new PdfGenerateConfig();
            _config.PageSize = pageSize;
            _config.PageOrientation = pageOrientation;
            _config.SetMargins(margin);
        }

        /// <summary>
        /// Creates a PDF file from the supplied html.
        /// </summary>
        /// <param name="html">The html to convert to pdf</param>
        /// <returns>The PDF file as a byte array - suitable for streaming/downloading.</returns>
        public byte[] CreatePdfFromHtml(string html)
        {
            return CreatePdfFromHtml(html, string.Empty);
        }

        /// <summary>
        /// Creates a PDF file from the supplied html and styles.
        /// </summary>
        /// <param name="html">The html to convert to pdf</param>
        /// <param name="css">Css to be used with the html</param>
        /// <returns>The PDF file as a byte array - suitable for streaming/downloading e.g. for local printing</returns>
        public byte[] CreatePdfFromHtml(string html, string css)
        {
            var filePath = CreateFile(html, css);
            var bytes = File.ReadAllBytes(filePath);
            File.Delete(filePath);

            return bytes;
        }

        /// <summary>
        /// Creates a PDF file from the supplied html and styles then prints it (network printing).
        /// </summary>
        /// <param name="html">The html to convert to pdf</param>
        /// <param name="css">Css to be used with the html</param>
        /// <param name="printerName">The name of the printer e.g. \\RHSTDEVPRT1\RFH~_IT_LP_01</param>
        /// <returns></returns>
        /// <summary>
        /// PrintPdfFromHtml operation
        /// </summary>
        public bool PrintPdfFromHtml(string html, string css, string printerName)
        {
            var filePath = CreateFile(html, css);
            PrintPdfHelper helper = new PrintPdfHelper();
            var result = helper.PrintPDF(printerName, filePath);
            File.Delete(filePath);
            return result;
        }

        /// <summary>
        /// Creates a PDF file from the supplied html and styles on disk.
        /// </summary>
        /// <param name="html">The html to convert to pdf</param>
        /// <param name="css">Css to be used with the html</param>
        /// <returns>The path to the newly created file</returns>
        private string CreateFile(string html, string css)
        {
            var fileName = Guid.NewGuid().ToString();
            var filePath = @"C:\windows\temp\" + fileName + ".pdf";
            CssData styles = PdfGenerator.ParseStyleSheet(css);

            PdfDocument pdf = PdfGenerator.GeneratePdf(html, _config, styles);
            pdf.Save(filePath);

            return filePath;
        }
    }
}