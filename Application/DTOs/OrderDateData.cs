using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// OrderDateData
    /// </summary>
    public class OrderDateData
    {
        public DateTime? Date { get; set; }
        /// <summary>
        /// Gets or sets AlternateID
        /// </summary>
        public string AlternateID { get; set; }
        public int? OrderIdToUpdate { get; set; }
    }

}
