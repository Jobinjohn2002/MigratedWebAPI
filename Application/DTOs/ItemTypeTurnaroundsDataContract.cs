using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemTypeTurnaroundsDataContract
    /// </summary>
    public class ItemTypeTurnaroundsDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets ParentTurnarounds
        /// </summary>
        public List<ParentTurnaroundDataContract> ParentTurnarounds { get; set; }
    }
}