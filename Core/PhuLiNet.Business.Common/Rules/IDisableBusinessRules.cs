namespace PhuLiNet.Business.Common.Rules
{
    /// <summary>
    /// Enable or disable of business rules
    /// </summary>
    public interface IDisableBusinessRules
    {
        /// <summary>
        /// Enable business rules
        /// </summary>
        void EnableBusinessRules();

        /// <summary>
        /// Disable business rules
        /// </summary>
        void DisableBusinessRules();
    }
}