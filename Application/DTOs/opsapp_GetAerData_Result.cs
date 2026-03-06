using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class opsapp_GetAerData_Result
    {
        /// <summary>
        /// Gets or sets MachineId
        /// </summary>
        public int MachineId { get; set; }
        /// <summary>
        /// Gets or sets BatchPrefix
        /// </summary>
        public string BatchPrefix { get; set; }
        /// <summary>
        /// Gets or sets MachineText
        /// </summary>
        public string MachineText { get; set; }
        /// <summary>
        /// Gets or sets RunningTime
        /// </summary>
        public short RunningTime { get; set; }
        /// <summary>
        /// Gets or sets ReadOnly
        /// </summary>
        public bool ReadOnly { get; set; }
        /// <summary>
        /// Gets or sets DisinfectionOverdue
        /// </summary>
        public Nullable<bool> DisinfectionOverdue { get; set; }
        /// <summary>
        /// Gets or sets CurrentlyInProgressBatchId
        /// </summary>
        public Nullable<int> CurrentlyInProgressBatchId { get; set; }
        /// <summary>
        /// Gets or sets CurrentlyInProgressBatchExternalId
        /// </summary>
        public string CurrentlyInProgressBatchExternalId { get; set; }
        public Nullable<System.DateTime> CurrentlyInProgressBatchStarted { get; set; }
        /// <summary>
        /// Gets or sets MachineEventTypeId
        /// </summary>
        public Nullable<byte> MachineEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets CurrentlyInProgressBatchHasCurrentlyAssignedTurnarounds
        /// </summary>
        public Nullable<bool> CurrentlyInProgressBatchHasCurrentlyAssignedTurnarounds { get; set; }
        /// <summary>
        /// Gets or sets CurrentlyInProgressBatchCycleId
        /// </summary>
        public Nullable<int> CurrentlyInProgressBatchCycleId { get; set; }
        /// <summary>
        /// Gets or sets LocationId
        /// </summary>
        public int LocationId { get; set; }
        /// <summary>
        /// Gets or sets LocationDescription
        /// </summary>
        public string LocationDescription { get; set; }
        /// <summary>
        /// Gets or sets LocationText
        /// </summary>
        public string LocationText { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceId
        /// </summary>
        public Nullable<int> ContainerInstanceId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceLinear1dBarcodeId
        /// </summary>
        public Nullable<short> ContainerInstanceLinear1dBarcodeId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceDatamatrix2dBarcodeId
        /// </summary>
        public Nullable<short> ContainerInstanceDatamatrix2dBarcodeId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterText
        /// </summary>
        public string ContainerMasterText { get; set; }
        public Nullable<System.DateTime> AssignedToAerEventCreated { get; set; }
        /// <summary>
        /// Gets or sets AssignedToAerEventUsersName
        /// </summary>
        public string AssignedToAerEventUsersName { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointText
        /// </summary>
        public string DeliveryPointText { get; set; }
    }
}
