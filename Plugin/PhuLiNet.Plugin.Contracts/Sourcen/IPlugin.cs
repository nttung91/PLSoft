using System;
using System.Drawing;

namespace PhuLiNet.Plugin.Contracts
{
    /// <summary>
    /// All plugins must derive this interface.
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Primary Key in database
        /// </summary>
        int ArtId { get; set; }

        /// <summary>
        /// Key of the plugin, should always be in english. 
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Description of what the plugin does. Shown to the end user.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Shortcut of the plugin, user can enter this shortcut for plugin start.
        /// </summary>
        string Shortcut { get; set; }

        /// <summary>
        /// Shortcuts of previous program e.g. Form-Ids of previous oracle form modules
        /// </summary>
        string[] PreviousShortcuts { get; set; }

        /// <summary>
        /// Version
        /// </summary>
        Version Version { get; }

        /// <summary>
        /// Image of plugin
        /// </summary>
        Image Image { get; set; }

        /// <summary>
        /// Has plugin all valid data
        /// </summary>
        bool IsValid { get; }

        /// <summary>
        /// Is plugin visible
        /// </summary>
        bool IsVisible { get; set; }

        /// <summary>
        /// Is this an external plugin 
        /// , external = an external oracle-forms or windows application start
        /// , internal = an internal .net plugin
        /// </summary>
        bool IsExternal { get; }

        /// <summary>
        /// Configures the plugin
        /// </summary>
        void Configure();

        /// <summary>
        /// Start the plugin
        /// </summary>
        void Start(IStartParameter parameter);

        /// <summary>
        /// Is there a valid id assigned
        /// </summary>
        bool HasValidId { get; }

        /// <summary>
        /// Is there a valid shortcut assigned
        /// </summary>
        bool HasValidShortcut { get; }

        /// <summary>
        /// Startable from this date on
        /// </summary>
        DateTime? ValidFrom { get; set; }

        /// <summary>
        /// Startable until this date
        /// </summary>
        DateTime? ValidTo { get; set; }

        /// <summary>
        /// Is plugin active today (compares today with valid-from and valid-to)
        /// </summary>
        bool IsActiveByDate { get; }

        /// <summary>
        /// Returns type of plugin/program (oracle-form, plugin, ...)
        /// </summary>
        /// <returns></returns>
        string GetProgramType();
    }
}