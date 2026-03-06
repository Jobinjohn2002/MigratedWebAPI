using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class CombinedBarcodeInstanceLabel : Form, IPrintableForm
    {
        private readonly string _printerName;
        public CombinedBarcodeInstanceLabel()
        {
            InitializeComponent();
        }

        public CombinedBarcodeInstanceLabel(string printerName, InstanceLabelData instance)
        {
            InitializeComponent();
            CustomerLabel.Text = instance.CustomerName;
            ItemNameLabel.Text = instance.ItemName;
            DeliveryPointLabel.Text = instance.DeliveryPointName;
            barcode2d.Code = instance.Datamatrix2dBarcode;
            barcode1d.Code = instance.InstanceExternalId;
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

            barcode2d.DrawOnCanvas(g, new PointF(2.7f, 0.1f), new SizeF(0.6F, 0.48F));

            var rect = new RectangleF(ItemNameLabel.Left,
                                    ItemNameLabel.Top,
                                    ItemNameLabel.Width,
                                    ItemNameLabel.Height);
            Label lbl = new Label();
            float fntSize = 13F;
            lbl.Text = ItemNameLabel.Text;
            lbl.Font = new Font(ItemNameLabel.Font.FontFamily, fntSize);
            while ((lbl.PreferredWidth + 50) > ItemNameLabel.Width)
            {
                if (fntSize > 7.0F)
                {
                    fntSize -= 0.5F;
                    lbl.Font = new Font(Font.FontFamily, fntSize);
                }
                else
                {
                    ItemNameLabel.MaximumSize = new Size(284, 0);
                    ItemNameLabel.AutoSize = true;
                    break;

                }
            }
            ItemNameLabel.Font = new Font(lbl.Font.FontFamily, fntSize);

            g.DrawString(ItemNameLabel.Text,
                         ItemNameLabel.Font,
                         Brushes.Black,
                         rect,
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

            barcode1d.DrawOnCanvas(g, new PointF(3.6f, 0.15f));

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
