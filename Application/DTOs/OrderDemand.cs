using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// OrderDemand
    /// </summary>
    public class OrderDemand
    {
        public int ContainerMasterDefinitionId;
        public int  ContainerMasterId;
        public string ContainerMasterExternalId;
        public string ContainerMasterText;
        public int  ItemTypeId;
        public string ItemTypeText;
        public int  CustomerDefinitionId;
        public string  CustomerText;
        public int QuantityOrdered;
        public int QuantityInStock;
        public int QuantityPicked;
        public int QuantityInProduction;
    }
}
