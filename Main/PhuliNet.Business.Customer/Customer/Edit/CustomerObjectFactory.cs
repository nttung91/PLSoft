using DbModel.Core;
using PhuLiNet.Business.Common.CslaBase.ObjectFactory;
using PhuLiNet.Repository;

namespace PhuliNet.Business.Customer.Customer.Edit
{
    public class CustomerObjectFactory : GenericObjectFactoryBase<CustomerEdit, PhuLiNet.DbModels.Customer, int>
    {
        public CustomerObjectFactory(CustomerEdit businessObject)
            : base(null, null, businessObject)
        {
        }

        public CustomerObjectFactory(CustomerEdit businessObject, PhuLiNet.DbModels.Customer databaseEntity)
            : base(null, null, businessObject)
        {
            DatabaseEntity = databaseEntity;
        }

        public CustomerObjectFactory(IUnitOfWork unitOfWork, CustomerEdit businessObject)
            : base(unitOfWork, new CustomerRepository(unitOfWork), businessObject)
        {
        }

        public override void CreateNew()
        {
        }

        public override void Fetch()
        {
            using (BypassPropertyChecks(BusinessObject))
            {
                LoadProperty(BusinessObject, CustomerEdit.CusIdProperty, DatabaseEntity.CusId);
                LoadProperty(BusinessObject, CustomerEdit.AddressProperty, DatabaseEntity.Address);
                LoadProperty(BusinessObject, CustomerEdit.DescrProperty, DatabaseEntity.Descr);
                LoadProperty(BusinessObject, CustomerEdit.TelProperty, DatabaseEntity.Tel);
                LoadProperty(BusinessObject, CustomerEdit.ArtCusIdProperty, DatabaseEntity.ArtCusId);
            }
        }

        public override void InsertPreparation()
        {
            DatabaseEntity = new PhuLiNet.DbModels.Customer();
            UpdateProperties();
        }

        public override void UpdatePreparation()
        {
            if (BusinessObject.IsSelfDirty)
            {
                UpdateProperties();
            }
        }

        private void UpdateProperties()
        {
            DatabaseEntity.CusId = BusinessObject.CusId;
            DatabaseEntity.Address = BusinessObject.Address;
            DatabaseEntity.Tel = BusinessObject.Tel;
            DatabaseEntity.Descr = BusinessObject.Descr;
        }
    }
}

