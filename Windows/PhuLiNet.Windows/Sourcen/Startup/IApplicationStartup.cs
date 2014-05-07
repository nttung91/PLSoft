namespace Windows.Core.Startup
{
    /// <summary>
    /// Windows application startup interface
    /// Used by plugin application
    /// </summary>
    public interface IApplicationStartup
    {
        /// <summary>
        /// First init step
        /// </summary>
        void PreInit();

        /// <summary>
        /// Main init step
        /// </summary>
        void Init();

        /// <summary>
        /// Before splash screen is shown
        /// </summary>
        void BeforeSplash();

        /// <summary>
        /// Shows splash screen
        /// </summary>
        void ShowSplash();

        /// <summary>
        /// After splash screen is shown
        /// </summary>
        void AfterSplash();

        /// <summary>
        /// Last step before Run
        /// </summary>
        void BeforeRun();

        /// <summary>
        /// Run application
        /// </summary>
        void Run();

        /// <summary>
        /// Shutdown application
        /// </summary>
        void Shutdown();
    }
}