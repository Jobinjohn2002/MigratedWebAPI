using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ReportModel
    /// </summary>
    public class ReportModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "ReportName")]
        /// <summary>
        /// Gets or sets ReportName
        /// </summary>
        public string ReportName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "ReportPath")]
        /// <summary>
        /// Gets or sets ReportPath
        /// </summary>
        public string ReportPath { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "ReportDescription")]
        /// <summary>
        /// Gets or sets ReportDescription
        /// </summary>
        public string ReportDescription { get; set; }

        [Display(Name = "ReportParameters")]
        /// <summary>
        /// Gets or sets ReportParameters
        /// </summary>
        public ReportParameterInfoCollection ReportParameters { get; set; }

        /// <summary>
        /// Gets or sets DateReportParameters
        /// </summary>
        public List<ReportParameter> DateReportParameters { get; set; }

        /// <summary>
        /// Gets or sets TablaeuViewUrl
        /// </summary>
        public string TablaeuViewUrl { get; set; }

        /// <summary>
        /// Gets or sets ReportId
        /// </summary>
        public short ReportId { get; set; }
        /// <summary>
        /// Gets or sets FavouriteReportId
        /// </summary>
        public int FavouriteReportId { get;set; }
        /// <summary>
        /// Gets or sets ParametersChanged
        /// </summary>
        public bool ParametersChanged { get;set; }
        /// <summary>
        /// Gets or sets EmailReportOutputId
        /// </summary>
        public int EmailReportOutputId { get; set; }
    }
}
