using System;
using Csla;
using PhuLiNet.Business.Common.CslaBase;
using PhuLiNet.Repository.Config;

namespace PhuliNet.Business.Customer.Customer.Edit
{
    [Serializable]
    public class CustomerEditGroup : PhuLiBusinessBase<CustomerEditGroup>
    {
        #region Business Methods

        public static PropertyInfo<CustomerEditList> AbbrevsEditListProperty =
            RegisterProperty<CustomerEditList>(c => c.CustomerEditList);

        public CustomerEditList CustomerEditList
        {
            get { return GetProperty(AbbrevsEditListProperty); }
        }

        #endregion

        #region Factory Methods

        public static CustomerEditGroup Get()
        {
            return DataPortal.Fetch<CustomerEditGroup>();
        }

        private CustomerEditGroup()
        {
            /* Require use of factory methods */
        }

        #endregion

        #region Data Access

        [RunLocal]
        protected override void DataPortal_Create()
        {
            var objectFactory = new CustomerGroupObjectFactory(this);
            objectFactory.CreateNew();
        }

        // ReSharper disable UnusedMember.Local
        [Transactional(TransactionalTypes.Manual)]
        private void DataPortal_Fetch()
        // ReSharper restore UnusedMember.Local
        {
            using (var ctx = UnitOfWorkContextManager<UnitOfWork>.Get(true))
            {
                var objectFactory = new CustomerGroupObjectFactory(ctx.UnitOfWork, this);
                objectFactory.Fetch();

                ctx.Complete();
            }
        }

        // We can only edit, insert and delete children of the list, so just propagate the update.
        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_Update()
        {
            using (var ctx = UnitOfWorkContextManager<UnitOfWork>.Get(true))
            {
                FieldManager.UpdateChildren();
                ctx.Complete();
            }
        }

        #endregion
    }
}