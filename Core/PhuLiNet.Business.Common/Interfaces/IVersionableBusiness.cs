namespace PhuLiNet.Business.Common.Interfaces
{
    /// <summary>
    /// A versionable business object with version counter for optimistic locking (first wins)
    /// </summary>
    public interface IVersionableBusiness
    {
        int Version { get; set; }
    }
}