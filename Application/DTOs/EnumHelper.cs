using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public static class EnumHelper
    {
        /// <summary>
        /// ToString operation
        /// </summary>
        public static string ToString(CompareOperator value)
        {
            switch (value)
            {
                case CompareOperator.EqualTo:
                {
                    return SharedResources.Operator_Comparison_EqualToText;
                }
                case CompareOperator.NotEqualTo:
                {
                    return SharedResources.Operator_Comparison_NotEqualToText; 
                }
                case CompareOperator.GreaterThan:
                {
                    return SharedResources.Operator_Comparison_GreaterThanText; 
                }
                case CompareOperator.GreaterThanEqualTo:
                {
                    return SharedResources.Operator_Comparison_GreaterThanEqualToText; 
                }
                case CompareOperator.LessThan:
                {
                    return SharedResources.Operator_Comparison_LessThanText; 
                }
                case CompareOperator.LessThanEqualTo:
                {
                    return SharedResources.Operator_Comparison_LessThanEqualToText; 
                }
                default:
                {
                    throw new NotSupportedException();
                }
            }
        }

        /// <summary>
        /// GetDescription operation
        /// </summary>
        public static string GetDescription(Enum en)
        {
            var type = en.GetType();
            var memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return en.ToString();
        }
    }
}
