using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CatalogueLoansetCase
    /// </summary>
    public class CatalogueLoansetCase
    {
        [Required]
        /// <summary>
        /// Gets or sets CaseId
        /// </summary>
        public int CaseId { get; set; }
        /// <summary>
        /// Gets or sets CaseNumber
        /// </summary>
        public string CaseNumber { get; set; }
        /// <summary>
        /// Gets or sets ForeignCaseId
        /// </summary>
        public string ForeignCaseId { get; set; }
        [Required]
        /// <summary>
        /// Gets or sets SiteId
        /// </summary>
        public int SiteId { get; set; }
        /// <summary>
        /// Gets or sets SiteName
        /// </summary>
        public string SiteName { get; set; }
        [Required]
        /// <summary>
        /// Gets or sets TenantCode
        /// </summary>
        public string TenantCode { get; set; }
        /// <summary>
        /// Gets or sets TenantName
        /// </summary>
        public string TenantName { get; set; }
        [Required]
        /// <summary>
        /// Gets or sets StartTime
        /// </summary>
        public DateTime StartTime { get; set; }
        [Required]
        /// <summary>
        /// Gets or sets EndTime
        /// </summary>
        public DateTime EndTime { get; set; }
        [Required]
        /// <summary>
        /// Gets or sets OrRoomId
        /// </summary>
        public int OrRoomId { get; set; }
        /// <summary>
        /// Gets or sets OrRoomName
        /// </summary>
        public string OrRoomName { get; set; }
        /// <summary>
        /// Gets or sets State
        /// </summary>
        public int State { get; set; }

        [JsonIgnore]
        public bool KnownState
        {
            get
            {
                return Enum.IsDefined(typeof(KnownCatalogueLoanSetState), State);
            }
        }
        [Required]
        /// <summary>
        /// Gets or sets Procedures
        /// </summary>
        public List<CatalogueLoansetProcedure> Procedures { get; set; }
    }
}