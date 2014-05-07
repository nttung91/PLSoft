namespace PhuLiNet.Business.Common.Languages.Provider
{
    public class FrenchLanguageProvider : ILanguageProvider
    {
        #region ILanguageProvider Members

        public string GetLanguageId()
        {
            return Language.Lang_Id_French;
        }

        #endregion
    }
}