using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BiologicalIndicatorTestDataContract
    /// </summary>
    public class BiologicalIndicatorTestDataContract 
    {
        public bool IsBiologicalIndicatorRequired;
        public int BiologicalIndicatorTestId;
        public int BatchId;
        public string BatchExternalId;
        public DateTime? BatchStartDate;
        public bool? IsTestBatch;
        public bool? TestBiologicalIndicatorResult;
        public string TestBiologicalIndicatorLotNumber;
        public bool? ControlIndicatorResult;
        public string ControlBiologicalIndicatorLotNumber;
        public bool? IntegratorResults;
        public string ResultsDetails;
        public DateTime? StartDate;
        public DateTime? EndDate;
        public int? TestedUserId;
        public DateTime? TestedDate;
        public int? ReviewedUserId;
        public DateTime? ReviewedDate;
        public int? BiologicalIndicatorTestStatusId;
        public bool? TestResult;
        public int? PinRequestReasonId;
        public string Well;
        public string ControlWell;
        public bool RecallRequired;
    }
}