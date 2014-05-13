using System.Collections.Generic;
using Manor.Plugin;
using Manor.Plugin.Application;
using PhuLiNet.Plugin.Manager;
using PhuLiNet.Plugin.Menu;

namespace PhuLiNet.Plugin
{
    public interface IHostApplicationInternals : IPluginManager
    {
        /// <summary>
        /// Source of menu definitions
        /// </summary>
       // EMenuSource MenuSource { get; }

        /// <summary>
        /// Returns application information
        /// </summary>
        /// <returns></returns>
       // IApplicationInfo GetApplicationInfo();

        /// <summary>
        /// Get Main application menu
        /// </summary>
        /// <returns></returns>
        List<IMenuItem> GetMainMenu();

        /// <summary>
        /// Get toolbar menu
        /// </summary>
        /// <returns></returns>
     //   List<IMenuItem> GetToolbarMenu();

        /// <summary>
        /// Get the first menu item with autostart flag == true
        /// </summary>
     //   IMenuItem GetAutoStartMenuItem();

        /// <summary>
        /// PluginId to autostart (from command line arguments)
        /// </summary>
     //   string AutoStartPluginId { get; set; }

        /// <summary>
        /// Language code
        /// </summary>
      //  string LanguageCode { get; set; }

        /// <summary>
        /// Get plugin validator
        /// </summary>
        /// <returns></returns>
    //    IPluginValidator GetPluginValidator();

        /// <summary>
        /// Start the plugin mechanism
        /// </summary>
        void Run();

         //<summary>
         //Reinit all menus and user rights when changing the user context
         //</summary>
        void ReRun();
    }
}