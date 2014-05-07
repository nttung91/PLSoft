using System;
using Csla;
using Csla.Rules.CommonRules;
using PhuLiNet.Business.Common.Localization;
using PhuLiNet.Business.Common.Rules.CommonRules;

namespace PhuLiNet.Business.Common.Languages.DescriptionBase
{
    [Serializable]
    public class ShortAndLongDescriptionEditBase<T> : LongDescriptionEditBase<T>
        where T : ShortAndLongDescriptionEditBase<T>
    {
        #region Business Methods

        // ReSharper disable StaticFieldInGenericType
        // you'll really get one field per combination of type arguments
        public static readonly PropertyInfo<string> ShortDescriptionProperty =
            RegisterProperty<string>(c => c.ShortDescription, DescriptionEdit.ShortDescription,
                RelationshipTypes.PrivateField);

        // ReSharper restore StaticFieldInGenericType

        private string _shortDescription = DescriptionProperty.DefaultValue;

        public string ShortDescription
        {
            get { return GetProperty(ShortDescriptionProperty, _shortDescription); }
            set { SetProperty(ShortDescriptionProperty, ref _shortDescription, value); }
        }

        public override int? MaxLengthShortDescription
        {
            get { return 20; }
        }

        #endregion

        protected ShortAndLongDescriptionEditBase(Type descriptionEntityTpye, Type descriptionEntityParentType)
            : base(descriptionEntityTpye, descriptionEntityParentType)
        {
        }

        #region Business Rules

        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();

            if (MaxLengthShortDescription.HasValue)
                BusinessRules.AddRule(new MaxLength(ShortDescriptionProperty, MaxLengthShortDescription.Value));

            AddPropertyDependencyRules();
        }

        protected virtual void AddPropertyDependencyRules()
        {
            BusinessRules.AddRule(new PropertyXCanNotBeEmptyIfPropertyYHasValue(DescriptionProperty,
                ShortDescriptionProperty));
            BusinessRules.AddRule(new PropertyXCanNotBeEmptyIfPropertyYHasValue(ShortDescriptionProperty,
                DescriptionProperty));
            BusinessRules.AddRule(new Dependency(DescriptionProperty, ShortDescriptionProperty));
        }

        #endregion

        protected override IDescriptionEditObjectFactory CreateObjectFactoryInstance(
            Type genericDescriptionEditObjectFactoryType, Type descriptionEntityType)
        {
            return base.CreateObjectFactoryInstance(typeof (ShortAndLongDescriptionEditObjectFactory<,>),
                DescriptionEntityType);
        }
    }
}