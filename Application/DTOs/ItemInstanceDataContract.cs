using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemInstanceDataContract
    /// </summary>
    public class ItemInstanceDataContract
    {
        /// <summary>
        /// Gets or sets ItemInstanceId
        /// </summary>
        public int ItemInstanceId { get; set; }
        public List<ItemInstanceIdentifierDataContract> ItemInstanceIdentifierList {get; set;}
        /// <summary>
        /// Gets or sets InstanceName
        /// </summary>
        public string InstanceName { get; set; }

        [IgnoreDataMember]
        /// <summary>
        /// Gets or sets HasBeenScanned
        /// </summary>
        public bool HasBeenScanned { get; set; }    // Client side only.
    }
}