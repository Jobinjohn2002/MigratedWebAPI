using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ChargeListSummaryData
    /// </summary>
    public class ChargeListSummaryData
    {
        public ChargeListSummaryData()
        { }

        public ChargeListSummaryData(IChargeListSummary data)
        {
            ChargeListId = data.ChargeListId;
            ChargeListCategory = data.ChargeListCategory;
            Name = data.Name;
            BasePrice = data.BasePrice;
            CurrentPrice = data.CurrentPrice;
        }

        public ChargeListSummaryData(int chargeListId, string chargeListCategory, string name, decimal basePrice, decimal currentPrice)
        {
            ChargeListId = chargeListId;
            ChargeListCategory = chargeListCategory;
            Name = name;
            BasePrice = basePrice;
            CurrentPrice = currentPrice;
        }
        /// <summary>
        /// Gets or sets ChargeListId
        /// </summary>
        public int ChargeListId { get; set; }
        /// <summary>
        /// Gets or sets ChargeListCategory
        /// </summary>
        public string ChargeListCategory { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets BasePrice
        /// </summary>
        public decimal BasePrice { get; set; }
        /// <summary>
        /// Gets or sets CurrentPrice
        /// </summary>
        public decimal CurrentPrice { get; set; }
    }
}
