using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class ItemTypeExtensions
    {
        /// <summary>
        /// IsReprocessableType operation
        /// </summary>
        public static bool IsReprocessableType(this ItemType itemType)
        {
            var itemTypes = new[] { 
                ItemTypeIdentifier.Tray, 
                ItemTypeIdentifier.Supplementary, 
                ItemTypeIdentifier.LoanTray, 
                ItemTypeIdentifier.Extra, 
                ItemTypeIdentifier.Endoscopy };
            return itemTypes.Contains((ItemTypeIdentifier)(itemType.ParentItemTypeId ?? itemType.ItemTypeId));
        }
    }
}
