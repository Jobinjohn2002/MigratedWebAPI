using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// ITranslator
    /// </summary>
    public interface ITranslator
    {
        /// <summary>
        /// Loads the translator with languages contained in the streams provided by the stream provider function.
        /// </summary>
        /// <param name="streamProvider">A function to provide access to streams containing the language data.</param>
        void Load(Func<IEnumerable<Stream>> streamProvider);

        /// <summary>
        /// Gets the translated text for a specific term
        /// </summary>
        /// <param name="term">The term to translate</param>
        /// <param name="culture">The culture to translate to</param>
        /// <returns>The translated term or a missing term message</returns>
        string GetTerm(string term, CultureInfo culture = null);

        /// <summary>
        /// Gets the translated text for a static piece of text
        /// </summary>
        /// <param name="text">The text to translate</param>
        /// <param name="culture">The culture to translate to</param>
        /// <returns>The translated text or a missing text message</returns>
        string GetText(string text, CultureInfo culture = null);

        /// <summary>
        /// Gets the translated text for a specific section group and section
        /// </summary>
        /// <param name="sectionGroup">The section group</param>
        /// <param name="section">The section</param>
        /// <param name="text">The text to translate</param>
        /// <param name="culture">The culture to translate to</param>
        /// <returns>The translated text or a missing text message</returns>
        string GetText(string sectionGroup, string section, string text, CultureInfo culture = null);

        /// <summary>
        /// Gets a collection containing the support cultures
        /// </summary>
        /// <returns>A collection of supported cultures</returns>
        IEnumerable<CultureInfo> GetSupportedCultures();
    }
}
