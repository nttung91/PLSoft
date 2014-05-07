namespace Windows.Core.SmartPart
{
    /// <summary>
    /// Basic interface for a Smart Part
    /// </summary>
    public interface ISmartPart
    {
        string Key { get; set; }
        bool Visible { get; set; }
        bool ReadOnly { get; set; }
        string DisplayName { get; set; }
        string Description { get; set; }
        object Control { get; }

        /// <summary>
        /// Initalization done
        /// </summary>
        bool InitDone { get; }

        /// <summary>
        /// Initalization of smart part
        /// </summary>
        void Init();

        /// <summary>
        /// Deinitalization of the smart part, the smart part can init again
        /// </summary>
        void Deinit();

        /// <summary>
        /// Destroys the smart part and its data, the smart part cannot be showed again
        /// </summary>
        void Destroy();
    }
}