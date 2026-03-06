using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// HISOrderRequest
    /// </summary>
    public class HISOrderRequest
    {
        public const int MAX_LOCATION_LENGTH = 100;
        public const int MAX_YOUR_REFERENCE_LENGTH = 50;
        public const int MAX_SURGEON_NAME_LENGTH = 100;
        public const int MAX_SURGEON_CODE_LENGTH = 15;
        public const int MAX_PROCEDURE_CODE_LENGTH = 50;
        public const int MAX_PROCEDURE_NAME_LENGTH = 128;
        public const int MAX_YOUR_MESSAGE_REFERENCE_LENGTH = 50;

        /// <summary>
        /// The Synergy CustomerDefinitionId that this order is for.
        /// </summary>
        [Required]
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }

        /// <summary>
        /// The delivery location for this order.
        /// </summary>
        [Required]
        [MaxLength(MAX_LOCATION_LENGTH)]
        /// <summary>
        /// Gets or sets Location
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// The individual products, with quantities, to add to this order.
        /// </summary>
        /// <summary>
        /// Gets or sets Lines
        /// </summary>
        public List<HISOrderRequestLine> Lines { get; set; }

        /// <summary>
        /// The procedure date of the order.
        /// </summary>
        [Required]
        /// <summary>
        /// Gets or sets ProcedureDate
        /// </summary>
        public DateTime ProcedureDate { get; set; }

        /// <summary>
        /// Your reference number for the order, e.g. your internal system reference number to link to this record.
        /// </summary>
        [MaxLength(MAX_YOUR_REFERENCE_LENGTH)]
        [Required]
        /// <summary>
        /// Gets or sets YourReference
        /// </summary>
        public string YourReference { get; set; }

        /// <summary>
        /// The name of the surgeon scheduled to perform the procedure
        /// </summary>
        [MaxLength(MAX_SURGEON_NAME_LENGTH)]
        /// <summary>
        /// Gets or sets SurgeonName
        /// </summary>
        public string SurgeonName { get; set; }

        /// <summary>
        /// Your unique code to identify the surgeon who is scheduled to perform the procedure
        /// </summary>
        [MaxLength(MAX_SURGEON_CODE_LENGTH)]
        /// <summary>
        /// Gets or sets SurgeonCode
        /// </summary>
        public string SurgeonCode { get; set; }

        /// <summary>
        /// The name of the procedure
        /// </summary>
        [MaxLength(MAX_PROCEDURE_NAME_LENGTH)]
        /// <summary>
        /// Gets or sets ProcedureName
        /// </summary>
        public string ProcedureName { get; set; }

        /// <summary>
        /// The unique code for the procedure
        /// </summary>
        [MaxLength(MAX_PROCEDURE_CODE_LENGTH)]
        /// <summary>
        /// Gets or sets ProcedureCode
        /// </summary>
        public string ProcedureCode { get; set; }

        /// <summary>
        /// Notes for the order
        /// </summary>
        /// <summary>
        /// Gets or sets Notes
        /// </summary>
        public List<string> Notes { get; set; }

        /// <summary>
        /// Your unique code to identify this individual communications message
        /// </summary>
        [Required]
        [MaxLength(MAX_YOUR_MESSAGE_REFERENCE_LENGTH)]
        /// <summary>
        /// Gets or sets YourMessageReference
        /// </summary>
        public string YourMessageReference { get; set; }
    }
}
