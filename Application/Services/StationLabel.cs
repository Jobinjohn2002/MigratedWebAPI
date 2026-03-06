using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class StationLabel : Form, IPrintableForm
    {
        private readonly string _printerName;

        public StationLabel()
        {
            InitializeComponent();
        }

        public StationLabel(string printerName, StationLabelData station)
        {
            InitializeComponent();
            barcode1d.Code = station.NTLogon;
            barcode1d.Text = string.Empty;
            _printerName = printerName;
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

            #region
            #endregion

            barcode1d.DrawOnCanvas(g, new PointF(0.5f, 0.15f));
            e.HasMorePages = false;
        }
    }
}