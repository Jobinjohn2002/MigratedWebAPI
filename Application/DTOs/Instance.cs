using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// A composite of the ContainerInstance and ItemInstance entities
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// Instance
    /// </summary>
    public class Instance
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Instance"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Instance(ContainerInstance value)
        {
            ContainerInstance = value;
            ExternalId = value.PrimaryId;
        }

        /// <summary>
        /// Gets or sets the container instance.
        /// </summary>
        /// <value>The container instance.</value>
        /// <summary>
        /// Gets or sets ContainerInstance
        /// </summary>
        public ContainerInstance ContainerInstance { get; set; }

        /// <summary>
        /// Gets or sets the external id.
        /// </summary>
        /// <value>The external id.</value>
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// Gets the master.
        /// </summary>
        public Master Master
        {
            get
            {
                return Property(
                    i =>
                    new Master(
                        i.ContainerMasterDefinition.ContainerMasters.SingleOrDefault(
                            j => j.ItemStatusId == (int)ItemStatusId.Active)));
            }
        }

        /// <summary>
        /// Properties the specified container property.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="containerProperty">The container property.</param>
        protected TProperty Property<TProperty>(Func<ContainerInstance, TProperty> containerProperty)
        {
            if (ContainerInstance != null)
            {
                return containerProperty.Invoke(ContainerInstance);
            }

            return default(TProperty);
        }
    }
}