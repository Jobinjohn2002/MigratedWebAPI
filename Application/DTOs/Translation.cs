using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class Translation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use TranslationFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public Translation()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets TranslationId
        /// </summary>
        public int TranslationId { get; set; }
        /// <summary>
        /// Gets or sets Application
        /// </summary>
        public string Application { get; set; }
        /// <summary>
        /// Gets or sets LanguageSet
        /// </summary>
        public string LanguageSet { get; set; }
        /// <summary>
        /// Gets or sets Culture
        /// </summary>
        public string Culture { get; set; }
        /// <summary>
        /// Gets or sets SectionGroup
        /// </summary>
        public string SectionGroup { get; set; }
        /// <summary>
        /// Gets or sets Section
        /// </summary>
        public string Section { get; set; }
        /// <summary>
        /// Gets or sets From
        /// </summary>
        public string From { get; set; }
        /// <summary>
        /// Gets or sets To
        /// </summary>
        public string To { get; set; }
    }
}
