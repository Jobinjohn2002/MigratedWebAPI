using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// GenericKeyValue
    /// </summary>
    public class GenericKeyValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        /// <remarks></remarks>
        public GenericKeyValue()
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericKeyValue"/> class.
        /// </summary>
        /// <param name="uniqueIdentifier">The unique identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="tag"></param>
        /// <remarks></remarks>
        public GenericKeyValue(Guid uniqueIdentifier, string name)
        {
            UniqueIdentifier = uniqueIdentifier;
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericKeyValue"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        /// <remarks></remarks>
        public GenericKeyValue(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericKeyValue"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="uniqueIdentifier">The unique identifier.</param>
        /// <param name="name">The name.</param>
        /// <remarks></remarks>
        public GenericKeyValue(int id, Guid uniqueIdentifier, string name)
        {
            Id = id;
            UniqueIdentifier = uniqueIdentifier;
            Name = name;
        }

        public GenericKeyValue(int id, int parentId, string name)
        {
            Id = id;
            ParentId = parentId;
            Name = name;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }

        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>The unique identifier.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets UniqueIdentifier
        /// </summary>
        public Guid UniqueIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Tag.
        /// </summary>
        /// <value>The Tag.</value>
        /// <remarks></remarks>
        public string Tag{ get; set; }

        /// <summary>
        /// Gets or sets the Tag.
        /// </summary>
        /// <value>The Tag.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public string Status { get; set; }
        
    }
}
