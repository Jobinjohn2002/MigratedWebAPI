using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TurnaroundInfo
    /// </summary>
    public class TurnaroundInfo
    {
        DateTime expiry;
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public long ExternalId { get; set; }
        public int? ParentId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstance
        /// </summary>
        public ContainerInstanceInfo ContainerInstance { get; set; }
        public DateTime Expiry
        {
            get
            {
                return expiry;
            }
            set
            {
                expiry = DateTime.SpecifyKind(value, DateTimeKind.Utc);
            }
        }
    }
}