using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// TrakStarPrint
    /// </summary>
    public class TrakStarPrint
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationPrinter"></param>
        /// <param name="asset"></param>
        /// <summary>
        /// PrintInstanceLabel operation
        /// </summary>
        static public void PrintInstanceLabel(StationPrinter stationPrinter, Asset asset)
        {
            Product product = Product.GetByVersionId(asset.ProductVersionID);
            Customer customer = Customer.GetById(asset.Location.CustomerID);
            KnownPrintType pti = KnownPrintType.InstanceLabel;

            string datamatrix2DBarcode = GetInstanceString(asset.Linear1dBarcodeID, asset);
            string instanceExternalId = GetInstanceString(asset.DataMatrix2dBarcodeId, asset); ;

            if ((!string.IsNullOrEmpty(instanceExternalId)) && (string.IsNullOrEmpty(datamatrix2DBarcode)))
            {
                pti = KnownPrintType.CombinedBarcodeInstanceLabel;
            }
            else if (string.IsNullOrEmpty(datamatrix2DBarcode))
            {
                pti = KnownPrintType.TwoDBarcodeInstanceLabel;
            }

            Print.SendToPrinter(stationPrinter.Printer.Text, 1, true, pti, new InstanceLabelData(product.Name, customer.Text, customer.GS1Code, asset.Location.Name, instanceExternalId, pti, datamatrix2DBarcode));
        }

        static string GetInstanceString(int? barcodeId, Asset asset)
        {
            if (barcodeId.HasValue)
            {
                if (barcodeId == (int)KnownCustomerLabelType.InstanceExternalId)
                {
                    return asset.ExternalID;
                }
                else if (barcodeId == (int)KnownCustomerLabelType.AlternateInstanceId)
                {
                    return asset.AlternateExternalId;
                }
            }

            return null;
        }
    }

    /// <summary>
    /// InstanceLabelData
    /// </summary>
    public class InstanceLabelData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        /// <remarks></remarks>
        public InstanceLabelData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstanceLabelData"/> class.
        /// </summary>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="customerName">Name of the customer.</param>
        /// <param name="customerGs1">The customer GS1.</param>
        /// <param name="deliveryPointName">Name of the delivery point.</param>
        /// <param name="instanceExternalId">The instance external id.</param>
        /// <remarks></remarks>
        public InstanceLabelData(string itemName,
                                 string customerName,
                                 string customerGs1,
                                 string deliveryPointName,
                                 string instanceExternalId,
                                 KnownPrintType printTypeIdentifierValue, string datamatrix2dBarcode = default(string))
        {
            CustomerName = customerName;
            CustomerGs1 = customerGs1;
            DeliveryPointName = deliveryPointName;
            InstanceExternalId = instanceExternalId;
            ItemName = itemName;
            PrintTypeIdentifierValue = printTypeIdentifierValue;
            Datamatrix2dBarcode = datamatrix2dBarcode;
        }

        #region Properties

        /// <summary>
        /// Gets the name of the item.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; private set; }

        /// <summary>
        /// Gets the instance external id.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets InstanceExternalId
        /// </summary>
        public string InstanceExternalId { get; private set; }

        /// <summary>
        /// Gets the Datamatrix2dBarcode instance external id.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Datamatrix2dBarcode
        /// </summary>
        public string Datamatrix2dBarcode { get; private set; }

        /// <summary>
        /// Gets the name of the customer.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; private set; }

        /// <summary>
        /// Gets the customer GS1.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerGs1
        /// </summary>
        public string CustomerGs1 { get; private set; }

        /// <summary>
        /// Gets the name of the delivery point.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; private set; }

        /// <summary>
        /// Gets or sets PrintTypeIdentifierValue
        /// </summary>
        public KnownPrintType PrintTypeIdentifierValue { get; private set; }

        #endregion
    }

    /// <summary>
    /// Print
    /// </summary>
    public class Print
    {
        /// <summary>
        /// SendToPrinter operation
        /// </summary>
        static public Print SendToPrinter(string printerName, int quantity, bool awaitingReturn, KnownPrintType printType, object printableObject)
        {
            var pd = new Print(printerName, quantity, awaitingReturn, printType, printableObject);

            var printHandler = GetPrintHandler(pd.PrintType);
            printHandler.PrintDetails = pd;

            var foregroundThread = new Thread(pd.DoThePrinting) { Name = "Foreground Printer thread" };
            foregroundThread.Start(printHandler);

            return pd;
        }

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PrintDetails"/> class.
        /// </summary>
        /// <param name="printer">The printer.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="awaitingReturn">if set to <c>true</c> [awaiting return].</param>
        /// <param name="printType">The print type.</param>
        /// <remarks></remarks>
        Print(string printerName, int quantity, bool awaitingReturn, KnownPrintType printType, object printableObject)
        {
            PrinterName = printerName;
            Quantity = quantity;
            AwaitingReturn = awaitingReturn;
            PrintType = printType;
            PrintableObject = printableObject;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets the printer.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets PrinterName
        /// </summary>
        public string PrinterName { get; private set; }

        /// <summary>
        /// Gets the quantity.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// Gets a value indicating whether [awaiting return].
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets AwaitingReturn
        /// </summary>
        public bool AwaitingReturn { get; private set; }

        /// <summary>
        /// Gets the print type.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets PrintType
        /// </summary>
        public KnownPrintType PrintType { get; private set; }

        /// <summary>
        /// Gets the printable object.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets PrintableObject
        /// </summary>
        public object PrintableObject { get; private set; }

        #endregion

        /// <summary>
        /// Prints the printable object, on a foreground thread, which stops the appDomain from closing until it has finished.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// DoThePrinting operation
        /// </summary>
        public void DoThePrinting(object obj)
        {
            var printHandler = obj as PrintHandlerBase;

            if (printHandler != null)
            {
                printHandler.Print();
            }
        }

        /// <summary>
        /// Takes identifier and returns handler.
        /// </summary>
        /// <param name="printType"></param>
        /// <returns></returns>
        static PrintHandlerBase GetPrintHandler(KnownPrintType printType)
        {
            switch (printType)
            {
                case KnownPrintType.TurnaroundLabel:
                    return new TurnaroundLabelPrintHandler();

                case KnownPrintType.InstanceLabel:
                    return new InstanceLabelPrintHandler();

                case KnownPrintType.StationLabel:
                    return new StationLabelPrintHandler();

                case KnownPrintType.TwoDBarcodeInstanceLabel:
                    return new InstanceLabelPrintHandler();

                case KnownPrintType.DeliveryPointTag:
                    return new PlainTagPrintHandler();

                case KnownPrintType.UserTag:
                    return new UserTagPrintHandler();

                case KnownPrintType.Report:
                    return new ReportPrintHandler();
                case KnownPrintType.Normal:
                    return new TestPrintHandler();

                case KnownPrintType.CombinedBarcodeInstanceLabel:
                    return new InstanceLabelPrintHandler();
            }

            return null;
        }
    }

}
