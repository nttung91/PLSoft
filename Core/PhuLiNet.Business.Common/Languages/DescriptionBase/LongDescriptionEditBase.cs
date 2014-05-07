using System;
using System.Linq;
using System.Reflection;
using Csla;
using Csla.Rules.CommonRules;
using DbModel.Core;
using PhuLiNet.Business.Common.CslaBase;
using PhuLiNet.Business.Common.Localization;

namespace PhuLiNet.Business.Common.Languages.DescriptionBase
{
    [Serializable]
    public class LongDescriptionEditBase<T> : PhuLiBusinessBaseVersionable<T>, IDescriptionBusinessObject
        where T : LongDescriptionEditBase<T>
    {
        #region Factory Methods

        internal static T New()
        {
            return DataPortal.CreateChild<T>();
        }

        protected LongDescriptionEditBase(Type descriptionEntityType, Type descriptionEntityParentType)
        {
            if (!typeof (IDescriptionEntity).IsAssignableFrom(descriptionEntityType))
            {
                // ReSharper disable LocalizableElement
                throw new ArgumentException("descriptionEntityType must implement IDescriptionEntity",
                    "descriptionEntityType");
                // ReSharper restore LocalizableElement
            }

            if (!descriptionEntityParentType.GetInterfaces().Any(x =>
                x.IsGenericType &&
                x.GetGenericTypeDefinition() == typeof (IDescriptionParentEntity<>)))
            {
                // ReSharper disable LocalizableElement
                throw new ArgumentException("descriptionEntityParentType must implement IDescriptionParentEntity<>",
                    "descriptionEntityParentType");
                // ReSharper restore LocalizableElement                
            }

            DescriptionEntityType = descriptionEntityType;
            DescriptionEntityParentType = descriptionEntityParentType;
        }

        protected Type DescriptionEntityType { get; set; }
        protected Type DescriptionEntityParentType { get; set; }

        public virtual int? MaxLengthDescription
        {
            get { return 40; }
        }

        public virtual int? MaxLengthShortDescription
        {
            get { return null; }
        }

        public virtual int? MaxLengthAdditionalDescription1
        {
            get { return null; }
        }

        public virtual int? MaxLengthAdditionalDescription2
        {
            get { return null; }
        }

        public virtual int? MaxLengthAdditionalDescription3
        {
            get { return null; }
        }

        #endregion

        #region Business Methods

        // ReSharper disable StaticFieldInGenericType
        public static readonly PropertyInfo<Language> LanguageProperty =
            RegisterProperty<Language>(c => c.Language, DescriptionEdit.Language, RelationshipTypes.PrivateField);

        public static readonly PropertyInfo<string> DescriptionProperty =
            RegisterProperty<string>(c => c.Description, DescriptionEdit.Description, RelationshipTypes.PrivateField);

        // ReSharper restore StaticFieldInGenericType

        private Language _language;

        public Language Language
        {
            get { return GetProperty(LanguageProperty, _language); }
            set { SetProperty(LanguageProperty, ref _language, value); }
        }

        private string _description = DescriptionProperty.DefaultValue;

        public virtual string Description
        {
            get { return GetProperty(DescriptionProperty, _description); }
            set { SetProperty(DescriptionProperty, ref _description, value); }
        }

        public int DisplaySequence { get; set; }

        protected override object GetIdValue()
        {
            return Language;
        }

        #endregion

        #region Business Rules

        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();

            if (MaxLengthDescription.HasValue)
                BusinessRules.AddRule(new MaxLength(DescriptionProperty, MaxLengthDescription.Value));
        }

        #endregion

        #region Data Access

        [RunLocal]
        protected override void Child_Create()
        {
            var objectFactory = CreateObjectFactoryInstance(typeof (LongDescriptionEditObjectFactory<,>),
                DescriptionEntityType);
            objectFactory.CreateNew();
        }

        // ReSharper disable UnusedMember.Local
        private void Child_Fetch(IDescriptionEntity currentDataAccessObject)
            // ReSharper restore UnusedMember.Local
        {
            var objectFactory = CreateObjectFactoryInstance(typeof (LongDescriptionEditObjectFactory<,>),
                DescriptionEntityType);
            objectFactory.EntityAsObject = currentDataAccessObject;
            objectFactory.Fetch();
        }

        protected virtual IDescriptionEditObjectFactory CreateObjectFactoryInstance(
            Type genericDescriptionEditObjectFactoryType, Type descriptionEntityType)
        {
            Type objectFactoryType = genericDescriptionEditObjectFactoryType.MakeGenericType(typeof (T),
                descriptionEntityType);

            return (IDescriptionEditObjectFactory) Activator.CreateInstance(objectFactoryType, new object[] {this});
        }

        // ReSharper disable UnusedMember.Local
        private void AddDescriptionGeneric<TP, TE>(TP parent, TE child)
            // ReSharper restore UnusedMember.Local
            where TP : IDescriptionParentEntity<TE>
            where TE : IDescriptionEntity
        {
            parent.AddDescription(child);
        }

        protected void AddDescription(object parent, IDescriptionEntity child)
        {
            typeof (LongDescriptionEditBase<>).MakeGenericType(typeof (T))
                .GetMethod("AddDescriptionGeneric", BindingFlags.Instance | BindingFlags.NonPublic)
                .MakeGenericMethod(new[] {DescriptionEntityParentType, DescriptionEntityType})
                .Invoke(this, new[] {parent, child});
        }

        // ReSharper disable UnusedMember.Local
        private void RemoveDescriptionGeneric<TP, TE>(TP parent, TE child)
            // ReSharper restore UnusedMember.Local
            where TP : IDescriptionParentEntity<TE>
            where TE : IDescriptionEntity
        {
            parent.RemoveDescription(child);
        }

        protected void RemoveDescription(object parent, IDescriptionEntity child)
        {
            typeof (LongDescriptionEditBase<>).MakeGenericType(typeof (T))
                .GetMethod("RemoveDescriptionGeneric", BindingFlags.Instance | BindingFlags.NonPublic)
                .MakeGenericMethod(new[] {DescriptionEntityParentType, DescriptionEntityType})
                .Invoke(this, new[] {parent, child});
        }

        // ReSharper disable UnusedMember.Local
        private TE FindDescriptionByLangIdGeneric<TP, TE>(TP parent, Language language)
            // ReSharper restore UnusedMember.Local
            where TP : IDescriptionParentEntity<TE>
            where TE : IDescriptionEntity
        {
            return parent.FindDescriptionByLangId(language.LangId);
        }

        protected IDescriptionEntity FindDescriptionByLangId(object parent, Language language)
        {
            return typeof (LongDescriptionEditBase<>).MakeGenericType(typeof (T))
                .GetMethod("FindDescriptionByLangIdGeneric", BindingFlags.Instance | BindingFlags.NonPublic)
                .MakeGenericMethod(new[] {DescriptionEntityParentType, DescriptionEntityType})
                .Invoke(this, new[] {parent, language}) as IDescriptionEntity;
        }

        // ReSharper disable UnusedMember.Local
        private void Child_Insert(object parent)
            // ReSharper restore UnusedMember.Local
        {
            if (ContainsData())
            {
                var objectFactory = CreateObjectFactoryInstance(typeof (LongDescriptionEditObjectFactory<,>),
                    DescriptionEntityType);
                objectFactory.InsertPreparation();
                AddDescription(parent, objectFactory.EntityAsObject as IDescriptionEntity);
                FieldManager.UpdateChildren(objectFactory.EntityAsObject);
            }
        }

        // ReSharper disable UnusedMember.Local
        private void Child_Update(object parent)
            // ReSharper restore UnusedMember.Local
        {
            if (ContainsData())
            {
                var objectFactory = CreateObjectFactoryInstance(typeof (LongDescriptionEditObjectFactory<,>),
                    DescriptionEntityType);
                objectFactory.EntityAsObject = FindDescriptionByLangId(parent, Language);
                objectFactory.UpdatePreparation();
                FieldManager.UpdateChildren(objectFactory.EntityAsObject);
            }
        }

        // ReSharper disable UnusedMember.Local
        private void Child_DeleteSelf(object parent)
            // ReSharper restore UnusedMember.Local
        {
            var desc = FindDescriptionByLangId(parent, Language);
            if (desc != null)
            {
                RemoveDescription(parent, desc);
            }
        }

        #endregion

        /// <summary>
        /// Answers if this business object contains data, i.e. if langauge and desription properties are filled.
        /// </summary>
        public bool ContainsData()
        {
            return (Language != null && !string.IsNullOrWhiteSpace(Description));
        }

        public override void Validate()
        {
            BusinessRules.CheckRules();
        }
    }
}