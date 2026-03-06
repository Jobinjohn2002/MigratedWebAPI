using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class TwoDBarcodeInstanceLabel : Form, IPrintableForm
    {
        private readonly string _printerName;

        public TwoDBarcodeInstanceLabel()
        {
            InitializeComponent();
        }

        public TwoDBarcodeInstanceLabel(string printerName, InstanceLabelData instance)
        {
            InitializeComponent();
            CustomerLabel.Text = instance.CustomerName;
            ItemNameLabel.Text = instance.ItemName;
            DeliveryPointLabel.Text = instance.DeliveryPointName;
            barcode2d.Code = instance.InstanceExternalId;
            CreateTwoDBarcodeLabel(barcode2d.Code);
            _printerName = printerName;
        }
        #region TP 1932
        /// <summary>
        /// CreateTwoDBarcodeLabel operation
        /// </summary>
        public void CreateTwoDBarcodeLabel(string barcode2dCode)
        {
            int length = barcode2dCode.Length;
            int i = 0;
            while (length % 40 != 0 && i < barcode2dCode.Length)
            {
                Label label = new Label();
                if (length >= 40)
                {
                    label.Text = barcode2dCode.Substring(i, 40);
                }
                else label.Text = barcode2dCode.Substring(i);
                label.Name = "lblBarcodeText";
                label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
                Controls.Add(label);
                i += 40;
                length = length - 40;

            }
        }
        #endregion

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
            int lblBarcodeTop = 0;
           
            var barcode2dText = Controls.Find("lblBarcodeText", false);

            g.DrawString(CustomerLabel.Text,
                         CustomerLabel.Font,
                         Brushes.Black,
                         (float)CustomerLabel.Left + (CustomerLabel.Width / 2),
                         CustomerLabel.Top,
                         drawFormat);
            g.DrawString(ItemNameLabel.Text,
                         ItemNameLabel.Font,
                         Brushes.Black,
                         (float)ItemNameLabel.Left + (ItemNameLabel.Width / 2),
                         ItemNameLabel.Top,
                         drawFormat);

            g.DrawString(PleaseReturnLabel.Text,
                         PleaseReturnLabel.Font,
                         Brushes.Black,
                         (float)PleaseReturnLabel.Left + (PleaseReturnLabel.Width / 2),
                         PleaseReturnLabel.Top,
                         drawFormat);

            g.DrawString(DeliveryPointLabel.Text,
                         DeliveryPointLabel.Font,
                         Brushes.Black,
                         (float)DeliveryPointLabel.Left + (DeliveryPointLabel.Width / 2),
                         DeliveryPointLabel.Top,
                         drawFormat);
            if (barcode2dText.Length > 1) lblBarcodeTop = 10;
            else lblBarcodeTop = 30;
            foreach (var item in barcode2dText)
            {
                drawFormat.Alignment = StringAlignment.Near;
                g.DrawString(item.Text,
                             item.Font,
                             Brushes.Black, (float)(barcode2d.Location.X + 10),
                            lblBarcodeTop,
                             drawFormat);
                lblBarcodeTop += 15;
            }
            g.DrawLine(Pens.Black,
                       CustomerLabel.Right,
                       CustomerLabel.Top,
                       CustomerLabel.Right,
                       (float)PleaseReturnLabel.Bottom);
            g.DrawLine(Pens.Black,
                       PleaseReturnLabel.Left,
                       PleaseReturnLabel.Top,
                       PleaseReturnLabel.Right,
                       (float)PleaseReturnLabel.Top);

            e.HasMorePages = false;
        }
    }
}