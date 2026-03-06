using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// DecontaminationTaskDataContract
    /// </summary>
    public class DecontaminationTaskDataContract
    {
        /// <summary>
        /// Gets or sets DeconTaskId
        /// </summary>
        public int DeconTaskId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets Order
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// Gets or sets FailureTypes
        /// </summary>
        public List<DataValueDataContract> FailureTypes { get; set; }
    }
}