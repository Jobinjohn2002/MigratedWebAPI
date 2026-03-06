using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// This represents a preformatted text sample on the help page. There's a display template named TextSample associated with this class.
    /// </summary>
    /// <summary>
    /// TextSample
    /// </summary>
    public class TextSample
    {
        public TextSample(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            Text = text;
        }

        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Equals operation
        /// </summary>
        public override bool Equals(object obj)
        {
            TextSample other = obj as TextSample;
            return other != null && Text == other.Text;
        }

        /// <summary>
        /// GetHashCode operation
        /// </summary>
        public override int GetHashCode()
        {
            return Text.GetHashCode();
        }

        /// <summary>
        /// ToString operation
        /// </summary>
        public override string ToString()
        {
            return Text;
        }
    }
}