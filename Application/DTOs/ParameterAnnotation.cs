using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ParameterAnnotation
    /// </summary>
    public class ParameterAnnotation
    {
        /// <summary>
        /// Gets or sets AnnotationAttribute
        /// </summary>
        public Attribute AnnotationAttribute { get; set; }

        /// <summary>
        /// Gets or sets Documentation
        /// </summary>
        public string Documentation { get; set; }
    }
}