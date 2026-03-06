using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
	public partial class ItemTypeData
	{
		/// <summary>
		/// Gets or sets ParentItemType
		/// </summary>
		public ItemTypeData ParentItemType { get; set; }
		/// <summary>
		/// Gets or sets ItemTypes
		/// </summary>
		public IList<ItemTypeData> ItemTypes { get; set; }
		/// <summary>
		/// Gets or sets Masters
		/// </summary>
		public IList<MasterData> Masters { get; set; }
        /// <summary>
        /// Gets or sets BaseName
        /// </summary>
        public string BaseName { get; set; }

        /// <summary>
        /// The number of turnarounds associated with this event tyoe
        /// </summary>
        /// <summary>
        /// Gets or sets TurnaroundCount
        /// </summary>
        public int TurnaroundCount { get; set; }

        public ItemTypeData()
		{
		}
	}
}