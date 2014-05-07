using PhuLiNet.Business.Common.Languages;
using Windows.Core.BaseForms;
using Windows.Core.Forms;
using Windows.Core.Localization;

namespace Windows.Core.HelpProvider
{
    public abstract class HelpProviderBase : IHelpProvider
    {
        /// <summary>
        /// Answers the full qualified name of the helpfile with or without language suffix.
        /// </summary>
        protected abstract string GetHelpfileFullName(IHelpOnForm help, bool useLanguage);

        /// <summary>
        /// Opens the help file with given full qualified name.
        /// </summary>
        protected abstract void OpenHelpfile(string fullName);

        /// <summary>
        /// Answers if file with given full qualified name exists.
        /// </summary>
        protected abstract bool FileExists(string filePath);

        /// <summary>
        /// Answers the name of the helpfile including extension, but without path.
        /// </summary>
        /// <param name="help">instance of form</param>
        /// <param name="withLanguage"><c>true</c> if language suffix should be appended, <c>false</c> if not.</param>
        protected string GetHelpFileNameWithoutPath(IHelpOnForm help, bool withLanguage)
        {
            if (help == null)
                return null;

            var pluginShortcut = GetPluginShortcut(help);

            var helpFileName = string.IsNullOrEmpty(help.HelpFileName)
                ? pluginShortcut
                : help.HelpFileName;

            return string.IsNullOrEmpty(helpFileName)
                ? null
                : string.Format("{0}{1}{2}", helpFileName, withLanguage ? GetLanguageSuffix() : null,
                    help.HelpFileExtension);
        }

        #region IHelpProvider implementation

        public void ShowHelp(IHelpOnForm help)
        {
            if (help == null)
                return;

            var fullNameWithLanguage = GetHelpfileFullName(help, true);
            if (string.IsNullOrEmpty(fullNameWithLanguage))
            {
                MessageBox.ShowInfo(HelpProviderMessages.NoHelpExists, HelpProviderMessages.MessageBoxTitle);
                return;
            }

            if (FileExists(fullNameWithLanguage))
            {
                OpenHelpfile(fullNameWithLanguage);
                return;
            }

            var fullNameWithoutLanguage = GetHelpfileFullName(help, false);
            if (FileExists(fullNameWithoutLanguage))
            {
                OpenHelpfile(fullNameWithoutLanguage);
                return;
            }

            MessageBox.ShowInfo(string.Format(HelpProviderMessages.NoSuchHelpfileFound, fullNameWithLanguage),
                HelpProviderMessages.MessageBoxTitle);
        }

        #endregion

        private static string GetPluginShortcut(IHelpOnForm help)
        {
            string pluginShortcut = null;
            var identifiableForm = help as IIdentifiableForm;
            if (identifiableForm == null) return null;

            return pluginShortcut;
        }

        private static string GetLanguageSuffix()
        {
            var currentLanguage = new LanguageList().SearchCurrentCulture();
            if (currentLanguage != null)
                return "-" + currentLanguage.HelpfileSuffix;
            return null;
        }
    }
}