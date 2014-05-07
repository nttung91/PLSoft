namespace PhuLiNet.Business.Common.Languages.Provider
{
    public class DutchLanguageProvider : ILanguageProvider
    {

        #region ILanguageProvider Members

        public string GetLanguageId()
        {
            return Language.Lang_Id_Dutch;
        }

        #endregion

    }
}
