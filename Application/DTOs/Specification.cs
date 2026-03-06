using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Specification Info.
    /// </summary>
    /// <summary>
    /// SpecificationInfo
    /// </summary>
    public class SpecificationInfo
    {
        /// <summary>
        /// The name of the item this specification is for.
        /// </summary>
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The unique product number of item this specification is for.
        /// </summary>
        /// <summary>
        /// Gets or sets ProductNumber
        /// </summary>
        public string ProductNumber { get; set; }
        /// <summary>
        /// The external identifier of the specification.
        /// </summary>
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// The revision number of this specification.
        /// </summary>
        /// <summary>
        /// Gets or sets Revision
        /// </summary>
        public short Revision { get; set; }
        /// <summary>
        /// The type of the item this specification is for.
        /// </summary>
        /// <summary>
        /// Gets or sets Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The sub type of the item this specification is for.
        /// </summary>
        /// <summary>
        /// Gets or sets SubType
        /// </summary>
        public string SubType { get; set; }
        /// <summary>
        /// The components in the specification.
        /// </summary>
        /// <summary>
        /// Gets or sets Components
        /// </summary>
        public List<SpecificationComponentInfo> Components { get; set; }
        /// <summary>
        /// The notes in the specification.
        /// </summary>
        /// <summary>
        /// Gets or sets Notes
        /// </summary>
        public List<SpecificationNoteInfo> Notes { get; set; }
    }
}