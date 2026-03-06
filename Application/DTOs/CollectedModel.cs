using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CollectedModel
    /// </summary>
    public class CollectedModel : EpocTrolleyModel
    {
        private const string Group = "pages";
        private const string Section = "services.trolley.collected";

        /// <summary>
        /// Gets or sets CollectedPrimaryId
        /// </summary>
        public string CollectedPrimaryId { get; set; }

        public string CollectedLabel => CollectedPrimaryId;

        public override string TranslationGroup => Group;

        public override string TranslationSection => Section;
    }

    public abstract class EpocModel
    {
        /// <summary>
        /// Gets or sets PrimaryId
        /// </summary>
        public string PrimaryId { get; set; }

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