using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemScanResponseDataContract
    /// </summary>
    public class ItemScanResponseDataContract : BaseReplyDataContract
    {
        public List<ItemDetailsDataContract> Items;
    }
}