namespace Techical.Dynamic.Manager
{
    public interface IColumnManagerHandler
    {
        void Add(IColumnManagerBase columnManager);
        void CreateData();
        void ClearData();
        void ClearComplete();
    }
}