using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Tag
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Gets or sets TagID
        /// </summary>
        public int TagID { get; set; }
        /// <summary>
        /// Gets or sets Value
        /// </summary>
        public string Value { get; set; }
        public int? TagContextID { get; set; }
        public int? Lft { get; set; }
        public int? Rgt { get; set; }
    }
    /// <summary>
    /// SuggestionTag
    /// </summary>
    public class SuggestionTag : Tag
    {
        /// <summary>
        /// Gets or sets Suggested
        /// </summary>
        public bool Suggested { get; protected set; }
        /// <summary>
        /// Gets or sets DNA
        /// </summary>
        public string DNA { get; protected set; }
        /// <summary>
        /// Gets or sets Path
        /// </summary>
        public string Path { get; protected set; }
    }
    /// <summary>
    /// FullTag
    /// </summary>
    public class FullTag : SuggestionTag
    {
        /// <summary>
        /// Gets or sets ContextName
        /// </summary>
        public string ContextName { get; protected set; }
        /// <summary>
        /// Gets or sets FullPath
        /// </summary>
        public string FullPath { get; protected set; }
        /// <summary>
        /// Gets or sets SoundEx
        /// </summary>
        public string SoundEx { get; protected set; }
    }
    /// <summary>
    /// TagSearchResult
    /// </summary>
    public class TagSearchResult
    {
        /// <summary>
        /// Gets or sets Hits
        /// </summary>
        public int Hits { get; set; }
        /// <summary>
        /// Gets or sets Score
        /// </summary>
        public int Score { get; set; }
    }
    /// <summary>
    /// ItemTagSearchResult
    /// </summary>
    public class ItemTagSearchResult : TagSearchResult
    {
        /// <summary>
        /// Gets or sets BaseType
        /// </summary>
        public string BaseType { get; set; }
        /// <summary>
        /// Gets or sets Catalogue
        /// </summary>
        public string Catalogue { get; set; }
        /// <summary>
        /// Gets or sets Category
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Gets or sets ComponentPartCount
        /// </summary>
        public int ComponentPartCount { get; set; }
        /// <summary>
        /// Gets or sets ExternalID
        /// </summary>
        public string ExternalID { get; set; }
        public int? ItemMasterDefinitionID { get; set; }
        public int? ItemMasterID { get; set; }
        /// <summary>
        /// Gets or sets SubType
        /// </summary>
        public string SubType { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets ManufacturersReference
        /// </summary>
        public string ManufacturersReference { get; set; }
    }
}
