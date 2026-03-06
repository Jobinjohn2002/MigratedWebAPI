using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
    public sealed partial class LoanSetProcessAcceptanceData 
    {
        public LoanSetProcessAcceptanceData()
        {
            
        }
        public bool? CEMarked { get; set; }
        public bool? DecontaminationCertificate { get; set; }
        public bool? IsThisANewSet { get; set; }
        public bool? ItemAreCompatibleWithProcess { get; set; }
        public bool? IsNeutralDetergentAvailable { get; set; }
        public bool? ThermalDisinfection90 { get; set; }
        public bool? Sterilisation134 { get; set; }
        public bool? Sterilisation121 { get; set; }
        public bool? AreInstrumentsMutuallyCompatible { get; set; }
        public bool? DoesDeviceThatItemContainsPhthalates { get; set; }
        public bool? IsExtraTrainingRequired { get; set; }
    }
}
        