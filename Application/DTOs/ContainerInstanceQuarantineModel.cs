using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ContainerInstanceQuarantineModel
    /// </summary>
    public class ContainerInstanceQuarantineModel
    {
        /// <summary>
        /// Gets or sets ContainerInstance
        /// </summary>
        public ContainerInstance ContainerInstance { get; set; }
        /// <summary>
        /// Gets or sets QuarantineReasons
        /// </summary>
        public IEnumerable<SelectListItem> QuarantineReasons { get; set; }
        public short? SelectedQuarantineReasonId { get; set; }
    }
}