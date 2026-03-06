using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// UpdateItemExceptionsRequestDataContract
    /// </summary>
    public class UpdateItemExceptionsRequestDataContract : ScanDetails, IItemExceptions
    {
        /// <summary>
        /// Gets or sets ItemExceptions
        /// </summary>
        public List<ItemExceptionDataContract> ItemExceptions { get; set; }
        /// <summary>
        /// Gets or sets HasBeenItemExceptionChanges
        /// </summary>
        public bool HasBeenItemExceptionChanges { get; set; }
        /// <summary>
        /// Gets or sets Quarantine
        /// </summary>
        public bool Quarantine { get; set; }
        /// <summary>
        /// Gets or sets ReWash
        /// </summary>
        public bool ReWash { get; set; }
        /// <summary>
        /// Gets or sets Cancel
        /// </summary>
        public bool Cancel { get; set; }
        /// <summary>
        /// Gets or sets IsFinished
        /// </summary>
        public bool IsFinished { get; set; }
        /// <summary>
        /// Gets or sets CheckingCancelled
        /// </summary>
        public bool CheckingCancelled { get; set; }
        /// <summary>
        /// Gets or sets CheckingRequired
        /// </summary>
        public bool CheckingRequired { get; set; }
        /// <summary>
        /// Gets or sets Checked
        /// </summary>
        public bool Checked { get; set; }
        public int? ContainerInstanceId { get; set; }
        public int? ContainerMasterDefinitionId { get; set; }
        public int? SecondaryEventType { get; set; }
        public int? SupervisorId { get; set; }
        /// <summary>
        /// Gets or sets DirtyInstruments
        /// </summary>
        public List<DirtyInstrument> DirtyInstruments { get; set; }
        /// <summary>
        /// Gets or sets RewashNotes
        /// </summary>
        public string RewashNotes { get; set; }
    }
}