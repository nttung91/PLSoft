using PhuLiNet.Business.Common.Interfaces;

namespace PhuLiNet.Business.Common.Processing
{
    /// <summary>
    /// Basic interface for all business processes
    /// </summary>
    public interface IBusinessProcess : ITransactionalBusiness
    {
        /// <summary>
        /// Executes the business process
        /// </summary>
        void Process();

        /// <summary>
        /// Is the business process composable?
        /// (Ist der Prozess mit anderen Prozessen kombinierbar?)
        /// </summary>
        bool IsComposable { get; }

        /// <summary>
        /// Where there exception during processing?
        /// </summary>
        bool HasException { get; }

        /// <summary>
        /// Logger for the business process
        /// </summary>
        IBusinessProcessLogger Logger { get; set; }
    }
}