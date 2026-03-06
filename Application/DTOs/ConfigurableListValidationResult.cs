using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ConfigurableListValidationResult
    /// </summary>
    public class ConfigurableListValidationResult : ConfigurableListBasicValidationResult
    {
        public ConfigurableListValidationResult()
        {

        }

        public ConfigurableListValidationResult(ConfigurableListTypeIdentifier listType)
        {
            ListType = listType;
        }

        public ConfigurableListValidationResult(bool isValid, ConfigurableListTypeIdentifier listType) : this(listType)
        {
            IsValid = isValid;
        }

        /// <summary>
        /// Gets or sets CanOverride
        /// </summary>
        public bool CanOverride { get; set; }

        /// <summary>
        /// Gets or sets InvalidValues
        /// </summary>
        public List<InvalidCustomisableListValue> InvalidValues { get; set; } = new List<InvalidCustomisableListValue>();
    }
}