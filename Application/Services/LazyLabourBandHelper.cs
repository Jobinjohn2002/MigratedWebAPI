using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyLabourBandHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(LabourBand concreteLabourBand, LabourBand genericLabourBand)
        {
            concreteLabourBand.LabourBandId = genericLabourBand.LabourBandId;
            concreteLabourBand.Text = genericLabourBand.Text;
            concreteLabourBand.Cost = genericLabourBand.Cost;
            concreteLabourBand.MaximumComponents = genericLabourBand.MaximumComponents;
            concreteLabourBand.Created = genericLabourBand.Created;
            concreteLabourBand.CreatedUserId = genericLabourBand.CreatedUserId;
            concreteLabourBand.Archived = genericLabourBand.Archived;
            concreteLabourBand.ArchivedUserId = genericLabourBand.ArchivedUserId;
            concreteLabourBand.CustomerId = genericLabourBand.CustomerId;
            concreteLabourBand.LegacyInternalId = genericLabourBand.LegacyInternalId;
        }
    }
}