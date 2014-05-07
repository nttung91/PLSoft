namespace PhuLiNet.Business.Common.Authorization.State
{
    /// <summary>
    /// Implementation of object state authorization on business object
    /// </summary>
    public interface IObjectStateAuthorization
    {
        IStateAuthorization Authorization { get; }
    }
}