using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public abstract class EpocTrolleyModel
    {
        public EpocTrolleyModel()
        {
            this.ChildContainers = new List<TrolleyContents>();
        }

        /// <summary>
        /// Gets or sets PrimaryId
        /// </summary>
        public string PrimaryId { get; set; }
        /// <summary>
        /// Gets or sets ChildContainers
        /// </summary>
        public IEnumerable<TrolleyContents> ChildContainers { get; set; }
        /// <summary>
        /// Gets or sets IsTrolley
        /// </summary>
        public bool IsTrolley { get; set; }

        public long? TurnaroundExternalId { get; set; }
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementText
        /// </summary>
        public string ServiceRequirementText { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeText
        /// </summary>
        public string ItemTypeText { get; set; }

        /// <summary>
        /// Gets or sets TranslationGroup
        /// </summary>
        public abstract string TranslationGroup { get; }
        /// <summary>
        /// Gets or sets TranslationSection
        /// </summary>
        public abstract string TranslationSection { get; }
    }
}