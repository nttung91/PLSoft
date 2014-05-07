namespace PhuLiNet.Business.Common.Interfaces
{
    public interface IFilterSelection
    {
        int WindowId { get; set; }
        bool SeperateWindow { get; set; }
        bool SelectionOk { get; }
        string DisplayText { get; }

        IFilterSelection Clone();
        void Overwrite(IFilterSelection selection);
    }
}