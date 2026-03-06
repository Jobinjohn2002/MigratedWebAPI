using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CustomerCostData
    /// </summary>
    public class CustomerCostData
    {
        public CustomerCostData(IList<ChargeData> customerCharges)
        {
            CustomerCharges = customerCharges;
        }
        IList<ChargeData> CustomerCharges { get; set; }
    }
}
