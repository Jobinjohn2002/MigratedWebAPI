using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ApiTypeApiModel
    /// </summary>
    public class ApiTypeApiModel : Dictionary<string, Collection<ApiDescription>>
    {
        /// <summary>
        /// Add operation
        /// </summary>
        public void Add(string apiType, ApiDescription api)
        {
            if (!ContainsKey(apiType))
            {
                Add(apiType, new Collection<ApiDescription> { api });

                return;
            }
            
            this[apiType].Add(api); 
        }
    }
}