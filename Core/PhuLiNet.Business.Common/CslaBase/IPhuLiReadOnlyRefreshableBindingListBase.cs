namespace PhuLiNet.Business.Common.CslaBase
{
    public interface IPhuLiReadOnlyRefreshableBindingListBase : IPhuLiReadOnlyBindingListBase
    {
        void RefreshItem(object key, bool wasDeleted);
    }
}