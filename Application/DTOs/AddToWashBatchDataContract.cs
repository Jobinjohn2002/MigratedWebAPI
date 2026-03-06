using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// AddToWashBatchDataContract
    /// </summary>
    public class AddToWashBatchDataContract : BaseRequestDataContract
    {
        public string FromContainerInstancePrimaryId;
        public int ToContainerInstanceId;
        public int? FromContainerInstanceId;
        public bool IgnoreNotes;
    }
}