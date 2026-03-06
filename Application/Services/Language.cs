using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Represents an Xml based translation dictionary
    /// </summary>
    /// <summary>
    /// Language
    /// </summary>
    public class Language
    {
        /// <summary>
        /// Gets the culture of this dictionary
        /// </summary>
        /// <summary>
        /// Gets or sets Culture
        /// </summary>
        public CultureInfo Culture { get; private set; }

        private readonly SortedDictionary<string, string> _terms = new SortedDictionary<string, string>();
        private readonly SortedDictionary<string, string> _texts = new SortedDictionary<string, string>();

        protected readonly SortedDictionary<string, SortedDictionary<string, SortedDictionary<string, string>>> SectionGroups =
            new SortedDictionary<string, SortedDictionary<string, SortedDictionary<string, string>>>();

        /// <summary>
        /// Load operation
        /// </summary>
        public void Load(Stream xmlStream)
        {
            if (xmlStream == null)
            {
                throw new ArgumentNullException(nameof(xmlStream));
            }

            try
            {
                var xml = XDocument.Load(xmlStream);

                BuildLanguage(xml);
            }
            catch (Exception ex)
            {
                throw new XmlException("Failed to load Xml stream", ex);
            }
        }

        private void BuildLanguage(XDocument xml)
        {
            ValidateRoot(xml);

            ValidateCulture(xml);

            var termElements = xml.Descendants("translations").Descendants("terms").Descendants("text");
            LoadTexts(termElements, _terms, false);

            var textElements = xml.Descendants("translations").Descendants("texts").Descendants("text");
            LoadTexts(textElements, _texts, true);

            var sectionGroupElements = xml.Descendants("translations").Descendants("sections").Descendants("sectionGroup");

            foreach (var sectionGroupElement in sectionGroupElements)
            {
                var sectionGroupName = sectionGroupElement.Attributes().Single(a => a.Name.ToString().ToLower() == "name").Value;

                var sectionGroup = new SortedDictionary<string, SortedDictionary<string, string>>();

                SectionGroups.Add(sectionGroupName, sectionGroup);

                foreach (XElement sectionElement in sectionGroupElement.Elements())
                {
                    var section = new SortedDictionary<string, string>();

                    var sectionName = sectionElement.Attributes().Single(a => a.Name.ToString().ToLower() == "name").Value;

                    sectionGroup.Add(sectionName, section);

                    LoadTexts(sectionElement.Elements(), section, true);
                }
            }
        }

        private void ValidateCulture(XDocument xml)
        {
            if (xml.Root == null)
            {
                throw new ArgumentException("Xml stream has no root element");
            }

            try
            {
                var culture = xml.Root.Attributes().Single(a => a.Name.ToString().ToLower() == "culture").Value;

                Culture = new CultureInfo(culture);
            }
            catch (Exception ex)
            {
                throw new XmlException("Invalid culture attribute on root element", ex);
            }
        }

        private static void ValidateRoot(XDocument xml)
        {
            if (xml.Root == null)
            {
                throw new ArgumentException("XDocument has no root element", nameof(xml));
            }
        }

        private void LoadTexts(IEnumerable<XElement> nodeList, SortedDictionary<string, string> dictionary, bool injectTerms)
        {
            foreach (XElement node in nodeList)
            {
                var atts = node.Attributes().ToArray();
                var from = atts.Single(a => a.Name.ToString().ToLower() == "from").Value;
                var to = atts.Single(a => a.Name.ToString().ToLower() == "to").Value;
                dictionary[from] = injectTerms
                    ? InjectTerms(to)
                    : to;
            }
        }

        /// <summary>
        /// Gets the translated text for a specific term
        /// </summary>
        /// <param name="term">The term to translate</param>
        /// <returns>The translated term or null</returns>
        /// <summary>
        /// GetTerm operation
        /// </summary>
        public string GetTerm(string term)
        {
            string trans;

            return _terms.TryGetValue(term, out trans) ? trans : null;
        }

        /// <summary>
        /// Gets the translated text for a static piece of text
        /// </summary>
        /// <param name="text">The text to translate</param>
        /// <returns>The translated text or null</returns>
        /// <summary>
        /// GetText operation
        /// </summary>
        public string GetText(string text)
        {
            string trans;

            return _texts.TryGetValue(text, out trans) ? trans : null;
        }

        /// <summary>
        /// Gets the translated text for a specific section group and section
        /// </summary>
        /// <param name="sectionGroup">The section group</param>
        /// <param name="section">The section</param>
        /// <param name="text">The text to translate</param>
        /// <returns>The translated text or null</returns>
        /// <summary>
        /// GetText operation
        /// </summary>
        public string GetText(string sectionGroup, string section, string text)
        {
            if (!SectionGroups.ContainsKey(sectionGroup))
                return null;

            var sectionGroupDictionary = SectionGroups[sectionGroup];

            if (!sectionGroupDictionary.ContainsKey(section))
                return null;

            var sectionDictionary = sectionGroupDictionary[section];

            string trans;

            return sectionDictionary.TryGetValue(text, out trans)
                ? trans
                : null;
        }

        private string InjectTerms(string text)
        {
            return text.IndexOf("##", StringComparison.Ordinal) == -1
                ? text :
                _terms.Keys.Aggregate(text, (current, term) => current.Replace("##" + term + "##", _terms[term]));
        }
    }
}
