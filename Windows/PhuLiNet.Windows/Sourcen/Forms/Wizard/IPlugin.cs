using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Windows.Core.Forms.Wizard
{
    public interface IPlugin : IDataModelBind
    {
        /// <summary>
        /// The plugin should return true if the current wizard page data is valid.
        /// </summary>
        bool IsValid { get; }

        /// <summary>
        /// The plugin should return true if there is help available.
        /// </summary>
        bool HasHelp { get; }

        /// <summary>
        /// The plugin can implement this method if it needs to do special processing
        /// before the wizard proceeds to the next page.
        /// </summary>
        void OnNext();

        /// <summary>
        /// The plugin can implement this method to display help.
        /// </summary>
        void OnHelp();

        /// <summary>
        /// The plugin should return the controls that the wizard will place in the
        /// container area.
        /// </summary>
        /// <returns></returns>
        List<Control> GetControls();

        /// <summary>
        /// The text property of the plugin that is loaded
        /// </summary>
        /// <returns></returns>
        string Text { get; }

        bool IsLoaded { get; set; }

        void PluginLoaded();

        /// <summary>
        /// The plugin needs to implement this event container so that the wizard can
        /// be notified of state changes, which the plugin will call itself.
        /// </summary>
        event EventHandler UpdateStateEvent;
    }
}