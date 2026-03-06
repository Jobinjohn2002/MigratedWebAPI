using System;
using System.Collections.Generic;
using System.Linq;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public static class IndexationExtensions
    {
        /// <summary>
        /// IndexedAmount operation
        /// </summary>
        public static decimal IndexedAmount(this IEnumerable<Indexation> indexations, decimal deindexedAmount, DateTime indexTo, IndexationCategoryIdentifier category)
        {
            return deindexedAmount * indexations.CompoundedAmount(indexTo, category);
        }

        /// <summary>
        /// CompoundedAmount operation
        /// </summary>
        public static decimal CompoundedAmount(this IEnumerable<Indexation> indexations, DateTime indexTo, IndexationCategoryIdentifier category)
        {
            return indexations.
                Where(i =>
                    i.IndexationCategoryId == (int)category &&
                    i.AppliesFrom <= indexTo &&
                    i.Archived == null).
                Aggregate(1m, (accumulatedValue, indexation) => accumulatedValue * indexation.Amount);
        }
    }
}
