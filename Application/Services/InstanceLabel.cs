using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class InstanceLabel : Form, IPrintableForm
    {
        private readonly string _printerName;

        public InstanceLabel()
        {
            InitializeComponent();
        }

        public InstanceLabel(string printerName, InstanceLabelData instance)
        {
            InitializeComponent();
            CustomerLabel.Text = instance.CustomerName;
            ItemNameLabel.Text = instance.ItemName;
            DeliveryPointLabel.Text = instance.DeliveryPointName;
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
                         (float) CustomerLabel.Left + (CustomerLabel.Width/2),
                         CustomerLabel.Top,
                         drawFormat);

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
                         (float) PleaseReturnLabel.Left + (PleaseReturnLabel.Width/2),
                         PleaseReturnLabel.Top,
                         drawFormat);

            g.DrawString(DeliveryPointLabel.Text,
                         DeliveryPointLabel.Font,
                         Brushes.Black,
                         (float) DeliveryPointLabel.Left + (DeliveryPointLabel.Width/2),
                         DeliveryPointLabel.Top,
                         drawFormat);

            barcode1d.DrawOnCanvas(g, new PointF(3.5f, 0.15f));

            g.DrawLine(Pens.Black,
                       CustomerLabel.Right,
                       CustomerLabel.Top,
                       CustomerLabel.Right,
                       (float) PleaseReturnLabel.Bottom);

            g.DrawLine(Pens.Black,
                       (float) PleaseReturnLabel.Left + 25,
                       PleaseReturnLabel.Top,
                       (float) PleaseReturnLabel.Right - 25,
                       PleaseReturnLabel.Top);
            g.DrawLine(Pens.Black,
                       (float) PleaseReturnLabel.Left + 25,
                       (float) PleaseReturnLabel.Top - 1,
                       (float) PleaseReturnLabel.Right - 25,
                       (float) PleaseReturnLabel.Top - 1);
            g.DrawLine(Pens.Black,
                       (float) PleaseReturnLabel.Left + 25,
                       (float) PleaseReturnLabel.Top - 2,
                       (float) PleaseReturnLabel.Right - 25,
                       (float) PleaseReturnLabel.Top - 2);

            e.HasMorePages = false;
        }
    }
}