using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SimilarTurnaroundModel
    /// </summary>
    public class SimilarTurnaroundModel
    {
        /// <summary>
        /// Gets or sets ContainerMaster
        /// </summary>
        public ContainerMaster ContainerMaster { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public DeliveryPoint DeliveryPoint { get; set; }
        /// <summary>
        /// Gets or sets TableModel
        /// </summary>
        public TableModel TableModel { get; set; }
    }
}