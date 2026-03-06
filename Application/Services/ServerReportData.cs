using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Services
{
    using Microsoft.Reporting.WinForms;

    /// <summary>
    /// The data required for a Server Report.
    /// Moved in here from Synergy.LabelPrinting nuget as reference to Microsoft.ReportViewer was causing SynergyTrak downloads to be too big!!
    /// </summary>
    /// <summary>
    /// ServerReportData
    /// </summary>
    public class ServerReportData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServerReportData"/> class.
        /// </summary>
        public ServerReportData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerReportData"/> class.
        /// </summary>
        /// <param name="reportTypeIdentifier">The report name.</param>
        /// <param name="parameters">The report parameters.</param>
        public ServerReportData(ReportTypeIdentifier reportTypeIdentifier, List<ReportParameter> parameters)
        {
            ReportName = reportTypeIdentifier.ToString();
            Parameters = parameters;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerReportData"/> class.
        /// </summary>
        /// <param name="reportTypeIdentifier">The report name.</param>
        /// <param name="parameters">The report parameters.</param>
        /// <param name="path">The name of a facility/tenancy/customer specific report.</param>
        public ServerReportData(ReportTypeIdentifier reportTypeIdentifier, List<ReportParameter> parameters, string path)
        {
            ReportName = reportTypeIdentifier.ToString();
            Parameters = parameters;
            ReportPath = path;
        }

        #region Properties

        /// <summary>
        /// Gets the name of the report.
        /// </summary>
        /// <summary>
        /// Gets or sets ReportName
        /// </summary>
        public string ReportName { get; private set; }

        /// <summary>
        /// Gets the list of report parameters.
        /// </summary>
        /// <summary>
        /// Gets or sets Parameters
        /// </summary>
        public List<ReportParameter> Parameters { get; private set; }

        /// <summary>
        /// Gets the name of a facility/tenancy/customer specific report.
        /// </summary>
        /// <summary>
        /// Gets or sets ReportPath
        /// </summary>
        public string ReportPath { get; private set; }

        #endregion
    }
}
