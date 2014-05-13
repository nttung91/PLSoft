using System.Collections.Generic;

namespace PhuLiNet.Plugin.Contracts
{
    /// <summary>
    /// Host application
    /// </summary>
    public interface IHostApplication
    {
        /// <summary>
        /// Control button pressed
        /// </summary>
        bool CtrlPressed { get; }

        /// <summary>
        /// Command line parameters on startup
        /// </summary>
        Dictionary<string, string> CustomCommandLineParameters { get; set; }

        /// <summary>
        /// Refresh toolbar and work-menu icons
        /// </summary>
        void RefreshToolbar();

        /// <summary>
        /// Expand or collapse main navigation area
        /// </summary>
        bool NavigationMenuExpanded { get; set; }
    }
}