using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Windows.Core.BaseForms;
using Windows.Core.Binding;
using Windows.Core.Binding.SaveManager;
using Windows.Core.Controls;
using Windows.Core.DxExtensions;
using Windows.Core.Helpers.Controls;
using Windows.Core.Localization;
using MessageBox = Windows.Core.Forms.MessageBox;

namespace Windows.Core.BaseForms
{
    /// <summary>
    /// Base form for edit screens, save possible
    /// </summary>
    public partial class FrmEditableBase : FrmReadOnlyBase, ISavableForm, IReloadableForm, IEditableForm
    {
        protected bool _saveEnabled = true;
        protected bool _saveOnClosing = true;
        protected SaveManagerBase _objectSaveManager;
        protected ControlEnablerDisabler _controlEnablerDisabler;

        public FrmEditableBase()
        {
            InitializeComponent();
            _controlEnablerDisabler = new ControlEnablerDisabler();
        }

        protected override void InitBindingManager()
        {
            _objectBindingManager = ObjectBindingManagerEditable.GetBindingManager();
            _objectSaveManager = StandardSaveManager.GetSaveManager(_objectBindingManager);
        }

        #region ISavableForm Members

        public virtual bool Save()
        {
            throw new NotImplementedException();
        }

        [Browsable(false)]
        public bool SaveEnabled
        {
            get { return _saveEnabled; }
            set
            {
                _saveEnabled = value;
                _objectSaveManager.Enabled = _saveEnabled;
                _saveOnClosing = _saveEnabled;
            }
        }

        #endregion

        #region IReloadableForm Members

        public virtual void ReloadBusiness()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEditableForm Members

        protected virtual BindingSource BindingSource
        {
            get { throw new NotImplementedException(); }
        }

        [Browsable(false)]
        public virtual bool IsDirty
        {
            get { throw new NotImplementedException(); }
        }

        [Browsable(false)]
        public virtual bool IsValid
        {
            get { throw new NotImplementedException(); }
        }

        [Browsable(false)]
        public virtual bool IsReadOnly
        {
            get { return !_saveEnabled; }
        }

        #endregion

        protected virtual bool AskAndSave()
        {
            const bool saved = true;
            return AskAndSave(saved);
        }

        protected bool AskAndSave(bool saved)
        {
            if (_saveEnabled)
            {
                var result = DialogResult.None;
                if (IsDirty)
                {
                    result = MessageBox.ShowYesNo(BaseFormMessages.SaveDataQuestion, BaseFormMessages.Save);
                }

                if (result == DialogResult.Yes)
                {
                    saved = Save();
                }
                else if (result == DialogResult.Cancel)
                {
                    saved = false;
                }
            }
            else
            {
                saved = true;
            }

            return saved;
        }

        private bool DoSave()
        {
            bool doSave = true;
            if (IsDirty)
            {
                if (!Focused)
                {
                    Focus();
                }

                DialogResult dr = MessageBox.ShowYesNo(BaseFormMessages.SaveDataQuestion, BaseFormMessages.Save);

                switch (dr)
                {
                    case DialogResult.Yes:
                        doSave = Save();
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        doSave = false;
                        break;
                    default:
                        doSave = false;
                        break;
                }
            }
            return doSave;
        }

        private void FrmCslaEditable_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_saveOnClosing)
                e.Cancel = !(DoSave());
        }

        protected void CommitChanges(BindingSource rootBindingSource)
        {
            // Commit the changes made on the currently active controls to the BindingSource
            _objectBindingManager.EndEditFocusedControl();

            // Commit the changes made on this form to the BindingSource
            _objectBindingManager.EndEditBinding(rootBindingSource);
        }

        public bool EndEditAndTryToSave()
        {
            CommitChanges(BindingSource);

            var saved = !IsDirty || AskAndSave(false);
            return saved;
        }

        protected void PerformForUserControls<T>(Action<T> action) where T : class, IBusinessControl
        {
            PerformForUserControls(action, false);
        }

        protected void PerformForUserControls<T>(Action<T> action, bool reverse) where T : class, IBusinessControl
        {
            var allControls = this.GetAllControls<T>();
            if (reverse)
            {
                allControls = allControls.Reverse();
            }
            foreach (var control in allControls)
            {
                action(control);
            }
        }
    }
}