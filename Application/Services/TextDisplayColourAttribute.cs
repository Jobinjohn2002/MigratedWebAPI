using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    class TextDisplayColor : Attribute
    {
        /// <summary>
        /// Gets or sets Color
        /// </summary>
        public string Color { get; private set; }

        public TextDisplayColor(string color)
        {
            Color = color;
        }
    }
}
