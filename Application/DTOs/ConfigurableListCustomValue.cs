using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ConfigurableListCustomValue
    /// </summary>
    public class ConfigurableListCustomValue
    {
        private ITranslator translator { get { return InstanceFactory.GetInstance<ITranslator>(); } }

        /// <summary>
        /// Gets or sets ConfigurableListType
        /// </summary>
        public ConfigurableListTypeIdentifier ConfigurableListType { get; set; }

        /// <summary>
        /// Gets or sets TableName
        /// </summary>
        public string TableName { get; set; }

        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets NewValue
        /// </summary>
        public string NewValue { get; set; }

        /// <summary>
        /// Gets or sets MachineTypeId
        /// </summary>
        public byte MachineTypeId { get; set; }

        /// <summary>
        /// Gets or sets IsChargeable
        /// </summary>
        public bool IsChargeable { get; set; }

        /// <summary>
        /// Gets or sets NewValueMaxLength
        /// </summary>
        public int NewValueMaxLength { get; set; }

        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
}
}