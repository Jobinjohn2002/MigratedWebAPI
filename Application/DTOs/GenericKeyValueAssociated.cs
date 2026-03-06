using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
   /// <summary>
   /// GenericKeyValueAssociated
   /// </summary>
   public class GenericKeyValueAssociated
    {
       public GenericKeyValueAssociated(object id,string name,bool isSelected)
       {
           Id = id;
           Name = name;
           IsSelected = isSelected;
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
