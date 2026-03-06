using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    [AttributeUsage(AttributeTargets.Class)]
    /// <summary>
    /// ExcludeHelpAttribute
    /// </summary>
    public class ExcludeHelpAttribute : Attribute
    {
        public ExcludeHelpAttribute()
        {
            Formatters = new Type[0];
        }

        public Type[] Formatters { get; set; }
    }
}