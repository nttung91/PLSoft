namespace PhuLiNet.Business.Common.Languages.Provider
{
    public class ItalianLanguageProvider : ILanguageProvider
    {
        #region ILanguageProvider Members

        public string GetLanguageId()
        {
            return Language.Lang_Id_Italian;
        }

        #endregion
    }
}