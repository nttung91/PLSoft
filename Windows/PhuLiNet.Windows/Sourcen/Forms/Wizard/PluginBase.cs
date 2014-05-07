using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Windows.Core.Forms.Wizard
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

        /// <summary>
        /// The control list is preserved so that the control's state is maintained
        /// as the user navigates backwards and forwards through the wizard.
        /// </summary>
        protected List<Control> _ctrlList;

        protected Form _form;
        protected IDataModel _dataModel;

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
            _ctrlList = new List<Control>();
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
        /// Returns the controls from the form that the plugin assigned
        /// in the class.  The plugin can override this method to return
        /// a custom control list.
        /// </summary>
        /// <returns></returns>
        public virtual List<Control> GetControls()
        {
            // If this is the first time we're calling this method,
            // load the controls from the plugin form.
            if (_ctrlList.Count == 0)
            {
                // Once loaded, we reuse the same control instances
                // which as the advantage of preserving state if the
                // user goes back to a previous page (and forward again.)
                GetFormControls();
            }

            // Otherwise, return the control list that we acquired from
            // the form. 
            return _ctrlList;
        }

        /// <summary>
        /// Iterates through the form's top level controls to construct
        /// a list of form controls.
        /// </summary>
        protected virtual void GetFormControls()
        {
            foreach (Control c in _form.Controls)
            {
                _ctrlList.Add(c);
            }
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
            ((IDataModelBind) _form).BindDataModel(_dataModel);
        }

        public void UnbindDataModel()
        {
            ((IDataModelBind) _form).UnbindDataModel();
            _dataModel = null;
        }

        public string Text
        {
            get { return _form.Text; }
        }

        public bool IsLoaded
        {
            get
            {
                var form = _form as FrmWizardPluginBase;
                bool loaded = false;
                if (form != null)
                    loaded = form.IsLoaded;

                return loaded;
            }
            set
            {
                var form = _form as FrmWizardPluginBase;
                if (form != null)
                    form.IsLoaded = value;
            }
        }

        public void PluginLoaded()
        {
            var form = _form as FrmWizardPluginBase;
            if (form != null)
                form.PluginLoaded();
        }

        #endregion
    }
}