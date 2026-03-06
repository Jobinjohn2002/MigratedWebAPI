using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemTypeInfo
    /// </summary>
    public class ItemTypeInfo
    {
        public int Id
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
    }
}
