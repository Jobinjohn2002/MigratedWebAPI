using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class ItemType 
	{
        /// <summary>
        /// Gets or sets ItemTypes
        /// </summary>
        public IEnumerable<ItemType> ItemTypes { get; set; }

        /// <summary>
        /// The number of turnarounds
        /// </summary>
        /// <summary>
        /// Gets or sets TurnaroundCount
        /// </summary>
        public int TurnaroundCount { get; set; }

        public ItemType(short itemTypeId)
        {
            ItemTypeId = itemTypeId;
        }

        public ItemType(IGrouping<ItemType, ItemType> subTypes)
        {
            ItemTypeId = subTypes.Key.ItemTypeId;
            Text = subTypes.Key.Text;
            ItemTypes = subTypes.Select(subType => new ItemType()
            {
                ItemTypeId = subType.ItemTypeId,
                Text = subType.Text,
            }).
            ToList();
        }
	}
}
		