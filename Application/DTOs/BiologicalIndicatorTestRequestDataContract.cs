using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BiologicalIndicatorTestRequestDataContract
    /// </summary>
    public class BiologicalIndicatorTestRequestDataContract : ScanDetails
    {
        public BiologicalIndicatorTestDataContract BiTestData;
    }
}