using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CustomerDefectEmailModel
    /// </summary>
    public class CustomerDefectEmailModel
    {
        /// <summary>
        /// Gets or sets Reference
        /// </summary>
        public string Reference { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundExternalID
        /// </summary>
        public string TurnaroundExternalID { get; set; }
        /// <summary>
        /// Gets or sets ContainerMaster
        /// </summary>
        public string ContainerMaster { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterExternalID
        /// </summary>
        public string ContainerMasterExternalID { get; set; }
        /// <summary>
        /// Gets or sets Response
        /// </summary>
        public string Response { get; set; }
        /// <summary>
        /// Gets or sets ResponseBy
        /// </summary>
        public string ResponseBy { get; set; }
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; } 
        /// <summary>
        /// Gets or sets History
        /// </summary>
        public List<CustomerDefectEmailModel> History { get; set; }
        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        public string Customer { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public string DeliveryPoint { get; set; }
        /// <summary>
        /// Gets or sets CSRReasons
        /// </summary>
        public List<CustomerDefectReason> CSRReasons { get; set; }
        /// <summary>
        /// Gets or sets CSRDetailNotes
        /// </summary>
        public string CSRDetailNotes { get; set; }
        /// <summary>
        /// Gets or sets URL
        /// </summary>
        public string URL { get; set; }
    }
}