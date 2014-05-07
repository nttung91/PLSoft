namespace PhuLiNet.Business.Common.Interfaces
{
    /// <summary>
    /// Duplication functionality for a business object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDuplicateBusiness<out T>
    {
        T Duplicate();
    }
}