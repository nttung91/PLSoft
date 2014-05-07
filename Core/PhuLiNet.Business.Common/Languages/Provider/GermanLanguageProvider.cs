namespace PhuLiNet.Business.Common.Languages.Provider
{
    public class GermanLanguageProvider : ILanguageProvider
    {
        #region ILanguageProvider Members

        public string GetLanguageId()
        {
            return Language.Lang_Id_German;
        }

        #endregion
    }
}