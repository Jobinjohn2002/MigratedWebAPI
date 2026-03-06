using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ComplexTypeModelDescription
    /// </summary>
    public class ComplexTypeModelDescription : ModelDescription
    {
        /// <summary>
        /// Gets or sets Properties
        /// </summary>
        public Collection<ParameterDescription> Properties { get; private set; }
        /// <summary>
        /// Gets or sets PartialViews
        /// </summary>
        public Collection<HelpPartialInfo> PartialViews { get; private set; }

        public ComplexTypeModelDescription()
        {
            Properties = new Collection<ParameterDescription>();
            PartialViews = new Collection<HelpPartialInfo>();
        }
    }
}