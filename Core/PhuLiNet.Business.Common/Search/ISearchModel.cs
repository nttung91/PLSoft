namespace PhuLiNet.Business.Common.Search
{
    public interface ISearchModel
    {
        bool HasData { get; }
        int Count { get; }

        int CountSelected();
        void ClearData();
        void ClearSelection();
        void Search();
        void SelectAll();
        void SelectNone();
    }
}