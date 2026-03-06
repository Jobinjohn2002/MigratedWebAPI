using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyBiologicalIndicatorTestHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(BiologicalIndicatorTest concreteBiologicalIndicatorTest, IBiologicalIndicatorTest genericBiologicalIndicatorTest)
        {		
			concreteBiologicalIndicatorTest.BiologicalIndicatorTestId = genericBiologicalIndicatorTest.BiologicalIndicatorTestId;			
			concreteBiologicalIndicatorTest.BatchId = genericBiologicalIndicatorTest.BatchId;			
			concreteBiologicalIndicatorTest.TestBiologicalIndicatorResult = genericBiologicalIndicatorTest.TestBiologicalIndicatorResult;			
			concreteBiologicalIndicatorTest.TestBiologicalIndicatorLotNumber = genericBiologicalIndicatorTest.TestBiologicalIndicatorLotNumber;			
			concreteBiologicalIndicatorTest.ControlIndicatorResult = genericBiologicalIndicatorTest.ControlIndicatorResult;			
			concreteBiologicalIndicatorTest.ControlBiologicalIndicatorLotNumber = genericBiologicalIndicatorTest.ControlBiologicalIndicatorLotNumber;			
			concreteBiologicalIndicatorTest.IntegratorResults = genericBiologicalIndicatorTest.IntegratorResults;			
			concreteBiologicalIndicatorTest.ResultsDetails = genericBiologicalIndicatorTest.ResultsDetails;			
			concreteBiologicalIndicatorTest.StartDate = genericBiologicalIndicatorTest.StartDate;			
			concreteBiologicalIndicatorTest.EndDate = genericBiologicalIndicatorTest.EndDate;			
			concreteBiologicalIndicatorTest.TestedUserId = genericBiologicalIndicatorTest.TestedUserId;			
			concreteBiologicalIndicatorTest.TestedDate = genericBiologicalIndicatorTest.TestedDate;			
			concreteBiologicalIndicatorTest.ReviewedUserId = genericBiologicalIndicatorTest.ReviewedUserId;			
			concreteBiologicalIndicatorTest.ReviewedDate = genericBiologicalIndicatorTest.ReviewedDate;			
			concreteBiologicalIndicatorTest.BiologicalIndicatorTestStatusId = genericBiologicalIndicatorTest.BiologicalIndicatorTestStatusId;			
			concreteBiologicalIndicatorTest.TestResult = genericBiologicalIndicatorTest.TestResult;			
			concreteBiologicalIndicatorTest.PinRequestReasonId = genericBiologicalIndicatorTest.PinRequestReasonId;
		}
	}
}
		