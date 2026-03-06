using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ContainerMasterSearchResult
    /// </summary>
    public class ContainerMasterSearchResult : BaseReplyDataContract
    {
        public List<ContainerMasterInfo> ContainerMasters
        {
            get; set;
        }
    }
}
