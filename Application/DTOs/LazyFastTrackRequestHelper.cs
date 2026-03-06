using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class LazyFastTrackRequestHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(FastTrackRequest concreteFastTrackRequest,
                                     FastTrackRequest genericFastTrackRequest)
        {
            concreteFastTrackRequest.FastTrackRequestId = genericFastTrackRequest.FastTrackRequestId;
            concreteFastTrackRequest.CreateduserId = genericFastTrackRequest.CreateduserId;
            concreteFastTrackRequest.DeliveryPointId = genericFastTrackRequest.DeliveryPointId;
            concreteFastTrackRequest.ExternalId = genericFastTrackRequest.ExternalId;
            concreteFastTrackRequest.Text = genericFastTrackRequest.Text;
            concreteFastTrackRequest.Created = genericFastTrackRequest.Created;
        }
    }
}