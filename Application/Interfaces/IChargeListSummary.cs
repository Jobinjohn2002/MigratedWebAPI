using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
   /// <summary>
   /// IChargeListSummary
   /// </summary>
   public interface IChargeListSummary
    {
       int ChargeListId { get; set; }

       string ChargeListCategory { get; set; }

       string Name { get; set; }

       decimal BasePrice { get; set; }

       decimal CurrentPrice { get; set; }
    }
}
