using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// ListItem
    /// </summary>
    public class ListItem : SelectListItem, ICloneable
    {
        public Dictionary<string, string> Attributes
        {
            get;
            set;
        }

        /// <summary>
        /// Clone operation
        /// </summary>
        public virtual object Clone()
        {
            return new ListItem
            {
                Attributes = new Dictionary<string, string>(Attributes),
                Selected = Selected,
                Text = Text,
                Value = Value
            };
        }
    }
}