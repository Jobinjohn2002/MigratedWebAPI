using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// OrderLineStatusData
    /// </summary>
    public class OrderLineStatusData
    {
        public int OrderLineStatusId;
        public string Text;
        public bool? FulfilsOrderLine;
        public bool? RequiresTurnaround;
    }
}
