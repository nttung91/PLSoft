using System;
using Csla;
using PhuLiNet.Business.Common.Languages.Provider;
using PhuLiNet.Business.Common.Security;

namespace PhuLiNet.Business.Common.Languages
{
    public class UserLanguage
    {
        public static Language Get()
        {
            var identity = ApplicationContext.User.Identity as PhuLiIdentity;
            if (identity != null)
            {
                return identity.Language;
            }

            return GetDefault();
        }

        public static void Set(ILanguageProvider languageProvider)
        {
            var langList = new LanguageList();
            Language language = langList.Search(languageProvider.GetLanguageId());
            Set(language);
        }

        public static void Set(Language language)
        {
            if (!(ApplicationContext.User.Identity is PhuLiIdentity)) PhuLiPrincipal.Login();

            var manorIdentity = ApplicationContext.User.Identity as PhuLiIdentity;
            if (manorIdentity == null) throw new NullReferenceException("PhuLiIdentity must be present");
            manorIdentity.Language = language;
        }

        public static bool IsDefault()
        {
            return Get().Equals(GetDefault());
        }

        public static Language GetDefault()
        {
            return new LanguageList().Search(Language.Lang_Id_German);
        }
    }
}