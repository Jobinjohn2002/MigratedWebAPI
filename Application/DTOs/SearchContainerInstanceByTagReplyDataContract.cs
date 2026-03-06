using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SearchContainerInstanceByTagReplyDataContract
    /// </summary>
    public class SearchContainerInstanceByTagReplyDataContract
    {
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        public int? ContainerInstanceId { get; set; }
        public int? ContainerMasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets MatchedTag
        /// </summary>
        public string MatchedTag { get; set; }
    }
}