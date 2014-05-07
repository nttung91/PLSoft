using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Technical.Utilities.Exceptions;

namespace Windows.Core.Forms.Wizardv2
{
    /// <summary>
    /// The four states of the wizard.
    /// </summary>
    public enum WizardState
    {
        Uninitialized,
        Start,
        Middle,
        End,
    }

    /// <summary>
    /// The plugin manager coordinates the index to the current 
    /// manager and isolates some of the details of managing the
    /// plugins.
    /// </summary>
    public class PluginManager
    {
        protected List<Plugin> _pluginList;
        protected int _position;
        protected WizardState _state;

        protected IDataModel _dataModel;

        /// <summary>
        /// Returns the current state of the wizard.
        /// </summary>
        public WizardState State
        {
            get { return _state; }
        }

        /// <summary>
        /// True if the plugin validates itself, indicating that the
        /// "Next" button can be enabled.
        /// </summary>
        public bool IsValid
        {
            get { return _pluginList[_position].Instance.IsValid; }
        }

        /// <summary>
        /// Constructor.  Initializes the plugin list and state.
        /// </summary>
        public PluginManager()
        {
            _pluginList = new List<Plugin>();
            _position = -1;
            _state = WizardState.Uninitialized;
        }

        /// <summary>
        /// Adds as assembly to the plugin list.
        /// </summary>
        /// <param name="assemblyPath">The full assembly path.</param>
        /// <param name="typeName">The qualifed [namespace].[class] name that is instantiated.</param>
        public void AddAssembly(string assemblyPath, string typeName)
        {
            var plugin = new Plugin(assemblyPath, typeName);
            _pluginList.Add(plugin);
        }

        /// <summary>
        /// Adds a plugin to the list of wizard plugins.
        /// </summary>
        /// <param name="pluginInstance">Plugin instance.</param>
        public void AddPlugin(IPlugin pluginInstance)
        {
            _pluginList.Add(new Plugin(pluginInstance));
        }

        /// <summary>
        /// Loads all plugin assemblies.
        /// </summary>
        public void LoadPlugins()
        {
            if (_pluginList.Count == 0)
            {
                throw new PhuLiException(
                    "At least one plugin assembly must be added to the plugin manager's collection.");
            }

            LoadPluginAssemblies();
        }

        /// <summary>
        /// Initialize the wizard state.
        /// </summary>
        public void Initialize()
        {
            _position = 0;
            _pluginList[_position].Instance.BindDataModel(_dataModel);
            SetState();
        }

        /// <summary>
        /// Returns to the previous wizard frame.
        /// </summary>
        public void Previous()
        {
            if (_position == 0)
            {
                throw new PhuLiException("The wizard position cannnot be decremented.");
            }
            _pluginList[_position].Instance.UnbindDataModel();
            --_position;
            _pluginList[_position].Instance.BindDataModel(_dataModel);
            SetState();
        }

        /// <summary>
        /// Calls the current plugin's OnNext method then increments the frame postion
        /// and updates the wizard state.
        /// </summary>
        public void Next()
        {
            if (_position == _pluginList.Count - 1)
            {
                throw new PhuLiException("The wizard position cannot be incremented.");
            }

            _pluginList[_position].Instance.UnbindDataModel();
            _pluginList[_position].Instance.OnNext();
            ++_position;
            _pluginList[_position].Instance.BindDataModel(_dataModel);
            SetState();
        }

        /// <summary>
        /// Calls the plugin's OnHelp method (if implemented).  The default behavior is to
        /// do nothing.
        /// </summary>
        public void OnHelp()
        {
            _pluginList[_position].Instance.OnHelp();
        }

        /// <summary>
        /// Calls the last plugin's OnNext method.
        /// </summary>
        public void Final(bool save)
        {
            if (save)
            {
                if (_dataModel.IsDirty && _dataModel.IsValid)
                {
                    _dataModel.Save();
                }
                else
                {
                    _dataModel.Cancel();
                }
            }
            if (_position != _pluginList.Count - 1)
            {
                throw new PhuLiException("Final can only be called on the last frame in the wizard plugin list.");
            }

            _pluginList[_position].Instance.UnbindDataModel();
            _pluginList[_position].Instance.OnNext();
        }

        /// <summary>
        /// Returns the controls specified by the plugin.
        /// </summary>
        public FrmWizardPageBase GetPage()
        {
            Plugin plugin = _pluginList[_position];
            FrmWizardPageBase page = plugin.GetPage();

            return page;
        }

        public void InitPage()
        {
            Plugin plugin = _pluginList[_position];
            plugin.Instance.InitPage();
        }

        public void ShowPage()
        {
            Plugin plugin = _pluginList[_position];
            plugin.Instance.ShowPage();
        }

        public virtual void HidePage()
        {
            Plugin plugin = _pluginList[_position];
            plugin.Instance.HidePage();
        }

        public void UnloadPages()
        {
            foreach (Plugin plugin in _pluginList)
            {
                plugin.Instance.UnloadPage();
            }
        }

        public ContainerInfo GetPageContainer()
        {
            return _pluginList[_position].Instance.GetPageButtonContainer();
        }

        /// <summary>
        /// Hooks the plugin's UpdateStateEvent, allowing the plugin to
        /// notify our wizard controller that the wizard state needs to
        /// be updated.
        /// </summary>
        /// <param name="eventHandler">The event handler sinking the notification.</param>
        public void HookUpdateStateEvent(EventHandler eventHandler)
        {
            foreach (Plugin plugin in _pluginList)
            {
                plugin.Instance.UpdateStateEvent += eventHandler;
            }
        }

        /// <summary>
        /// Loads each plugin.
        /// </summary>
        protected void LoadPluginAssemblies()
        {
            foreach (Plugin plugin in _pluginList)
            {
                plugin.LoadAndCreate();
            }
        }

        /// <summary>
        /// Sets the wizard state flag.
        /// </summary>
        protected void SetState()
        {
            if (_pluginList.Count - 1 == _position)
            {
                _state = WizardState.End;
            }
            else if (_position == 0)
            {
                _state = WizardState.Start;
            }
            else
            {
                _state = WizardState.Middle;
            }
        }

        public void SetMdiParent(Form mdiParent)
        {
            foreach (Plugin plugin in _pluginList)
            {
                plugin.Instance.GetPage().MdiParent = mdiParent;
            }
        }

        /// <summary>
        /// Gets or sets the current data model.
        /// </summary>
        public IDataModel DataModel
        {
            get { return _dataModel; }
            set { _dataModel = value; }
        }
    }
}