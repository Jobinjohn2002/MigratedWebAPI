using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// UserPrintersModel
    /// </summary>
    public class UserPrintersModel
    {
        public UserPrintersModel()
        {
            LaserPrinters = new List<SelectListItem>();
            BarcodePrinters = new List<SelectListItem>();
        }

        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        public int? LaserPrinterId { get; set; }
        public int? BarcodePrinterId { get; set; }

        /// <summary>
        /// Gets or sets LaserPrinters
        /// </summary>
        public List<SelectListItem> LaserPrinters { get; set; }
        /// <summary>
        /// Gets or sets BarcodePrinters
        /// </summary>
        public List<SelectListItem> BarcodePrinters { get; set; }
    }
}