using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// InvalidReference
    /// </summary>
    public class InvalidReference
    {
        public InvalidReference()
        {
            
        }

        public InvalidReference(InvalidReferenceObjectType type, string typeText)
        {
            InvalidReferenceType = type;
            InvalidReferenceTypeText = typeText;
        }

        public InvalidReference(InvalidReferenceObjectType type, string typeText, int id, string text)
        {
            InvalidReferenceType = type;
            InvalidReferenceTypeText = typeText;
            Id = id;
            Text = text;
        }

        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }

        public InvalidReferenceObjectType? InvalidReferenceType { get; set; }

        /// <summary>
        /// Gets or sets InvalidReferenceTypeText
        /// </summary>
        public string InvalidReferenceTypeText { get; set; }

        public int ChildrenCount => Children.Count;

        /// <summary>
        /// Needs to be a List (was originally a dictionary) else it doesn't JSON serialize in order correctly
        /// </summary>
        /// <summary>
        /// Gets or sets Children
        /// </summary>
        public List<InvalidReference> Children { get; set; } = new List<InvalidReference>();

        public int? OverridenCount { get; set; }
    }
}