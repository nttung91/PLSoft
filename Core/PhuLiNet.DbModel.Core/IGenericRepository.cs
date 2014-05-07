namespace DbModel.Core
{
    public interface IGenericRepository<TD> : IRepository where TD : class
    {
        void Insert(TD instance);
        void Update(TD instance);
        void Delete(TD instance);
    }
}