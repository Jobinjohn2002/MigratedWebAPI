using System.Collections.Generic;
using System;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class ContainerMasterNoteData
    {
        public ContainerMasterNoteData(IProcessingNote genericObj)
        {
            if (genericObj != null)
            {

                ProcessingNoteId = genericObj.ProcessingNoteId;

                ProcessingNoteTypeId = genericObj.ProcessingNoteTypeId;

                ContainerMasterDefinitionId = genericObj.ContainerMasterDefinitionId;

                Text = genericObj.Text;

                ItemMasterId = genericObj.ItemMasterId;

                EntityKeyValue = ContainerMasterNoteId.ToString();

                ActiveFrom = genericObj.ActiveFrom;

                CreatedByUserId = genericObj.CreatedBy;
            }
        }
        /// <summary>
        /// Gets or sets TypeText
        /// </summary>
        public string TypeText { get; set; }
        public int? ContainerMasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterExternalId
        /// </summary>
        public string ContainerMasterExternalId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        public int? ProcessingNoteId { get; set; }
        public int? ProcessingNoteTypeId { get; set; }
        public DateTime? ExpiryDate { get; set; }
        /// <summary>
        /// Gets or sets CreatedByUserId
        /// </summary>
        public int CreatedByUserId { get; set; }
        /// <summary>
        /// Gets or sets CreatedByFirstName
        /// </summary>
        public string CreatedByFirstName { get; set; }
        /// <summary>
        /// Gets or sets CreatedBySurname
        /// </summary>
        public string CreatedBySurname { get; set; }
        /// <summary>
        /// Gets or sets ProcessNoteType
        /// </summary>
        public ProcessNoteType ProcessNoteType { get; set; }
        public DateTime? ActiveFrom { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterNoteStationTypes
        /// </summary>
        public IEnumerable<ContainerMasterNoteStationTypeData> ContainerMasterNoteStationTypes { get; set; }

        public ContainerMasterNoteData() { }
    }
}