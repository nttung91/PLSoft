using System;
using System.Windows.Forms;
using Windows.Core.Helpers;
using DevExpress.XtraEditors;
using Technical.Utilities.Exceptions;
using Windows.Core.Helpers;

namespace Windows.Core.Forms.Wizardv2
{
    /// <summary>
    /// The container form (_form) should contain the following controls:
    /// 1. A panel in which the plugin controls go
    /// 2. Button "bar" containing "Back", "Next", "Help", and "Cancel" buttons
    /// The container form must be provided the instances of these controls.
    /// </summary>
    public class WizardController
    {
        protected PluginManager _manager;

        protected bool _saveOnFinish = false;
        protected bool _backButtonAlwaysVisible = false;
        protected bool _cancelButtonAlwaysVisible = false;

        /// <summary>
        /// Constructor.  The ContainerInfo is required.
        /// </summary>
        public WizardController()
        {
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
        /// <returns></returns>
        public void Start()
        {
            SetState();
            SetEvents();
            _manager.ShowPage();
        }

        private void SetEvents()
        {
            AttachEvent(_manager.GetPageContainer().BackButton, OnBack);
            AttachEvent(_manager.GetPageContainer().NextButton, OnNext);
            AttachEvent(_manager.GetPageContainer().CancelButton, OnCancel);
            AttachEvent(_manager.GetPageContainer().FinishButton, OnFinish);
            AttachEvent(_manager.GetPageContainer().HelpButton, OnHelp);
        }

        private void ClearEvents()
        {
            DetachEvent(_manager.GetPageContainer().BackButton, OnBack);
            DetachEvent(_manager.GetPageContainer().NextButton, OnNext);
            DetachEvent(_manager.GetPageContainer().CancelButton, OnCancel);
            DetachEvent(_manager.GetPageContainer().FinishButton, OnFinish);
            DetachEvent(_manager.GetPageContainer().HelpButton, OnHelp);
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
                    SetButtonState(_manager.GetPageContainer().BackButton, false, true);
                    SetButtonState(_manager.GetPageContainer().NextButton, true, true);
                    SetButtonState(_manager.GetPageContainer().FinishButton, false, true);
                    SetButtonState(_manager.GetPageContainer().CancelButton, true, true);
                    break;

                case WizardState.Middle:
                    SetButtonState(_manager.GetPageContainer().BackButton, true, true);
                    SetButtonState(_manager.GetPageContainer().NextButton, true, true);
                    SetButtonState(_manager.GetPageContainer().FinishButton, false, true);
                    SetButtonState(_manager.GetPageContainer().CancelButton, true, true);
                    break;

                case WizardState.End:
                    if (_backButtonAlwaysVisible)
                        SetButtonState(_manager.GetPageContainer().BackButton, true, true);
                    else
                        SetButtonState(_manager.GetPageContainer().BackButton, !_manager.IsValid, !_manager.IsValid);
                    SetButtonState(_manager.GetPageContainer().NextButton, false, true);
                    SetButtonState(_manager.GetPageContainer().FinishButton, _manager.IsValid, _saveOnFinish);
                    if (_cancelButtonAlwaysVisible)
                        SetButtonState(_manager.GetPageContainer().CancelButton, true, true);
                    else
                        SetButtonState(_manager.GetPageContainer().CancelButton, !_manager.IsValid, !_manager.IsValid);
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

        public void SetMdiParent(Form mdiParent)
        {
            _manager.SetMdiParent(mdiParent);
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
        protected void AttachEvent(SimpleButton btn, EventHandler eventHandler)
        {
            if (btn != null)
            {
                btn.Click += eventHandler;
            }
        }

        protected void DetachEvent(SimpleButton btn, EventHandler eventHandler)
        {
            if (btn != null)
            {
                btn.Click -= eventHandler;
            }
        }

        /// <summary>
        /// Handler for the back event.  The Back button is disabled
        /// when at the beginning of the wizard and is hidden when finished.
        /// </summary>
        protected void OnBack(object sender, EventArgs e)
        {
            using (var busy = new StatusBusy("Vorherige Wizard Seite wird geladen", true))
            {
                ClearEvents();
                _manager.HidePage();
                _manager.Previous();
                SetState();
                SetEvents();
                _manager.ShowPage();
            }
        }

        /// <summary>
        /// Handler for the next event.  The Next button is hidden
        /// when at the end of the wizard sequence.
        /// </summary>
        protected void OnNext(object sender, EventArgs e)
        {
            using (var busy = new StatusBusy("Nächste Wizard Seite wird geladen", true))
            {
                ClearEvents();
                _manager.HidePage();
                _manager.Next();
                SetState();
                SetEvents();
                _manager.ShowPage();
            }
        }

        /// <summary>
        /// Calls the last plugin's OnNext method and then closes
        /// the wizard form.
        /// </summary>
        protected void OnFinish(object sender, EventArgs e)
        {
            ClearEvents();
            _manager.Final(_saveOnFinish);
            _manager.HidePage();
            _manager.UnloadPages();
        }

        /// <summary>
        /// Closes the wizard form.
        /// </summary>
        protected void OnCancel(object sender, EventArgs e)
        {
            ClearEvents();
            _manager.DataModel.Cancel();
            _manager.HidePage();
            _manager.UnloadPages();
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