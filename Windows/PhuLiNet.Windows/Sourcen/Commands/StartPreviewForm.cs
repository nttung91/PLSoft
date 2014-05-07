using System.Windows.Forms;
using Windows.Core.Helpers;
using Windows.Core.BaseForms;
using Windows.Core.Helpers;
using Windows.Core.WindowsManager;

namespace Windows.Core.Commands
{
    public class StartPreviewForm<T> : BaseWindowCommand where T : FrmPreviewBase, new()
    {
        private readonly string _loadingMsg;
        private readonly object _formIdValueToSearchFor;
        private readonly object _formDataIdValueToSearchFor;

        public StartPreviewForm(string loadingMsg) : this(loadingMsg, null, null)
        {
        }

        public StartPreviewForm(string loadingMsg, object formIdValueToSearchFor, object formDataIdValueToSearchFor)
        {
            _loadingMsg = loadingMsg;
            _formIdValueToSearchFor = formIdValueToSearchFor;
            _formDataIdValueToSearchFor = formDataIdValueToSearchFor;
        }

        #region IApplicationCommand Members

        /// <summary>
        /// override to configure the form for loading specific data.
        /// </summary>
        protected virtual void PrepareLoadData(T form, bool isNewForm)
        {
        }

        public override void Execute()
        {
            var options = new WindowPrepareOptions
            {
                StatusText = _loadingMsg,
                ExistingFormReloadBusinessData = false,
                NewFormLoadBusinessData = false,
                UseExistingFormIfPresent = true,
                NewFormState = FormWindowState.Maximized,
                ShowWaitForm = false,
                FormIdValueToSearchFor = _formIdValueToSearchFor,
                FormDataIdValueToSearchFor = _formDataIdValueToSearchFor
            };

            bool newForm;
            var form = WindowManager.PrepareShowWindow<T>(options, out newForm);

            using (new StatusBusy(_loadingMsg, true))
            {
                PrepareLoadData(form, newForm);

                if (newForm)
                {
                    form.LoadBusiness();
                }
                else
                {
                    form.ReloadBusiness();
                }
            }
            form.Show();
        }

        #endregion
    }
}