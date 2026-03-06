using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// GroupedListItem
    /// </summary>
    public class GroupedListItem : ListItem
    {
        /// <summary>
        /// Gets or sets GroupKey
        /// </summary>
        public string GroupKey { get; set; }
        /// <summary>
        /// Gets or sets GroupName
        /// </summary>
        public string GroupName { get; set; }

        public static GroupedListItem Empty
        {
            get { return new GroupedListItem(); }
        }

        /// <summary>
        /// Clone operation
        /// </summary>
        public override object Clone()
        {
            return new GroupedListItem
            {
                Attributes = Attributes != null ? new Dictionary<string, string>(Attributes) : null,
                GroupKey = GroupKey,
                GroupName = GroupName,
                Selected = Selected,
                Text = Text,
                Value = Value
            };
        }
    }
}