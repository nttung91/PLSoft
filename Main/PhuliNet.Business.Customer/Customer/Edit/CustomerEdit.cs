using System;
using Csla;
using Csla.Rules.CommonRules;
using PhuLiNet.Business.Common.CslaBase;
using PhuLiNet.Repository.Config;

namespace PhuliNet.Business.Customer.Customer.Edit
{
    [Serializable]
    public class CustomerEdit : PhuLiBusinessBase<CustomerEdit>
    {
        #region Business Methods

        internal static readonly PropertyInfo<int> ArtCusIdProperty = RegisterProperty<int>(c => c.ArtCusId);
        internal static readonly PropertyInfo<string> CusIdProperty = RegisterProperty<string>(c => c.CusId);
        internal static readonly PropertyInfo<string> AddressProperty = RegisterProperty<string>(c => c.Address);
        internal static readonly PropertyInfo<string> DescrProperty = RegisterProperty<string>(c => c.Descr);
        internal static readonly PropertyInfo<string> TelProperty = RegisterProperty<string>(c => c.Tel);

        public string CusId
        {
            get { return GetProperty(CusIdProperty); }
            set { SetProperty(CusIdProperty, value); }
        }

        public string Address
        {
            get { return GetProperty(AddressProperty); }
            set { SetProperty(AddressProperty, value); }
        }

        public string Descr
        {
            get { return GetProperty(DescrProperty); }
            set { SetProperty(DescrProperty, value); }
        }

        public string Tel
        {
            get { return GetProperty(TelProperty); }
            set { SetProperty(TelProperty, value); }
        }

        public int ArtCusId
        {
            get { return GetProperty(ArtCusIdProperty); }
            private set { SetProperty(ArtCusIdProperty, value); }
        }

        protected override object GetIdValue()
        {
            return ArtCusId;
        }

        #endregion

        #region Business Rules

        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();

            BusinessRules.AddRule(new Required(CusIdProperty));
            BusinessRules.AddRule(new Required(DescrProperty));

            BusinessRules.AddRule(new MaxLength(CusIdProperty, 30));
            BusinessRules.AddRule(new MaxLength(TelProperty, 20));
            BusinessRules.AddRule(new MaxLength(AddressProperty, 200));
            BusinessRules.AddRule(new MaxLength(DescrProperty, 200));
        }

        #endregion

        #region Factory Methods

        private CustomerEdit()
        {
            /* Require use of factory methods */
        }

        #endregion

        #region Data Access

        protected override void Child_Create()
        {
            new CustomerObjectFactory(this).CreateNew();
        }

        /// <summary>
        /// Fetch data from DB
        /// </summary>
        /// <remarks>Called by CSLA <see cref="DataPortal"/>, not used directly in code.</remarks>
        // ReSharper disable UnusedMember.Local
        private void Child_Fetch(PhuLiNet.DbModels.Customer currentDataAccessObject)
        // ReSharper restore UnusedMember.Local
        {
            var factory = new CustomerObjectFactory(this, currentDataAccessObject);
            factory.Fetch();
        }

        /// <summary>
        /// Insert item to DB
        /// </summary>
        /// <remarks>Not used directly in code but by <see cref="DataPortal"/> at runtime.</remarks>
        // ReSharper disable UnusedMember.Local
        private void Child_Insert()
        // ReSharper restore UnusedMember.Local
        {
            using (var ctx = UnitOfWorkContextManager<UnitOfWork>.Get(false))
            {
                var objectFactory = new CustomerObjectFactory(ctx.UnitOfWork, this);
                objectFactory.InsertPreparation();
                FieldManager.UpdateChildren(objectFactory.Entity);
                objectFactory.Insert();
                objectFactory.Fetch();
                ctx.Complete();
            }
        }

        /// <summary>
        /// Update the database object with corresponding data.
        /// </summary>
        /// <remarks>Not used directly in code but by <see cref="DataPortal"/> at runtime.</remarks>
        // ReSharper disable UnusedMember.Local
        private void Child_Update()
        // ReSharper restore UnusedMember.Local
        {
            using (var ctx = UnitOfWorkContextManager<UnitOfWork>.Get(false))
            {
                var objectFactory = new CustomerObjectFactory(ctx.UnitOfWork, this);
                objectFactory.Get(ArtCusId);
                objectFactory.UpdatePreparation();
                FieldManager.UpdateChildren(objectFactory.Entity);
                objectFactory.Update();
                objectFactory.Fetch();
                ctx.Complete();
            }
        }

        /// <summary>
        /// Update the database object with corresponding data.
        /// </summary>
        /// <remarks>Not used directly in code but by <see cref="DataPortal"/> at runtime.</remarks>
        // ReSharper disable UnusedMember.Local
        private void Child_DeleteSelf()
        // ReSharper restore UnusedMember.Local
        {
            using (var ctx = UnitOfWorkContextManager<UnitOfWork>.Get(false))
            {
                var objectFactory = new CustomerObjectFactory(ctx.UnitOfWork, this);
                objectFactory.Delete(ArtCusId);

                ctx.Complete();
            }
        }

        #endregion

        public override void MarkAsDuplicate()
        {
            ArtCusId = 0;
        }
    }
}

