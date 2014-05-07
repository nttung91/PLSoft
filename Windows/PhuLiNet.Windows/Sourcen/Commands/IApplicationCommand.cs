namespace Windows.Core.Commands
{
    public interface IApplicationCommand
    {
        /// <summary>
        /// Log command on execute
        /// </summary>
        bool Log { get; set; }

        /// <summary>
        /// Audit command on execute
        /// </summary>
        bool Audit { get; set; }

        /// <summary>
        /// Executes command
        /// </summary>
        void Execute();
    }
}