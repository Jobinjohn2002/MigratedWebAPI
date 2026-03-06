using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CatalogueLoansetProduct
    /// </summary>
    public class CatalogueLoansetProduct
    {
        [Required]
        /// <summary>
        /// Gets or sets MasterLoanerId
        /// </summary>
        public int MasterLoanerId { get; set; }
        [Required]
        [MaxLength(100)]
        /// <summary>
        /// Gets or sets MasterLoanerName
        /// </summary>
        public string MasterLoanerName { get; set; }
        /// <summary>
        /// Gets or sets MasterLoanerDataModified
        /// </summary>
        public DateTime MasterLoanerDataModified { get; set; }
        [Required]
        [MaxLength(50)]
        /// <summary>
        /// Gets or sets UniqueId
        /// </summary>
        public string UniqueId { get; set; }
        [Required]
        [MaxLength(50)]
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public string Status { get; set; }

        [JsonIgnore]
        public bool KnownStatus
        {
            get
            {
                return Enum.TryParse(Status, true, out KnownCatalogueLoanSetStatus _);
            }
        }
        public DateTime? DateReceived { get; set; }
        public DateTime? DateReturned { get; set; }
        [Required]
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
    }
}