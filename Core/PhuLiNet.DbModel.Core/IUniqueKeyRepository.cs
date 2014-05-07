using System.Collections.Generic;
namespace DbModel.Core
{
    public interface IUniqueKeyRepository<TE, in TK> : IGenericRepository<TE> where TE : class
    {
        TE GetById(TK id);
        IList<TE> GetAll();
        IList<TE> GetFirst(int numberOfObjects);
    }
}