using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TrolleyCollectedModel
    /// </summary>
    public class TrolleyCollectedModel : EpocTrolleyModel
    {
        private const string Group = "pages";
        private const string Section = "services.trolley.collected";

        /// <summary>
        /// Gets or sets TrolleyCollectedPrimaryId
        /// </summary>
        public string TrolleyCollectedPrimaryId { get; set; }

        public string TrolleyCollectedLabel => TrolleyCollectedPrimaryId;

        public override string TranslationGroup => Group;

        public override string TranslationSection => Section;
    }
}