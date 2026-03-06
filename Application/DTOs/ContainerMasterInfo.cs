using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ContainerMasterInfo
    /// </summary>
    public class ContainerMasterInfo
    {
        public int Id
        {
            get; set;
        }
        public int DefinitionId
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public string ExternalId
        {
            get; set;
        }
        public ItemTypeInfo ParentItemType
        {
            get; set;
        }
        public ItemTypeInfo ItemType
        {
            get; set;
        }
        public int OwningCustomerDefinitionId
        {
            get; set;
        }
    }
}
