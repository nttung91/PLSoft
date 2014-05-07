namespace DbModel.Core
{
    public abstract class EntityWithTypedIdVersionable<TId> : EntityWithTypedId<TId>, IVersionableEntity
    {
        public virtual int Version { get; set; }
    }
}