using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum TranslationIndexNotification
    {
        None = 0,
        Reload = 1
    }

    /// <summary>
    /// TranslationIndexModel
    /// </summary>
    public class TranslationIndexModel
    {
        /// <summary>
        /// Gets or sets Notification
        /// </summary>
        public TranslationIndexNotification Notification { get; set; }
    }
}