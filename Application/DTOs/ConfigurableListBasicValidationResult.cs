using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ConfigurableListBasicValidationResult
    /// </summary>
    public class ConfigurableListBasicValidationResult
    {
        public ConfigurableListBasicValidationResult()
        {

        }

        public ConfigurableListBasicValidationResult(ConfigurableListTypeIdentifier listType)
        {
            ListType = listType;
        }

        public ConfigurableListBasicValidationResult(bool isValid, ConfigurableListTypeIdentifier listType) : this(listType)
        {
            IsValid = isValid;
        }

        /// <summary>
        /// Gets or sets IsValid
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Gets or sets ErrorMessage
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets ListType
        /// </summary>
        public ConfigurableListTypeIdentifier ListType { get; set; }
    }
}