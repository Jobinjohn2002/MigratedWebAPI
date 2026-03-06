using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    ///  Station data interface
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// IStationData
    /// </summary>
    public interface IStationData : IData
    {
        IList<PrintDetailsDataContract> PrintJobs { get; set; }

        /// <summary>
        /// Gets or sets the turnaround id.
        /// </summary>
        /// <value>The turnaround id.</value>
        /// <remarks></remarks>
        int TurnaroundId { get; set; }

        /// <summary>
        /// Gets or sets the container instance id.
        /// </summary>
        /// <value>The container instance id.</value>
        /// <remarks></remarks>
        int ContainerInstanceId { get; set; }

        /// <summary>
        /// Gets or sets the container instance external id.
        /// </summary>
        /// <value>The container instance external id.</value>
        /// <remarks></remarks>
        string ContainerInstancePrimaryId { get; set; }

        /// <summary>
        /// Gets or sets the item id.
        /// </summary>
        /// <value>The item id.</value>
        /// <remarks></remarks>
        int ItemId { get; set; }

        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        /// <value>The name of the item.</value>
        /// <remarks></remarks>
        string ItemName { get; set; }

        /// <summary>
        /// Gets or sets the service requirement id.
        /// </summary>
        /// <value>The service requirement id.</value>
        /// <remarks></remarks>
        int ServiceRequirementId { get; set; }

        /// <summary>
        /// Gets or sets the name of the service requirement.
        /// </summary>
        /// <value>The name of the service requirement.</value>
        /// <remarks></remarks>
        string ServiceRequirementName { get; set; }

        /// <summary>
        /// Gets or sets the expiry.
        /// </summary>
        /// <value>The expiry.</value>
        /// <remarks></remarks>
        DateTime Expiry { get; set; }

        /// <summary>
        /// Gets or sets the defects.
        /// </summary>
        /// <value>The defects.</value>
        /// <remarks></remarks>
        IList<DefectData> Defects { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        /// <remarks></remarks>
        IList<TurnaroundNoteData> Notes { get; set; }

        /// <summary>
        /// Gets or sets the item notes.
        /// </summary>
        /// <value>The item notes.</value>
        /// <remarks></remarks>
        IList<ContainerMasterNoteData> ItemNotes { get; set; }
    }
}