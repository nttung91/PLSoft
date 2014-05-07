namespace PhuLiNet.Business.Common.Interfaces
{
    /// <summary>
    /// A transactional business object
    /// </summary>
    public interface ITransactionalBusiness
    {
        /// <summary>
        /// Should the business class use it's own transaction
        /// </summary>
        bool UseTransaction { get; set; }
    }
}