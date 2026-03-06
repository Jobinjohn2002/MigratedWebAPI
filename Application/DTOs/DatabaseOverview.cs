using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DatabaseOverview
    /// </summary>
    public class DatabaseOverview
    {
        public IList<Columbus.Services.Models.TableInfo> TableInfo { get; set; }
        /// <summary>
        /// Gets or sets Schemas
        /// </summary>
        public IEnumerable<string> Schemas { get; set; }
        /// <summary>
        /// Gets or sets CDCSchemas
        /// </summary>
        public IEnumerable<string> CDCSchemas { get; set; }
    }
}