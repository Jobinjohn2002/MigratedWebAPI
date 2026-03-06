using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class ContainerInstanceIdentifierData
    {
        /// <summary>
        /// Gets or sets IdentifierType
        /// </summary>
        public ContainerInstanceIdentifierTypeData IdentifierType { get; set; }
    }
}
