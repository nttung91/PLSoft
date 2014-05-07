using DbModel.Core;

namespace PhuLiNet.Business.Common.Languages.DescriptionBase
{
    /// <summary>
    /// Object Factory for Short and Long Description Edit
    /// </summary>
    /// <typeparam name="TB">Type of Description Business Object</typeparam>
    /// <typeparam name="TE">Type of Description Entity</typeparam>
    /// <typeparam name="TP">Type of parent of Description Entity</typeparam>
    public class ShortAndLongDescriptionEditObjectFactory<TB, TE> : LongDescriptionEditObjectFactory<TB, TE>
        where TB : ShortAndLongDescriptionEditBase<TB>
        where TE : BaseObject, IVersionableEntity, IShortAndLongDescriptionEntity, new()
    {
        public ShortAndLongDescriptionEditObjectFactory(TB businessObject)
            : base(businessObject)
        {
        }

        /// <summary>
        /// Set additional business object properties.
        /// </summary>
        /// <example><c>BusinessObject.AdditionalDescription = DatabaseEntity.AdditionalDescription;</c></example>
        protected override void FetchAdditionalProperties()
        {
            BusinessObject.ShortDescription = DatabaseEntity.ShortDescr;
        }

        /// <summary>
        /// Set additional database entity properties
        /// </summary>
        /// <example><c>DatabaseEntity.AdditionalDescription = BusinessObject.AdditionalDescription;</c></example>
        protected override void UpdateAdditionalProperties()
        {
            DatabaseEntity.ShortDescr = BusinessObject.ShortDescription;
        }
    }
}