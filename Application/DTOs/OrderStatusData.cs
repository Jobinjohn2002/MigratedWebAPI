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
    /// OrderStatusData
    /// </summary>
    public class OrderStatusData
    {
        public int OrderStatusId;
		public string Text;
        public bool? CompletesOrder;
    }
}