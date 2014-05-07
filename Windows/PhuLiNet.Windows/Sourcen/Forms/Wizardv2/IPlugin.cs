using System;

namespace Windows.Core.Forms.Wizardv2
{
    public interface IPlugin : IDataModelBind
    {
        void InitPage();
        void ShowPage();
        void HidePage();
        void UnloadPage();

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
        /// The plugin should return the page that the wizard will show.
        /// </summary>
        /// <returns></returns>
        FrmWizardPageBase GetPage();

        ContainerInfo GetPageButtonContainer();

        /// <summary>
        /// The plugin needs to implement this event container so that the wizard can
        /// be notified of state changes, which the plugin will call itself.
        /// </summary>
        event EventHandler UpdateStateEvent;
    }
}