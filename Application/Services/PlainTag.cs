using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class PlainTag : Form, IPrintableForm
    {
        private readonly string _printerName;

        public PlainTag()
        {
            InitializeComponent();
        }

        public PlainTag(string printerName, string barcode)
        {
            InitializeComponent();
            _printerName = printerName;
            barcode1d.Code = barcode;
            barcode1d.Text = string.Empty;
        }

        #region IPrintableForm Members

        /// <summary>
        /// Print operation
        /// </summary>
        public void Print()
        {
            DocumentPrint.PrinterSettings.PrinterName = _printerName;
            DocumentPrint.Print();
        }

        #endregion

        private void OnDocumentPrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            var drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;

            e.HasMorePages = false;
        }
    }
}