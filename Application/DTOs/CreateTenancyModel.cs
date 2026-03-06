using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CreateTenancyModel
    /// </summary>
    public class CreateTenancyModel
    {
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets TenancyName
        /// </summary>
        public string TenancyName { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets FacilityAddress1
        /// </summary>
        public string FacilityAddress1 { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets FacilityAddress2
        /// </summary>
        public string FacilityAddress2 { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets FacilityAddress3
        /// </summary>
        public string FacilityAddress3 { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets FacilityCity
        /// </summary>
        public string FacilityCity { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets FacilityPostCode
        /// </summary>
        public string FacilityPostCode { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets FacilityTelephone
        /// </summary>
        public string FacilityTelephone { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets FacilityEmail
        /// </summary>
        public string FacilityEmail { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets ImportData
        /// </summary>
        public HttpPostedFileBase ImportData { get; set; }

        /// <summary>
        /// Gets or sets ShowSavedBanner
        /// </summary>
        public bool ShowSavedBanner { get; set; }

        /// <summary>
        /// Gets or sets FacilityCatalogueEnabled
        /// </summary>
        public bool FacilityCatalogueEnabled { get; set; }
        /// <summary>
        /// Gets or sets TenancyCatalogueEnabled
        /// </summary>
        public bool TenancyCatalogueEnabled { get; set; }
        /// <summary>
        /// Gets or sets GlobalCatalogueEnabled
        /// </summary>
        public bool GlobalCatalogueEnabled { get; set; }
    }
}