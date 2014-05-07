using System;
using System.Windows.Forms;

namespace Windows.Core.WindowsManager
{
    /// <summary>
    /// Contains all parameters which can be used in WindowManager Show/PrepareShow methods.
    /// </summary>
    public class WindowPrepareOptions
    {
        public String StatusText { get; set; }
        public bool ShowWaitForm { get; set; }
        public bool UseExistingFormIfPresent { get; set; }
        public FormWindowState NewFormState { get; set; }
        public bool NewFormLoadBusinessData { get; set; }
        public bool ExistingFormReloadBusinessData { get; set; }
        public object FormIdValueToSearchFor { get; set; }
        public object FormDataIdValueToSearchFor { get; set; }

        /// <summary>
        /// Paramters to pass to InitalizeForm, so that it's possible to pass custom parameters to the form during construction.
        /// </summary>
        public object InitalizationParameters { get; set; }
    }
}