using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DialogLayoutModel
    /// </summary>
    public class DialogLayoutModel
    {
        /// <summary>
        /// Gets or sets Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets DialogClass
        /// </summary>
        public string DialogClass { get; set; }
        /// <summary>
        /// Gets or sets Title
        /// </summary>
        public string Title { get; set; }

    }

    /// <summary>
    /// FeatureTourLayoutModel
    /// </summary>
    public class FeatureTourLayoutModel : DialogLayoutModel
    {
        public FeatureTourLayoutModel(string token)
        {
            Pages = new List<FeatureTourPage>();
            Token = token;
        }

        /// <summary>
        /// Gets or sets Pages
        /// </summary>
        public List<FeatureTourPage> Pages { get; }

        /// <summary>
        /// Gets or sets Token
        /// </summary>
        public string Token { get; }
    }

    /// <summary>
    /// FeatureTourPage
    /// </summary>
    public class FeatureTourPage
    {
        /// <summary>
        /// Gets or sets ArticleLinkText
        /// </summary>
        public string ArticleLinkText { get; set; }
        /// <summary>
        /// Gets or sets ArticleURL
        /// </summary>
        public string ArticleURL { get; set; }
        /// <summary>
        /// Gets or sets BackgroundColour
        /// </summary>
        public string BackgroundColour { get; set; }
        /// <summary>
        /// Gets or sets ImagePath
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets Title
        /// </summary>
        public string Title { get; set; }
    }
}