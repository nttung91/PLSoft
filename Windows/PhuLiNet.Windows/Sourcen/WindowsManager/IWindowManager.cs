using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Windows.Core.BaseForms;
using Windows.Core.BaseForms;

namespace Windows.Core.WindowsManager
{
    /// <summary>
    /// Manages all application windows
    /// </summary>
    public interface IWindowManager
    {
        /// <summary>
        /// Show a new window in main application form (MDI-Child)
        /// </summary>       
        T ShowWindow<T>(bool showWaitForm) where T : FrmBase, new();

        /// <summary>
        /// Show a new window in main application form (MDI-Child)
        /// </summary>       
        T ShowWindow<T>(String statusText, bool showWaitForm) where T : FrmBase, new();

        /// <summary>
        /// Show a new window in main application form (MDI-Child)
        /// </summary>       
        T ShowWindow<T>(String statusText, bool showWaitForm, bool checkExists) where T : FrmBase, new();

        /// <summary>
        /// Show a new window in main application form (MDI-Child)
        /// </summary>
        T ShowWindow<T>(String statusText, bool showWaitForm, bool checkExists, FormWindowState state)
            where T : FrmBase, new();

        /// <summary>
        /// Show a new window in main application form (MDI-Child)
        /// </summary>     
        T ShowWindow<T>(String statusText, bool showWaitForm, bool checkExists, FormWindowState state,
            bool loadBusinessData) where T : FrmBase, new();

        /// <summary>
        /// Show a new window in main application form (MDI-Child)
        /// </summary>       
        T ShowWindow<T>(String statusText, bool showWaitForm, bool checkExists, FormWindowState state,
            bool loadBusinessData, object formIdValue) where T : FrmBase, new();

        /// <summary>
        /// Show a new window in main application form (MDI-Child)
        /// </summary>
        T ShowWindow<T>(WindowPrepareOptions options) where T : FrmBase, new();

        /// <summary>
        /// Prepare to show a new window in main application form (MDI-Child)
        /// </summary>
        T PrepareShowWindow<T>() where T : FrmBase, new();

        /// <summary>
        /// Prepare to show a new window in main application form (MDI-Child)
        /// </summary>
        T PrepareShowWindow<T>(string statusText, bool showWaitForm) where T : FrmBase, new();

        /// <summary>
        /// Prepare to show a new window in main application form (MDI-Child)
        /// </summary>
        T PrepareShowWindow<T>(string statusText, bool showWaitForm, bool checkExists) where T : FrmBase, new();

        /// <summary>
        /// Prepare to show a new window in main application form (MDI-Child)
        /// </summary>
        T PrepareShowWindow<T>(string statusText, bool showWaitForm, bool checkExists, FormWindowState state)
            where T : FrmBase, new();

        /// <summary>
        /// Prepare to show a new window in main application form (MDI-Child)
        /// </summary>
        T PrepareShowWindow<T>(string statusText, bool showWaitForm, bool checkExists, FormWindowState state,
            object formIdValue) where T : FrmBase, new();

        /// <summary>
        /// Prepare to show a new window in main application form (MDI-Child)
        /// </summary>
        /// <remarks>Doesn't call Show of the window, so that it's possible to adapt the prepared form before it is shown.</remarks>
        T PrepareShowWindow<T>(WindowPrepareOptions options) where T : FrmBase, new();

        /// <summary>
        /// Prepare to show a new window in main application form (MDI-Child)
        /// </summary>
        /// <remarks>Doesn't call Show of the window, so that it's possible to adapt the prepared form before it is shown.
        /// Returns true for createdWindow, if no new window created.</remarks>
        T PrepareShowWindow<T>(WindowPrepareOptions options, out bool createdWindow) where T : FrmBase, new();

        /// <summary>
        /// Show new dialog.
        /// ATTENTION: Call Dialog.Dispose after dialog exit
        /// </summary>     
        T ShowDialog<T>(bool showWaitForm) where T : FrmBase, new();

        /// <summary>
        /// Show new dialog.
        /// ATTENTION: Call Dialog.Dispose after dialog exit
        /// </summary>     
        T ShowDialog<T>(String statusText, bool showWaitForm) where T : FrmBase, new();

        /// <summary>
        /// Show new dialog.
        /// ATTENTION: Call Dialog.Dispose after dialog exit
        /// </summary>      
        T ShowDialog<T>(String statusText, bool showWaitForm, FormWindowState state) where T : FrmBase, new();

        /// <summary>
        /// Show new dialog.
        /// ATTENTION: Call Dialog.Dispose after dialog exit
        /// </summary>
        T ShowDialog<T>(WindowPrepareOptions options) where T : FrmBase, new();

        /// <summary>
        /// Prepare to show a new dialog.
        /// ATTENTION: Call Dialog.Dispose after dialog exit
        /// </summary>
        T PrepareShowDialog<T>(bool showWaitForm) where T : FrmBase, new();

        /// <summary>
        /// Prepare to show a new dialog.
        /// ATTENTION: Call Dialog.Dispose after dialog exit
        /// </summary>
        T PrepareShowDialog<T>(String statusText, bool showWaitForm) where T : FrmBase, new();

        /// <summary>
        /// Prepare to show a new dialog.
        /// ATTENTION: Call Dialog.Dispose after dialog exit
        /// </summary>
        T PrepareShowDialog<T>(String statusText, bool showWaitForm, FormWindowState state) where T : FrmBase, new();

        /// <summary>
        /// Prepare to show a new dialog.
        /// ATTENTION: Call Dialog.Dispose after dialog exit
        /// </summary>
        T PrepareShowDialog<T>(String statusText, bool showWaitForm, FormWindowState state, bool loadBusinessData)
            where T : FrmBase, new();

        /// <summary>
        /// Prepare to show a new dialog.
        /// ATTENTION: Call Dialog.Dispose after dialog exit
        /// </summary>
        /// <remarks>Doesn't call ShowDialog, so that it's possible to adapt the prepared form before it is shown.</remarks>
        T PrepareShowDialog<T>(WindowPrepareOptions options) where T : FrmBase, new();


        /// <summary>
        /// Search for a window instance of type T
        /// </summary>
        T FindWindowInstance<T>() where T : FrmBase;

        /// <summary>
        /// Search for a window instance of type T
        /// </summary>
        T FindWindowInstance<T>(object formIdValue) where T : FrmBase;

        /// <summary>
        /// Search for a window instance of type T by dataId
        /// </summary>
        T FindWindowInstanceByData<T>(object dataIdValue) where T : FrmBase;

        /// <summary>
        /// Search for windows which are not saved to the database.
        /// </summary>
        /// <returns></returns>
        IList<FrmBase> FindDirtyWindows();

        /// <summary>
        /// Gets the active window (MDI-Child)
        /// </summary>
        /// <returns></returns>
        Form GetActiveWindow();

        /// <summary>
        /// Gets the main application window (MDI-Parent)
        /// </summary>
        /// <returns></returns>
        Form GetMainWindow();

        /// <summary>
        /// Close all windows (MDI-Childs)
        /// </summary>
        void CloseAllWindows();

        /// <summary>
        /// Close all forms of the application (call only at application exit)
        /// </summary>
        void CloseAllForms();
    }
}