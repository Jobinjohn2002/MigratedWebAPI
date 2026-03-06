using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class opsapp_GetEndoscopeOverview_Result
    {
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public Nullable<short> FacilityId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceId
        /// </summary>
        public int ContainerInstanceId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets Linear1dBarcodeId
        /// </summary>
        public Nullable<short> Linear1dBarcodeId { get; set; }
        /// <summary>
        /// Gets or sets Datamatrix2dBarcodeId
        /// </summary>
        public Nullable<short> Datamatrix2dBarcodeId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointText
        /// </summary>
        public string DeliveryPointText { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterText
        /// </summary>
        public string ContainerMasterText { get; set; }
        /// <summary>
        /// Gets or sets CurrentProcessEventTypeId
        /// </summary>
        public short CurrentProcessEventTypeId { get; set; }
        public System.DateTime CurrentProcessEventCreated { get; set; }
        /// <summary>
        /// Gets or sets MachineId
        /// </summary>
        public Nullable<int> MachineId { get; set; }
        /// <summary>
        /// Gets or sets MachineRunningTime
        /// </summary>
        public Nullable<short> MachineRunningTime { get; set; }
        /// <summary>
        /// Gets or sets MachineMaxDryingTime
        /// </summary>
        public Nullable<int> MachineMaxDryingTime { get; set; }
        /// <summary>
        /// Gets or sets LocationId
        /// </summary>
        public Nullable<int> LocationId { get; set; }
        /// <summary>
        /// Gets or sets LocationText
        /// </summary>
        public string LocationText { get; set; }
        /// <summary>
        /// Gets or sets LastKnownLocationId
        /// </summary>
        public Nullable<int> LastKnownLocationId { get; set; }
        /// <summary>
        /// Gets or sets LastKnownLocationText
        /// </summary>
        public string LastKnownLocationText { get; set; }
        public Nullable<System.DateTime> SterileExpiryDate { get; set; }
    }
}
