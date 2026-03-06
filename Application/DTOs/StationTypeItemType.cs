using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class StationTypeItemType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use StationTypeItemTypeFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public StationTypeItemType()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets StationTypeItemTypeId
        /// </summary>
        public int StationTypeItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets StationTypeId
        /// </summary>
        public byte StationTypeId { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public short ItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets Assigned
        /// </summary>
        public bool Assigned { get; set; }
    
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public virtual ItemType ItemType { get; set; }
        /// <summary>
        /// Gets or sets StationType
        /// </summary>
        public virtual StationType StationType { get; set; }
    }
}
