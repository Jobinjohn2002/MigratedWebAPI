using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
        /// <summary>
        /// BatchResultData
        /// </summary>
        public class BatchResultData
        {
            public BatchResultData()
            {

            }

            public BatchResultData(string itempassed, int itemsPassedCount, int itemsFailedCount)
            {
                FirstItemScannedOut = itempassed;
                ItemsPassed = itemsPassedCount;
                ItemsFailed = itemsFailedCount;
            }

            public BatchResultData(IBatchResult genericObj)
            {
                FirstItemScannedOut = genericObj.FirstItemScannedOut;
                ItemsPassed = genericObj.ItemsPassed;
                ItemsFailed = genericObj.ItemsFailed;
            }
            /// <summary>
            /// Gets or sets FirstItemScannedOut
            /// </summary>
            public string FirstItemScannedOut { get; set; }
            public DateTime? FirstItemScannedOutDate { get; set; }
            /// <summary>
            /// Gets or sets ItemsPassed
            /// </summary>
            public int ItemsPassed { get; set; }
            /// <summary>
            /// Gets or sets ItemsFailed
            /// </summary>
            public int ItemsFailed { get; set; }
        }
}
