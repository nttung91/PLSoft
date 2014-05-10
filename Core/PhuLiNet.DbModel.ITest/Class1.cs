using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhuLiNet.Repository;
using PhuLiNet.Repository.Config;

namespace PhuLiNet.DbModel.ITest
{
    [TestClass]
    public class Class1
    {
        [TestMethod]
        public void Get()
        {
            using (var uow = UnitOfWork.Create(true))
            {
                var repository = new CustomerRepository(uow);
                var cus = repository.GetById(1);
                Assert.IsNotNull(cus);
                uow.Complete();
            }
        }
    }
}
