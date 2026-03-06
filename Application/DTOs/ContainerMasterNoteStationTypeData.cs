using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
	public partial class ContainerMasterNoteStationTypeData 
	{
        public int? ProcessingNoteStationTypeId { get; set; }
        /// <summary>
        /// Gets or sets ProcessNoteType
        /// </summary>
        public ProcessNoteType ProcessNoteType { get; set; } = ProcessNoteType.Revision;
        public ContainerMasterNoteStationTypeData()
        {

        }
        /// <summary>
        /// Gets or sets StationTypeData
        /// </summary>
        public StationTypeData StationTypeData { get; set; }
    }
}