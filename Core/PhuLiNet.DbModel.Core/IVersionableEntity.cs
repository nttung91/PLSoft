namespace DbModel.Core
{
    /// <summary>
    /// A versionable entity with version counter for optimistic locking (first wins)
    /// </summary>
    public interface IVersionableEntity
    {
        int Version { get; }
    }
}