using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// AddToBatchTagDataContract
    /// </summary>
    public class AddToBatchTagDataContract : CreateContainerInstanceDataContract
    {
        public int BatchTagTurnaroundId;
        public int ContainerMasterItemTypeId;
        public string ContainerInstancePrimaryId;
        public string ScannedString;
    }
}