using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// StoragePointDeleteModel
    /// </summary>
    public class StoragePointDeleteModel
    {
        /// <summary>
        /// Gets or sets StoragePoint
        /// </summary>
        public StoragePoint StoragePoint { get; set; }
        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        public Customer Customer { get; set; }
        /// <summary>
        /// Gets or sets State
        /// </summary>
        public DeleteModelState State { get; set; }
    }
}