using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class ContainerMasterContract
    {

        /// <summary>
        /// Gets or sets MachineType
        /// </summary>
        public byte MachineType { get; set; }

        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }

        /// <summary>
        /// Gets or sets ProcessingBatchCycles
        /// </summary>
        public List<BatchCycleData> ProcessingBatchCycles { get; set; }

        /// <summary>
        /// Gets or sets ProcessingDecontaminationTasks
        /// </summary>
        public List<DecontaminationTaskData> ProcessingDecontaminationTasks { get; set; }
    }
}
