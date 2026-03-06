using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyContainerMasterPriceFullHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ContainerMasterPriceFull concreteContainerMasterPriceFull, ContainerMasterPriceFull genericContainerMasterPriceFull)
        {
					
			concreteContainerMasterPriceFull.ContainerMasterId = genericContainerMasterPriceFull.ContainerMasterId;			
			concreteContainerMasterPriceFull.ComponentCount = genericContainerMasterPriceFull.ComponentCount;			
			concreteContainerMasterPriceFull.InstrumentCount = genericContainerMasterPriceFull.InstrumentCount;			
			concreteContainerMasterPriceFull.SingleUseItemCount = genericContainerMasterPriceFull.SingleUseItemCount;			
			concreteContainerMasterPriceFull.OtherComponentCount = genericContainerMasterPriceFull.OtherComponentCount;			
			concreteContainerMasterPriceFull.FinancialComponentCount = genericContainerMasterPriceFull.FinancialComponentCount;			
			concreteContainerMasterPriceFull.PriceCategoryGroupId = genericContainerMasterPriceFull.PriceCategoryGroupId;			
			concreteContainerMasterPriceFull.PriceCategoryGroupName = genericContainerMasterPriceFull.PriceCategoryGroupName;			
			concreteContainerMasterPriceFull.PriceCategoryDefinitionId = genericContainerMasterPriceFull.PriceCategoryDefinitionId;			
			concreteContainerMasterPriceFull.PriceCategoryId = genericContainerMasterPriceFull.PriceCategoryId;			
			concreteContainerMasterPriceFull.PriceCategoryExternalId = genericContainerMasterPriceFull.PriceCategoryExternalId;			
			concreteContainerMasterPriceFull.PriceCategoryName = genericContainerMasterPriceFull.PriceCategoryName;			
			concreteContainerMasterPriceFull.PriceCategoryOverride = genericContainerMasterPriceFull.PriceCategoryOverride;			
			concreteContainerMasterPriceFull.BatchCycleId = genericContainerMasterPriceFull.BatchCycleId;			
			concreteContainerMasterPriceFull.BatchCycleName = genericContainerMasterPriceFull.BatchCycleName;			
			concreteContainerMasterPriceFull.PriceCategoryCharge = genericContainerMasterPriceFull.PriceCategoryCharge;			
			concreteContainerMasterPriceFull.ManualPriceCategoryCharge = genericContainerMasterPriceFull.ManualPriceCategoryCharge;			
			concreteContainerMasterPriceFull.SingleUseItemCharge = genericContainerMasterPriceFull.SingleUseItemCharge;			
			concreteContainerMasterPriceFull.ManualSingleUseItemCharge = genericContainerMasterPriceFull.ManualSingleUseItemCharge;			
			concreteContainerMasterPriceFull.HandWashMarginApplicableAdjustment = genericContainerMasterPriceFull.HandWashMarginApplicableAdjustment;			
			concreteContainerMasterPriceFull.HandWashNonMarginApplicableAdjustment = genericContainerMasterPriceFull.HandWashNonMarginApplicableAdjustment;			
			concreteContainerMasterPriceFull.DiscountMarginApplicableAdjustment = genericContainerMasterPriceFull.DiscountMarginApplicableAdjustment;			
			concreteContainerMasterPriceFull.DiscountNonMarginApplicableAdjustment = genericContainerMasterPriceFull.DiscountNonMarginApplicableAdjustment;			
			concreteContainerMasterPriceFull.OtherMarginApplicableAdjustment = genericContainerMasterPriceFull.OtherMarginApplicableAdjustment;			
			concreteContainerMasterPriceFull.OtherNonMarginApplicableAdjustment = genericContainerMasterPriceFull.OtherNonMarginApplicableAdjustment;
		}
	}
}
		