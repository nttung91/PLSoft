namespace DbModel.Core
{
    public abstract class EntityWithCompositeIdsVersionable : EntityWithCompositeIds, IVersionableEntity
    {
        public virtual int Version { get; set; }
    }
}