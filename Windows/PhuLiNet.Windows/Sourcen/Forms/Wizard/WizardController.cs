using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid;
using PhuLiNet.Business.Common.Authorization.Specific;
using PhuLiNet.Business.Common.Authorization.State;
using Technical.Utilities.Exceptions;
using Windows.Core.Helpers;

namespace Windows.Core.Forms.Wizard
{
    /// <summary>
    /// The container form (_form) should contain the following controls:
    /// 1. A panel in which the plugin controls go
    /// 2. Button "bar" containing "Back", "Next", "Help", and "Cancel" buttons
    /// The container form must be provided the instances of these controls.
    /// </summary>
    public class WizardController
    {
        protected ContainerInfo _info;
        protected PluginManager _manager;
        private Dictionary<EAuthorizationType, List<Control>> _controlAuthorization;

        public Dictionary<EAuthorizationType, List<Control>> ControlAuthorization
        {
            get { return _controlAuthorization; }
            set { _controlAuthorization = value; }
        }

        protected Form _form;

        protected bool _saveOnFinish = false;
        protected bool _backButtonAlwaysVisible = false;
        protected bool _cancelButtonAlwaysVisible = false;

        /// <summary>
        /// Constructor.  The ContainerInfo is required.
        /// </summary>
        /// <param name="info"></param>
        public WizardController(ContainerInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException("A ContainerInfo instance must be provided.");
            }

            _info = info;
            _manager = new PluginManager();
        }

        /// <summary>
        /// Adds a plugin to the list of wizard plugins from a specific assembly.
        /// </summary>
        /// <param name="assemblyPath">The full assembly path.</param>
        /// <param name="typeName">The qualified [namespace].[class] to instantiate as the wizard plugin.</param>
        public void AddAssembly(string assemblyPath, string typeName)
        {
            _manager.AddAssembly(assemblyPath, typeName);
        }

        /// <summary>
        /// Adds a plugin to the list of wizard plugins.
        /// </summary>
        /// <param name="pluginInstance">Plugin instance.</param>
        public void AddPlugin(IPlugin pluginInstance)
        {
            _manager.AddPlugin(pluginInstance);
        }

        /// <summary>
        /// This call is required before starting the wizard.  It loads assemblies
        /// and hooks state events.
        /// </summary>
        public void Initialize()
        {
            _manager.LoadPlugins();
            _manager.Initialize();
            _manager.HookUpdateStateEvent(OnUpdateState);
        }

        /// <summary>
        /// Start the wizard with the supplied parent container form.
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public void Start(Form form)
        {
            _form = form;
            SetState();
            WireUp(_info.BackButton, OnBack);
            WireUp(_info.NextButton, OnNext);
            WireUp(_info.CancelButton, OnCancel);
            WireUp(_info.FinishButton, OnFinish);
            WireUp(_info.HelpButton, OnHelp);
            LoadUI();
            form.Show();
        }

        /// <summary>
        /// Start the wizard with the supplied parent container form.
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public DialogResult StartDialog(Form form)
        {
            _form = form;
            SetState();
            WireUp(_info.BackButton, OnBack);
            WireUp(_info.NextButton, OnNext);
            WireUp(_info.CancelButton, OnCancel);
            WireUp(_info.FinishButton, OnFinish);
            WireUp(_info.HelpButton, OnHelp);
            LoadUI();
            DialogResult res = form.ShowDialog();
            form.Dispose();

            return res;
        }

        /// <summary>
        /// Set the state of the buttons.
        /// </summary>
        protected void SetState()
        {
            switch (_manager.State)
            {
                case WizardState.Uninitialized:
                    throw new PhuLiException("The plugin manager has not been initialized with any plugins.");

                case WizardState.Start:
                    SetButtonState(_info.BackButton, false, true);
                    SetButtonState(_info.NextButton, true, true);
                    SetButtonState(_info.FinishButton, false, true);
                    SetButtonState(_info.CancelButton, true, true);
                    break;

                case WizardState.Middle:
                    SetButtonState(_info.BackButton, true, true);
                    SetButtonState(_info.NextButton, true, true);
                    SetButtonState(_info.FinishButton, false, true);
                    SetButtonState(_info.CancelButton, true, true);
                    break;

                case WizardState.End:
                    if (_backButtonAlwaysVisible)
                        SetButtonState(_info.BackButton, true, true);
                    else
                        SetButtonState(_info.BackButton, true, true);
                    SetButtonState(_info.NextButton, false, true);
                    SetButtonState(_info.FinishButton, _manager.IsValid, _saveOnFinish);
                    if (_cancelButtonAlwaysVisible)
                        SetButtonState(_info.CancelButton, true, true);
                    else
                        SetButtonState(_info.CancelButton, !_manager.IsValid, !_manager.IsValid);
                    break;
            }
        }

        /// <summary>
        /// Set data model to all underlying plugins
        /// </summary>
        public void SetDataModel(IDataModel dataModel)
        {
            dataModel.Init();
            _manager.DataModel = dataModel;
        }

        /// <summary>
        /// Sets a button state.  The button may be null, in which case the state is ignored.
        /// </summary>
        /// <param name="btn">The button that requires a state change.</param>
        /// <param name="isEnabled">True if the button is enabled.</param>
        /// <param name="isVisible">True if the button is visible.</param>
        protected void SetButtonState(SimpleButton btn, bool isEnabled, bool isVisible)
        {
            if (btn != null)
            {
                btn.Enabled = isEnabled;
                btn.Visible = isVisible;
            }
        }

        /// <summary>
        /// Wire up an event handler for the specified button Click event.
        /// </summary>
        /// <param name="btn">The button.</param>
        /// <param name="eventHandler">The event handler to call when the button is clicked.</param>
        protected void WireUp(SimpleButton btn, EventHandler eventHandler)
        {
            if (btn != null)
            {
                btn.Click += eventHandler;
            }
        }

        private void enableDisableControls(Control.ControlCollection ctrls, bool enableDisable)
        {
            foreach (Control ctrl in ctrls)
            {
                EnableDisableControlWithTagCheck(enableDisable, ctrl);
            }
        }

        private void enableDisableControls(List<Control> ctrls, bool enableDisable)
        {
            foreach (Control ctrl in ctrls)
            {
                EnableDisableControlWithTagCheck(enableDisable, ctrl);
            }
        }

        private void EnableDisableControlWithTagCheck(bool enableDisable, Control ctrl)
        {
            if (ctrl.Tag != null && ctrl.Tag.ToString().Equals("AlwaysEnabled"))
            {
                EnableDisableControl(ctrl, true);
            }
            else
            {
                EnableDisableControl(ctrl, enableDisable);
            }

            if (ctrl.Controls != null)
            {
                enableDisableControls(ctrl.Controls, enableDisable);
            }
        }

        private static void EnableDisableControl(Control ctrl, bool enable)
        {
            if (!(ctrl is GroupBox) && !(ctrl is GroupControl) && !(ctrl is Panel))
            {
                if (ctrl is BaseEdit)
                {
                    BaseEditHelper.GetBaseEditHelper(false).SetReadonly(ctrl, !enable);
                }
                else if (ctrl is VGridControl)
                {
                    var vGrid = ctrl as VGridControl;
                    VGridControlHelper.SetReadOnly(vGrid, enable);
                }
                else
                {
                    ctrl.Enabled = enable;
                }
            }
        }

        /// <summary>
        /// Loads the wizard plugin controls into the container area.
        /// This is done by setting the control parent to the container area.
        /// </summary>
        protected void LoadUI()
        {
            _info.PluginArea.Controls.Clear();
            List<Control> controls = _manager.GetControls();
            _manager.IsLoaded = false;
            foreach (Control ctrl in controls)
            {
                ctrl.Parent = _info.PluginArea;

                if (_manager.DataModel is IObjectStateAuthorization)
                {
                    var iBaseAuthorization = (IObjectStateAuthorization) _manager.DataModel;
                    if (iBaseAuthorization.Authorization.AllowEdit() == false)
                    {
                        enableDisableControls(_info.PluginArea.Controls, false);
                    }
                }

                if (_manager.DataModel is ISpecificBusinessObjectAuthorizations)
                {
                    ApplySpecificAuthorization();
                }
            }
            _manager.IsLoaded = true;
            _manager.PluginLoaded();
            string text = _manager.Text;
            if (!String.IsNullOrEmpty(text))
            {
                _form.Text = text;
            }
        }

        public void EnableSpecificAuthorization(IStateAuthorization authorization, EAuthorizationType type)
        {
            if (_controlAuthorization != null && authorization.AllowEdit() == true)
            {
                enableDisableControls(_controlAuthorization[type], true);
            }
        }

        private void ApplySpecificAuthorization()
        {
            var specificBusinessObjectAuthorizations = _manager.DataModel as ISpecificBusinessObjectAuthorizations;
            foreach (
                KeyValuePair<EAuthorizationType, IStateAuthorization> specificauthorization in
                    specificBusinessObjectAuthorizations.Authorizations)
            {
                IStateAuthorization authorization =
                    specificBusinessObjectAuthorizations.Authorizations[specificauthorization.Key];
                EnableSpecificAuthorization(authorization, specificauthorization.Key);
            }
        }

        /// <summary>
        /// Handler for the back event.  The Back button is disabled
        /// when at the beginning of the wizard and is hidden when finished.
        /// </summary>
        protected void OnBack(object sender, EventArgs e)
        {
            _manager.Previous();
            SetState();
            LoadUI();
        }

        /// <summary>
        /// Handler for the next event.  The Next button is hidden
        /// when at the end of the wizard sequence.
        /// </summary>
        protected void OnNext(object sender, EventArgs e)
        {
            _manager.Next();
            SetState();
            LoadUI();
        }

        /// <summary>
        /// Calls the last plugin's OnNext method and then closes
        /// the wizard form.
        /// </summary>
        protected void OnFinish(object sender, EventArgs e)
        {
            _manager.Final(_saveOnFinish);
            _form.DialogResult = DialogResult.OK;
            _form.Close();
        }

        /// <summary>
        /// Closes the wizard form.
        /// </summary>
        protected void OnCancel(object sender, EventArgs e)
        {
            _form.DialogResult = DialogResult.Cancel;
            _manager.DataModel.Cancel();
            _form.Close();
        }

        /// <summary>
        /// Add your own help handler here.
        /// </summary>
        protected void OnHelp(object sender, EventArgs e)
        {
            _manager.OnHelp();
        }

        /// <summary>
        /// Callback to allow the plugin to notify the wizard to update
        /// the button states.
        /// </summary>
        protected void OnUpdateState(object sender, EventArgs e)
        {
            SetState();
        }

        public bool BackButtonAlwaysVisible
        {
            get { return _backButtonAlwaysVisible; }
            set { _backButtonAlwaysVisible = value; }
        }

        public bool CancelButtonAlwaysVisible
        {
            get { return _cancelButtonAlwaysVisible; }
            set { _cancelButtonAlwaysVisible = value; }
        }

        public bool SaveOnFinish
        {
            get { return _saveOnFinish; }
            set { _saveOnFinish = value; }
        }
    }
}