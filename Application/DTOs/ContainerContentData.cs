using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class ContainerContentData 
	{
        public ContainerContentData()
        {

        }
		/// <summary>
		/// Gets or sets ContainerMasterName
		/// </summary>
		public string ContainerMasterName { get; set; }
		public int? ItemMasterId { get; set; }
		/// <summary>
		/// Gets or sets ItemMasterName
		/// </summary>
		public string ItemMasterName { get; set; }
        /// <summary>
        /// Gets or sets ContainerContentNoteText
        /// </summary>
        public string ContainerContentNoteText { get; set; }
        /// <summary>
        /// Gets or sets ContainerContentNote
        /// </summary>
        public ContainerContentNoteData ContainerContentNote { get; set; }
    }
}
		