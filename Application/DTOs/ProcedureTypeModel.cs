using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ProcedureTypeModel
    /// </summary>
    public class ProcedureTypeModel
    {
        /// <summary>
        /// Gets or sets Result
        /// </summary>
        public HttpStatusCode Result { get; set; }
        /// <summary>
        /// Gets or sets SurgicalProcedureId
        /// </summary>
        public int SurgicalProcedureId { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Reference
        /// </summary>
        public string Reference { get; set; }
        /// <summary>
        /// ShowAdvisory operation
        /// </summary>
        public bool ShowAdvisory()
        {
            return string.IsNullOrEmpty(Name);
        }
    }
}