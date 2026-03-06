using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// GenericKeyValueData
    /// </summary>
    public class GenericKeyValueData
    {
        public GenericKeyValueData(IGenericKeyValue genericKeyValue)
        {
            Id = genericKeyValue.Id;
            UniqueIdentifier = genericKeyValue.UniqueIdentifier;
            Name = genericKeyValue.Name;
            Tag = genericKeyValue.Tag;
            ParentId = genericKeyValue.ParentId;
            Status = genericKeyValue.Status;
        }

        public GenericKeyValueData()
        {
        }
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets UniqueIdentifier
        /// </summary>
        public Guid UniqueIdentifier { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        public string Tag{ get; set; }
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public string Status { get; set; }
        public int? ParentId { get; set; }
        public int? TypeId { get; set; }
    }
}
