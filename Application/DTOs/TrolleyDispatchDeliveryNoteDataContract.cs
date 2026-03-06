using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TrolleyDispatchDeliveryNoteDataContract
    /// </summary>
    public class TrolleyDispatchDeliveryNoteDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets Turnarounds
        /// </summary>
        public List<DeliveryNoteTurnaroundDataContract> Turnarounds { get; set; }
        /// <summary>
        /// Gets or sets TrolleyContainerInstanceId
        /// </summary>
        public int TrolleyContainerInstanceId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryNoteIds
        /// </summary>
        public List<int> DeliveryNoteIds { get; set; }
    }
    /// <summary>
    /// TrolleyDispatchDeliveryNoteBatchDataContract
    /// </summary>
    public class TrolleyDispatchDeliveryNoteBatchDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets TrolleyDeliveryNotes
        /// </summary>
        public List<TrolleyDeliveryNotesDataContract> TrolleyDeliveryNotes { get; set; }
    }
    /// <summary>
    /// TrolleyDeliveryNotesDataContract
    /// </summary>
    public class TrolleyDeliveryNotesDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets TrolleyContainerInstanceId
        /// </summary>
        public int TrolleyContainerInstanceId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryNoteIds
        /// </summary>
        public List<int> DeliveryNoteIds { get; set; }
        /// <summary>
        /// Gets or sets Asset
        /// </summary>
        public AssetDetailsDataContract Asset { get; set; }
    }
}
