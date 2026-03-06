using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ContainerMasterSearchArgs
    /// </summary>
    public class ContainerMasterSearchArgs : BaseRequestDataContract
    {
        public int DeliveryPointId
        {
            get; set;
        }
        public string SearchText
        {
            get; set;
        }
        public bool IncludeArchived
        { get; set; }
    }
}
