namespace PhuLiNet.Business.Common.Languages.Provider
{
    public class EnglishLanguageProvider : ILanguageProvider
    {
        #region ILanguageProvider Members

        public string GetLanguageId()
        {
            return Language.Lang_Id_English;
        }

        #endregion
    }
}