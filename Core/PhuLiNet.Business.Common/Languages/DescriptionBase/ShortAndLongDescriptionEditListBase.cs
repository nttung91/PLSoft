using System;

namespace PhuLiNet.Business.Common.Languages.DescriptionBase
{
    [Serializable]
    public class ShortAndLongDescriptionEditListBase<TList, TEntity> : LongDescriptionEditListBase<TList, TEntity>
        where TList : ShortAndLongDescriptionEditListBase<TList, TEntity>
        where TEntity : ShortAndLongDescriptionEditBase<TEntity>
    {
        protected override void MapDescription(TEntity existingDescr, TEntity desc)
        {
            base.MapDescription(existingDescr, desc);
            existingDescr.ShortDescription = desc.ShortDescription;
        }
    }
}