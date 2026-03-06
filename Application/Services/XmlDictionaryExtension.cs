using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// XmlDictionaryExtension
    /// </summary>
    public class XmlDictionaryExtension : XmlDictionary
    {
        public XmlDictionaryExtension(string xmlFile) : base (xmlFile)
        {
            
        }

        /// <summary>
        /// GetAllSectionGroups operation
        /// </summary>
        public SortedDictionary<string, SortedDictionary<string, SortedDictionary<string, string>>> GetAllSectionGroups()
        {
            return _sectionGroups;
        }
    }
}
