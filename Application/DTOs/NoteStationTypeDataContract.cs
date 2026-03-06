using System;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// NoteStationTypeDataContract
    /// </summary>
    public class NoteStationTypeDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets StationType
        /// </summary>
        public StationDataContract StationType { get; set; }
        /// <summary>
        /// Gets or sets EventType
        /// </summary>
        public EventTypeDataContract EventType { get; set; }
    }
}