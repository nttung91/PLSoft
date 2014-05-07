using DbModel.Core;
using PhuLiNet.Business.Common.CslaBase.ObjectFactory;

namespace PhuLiNet.Business.Common.Languages.DescriptionBase
{
    /// <summary>
    /// Object Factory for Short and Long Description Edit
    /// </summary>
    /// <typeparam name="TB">Type of Description Business Object</typeparam>
    /// <typeparam name="TE">Type of Description Entity</typeparam>
    public class LongDescriptionEditObjectFactory<TB, TE> : ChildObjectFactoryBase<TB, TE>,
        IDescriptionEditObjectFactory
        where TB : LongDescriptionEditBase<TB>
        where TE : BaseObject, IVersionableEntity, IDescriptionEntity, new()
    {
        public LongDescriptionEditObjectFactory(TB businessObject)
            : base(businessObject)
        {
            BusinessObject = businessObject;
        }

        public override void CreateNew()
        {
        }

        public override void Fetch()
        {
            var languageList = new LanguageList();

            using (BypassPropertyChecks(BusinessObject))
            {
                var descriptionEntity = DatabaseEntity as IDescriptionEntity;

                BusinessObject.Version = DatabaseEntity.Version;
                BusinessObject.Language = languageList.Search(descriptionEntity.LangId);
                BusinessObject.Description = descriptionEntity.Descr;
                FetchAdditionalProperties();
            }
        }

        /// <summary>
        /// Set additional business object properties.
        /// </summary>
        /// <example><c>BusinessObject.AdditionalDescription = DatabaseEntity.AdditionalDescription;</c></example>
        protected virtual void FetchAdditionalProperties()
        {
        }

        public override void InsertPreparation()
        {
            var description = new TE
            {
                LangId = BusinessObject.Language.LangId,
            };
            DatabaseEntity = description;
            UpdateProperties();
        }

        public override void UpdatePreparation()
        {
            UpdateProperties();
        }

        private void UpdateProperties()
        {
            DatabaseEntity.Descr = BusinessObject.Description;
            UpdateAdditionalProperties();
        }

        /// <summary>
        /// Set additional database entity properties
        /// </summary>
        /// <example><c>DatabaseEntity.AdditionalDescription = BusinessObject.AdditionalDescription;</c></example>
        protected virtual void UpdateAdditionalProperties()
        {
        }
    }
}