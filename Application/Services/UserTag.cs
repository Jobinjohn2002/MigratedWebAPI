using System.Drawing;
using System.Drawing.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class UserTag : Form, IPrintableForm
    {
        private readonly string _printerName;

        public UserTag()
        {
            InitializeComponent();
        }

        public UserTag(string printerName, UserTagData userTag)
        {
             InitializeComponent();
            _printerName = printerName;
            lblFirstName.Text = string.Empty;
            lblSurName.Text = string.Empty;
            lblFullName.Text = string.Empty;
            barcode1d.Code = userTag.ExternalId;

            if (userTag.FirstName.Length + userTag.Surname.Length > 20)
            {
                lblFirstName.Text = userTag.FirstName;
                lblSurName.Text = userTag.Surname;
            }
            else
            {
                lblFullName.Text = userTag.FirstName + " " + userTag.Surname;
                lblFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            }
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
            var width = (e.PageBounds.Width / 2) + 10; // an extra 10 pixels to recover some margin
            var height = e.PageBounds.Height;

            var bounds = new Rectangle(width - 10, 1, width - 2, height - 3);

            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            using (var format = new StringFormat())
            {
                format.Trimming = StringTrimming.None;
                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Center;

                var txt = string.IsNullOrEmpty(lblFullName.Text)
                    ? string.Format("{0} {1}", lblFirstName.Text, lblSurName.Text).Trim()
                    : lblFullName.Text.Trim();

                using (var font = new Font(lblSurName.Font.FontFamily, height / 3.6f))
                {
                    e.Graphics.DrawString(txt, font, Brushes.Black, bounds, format);
                }
            }

            barcode1d.DrawOnCanvas(e.Graphics, new PointF(0.3f, 0.1f));
            e.HasMorePages = false;
        }
    }
}