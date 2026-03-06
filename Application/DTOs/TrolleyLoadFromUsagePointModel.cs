using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TrolleyLoadFromUsagePointModel
    /// </summary>
    public class TrolleyLoadFromUsagePointModel : EpocTrolleyModel
    {
        private const string Group = "pages";
        private const string Section = "services.trolley.loadfromusagepoint";

        /// <summary>
        /// Gets or sets Contents
        /// </summary>
        public TrolleyLoadFromUsagePointContentsModel Contents { get; set; }
        /// <summary>
        /// Gets or sets Warnings
        /// </summary>
        public List<string> Warnings { get; set; }

        public int? UsagePointId { get; set; }

        public override string TranslationGroup => Group;

        public override string TranslationSection => Section;
    }
}