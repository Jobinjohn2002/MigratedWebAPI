using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// FacilityDetailsModel
    /// </summary>
    public class FacilityDetailsModel
    {
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public int FacilityId { get; set; }
        /// <summary>
        /// Gets or sets ProcessingMode
        /// </summary>
        public KnownProcessingMode ProcessingMode { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets GlobalCatalogEnabled
        /// </summary>
        public bool GlobalCatalogEnabled { get; set; }
        /// <summary>
        /// Gets or sets TenancyCatalogEnabled
        /// </summary>
        public bool TenancyCatalogEnabled { get; set; }
        /// <summary>
        /// Gets or sets FacilityCatalogEnabled
        /// </summary>
        public bool FacilityCatalogEnabled { get; set; }
        /// <summary>
        /// Gets or sets Address1
        /// </summary>
        public string Address1 { get; set; }
        /// <summary>
        /// Gets or sets Address2
        /// </summary>
        public string Address2 { get; set; }
        /// <summary>
        /// Gets or sets Address3
        /// </summary>
        public string Address3 { get; set; }
        /// <summary>
        /// Gets or sets City
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Gets or sets Postcode
        /// </summary>
        public string Postcode { get; set; }
        /// <summary>
        /// Gets or sets Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets Telephone
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// Gets or sets FDAEnabled
        /// </summary>
        public bool FDAEnabled { get; set; }

        /// <summary>
        /// Gets or sets ShowSuccessMessage
        /// </summary>
        public bool ShowSuccessMessage { get; set; }

        /// <summary>
        /// AvailableProcessingModes operation
        /// </summary>
        public Dictionary<string, int> AvailableProcessingModes(ITranslator translator)
        {
            return new Dictionary<string, int>
                
            {
                { translator.GetText("enum", "KnownProcessingMode", KnownProcessingMode.BestPractice.ToString()), (int)KnownProcessingMode.BestPractice },
                { translator.GetText("enum", "KnownProcessingMode", KnownProcessingMode.RelaxedProcessing.ToString()), (int)KnownProcessingMode.RelaxedProcessing },
                { translator.GetText("enum", "KnownProcessingMode", KnownProcessingMode.SystemLearning.ToString()), (int)KnownProcessingMode.SystemLearning },
            };      
        }
    }
}