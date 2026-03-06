using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// AvailableForCollectionModel
    /// </summary>
    public class AvailableForCollectionModel : EpocTrolleyModel
    {
        private const string Group = "pages";
        private const string Section = "services.trolley.availableforcollection";

        /// <summary>
        /// Gets or sets MadeAvailablePrimaryId
        /// </summary>
        public string MadeAvailablePrimaryId { get; set; }

        /// <summary>
        /// Gets or sets ContainerInstanceId
        /// </summary>
        public int ContainerInstanceId { get; set; }

        public string MadeAvailableLabel => MadeAvailablePrimaryId;

        public override string TranslationGroup => Group;

        public override string TranslationSection => Section;

        /// <summary>
        /// Gets or sets TurnaroundTable
        /// </summary>
        public TableModel TurnaroundTable { get; set; }
    }
}