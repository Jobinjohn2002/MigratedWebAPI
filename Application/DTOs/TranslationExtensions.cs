using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public static class TranslationExtensions
    {
        /// <summary>
        /// GetTranslation operation
        /// </summary>
        public static IQueryable<Translation> GetTranslation(this IQueryable<Translation> translation, UserCultureData userCultureData, string sectionGroup, string section, string from = null)
        {
            if (translation == null)
                throw new ArgumentNullException("translation");
            var missingTranslationFallback = true;

            #if DEBUG
                missingTranslationFallback = false;
            #endif

            const string fallbackCulture = "en-GB";

            var translations = translation
                .Where(t =>
                    t.Application == userCultureData.Application &&
                    t.LanguageSet == userCultureData.LanguageSet &&
                    t.Culture == userCultureData.Culture &&
                    t.SectionGroup == sectionGroup &&
                    t.Section == section &&
                    (from == null || t.From == from));

#pragma warning disable S2583 // Debug block above controls condition
            if (missingTranslationFallback)
#pragma warning restore S2583
            {
                var enTranslation = translation
                    .Where(t =>
                        t.Application == userCultureData.Application &&
                        t.LanguageSet == userCultureData.LanguageSet &&
                        t.Culture == fallbackCulture &&
                        t.SectionGroup == sectionGroup &&
                        t.Section == section &&
                        (from == null || t.From == from));
                var translations1 = translations;
                var onlyExistsInFallback = enTranslation.Where(ent => !translations1.Any(t =>
                        ent.Application == t.Application &&
                        ent.LanguageSet == t.LanguageSet &&
                        ent.SectionGroup == t.SectionGroup &&
                        ent.Section == t.Section &&
                        ent.From == t.From));

                translations = translations.Union(onlyExistsInFallback);
            }

            return translations;
        }
    }
}
