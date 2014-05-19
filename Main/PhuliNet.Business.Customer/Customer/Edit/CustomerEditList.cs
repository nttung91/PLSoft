using System;
using Csla;
using PhuLiNet.Business.Common.CslaBase;
using PhuLiNet.Repository;
using PhuLiNet.Repository.Config;

namespace PhuliNet.Business.Customer.Customer.Edit
{
    [Serializable]
    public class CustomerEditList : PhuLiBusinessBindingListBase<CustomerEditList, CustomerEdit>
    {
        #region Data Access

        /// <summary>
        /// Fetch data from DB
        /// </summary>
        /// <remarks>Called by CSLA <see cref="DataPortal"/>, not used directly in code.</remarks>        
        // ReSharper disable UnusedMember.Local
        private void Child_Fetch()
        // ReSharper restore UnusedMember.Local
        {
            using (var ctx = UnitOfWorkContextManager<UnitOfWork>.Get(false))
            {
                var repository = new CustomerRepository(ctx.UnitOfWork);
                var data = repository.GetAll();
                FetchChildren(data);
            }
        }

        #endregion
    }
}
