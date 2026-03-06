using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum FeedbackFetchHint
    {
        [EnumMember]
        Mine,
        [EnumMember]
        Recent,
        [EnumMember]
        Trending
    }
    /// <summary>
    /// UserFeedback
    /// </summary>
    public class UserFeedback
    {
        /// <summary>
        /// Gets or sets CanVote
        /// </summary>
        public bool CanVote { get; set; }
        /// <summary>
        /// Gets or sets Channel
        /// </summary>
        public string Channel { get; set; }
        /// <summary>
        /// Gets or sets CreatedByUserID
        /// </summary>
        public int CreatedByUserID { get; set; }
        /// <summary>
        /// Gets or sets CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets Feedback
        /// </summary>
        public string Feedback { get; set; }
        /// <summary>
        /// Gets or sets FeedbackID
        /// </summary>
        public int FeedbackID { get; set; }
        /// <summary>
        /// Gets or sets LastCommentBy
        /// </summary>
        public string LastCommentBy { get; set; }
        public DateTime? LastCommentOn { get; set; }
        /// <summary>
        /// Gets or sets LastCommentText
        /// </summary>
        public string LastCommentText { get; set; }
        /// <summary>
        /// Gets or sets NumberOfComments
        /// </summary>
        public int NumberOfComments { get; set; }
        /// <summary>
        /// Gets or sets Sentiment
        /// </summary>
        public string Sentiment { get; set; }
        /// <summary>
        /// Gets or sets Tags
        /// </summary>
        public string Tags { get; set; }
        /// <summary>
        /// Gets or sets URL
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// Gets or sets Votes
        /// </summary>
        public int Votes { get; set; }
    }
    /// <summary>
    /// UserFeedbackDetail
    /// </summary>
    public class UserFeedbackDetail : UserFeedback
    {
        /// <summary>
        /// Gets or sets Comments
        /// </summary>
        public List<Comment> Comments { get; set; }
    }
}
