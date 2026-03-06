using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemDetailsDataContract
    /// </summary>
    public class ItemDetailsDataContract
    {
        public string InstanceExternalId;
        public int ItemTypeId;
        public int InstanceId;
        public int MasterId;
        public int MasterDefinitionId;
        public string Description;
    }
}