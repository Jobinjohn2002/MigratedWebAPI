using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyIndexationHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(Indexation concreteIndexation, Indexation genericIndexation)
        {
            concreteIndexation.IndexationId = genericIndexation.IndexationId;
            concreteIndexation.ArchivedUserId = genericIndexation.ArchivedUserId;
            concreteIndexation.CreatedUserId = genericIndexation.CreatedUserId;
            concreteIndexation.CustomerDefinitionId = genericIndexation.CustomerDefinitionId;
            concreteIndexation.IndexationCategoryId = genericIndexation.IndexationCategoryId;
            concreteIndexation.IndexationTypeId = genericIndexation.IndexationTypeId;
            concreteIndexation.Amount = genericIndexation.Amount;
            concreteIndexation.AppliesFrom = genericIndexation.AppliesFrom;
            concreteIndexation.Created = genericIndexation.Created;
            concreteIndexation.Archived = genericIndexation.Archived;
            concreteIndexation.LegacyId = genericIndexation.LegacyId;
            concreteIndexation.LegacyFacilityOrigin = genericIndexation.LegacyFacilityOrigin;
            concreteIndexation.LegacyImported = genericIndexation.LegacyImported;
            concreteIndexation.Text = genericIndexation.Text;
        }
    }
}