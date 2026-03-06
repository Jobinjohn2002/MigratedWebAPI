using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ReportNavigationMenuModel
    /// </summary>
    public class ReportNavigationMenuModel
    {
        /// <summary>
        /// Gets or sets ID
        /// </summary>
        public short ID { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets Url
        /// </summary>
        public string Url { get; set; }
    }

    /// <summary>
    /// ReportCardModel
    /// </summary>
    public class ReportCardModel
    {
        /// <summary>
        /// Gets or sets Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets ReportId
        /// </summary>
        public short ReportId { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Type
        /// </summary>
        public ReportTypeExternalIdentifier Type { get; set; }
        /// <summary>
        /// Gets or sets Url
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Gets or sets IsFavourite
        /// </summary>
        public bool IsFavourite { get;set; }
        /// <summary>
        /// Gets or sets IsCustom
        /// </summary>
        public bool IsCustom { get; set; }
        /// <summary>
        /// Gets or sets FavouriteReportId
        /// </summary>
        public int FavouriteReportId { get;set; }
        /// <summary>
        /// Gets or sets ParametersChanged
        /// </summary>
        public bool ParametersChanged { get;set; }
        /// <summary>
        /// Gets or sets ReportOutputTypeId
        /// </summary>
        public int ReportOutputTypeId { get; set; }
        /// <summary>
        /// Gets or sets OriginalName
        /// </summary>
        public string OriginalName { get;set; }
    }
}