using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ErrorModel
    /// </summary>
    public class ErrorModel
    {
        public HttpStatusCode StatusCode
        {
            get;
            set;
        }

        public Guid ID
        {
            get;
            set;
        }
    }
}