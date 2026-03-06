using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public static class TurnaroundEventWeightExtensions
    {
        /// <summary>
        /// IsWithinTolerance operation
        /// </summary>
        public static bool IsWithinTolerance(this TurnaroundEventWeight turnaroundEventWeight)
        {
            var passed = (turnaroundEventWeight.WeightKg >=
                          turnaroundEventWeight.ReferenceWeightKg - turnaroundEventWeight.ToleranceKg)
                         &&
                         (turnaroundEventWeight.WeightKg <=
                          turnaroundEventWeight.ReferenceWeightKg + turnaroundEventWeight.ToleranceKg);

            return passed;
        }
    }
}
