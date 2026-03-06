using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CustomerDefectResponseModel
    /// </summary>
    public class CustomerDefectResponseModel
    {
        [SmartPropertyValidation]
        public int? CustomerDefectID
        {
            get;
            set;
        }

        [SmartPropertyValidation]
        public string Response
        {
            get;
            set;
        }
    }
}