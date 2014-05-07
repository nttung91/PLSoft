namespace Windows.Core.Controls
{
    /// <summary>
    /// Specifies that the control is a business control,
    /// which needs init and deinit
    /// </summary>
    public interface IBusinessControl
    {
        /// <summary>
        /// Initialization of databinding and sub-controls
        /// </summary>
        void InitBusiness();

        /// <summary>
        /// Clear databinding before setting new business data
        /// </summary>
        void ClearBusiness();

        /// <summary>
        /// Restore databinding to bind new data after ClearBusiness()
        /// </summary>
        void RefreshBusiness();
    }
}