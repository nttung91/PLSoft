using Csla;
using DbModel.Core;
using PhuLiNet.Business.Common.CslaBase.ObjectFactory;

namespace PhuliNet.Business.Customer.Customer.Edit
{
    internal class CustomerGroupObjectFactory : PseudoRootObjectFactoryBase<CustomerEditGroup>
    {
        public CustomerGroupObjectFactory(IUnitOfWork unitOfWork, CustomerEditGroup businessObject)
            : base(unitOfWork, businessObject)
        {
        }

        public CustomerGroupObjectFactory(CustomerEditGroup businessObject)
            : base(null, businessObject)
        {
        }

        public override void CreateNew()
        {
            LoadProperty(BusinessObject, CustomerEditGroup.AbbrevsEditListProperty, DataPortal.CreateChild<CustomerEditList>());
        }

        public override void Fetch()
        {
            LoadProperty(BusinessObject, CustomerEditGroup.AbbrevsEditListProperty, DataPortal.FetchChild<CustomerEditList>());
        }
    }
}

