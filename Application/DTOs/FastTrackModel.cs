using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum FastTrackType
    {
        Light,
        Standard
    }
    /// <summary>
    /// FastTrackModel
    /// </summary>
    public class FastTrackModel
    {
        /// <summary>
        /// Gets or sets FastTrackID
        /// </summary>
        public int FastTrackID { get; set; }

        /// <summary>
        /// Gets or sets FastTrackType
        /// </summary>
        public FastTrackType FastTrackType { get; set; }

        /// <summary>
        /// Gets or sets RequestedBy
        /// </summary>
        public string RequestedBy { get; set; }

        public DateTime? RequiredDate { get; set; }

        public int? FastTrackRequestStatusId { get; set; }

        public int? ContainerMasterDefinitionId { get; set; }

        public int? ContainerInstanceId { get; set; }

        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }

        public int? CustomerDefinitionId { get; set; }

        public int? LocationID { get; set; }

        /// <summary>
        /// Gets or sets ItemDetails
        /// </summary>
        public string ItemDetails { get; set; }

        /// <summary>
        /// Gets or sets ContainerMasterDefinitionText
        /// </summary>
        public string ContainerMasterDefinitionText { get; set; }

        /// <summary>
        /// Gets or sets ContainerMasterExternalId
        /// </summary>
        public string ContainerMasterExternalId { get; set; }

        /// <summary>
        /// Gets or sets ShowGettingStarted
        /// </summary>
        public bool ShowGettingStarted { get; set; }

        /// <summary>
        /// Gets or sets HasErrors
        /// </summary>
        public bool HasErrors { get; set; }

        /// <summary>
        /// Gets or sets SearchForSpecificInstance
        /// </summary>
        public bool SearchForSpecificInstance { get; set; }

        /// <summary>
        /// Gets or sets IsAutomaticallyGenerated
        /// </summary>
        public bool IsAutomaticallyGenerated { get; set; }

        public int? DefectId { get; set; }

        /// <summary>
        /// Gets or sets FastTrackTypeName
        /// </summary>
        public string FastTrackTypeName { get; set; }
        /// <summary>
        /// Gets or sets FastTrackTypeValue
        /// </summary>
        public string FastTrackTypeValue { get; set; }

        /// <summary>
        /// Gets or sets SearchResults
        /// </summary>
        public SearchForFastTrackTargetsResultModel SearchResults { get; set; }

        public const int MAX_TRAYS_PER_FASTTRACK = 20;
        public const int DEFAULT_ITEMS_TO_FETCH = 10;
        public const int ITEMS_TO_FETCH_INCREMENT = 10;
        public const int MAX_QUANTITY_PER_LINE = 10;
        public const int MAX_INFO_LENGTH = 1000;
        public const int MAX_REQUESTED_BY_LENGTH = 255;
        public const int MIN_SEARCH_CHARACTERS = 3;

        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets FastTrackAction
        /// </summary>
        public short FastTrackAction { get; set; }
    }

}
