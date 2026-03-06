using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum AccessContext
    {
        Unknown = 0,
        Customer = 1,
        Facility = 2
    }

    /// <summary>
    /// AccessDeniedModel
    /// </summary>
    public class AccessDeniedModel : ErrorModel
    {
        public static readonly AccessDeniedModel Default = new AccessDeniedModel
        {
            ID = Guid.Empty,
            StatusCode = System.Net.HttpStatusCode.NotFound,
            ResourceType = typeof(AccessDeniedModel)
        };

        /// <summary>
        /// Gets or sets ResourceUrl
        /// </summary>
        public string ResourceUrl { get; set; }
        /// <summary>
        /// Gets or sets ReferrerUrl
        /// </summary>
        public string ReferrerUrl { get; set; }
        /// <summary>
        /// Gets or sets Context
        /// </summary>
        public AccessContext Context { get; set; }
        /// <summary>
        /// Gets or sets ResourceType
        /// </summary>
        public Type ResourceType { get; set; }
        /// <summary>
        /// Gets or sets Identifier
        /// </summary>
        public object Identifier { get; set; }

        /// <summary>
        /// GetParagraphs operation
        /// </summary>
        public List<string> GetParagraphs(string text)
        {
            return text?
                .Split(new [] { '|' }, StringSplitOptions.None)
                .ToList() 
                ?? new List<string>();
        }

        /// <summary>
        /// ToLogMessage operation
        /// </summary>
        public string ToLogMessage()
        {
            return $"Error: {ID}, Context: {Context}, Resource: {ResourceType}//{Identifier}, Requested Resource: {ResourceUrl}, Referrer: {ReferrerUrl}";
        }
    }
}