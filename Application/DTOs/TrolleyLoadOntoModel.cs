using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TrolleyLoadOntoModel
    /// </summary>
    public class TrolleyLoadOntoModel : EpocTrolleyModel
    {
        private const string Group = "pages";
        private const string Section = "services.trolley.load";

        /// <summary>
        /// Gets or sets TrolleyLoadedInstanceId
        /// </summary>
        public int TrolleyLoadedInstanceId { get; set; }
        /// <summary>
        /// Gets or sets TrolleyLoadedPrimaryId
        /// </summary>
        public string TrolleyLoadedPrimaryId { get; set; }

        public string TrolleyLoadedLabel => TrolleyLoadedPrimaryId;

        /// <summary>
        /// Gets or sets InstanceToAddId
        /// </summary>
        public int InstanceToAddId { get; set; }
        /// <summary>
        /// Gets or sets LastLoadedContainerInstancePrimaryId
        /// </summary>
        public string LastLoadedContainerInstancePrimaryId { get; set; }

        public override string TranslationGroup => Group;

        public override string TranslationSection => Section;
    }
}