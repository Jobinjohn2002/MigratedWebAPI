using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// GettingStartedModel
    /// </summary>
    public class GettingStartedModel
    {
        public GettingStartedModel()
        {
            CheckList = new List<string>();
            Dismissable = true;
        }

        /// <summary>
        /// Gets or sets Dismissable
        /// </summary>
        public bool Dismissable { get; set; }
        /// <summary>
        /// Gets or sets Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets Caption
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// Gets or sets Summary
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// Gets or sets CheckList
        /// </summary>
        public List<string> CheckList { get; set; }
        /// <summary>
        /// Gets or sets TipsCaption
        /// </summary>
        public string TipsCaption { get; set; }
        /// <summary>
        /// Gets or sets Tips
        /// </summary>
        public List<string> Tips { get; set; }
        /// <summary>
        /// Gets or sets ParagraphAfter
        /// </summary>
        public List<string> ParagraphAfter { get; set; }
        /// <summary>
        /// Gets or sets Footer
        /// </summary>
        public string Footer { get; set; }
    }
}