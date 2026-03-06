using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ContainerInstanceIdentifierTypeDataContract
    /// </summary>
    public class ContainerInstanceIdentifierTypeDataContract
    {
        /// <summary>
        /// Gets or sets ContainerInstanceIdentifierTypeId
        /// </summary>
        public short ContainerInstanceIdentifierTypeId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets IsEditable
        /// </summary>
        public bool IsEditable { get; set; }
        /// <summary>
        /// Gets or sets IsUnique
        /// </summary>
        public bool IsUnique { get; set; }
    }
}
