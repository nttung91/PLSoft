using System.Security.Principal;

namespace Technical.Settings.Contracts
{
    /// <summary>
    /// Application config and instance
    /// </summary>
    public interface IConfigProvider
    {
        string Name { get; }
        string InstanceName { get; }
        IIdentity Identity { get; set; }

        /// <summary>
        /// Load section and all settings.
        /// </summary>
        /// <param name="sectionId"></param>
        /// <returns></returns>
        IConfigSection LoadSection(string sectionId);

        /// <summary>
        /// Load section and all settings.
        /// Creates section if it's not defined.
        /// </summary>
        /// <param name="sectionId"></param>
        /// <param name="createIfMissing"> </param>
        /// <returns></returns>
        IConfigSection LoadSection(string sectionId, bool createIfMissing);

        /// <summary>
        /// Loads section and only given setting. 
        /// Use this (for better performance) if there are many settings in one section and you only need a special one.
        /// </summary>
        /// <param name="sectionId"></param>
        /// <param name="settingId"></param>
        /// <returns></returns>
        IConfigSection LoadSingleSetting(string sectionId, string settingId);

        /// <summary>
        /// Persists all changed settings
        /// </summary>
        /// <param name="section"></param>
        void SaveSection(IConfigSection section);
    }
}