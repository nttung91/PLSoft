namespace PhuLiNet.Business.Common.Authorization.State
{
    /// <summary>
    /// Business object authorization via current object state
    /// New, Remove and Edit depend on object state (Not user rights)
    /// </summary>
    public interface IStateAuthorization
    {
        bool AllowNew();
        bool AllowRemove();
        bool AllowEdit();
    }
}