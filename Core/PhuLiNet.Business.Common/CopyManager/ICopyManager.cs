namespace PhuLiNet.Business.Common.CopyManager
{
    /// <summary>
    /// Basic interface for all business object copy manager
    /// </summary>
    public interface ICopyManager<T>
    {
        T Copy();
    }
}