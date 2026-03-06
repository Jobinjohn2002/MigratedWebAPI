using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TrolleyLoadModel
    /// </summary>
    public class TrolleyLoadModel : EpocTrolleyModel
    {
        private const string Group = "pages";
        private const string Section = "services.trolley.load";

        public readonly static TrolleyLoadModel NULL = new TrolleyLoadModel();

        /// <summary>
        /// Gets or sets TrolleyLoadedInstanceId
        /// </summary>
        public int TrolleyLoadedInstanceId { get; set; }
        /// <summary>
        /// Gets or sets TrolleyLoadedExternalId
        /// </summary>
        public string TrolleyLoadedExternalId { get; set; }

        public override string TranslationGroup => Group;

        public override string TranslationSection => Section;
    }
}
