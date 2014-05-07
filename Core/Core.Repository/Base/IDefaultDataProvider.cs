namespace Core.Repository.Base
{
    public interface IDefaultDataProvider<T>
    {
        void Insert(T dataTransferObject);
        void Update(T dataTransferObject);
        void Delete(long id);
    }
}