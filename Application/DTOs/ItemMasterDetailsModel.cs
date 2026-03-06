using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum ItemMasterDetailsTab
    {
        Details = 0,
        Comments = 1
    }

    /// <summary>
    /// ItemMasterDetailsModel
    /// </summary>
    public class ItemMasterDetailsModel
    {
        /// <summary>
        /// Gets or sets ItemMaster
        /// </summary>
        public ItemMaster ItemMaster { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasters
        /// </summary>
        public TableModel ContainerMasters { get; set; }
        /// <summary>
        /// Gets or sets SelectedTab
        /// </summary>
        public ItemMasterDetailsTab SelectedTab { get; set; }
        /// <summary>
        /// Gets or sets masterHasImages
        /// </summary>
        public bool masterHasImages { get; set; }
    }
}