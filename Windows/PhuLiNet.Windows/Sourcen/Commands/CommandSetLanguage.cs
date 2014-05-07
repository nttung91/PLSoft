using System;
using PhuLiNet.Business.Common.Languages;
using PhuLiNet.Business.Common.Languages.Provider;
using Windows.Core.Localization;

namespace Windows.Core.Commands
{
    public class CommandSetLanguage : BaseCommand
    {
        private ILanguageProvider _languageProvider;
        private Language _language;
        private string _langId;

        [Obsolete("Use constructor with ILanguageProvider")]
        public CommandSetLanguage(string langId)
        {
            _langId = langId;
        }

        public CommandSetLanguage(ILanguageProvider languageProvider)
        {
            _languageProvider = languageProvider;
            Audit = false;
            Log = false;
        }

        public CommandSetLanguage(Language language)
        {
            _language = language;
            Audit = false;
            Log = false;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            if (_languageProvider != null)
            {
                var langList = new LanguageList();
                _language = langList.Search(_languageProvider.GetLanguageId());
            }
            else if (!string.IsNullOrEmpty(_langId))
            {
                var langList = new LanguageList();
                _language = langList.Search(_langId);
            }

            CurrentCulture.Set(_language.WindowsCultureName);
            UserLanguage.Set(_language);
        }

        #endregion
    }
}