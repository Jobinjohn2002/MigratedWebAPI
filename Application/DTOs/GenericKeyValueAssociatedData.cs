using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
   /// <summary>
   /// GenericKeyValueAssociatedData
   /// </summary>
   public class GenericKeyValueAssociatedData
    {
       public GenericKeyValueAssociatedData(IGenericKeyValueAssociated genericKeyValueAssociated)
       {
           Id = genericKeyValueAssociated.Id;
           Name = genericKeyValueAssociated.Name;
           IsSelected = genericKeyValueAssociated.IsSelected;
       }
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public object Id { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets IsSelected
        /// </summary>
        public bool IsSelected { get; set; }
    }
}
