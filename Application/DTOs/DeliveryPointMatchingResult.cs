using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DeliveryPointMatchingResult
    /// </summary>
    public class DeliveryPointMatchingResult
    {
        public enum DeliveryPointResult
        {
            MatchedFromRule,
            MatchedFromName,
            MatchedButInvalid,
            Unmatched
        }

        /// <summary>
        /// Gets or sets Result
        /// </summary>
        public DeliveryPointResult Result { get; set; }

        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public DeliveryPoint DeliveryPoint { get; set; }

    }
}
