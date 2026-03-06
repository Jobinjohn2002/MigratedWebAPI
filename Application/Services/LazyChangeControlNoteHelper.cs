using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyChangeControlNoteHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ChangeControlNote concreteChangeControlNote,
                                     ChangeControlNote genericChangeControlNote)
        {
            concreteChangeControlNote.ChangeControlNoteId = genericChangeControlNote.ChangeControlNoteId;
            concreteChangeControlNote.CreatedUserId = genericChangeControlNote.CreatedUserId;
            concreteChangeControlNote.ExternalId = genericChangeControlNote.ExternalId;
            concreteChangeControlNote.ItemExternalId = genericChangeControlNote.ItemExternalId;
            concreteChangeControlNote.ItemName = genericChangeControlNote.ItemName;
            concreteChangeControlNote.HasSpecificationSheet = genericChangeControlNote.HasSpecificationSheet;
            concreteChangeControlNote.HasInstructions = genericChangeControlNote.HasInstructions;
            concreteChangeControlNote.Request = genericChangeControlNote.Request;
            concreteChangeControlNote.Reason = genericChangeControlNote.Reason;
            concreteChangeControlNote.EstimatedUsage = genericChangeControlNote.EstimatedUsage;
            concreteChangeControlNote.RequestedBy = genericChangeControlNote.RequestedBy;
            concreteChangeControlNote.Created = genericChangeControlNote.Created;
        }
    }
}