using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TrolleyLoadFromUsagePointContentsModel
    /// </summary>
    public class TrolleyLoadFromUsagePointContentsModel : EpocTrolleyModel
    {
        private const string Group = "pages";
        private const string Section = "services.trolley.loadfromusagepoint";

        /// <summary>
        /// Gets or sets WarningCount
        /// </summary>
        public int WarningCount { get; set; }

        /// <summary>
        /// Gets or sets CanReadContainerMaster
        /// </summary>
        public bool CanReadContainerMaster { get; set; }
        /// <summary>
        /// Gets or sets CanReadInstance
        /// </summary>
        public bool CanReadInstance { get; set; }
        /// <summary>
        /// Gets or sets CanReadTurnaround
        /// </summary>
        public bool CanReadTurnaround { get; set; }
        /// <summary>
        /// Gets or sets CanReadStoragePoint
        /// </summary>
        public bool CanReadStoragePoint { get; set; }

        public override string TranslationGroup => Group;
        public override string TranslationSection => Section;

        public int? SelectedStoragePointId { get; set; }
        /// <summary>
        /// Gets or sets StoragePointDescription
        /// </summary>
        public string StoragePointDescription { get; set; }
        public string StoragePointContentsIndex
        {
            get
            {
                if (_stockData.Count == 0) return null;
                var result = string.Empty;
                foreach (var group in _stockDataGrouped)
                {
                    result += string.Format("{0} ({1}), ", group.Key, group.Value.Count);
                }
                return result.Substring(0, result.Length-2);
            }
        }

        public bool AnyExtras => StockData.Any(a => a.ItemTypeId == (int)KnownItemType.Extra);

        private List<StockItem> _stockData { get; set; }
        private Dictionary<string, List<StockItem>> _stockDataGrouped { get; set; }
        /// <summary>
        /// Gets or sets StockData
        /// </summary>
        public List<StockItem> StockData { get => _stockData; set
            {
                _stockData = value;
                _stockDataGrouped = _stockData.GroupBy(a => a.ItemType).ToDictionary(a => a.Key, a => a.ToList());
            } }

        public Dictionary<string, List<StockItem>> StockDataGrouped => _stockDataGrouped;
    }
}