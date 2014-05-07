using System.Windows.Forms;
using Windows.Core.BaseForms;
using Windows.Core.WindowsManager;

namespace Windows.Core.Commands
{
    public class StartEditListForm<T> : BaseWindowCommand where T : FrmEditBusinessListBase, new()
    {
        private readonly string _loadingMsg;
        private readonly object _initParams;
        private readonly object _formDataId;

        public StartEditListForm(string loadingMsg)
            : this(loadingMsg, null, null)
        {
        }

        public StartEditListForm(string loadingMsg, object initParams)
            : this(loadingMsg, initParams, null)
        {
        }

        public StartEditListForm(string loadingMsg, object initParams, object formDataId)
        {
            _loadingMsg = loadingMsg;
            _initParams = initParams;
            _formDataId = formDataId;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            var options = new WindowPrepareOptions
            {
                ExistingFormReloadBusinessData = true,
                NewFormLoadBusinessData = true,
                NewFormState = FormWindowState.Maximized,
                ShowWaitForm = true,
                StatusText = _loadingMsg,
                UseExistingFormIfPresent = true,
                FormDataIdValueToSearchFor = _formDataId,
                InitalizationParameters = _initParams
            };

            WindowManager.ShowWindow<T>(options);
        }

        #endregion
    }
}