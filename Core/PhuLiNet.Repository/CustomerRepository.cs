using DbModel.Core;
using PhuLiNet.DbModels;

namespace PhuLiNet.Repository
{
    public class CustomerRepository : UniqueKeyRepositoryBase<Customer, int>
    {
        public CustomerRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
