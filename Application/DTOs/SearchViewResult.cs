using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Flags]
    public enum SearchCategoryType : long
    {
        All = 0,
        ChangeRequest = 1,
        ContainerInstance = 2,
        ContainerMaster = 4,
        CustomerDefect = 8,
        Defect = 16,
        DeliveryNote = 32,
        Enquiry = 64,
        FastTrack = 128,
        ItemMaster = 256,
        LoanSet = 512,
        Turnaround = 1024,
        StoragePoint = 2048,
        Order = 4096,
        OrderTemplate = 8192,
        SurgicalProcedure = 16384,
        MaintenanceReport = 32768
    }

    /// <summary>
    /// SearchViewResult
    /// </summary>
    public class SearchViewResult
    {
        /// <summary>
        /// Gets or sets MatchedIdType
        /// </summary>
        public string MatchedIdType { get; set; }
        /// <summary>
        /// Gets or sets MatchedId
        /// </summary>
        public string MatchedId { get; set; }
        /// <summary>
        /// Gets or sets ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Gets or sets ExternalID
        /// </summary>
        public string ExternalID { get; set; }
        /// <summary>
        /// Gets or sets AlternateID
        /// </summary>
        public string AlternateID { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets Action
        /// </summary>
        public ActionInfo Action { get; set; }
        /// <summary>
        /// Gets or sets Type
        /// </summary>
        public SearchCategoryType Type { get; set; }
        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        public string Customer { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public string DeliveryPoint { get; set; }
        public DateTime? Date { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEventName
        /// </summary>
        public string TurnaroundEventName { get; set; }
    }
}
