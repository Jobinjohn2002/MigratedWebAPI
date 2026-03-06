using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemScanDataContract
    /// </summary>
    public class ItemScanDataContract : BaseRequestDataContract
    {
        public List<string> ExternalIds;
        public int StationTypeId;
    }
}