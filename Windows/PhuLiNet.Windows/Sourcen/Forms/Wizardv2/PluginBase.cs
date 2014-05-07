using System;
using System.Windows.Forms;

namespace Windows.Core.Forms.Wizardv2
{
    /// <summary>
    /// This abstract class defines common fields, properties, and certain
    /// default behavior that each plugin can leverage.
    /// </summary>
    public abstract class PluginBase : IPlugin
    {
        /// <summary>
        /// The event that the plugin can use to notify the wizard of a state change.
        /// </summary>
        public event EventHandler UpdateStateEvent;

        protected FrmWizardPageBase _frmPage;
        protected IDataModel _dataModel;
        protected ContainerInfo _info;

        /// <summary>
        /// True if the plugin's data is validated and the user can proceed with
        /// the next wizard page.  True is the default.
        /// </summary>
        public virtual bool IsValid
        {
            get { return _dataModel.IsValid; }
        }

        /// <summary>
        /// True if the plugin is going to provide help.  The default is false.
        /// </summary>
        public virtual bool HasHelp
        {
            get { return false; }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public PluginBase()
        {
        }

        public virtual void InitPage()
        {
        }

        public virtual void ShowPage()
        {
            _frmPage.WindowState = FormWindowState.Maximized;
            _frmPage.Show();
        }

        public virtual void HidePage()
        {
            _frmPage.Hide();
        }

        public virtual void UnloadPage()
        {
            _frmPage.Hide();
            _frmPage.UnbindDataModel();
            _frmPage.Dispose();
            _frmPage = null;
            _info = null;
            _dataModel = null;
        }

        /// <summary>
        /// The plugin can override this method if it needs to do
        /// something before the wizard proceeds to the next page.
        /// </summary>
        public virtual void OnNext()
        {
            // Do nothing.
        }

        /// <summary>
        /// The plugin can override this method if it wants to display 
        /// some help.
        /// </summary>
        public virtual void OnHelp()
        {
            // Do nothing.
        }

        /// <summary>
        /// Returns the the form that the plugin assigned
        /// in the class.
        /// </summary>
        /// <returns></returns>
        public FrmWizardPageBase GetPage()
        {
            return _frmPage;
        }

        public ContainerInfo GetPageButtonContainer()
        {
            if (_info == null)
                _info = new ContainerInfo(_frmPage.WizardBackButton, _frmPage.WizardNextButton,
                    _frmPage.WizardFinishButton, _frmPage.WizardCancelButton, null);

            return _info;
        }

        /// <summary>
        /// The plugin can call this method to raise the UpdateStateEvent,
        /// which informs the wizard that the button states need to be updated.
        /// </summary>
        protected void RaiseUpdateState()
        {
            if (UpdateStateEvent != null)
            {
                UpdateStateEvent(this, EventArgs.Empty);
            }
        }

        #region IDataModelBind Members

        public void BindDataModel(IDataModel dataModel)
        {
            _dataModel = dataModel;
            _frmPage.BindDataModel(_dataModel);
        }

        public void UnbindDataModel()
        {
            _frmPage.UnbindDataModel();
            _dataModel = null;
        }

        #endregion
    }
}