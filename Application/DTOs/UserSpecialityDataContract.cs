using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// UserSpecialityDataContract
    /// </summary>
    public class UserSpecialityDataContract
    {
        /// <summary>
        /// Gets or sets SpecialityId
        /// </summary>
        public int SpecialityId { get; set; }
        /// <summary>
        /// Gets or sets Complexity
        /// </summary>
        public int Complexity { get; set; }
    }
}