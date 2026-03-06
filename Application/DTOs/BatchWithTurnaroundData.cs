using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{

    [KnownType(typeof(IBatchWithTurnaroundDetails))]
    [Serializable]
    /// <summary>
    /// BatchWithTurnaroundData
    /// </summary>
    public class BatchWithTurnaroundData
    {
        public BatchWithTurnaroundData(IBatch batch,int itemsPassed, int itemsFailed, DateTime firstItemPassed)
        {
            Batch = batch;
            ItemsPassed = itemsPassed;
            ItemsFailed = itemsFailed;
            FirstItemPassed = firstItemPassed;
        }
        /// <summary>
        /// Gets or sets Batch
        /// </summary>
        public IBatch Batch { get; set; }
        /// <summary>
        /// Gets or sets ItemsPassed
        /// </summary>
        public int ItemsPassed { get; set; }
        /// <summary>
        /// Gets or sets ItemsFailed
        /// </summary>
        public int ItemsFailed { get; set; }
        /// <summary>
        /// Gets or sets FirstItemPassed
        /// </summary>
        public DateTime FirstItemPassed { get; set; }
    }
}
