using System;
using System.Drawing;

namespace Manor.Plugin.Contracts
{
    /// <summary>
    /// Summary information about a plugin, exists only to display plugin information in user interface
    /// </summary>
    public interface IPluginSummary
    {
        /// <summary>
        /// Key of the plugin, should always be in english. 
        /// Should not be confused with the human friendly name in <see cref="IPluginInfo"/>.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Type of plugin
        /// </summary>
        string FullNameOfType { get; }

        /// <summary>
        /// Description of what the plugin does. Shown to the end user.
        /// </summary>
        /// <remarks>
        /// The description may contain links to other pages and images.
        /// Just make sure that your controller can handle them.
        /// Links should be opened in new windows and not leave the market place.
        /// </remarks>
        string Description { get; }

        /// <summary>
        /// Shortcut of the plugin, user can enter this shortcut for plugin start.
        /// </summary>
        string Shortcut { get; }

        /// <summary>
        /// Version
        /// </summary>
        Version Version { get; }

        /// <summary>
        /// Image
        /// </summary>
        Image Image { get; }

        /// <summary>
        /// PermissionId
        /// </summary>
        string PermissionId { get; }

        /// <summary>
        /// Has plugin all valid data
        /// </summary>
        bool IsValid { get; }

        /// <summary>
        /// Is plugin visible
        /// </summary>
        bool IsVisible { get; }

        /// <summary>
        /// Shortcuts of previous program e.g. Form-Ids of previous oracle form modules
        /// </summary>
        string PreviousShortcutsAsString { get; }

        /// <summary>
        /// Responsible team / person
        /// </summary>
        string Responsible { get; }

        /// <summary>
        /// Program type
        /// </summary>
        string ProgramType { get; }

        DateTime? ValidFrom { get; set; }
        DateTime? ValidTo { get; set; }

        string ToJsonString();
    }
}