using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CustomerDataContract
    /// </summary>
    public class CustomerDataContract
    {
        /// <summary>
        /// Gets or sets DefinitionId
        /// </summary>
        public int DefinitionId { get; set; }
        /// <summary>
        /// Gets or sets DefinitionType
        /// </summary>
        public short DefinitionType { get; set; }
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets StatusId
        /// </summary>
        public int StatusId { get; set; }
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoints
        /// </summary>
        public List<DeliveryPointDataContract> DeliveryPoints { get; set; }
        /// <summary>
        /// Gets or sets DateTimeFormats
        /// </summary>
        public DateTimeFormatDataContract DateTimeFormats { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public int FacilityId { get; set; }
        /// <summary>
        /// Gets or sets IsHeader
        /// </summary>
        public bool IsHeader { get; set; }
        public short? QaLabelProceCodeId { get; set; }
        public short? Linear1DBarcodeId { get; set; }
        public short? Datamatrix2DBarcodeId { get; set; }
        public bool? ForceOrderToMatchDPsetting { get; set; }
        /// <summary>
        /// Gets or sets CanCreateNewTurnaround
        /// </summary>
        public bool CanCreateNewTurnaround { get; set; }
    }
}