using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CollectionModelDescription
    /// </summary>
    public class CollectionModelDescription : ModelDescription
    {
        /// <summary>
        /// Gets or sets ElementDescription
        /// </summary>
        public ModelDescription ElementDescription { get; set; }
    }
}