using System.Collections.Generic;
using System.Linq;
using System.Threading;
using PhuLiNet.Business.Common.Languages.Provider;
using PhuLiNet.Business.Common.Localization;

namespace PhuLiNet.Business.Common.Languages
{
    public class LanguageList : List<Language>
    {
        public Dictionary<string, ILanguageProvider> LanguageProviders { get; private set; }

        public readonly static string[] LanguageIdsToExclude = { Language.Lang_Id_German, Language.Lang_Id_Dutch };

        public LanguageList()
        {
            AddLanguages();
            AddLanguageProviders();
        }

        public IEnumerable<Language> GetCommonLanguages()
        {
            return this.Where(n => !LanguageIdsToExclude.Contains(n.LangId));
        }

        private void AddLanguages()
        {
            Add(new Language(LanguageResources.English, Language.Lang_Id_English, "en-GB", "e"));
            Add(new Language(LanguageResources.German, Language.Lang_Id_German, "de-CH", "d"));
            Add(new Language(LanguageResources.French, Language.Lang_Id_French, "fr-CH", "f"));
            Add(new Language(LanguageResources.Italian, Language.Lang_Id_Italian, "it-CH", "i"));
            Add(new Language(LanguageResources.Dutch, Language.Lang_Id_Dutch, "nl-NL", "n"));
        }

        private void AddLanguageProviders()
        {
            LanguageProviders = new Dictionary<string, ILanguageProvider>
            {
                { Language.Lang_Id_English, new EnglishLanguageProvider() },
                { Language.Lang_Id_German, new GermanLanguageProvider() },
                { Language.Lang_Id_French, new FrenchLanguageProvider() },
                { Language.Lang_Id_Italian, new ItalianLanguageProvider() },
                { Language.Lang_Id_Dutch, new DutchLanguageProvider() }
            };
        }

        public Language Search(string langId)
        {
            return this.FirstOrDefault(language => language.LangId == langId);
        }

        public Language SearchByIsoCode(string isoCode)
        {
            return this.FirstOrDefault(language => language.IsoCode == isoCode);
        }

        public Language SearchCurrentCulture()
        {
            return
                this.FirstOrDefault(language => language.WindowsCultureName == Thread.CurrentThread.CurrentCulture.Name);
        }
    }
}