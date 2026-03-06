using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable, XmlRoot("SearchType")]
    /// <summary>
    /// SearchType
    /// </summary>
    public class SearchType
    {
        [XmlElement]
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        [XmlElement]
        /// <summary>
        /// Gets or sets Sproc
        /// </summary>
        public string Sproc { get; set; }
        [XmlElement]
        /// <summary>
        /// Gets or sets SprocID
        /// </summary>
        public int SprocID { get; set; }
        [XmlElement]
        /// <summary>
        /// Gets or sets Weighting
        /// </summary>
        public int Weighting { get; set; }
    }
}
