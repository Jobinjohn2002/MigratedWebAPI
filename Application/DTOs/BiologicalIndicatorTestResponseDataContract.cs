using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BiologicalIndicatorTestResponseDataContract
    /// </summary>
    public class BiologicalIndicatorTestResponseDataContract : BaseReplyDataContract
    {
        public BiologicalIndicatorTestDataContract BiTestData;
        public ScanAssetDataContract ScannedAsset;
    }
}