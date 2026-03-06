using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class ContainerMasterPriceFull
    {
        /// <summary>
        /// Shortcut to the Customer's CostingModel
        /// </summary>
        public CostingModel CostingModel
        {
            get
            {
                return ContainerMaster.ContainerMasterDefinition.CustomerDefinition.CostingModel.Single();
            }
        }

        /// <summary>
        /// Determines whether the CostingModel's SingleUseItemCharge can be overidden
        /// </summary>
        public bool AllowSingleUseCostOverride
        {
            get
            {
                return (CostingModel.AllowSingleUseCostOverride);
            }
        }

        /// <summary>
        /// Determines whether the CostingModel's PriceCategory can be overidden
        /// </summary>
        public bool AllowPriceCategoryOverrideAdjustedForModelType
        {
            get
            {
                return (CostingModel.AllowPriceCategoryOverrideAdjustedForModelType);
            }
        }

        /// <summary>
        /// The associated customer's indexations
        /// </summary>
        public ICollection<Indexation> Indexations
        {
            get
            {
                return ContainerMaster.ContainerMasterDefinition.CustomerDefinition.Indexation;
            }
        }

        /// <summary>
        /// The single use item charge (calculated, manual or final) with or without indexation applied
        /// </summary>
        /// <param name="overrideType"></param>
        /// <param name="indexTo"></param>
        /// <returns></returns>
        public decimal? SingleUseItemCharge2(ItemPriceType type, DateTime? indexTo)
        {
            decimal? value;
            switch (type)
            {
                case ItemPriceType.Calculated:
                {
                    value = SingleUseItemCharge;
                    break;
                }
                case ItemPriceType.Manual:
                {
                    value = ManualSingleUseItemCharge;
                    break;
                }
                case ItemPriceType.Final:
                {
                    value = (AllowSingleUseCostOverride && ManualSingleUseItemCharge != null ? ManualSingleUseItemCharge : SingleUseItemCharge);
                    break;
                }
                default:
                {
                    throw new NotSupportedException();
                }
            }

            if (value != null && indexTo != null)
            {
                value = Indexations.IndexedAmount(value.Value, indexTo.Value, IndexationCategoryIdentifier.SingleUse);
            }

            return value;
        }

        /// <summary>
        /// The price category charge (calculated, manual or final) with or without indexation applied
        /// </summary>
        /// <param name="overrideType"></param>
        /// <param name="indexTo"></param>
        /// <returns></returns>
        public decimal? PriceCategoryCharge2(ItemPriceType type, DateTime? indexTo)
        {
            decimal? value;
            switch (type)
            {
                case ItemPriceType.Calculated:
                {
                    value = PriceCategoryCharge;
                    break;
                }
                case ItemPriceType.Manual:
                {
                    value = ManualPriceCategoryCharge;
                    break;
                }
                case ItemPriceType.Final:
                {
                    value = (CostingModel.CostingModelTypeId == (int)CustomerCostingModelTypeIdentifier.Manual && ManualPriceCategoryCharge != null ? ManualPriceCategoryCharge : PriceCategoryCharge);
                    break;
                }
                default:
                {
                    throw new NotSupportedException();
                }
            }

            if (value != null && indexTo != null)
            {
                value = Indexations.IndexedAmount(value.Value, indexTo.Value, IndexationCategoryIdentifier.Reprocessing);
            }

            return value;
        }

        /// <summary>
        /// One of the adjustment values (hand-wash, discount or other) with or without the margin applied and with or without indexation applied
        /// </summary>
        /// <param name="type"></param>
        /// <param name="marginApplicable"></param>
        /// <param name="indexTo"></param>
        /// <returns></returns>
        /// <summary>
        /// Adjustment operation
        /// </summary>
        public decimal Adjustment(AdjustmentType type, bool marginApplicable, DateTime? indexTo)
        {
            decimal value;
            switch (type)
            {
                case AdjustmentType.HandWash:
                {
                    value = (marginApplicable ? HandWashMarginApplicableAdjustment : HandWashNonMarginApplicableAdjustment);
                    value = (indexTo == null ? value : Indexations.IndexedAmount(value, indexTo.Value, IndexationCategoryIdentifier.Handwash));
                    break;
                }
                case AdjustmentType.Discount:
                {
                    value = (marginApplicable ? DiscountMarginApplicableAdjustment : DiscountNonMarginApplicableAdjustment);
                    value = (indexTo == null ? value : Indexations.IndexedAmount(value, indexTo.Value, IndexationCategoryIdentifier.Other));
                    break;
                }
                case AdjustmentType.Other:
                {
                    value = (marginApplicable ? OtherMarginApplicableAdjustment : OtherNonMarginApplicableAdjustment);
                    value = (indexTo == null ? value : Indexations.IndexedAmount(value, indexTo.Value, IndexationCategoryIdentifier.Other));
                    break;
                }
                default:
                {
                    throw new NotSupportedException();
                }
            }

            return value;
        }

        /// <summary>
        /// The total of all adjustment values with or without indexation applied
        /// </summary>
        /// <param name="indexTo"></param>
        /// <returns></returns>
        /// <summary>
        /// TotalAdjustment operation
        /// </summary>
        public decimal TotalAdjustment(DateTime? indexTo)
        {
            return
                Adjustment(AdjustmentType.HandWash, true, indexTo) +
                Adjustment(AdjustmentType.HandWash, false, indexTo) +
                Adjustment(AdjustmentType.Discount, true, indexTo) +
                Adjustment(AdjustmentType.Discount, false, indexTo) +
                Adjustment(AdjustmentType.Other, true, indexTo) +
                Adjustment(AdjustmentType.Other, false, indexTo);
        }

        /// <summary>
        /// The total of all charges (calculated, manual or final) with or without indexation applied
        /// </summary>
        /// <param name="overrideType"></param>
        /// <param name="indexTo"></param>
        /// <returns></returns>
        public decimal? TotalCharge(ItemPriceType type, DateTime? indexTo)
        {
            return PriceCategoryCharge2(type, indexTo) + SingleUseItemCharge2(type, indexTo) + TotalAdjustment(indexTo);
        }
    }
}
		