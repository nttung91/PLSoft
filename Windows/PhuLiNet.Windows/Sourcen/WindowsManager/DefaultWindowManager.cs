using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Windows.Core.BaseForms;
using Windows.Core.Helpers;
using Windows.Core.BaseForms;
using Windows.Core.Helpers;
using Windows.Core.Localization;

namespace Windows.Core.WindowsManager
{
    internal class DefaultWindowManager : IWindowManager
    {
        private Form _mdiContainer;

        public DefaultWindowManager(Form mdiContainer)
        {
            _mdiContainer = mdiContainer;
        }

        #region IWindowManager Members

        public T ShowWindow<T>(bool showWaitForm) where T : FrmBase, new()
        {
            return ShowWindow<T>(WindowManagerRes.LoadingData, showWaitForm, true, FormWindowState.Maximized, true, null);
        }

        public T ShowWindow<T>(string statusText, bool showWaitForm) where T : FrmBase, new()
        {
            return ShowWindow<T>(statusText, showWaitForm, true, FormWindowState.Maximized, true, null);
        }

        public T ShowWindow<T>(string statusText, bool showWaitForm, bool checkExists) where T : FrmBase, new()
        {
            return ShowWindow<T>(statusText, showWaitForm, checkExists, FormWindowState.Maximized, true, null);
        }

        public T ShowWindow<T>(String statusText, bool showWaitForm, bool checkExists, FormWindowState state)
            where T : FrmBase, new()
        {
            return ShowWindow<T>(statusText, showWaitForm, checkExists, state, true, null);
        }

        public T ShowWindow<T>(String statusText, bool showWaitForm, bool checkExists, FormWindowState state,
            bool loadBusinessData) where T : FrmBase, new()
        {
            return ShowWindow<T>(statusText, showWaitForm, checkExists, state, loadBusinessData, null);
        }

        public T ShowWindow<T>(String statusText, bool showWaitForm, bool checkExists, FormWindowState state,
            bool loadBusinessData, object formIdValue) where T : FrmBase, new()
        {
            var options = new WindowPrepareOptions
            {
                StatusText = statusText,
                ShowWaitForm = showWaitForm,
                UseExistingFormIfPresent = checkExists,
                NewFormState = state,
                NewFormLoadBusinessData = loadBusinessData,
                FormIdValueToSearchFor = formIdValue
            };
            return ShowWindow<T>(options);
        }

        public T ShowWindow<T>(WindowPrepareOptions options) where T : FrmBase, new()
        {
            bool createdWindow;
            var newForm = PrepareShowWindow<T>(options, out createdWindow);

            if (createdWindow)
            {
                newForm.Show();
            }

            return newForm;
        }

        public T PrepareShowWindow<T>(WindowPrepareOptions options, out bool createdWindow) where T : FrmBase, new()
        {
            T newForm = null;

            using (new StatusBusy(options.StatusText, options.ShowWaitForm))
            {
                if (options.UseExistingFormIfPresent)
                {
                    if (options.FormDataIdValueToSearchFor != null)
                    {
                        newForm = FindWindowInstanceByData<T>(options.FormDataIdValueToSearchFor);
                    }
                    else
                    {
                        newForm = FindWindowInstance<T>(options.FormIdValueToSearchFor);
                    }
                }

                if (newForm == null)
                {
                    newForm = new T();
                    newForm.MdiParent = _mdiContainer;
                    newForm.WindowState = options.NewFormState;

                    if (newForm is IInitializableForm)
                    {
                        ((IInitializableForm) newForm).InitializeForm(options.InitalizationParameters);
                    }

                    if (newForm is ILoadableForm && options.NewFormLoadBusinessData)
                    {
                        ((ILoadableForm) newForm).LoadBusiness();
                    }

                    if (newForm is IFormPermissions)
                    {
                        ((IFormPermissions) newForm).InitPermissions();
                    }

                    createdWindow = true;
                }
                else
                {
                    createdWindow = false;
                    newForm.Focus();

                    if (newForm is IReloadableForm && options.ExistingFormReloadBusinessData)
                    {
                        ((IReloadableForm) newForm).ReloadBusiness();
                    }
                }
            }

            return newForm;
        }

        public T PrepareShowWindow<T>() where T : FrmBase, new()
        {
            return PrepareShowWindow<T>(null, false, true, FormWindowState.Maximized, null);
        }

        public T PrepareShowWindow<T>(string statusText, bool showWaitForm) where T : FrmBase, new()
        {
            return PrepareShowWindow<T>(statusText, showWaitForm, true, FormWindowState.Maximized, null);
        }

        public T PrepareShowWindow<T>(string statusText, bool showWaitForm, bool checkExists) where T : FrmBase, new()
        {
            return PrepareShowWindow<T>(statusText, showWaitForm, checkExists, FormWindowState.Maximized, null);
        }

        public T PrepareShowWindow<T>(string statusText, bool showWaitForm, bool checkExists, FormWindowState state)
            where T : FrmBase, new()
        {
            return PrepareShowWindow<T>(statusText, showWaitForm, checkExists, state, null);
        }

        public T PrepareShowWindow<T>(string statusText, bool showWaitForm, bool checkExists, FormWindowState state,
            object formIdValue) where T : FrmBase, new()
        {
            var options = new WindowPrepareOptions
            {
                StatusText = statusText,
                ShowWaitForm = showWaitForm,
                UseExistingFormIfPresent = checkExists,
                NewFormState = state,
                FormIdValueToSearchFor = formIdValue
            };

            return PrepareShowWindow<T>(options);
        }

        public T PrepareShowWindow<T>(WindowPrepareOptions options) where T : FrmBase, new()
        {
            bool createdWindow;
            return PrepareShowWindow<T>(options, out createdWindow);
        }

        public T ShowDialog<T>(bool showWaitForm) where T : FrmBase, new()
        {
            return PrepareShowDialog<T>(WindowManagerRes.LoadingDialog, showWaitForm, FormWindowState.Normal, true);
        }

        public T ShowDialog<T>(string statusText, bool showWaitForm) where T : FrmBase, new()
        {
            return ShowDialog<T>(statusText, showWaitForm, FormWindowState.Normal);
        }

        public T ShowDialog<T>(string statusText, bool showWaitForm, FormWindowState state) where T : FrmBase, new()
        {
            var options = new WindowPrepareOptions
            {
                StatusText = statusText,
                ShowWaitForm = showWaitForm,
                NewFormState = state,
                NewFormLoadBusinessData = true,
            };

            return ShowDialog<T>(options);
        }

        public T ShowDialog<T>(WindowPrepareOptions options) where T : FrmBase, new()
        {
            var newForm = PrepareShowDialog<T>(options);
            newForm.ShowDialog();

            return newForm;
        }

        public T PrepareShowDialog<T>(bool showWaitForm) where T : FrmBase, new()
        {
            var newForm = PrepareShowDialog<T>(WindowManagerRes.LoadingDialog, showWaitForm, FormWindowState.Normal,
                false);
            return newForm;
        }

        public T PrepareShowDialog<T>(string statusText, bool showWaitForm) where T : FrmBase, new()
        {
            var newForm = PrepareShowDialog<T>(statusText, showWaitForm, FormWindowState.Normal, false);
            return newForm;
        }

        public T PrepareShowDialog<T>(string statusText, bool showWaitForm, FormWindowState state)
            where T : FrmBase, new()
        {
            var newForm = PrepareShowDialog<T>(statusText, showWaitForm, state, false);
            return newForm;
        }

        public T PrepareShowDialog<T>(string statusText, bool showWaitForm, FormWindowState state, bool loadBusinessData)
            where T : FrmBase, new()
        {
            var options = new WindowPrepareOptions
            {
                StatusText = statusText,
                ShowWaitForm = showWaitForm,
                NewFormState = state,
                NewFormLoadBusinessData = loadBusinessData,
            };

            return PrepareShowDialog<T>(options);
        }

        public T PrepareShowDialog<T>(WindowPrepareOptions options) where T : FrmBase, new()
        {
            T newForm;

            using (new StatusBusy(options.StatusText, options.ShowWaitForm))
            {
                newForm = new T();
                newForm.WindowState = options.NewFormState;
                newForm.ControlBox = false;
                newForm.Owner = _mdiContainer;

                if (newForm is IInitializableForm)
                {
                    ((IInitializableForm) newForm).InitializeForm(options.InitalizationParameters);
                }

                if (newForm is ILoadableForm && options.NewFormLoadBusinessData)
                {
                    ((ILoadableForm) newForm).LoadBusiness();
                }
            }

            return newForm;
        }

        public T FindWindowInstance<T>() where T : FrmBase
        {
            return FindWindowInstance<T>(null);
        }

        public T FindWindowInstance<T>(object formIdValue) where T : FrmBase
        {
            T formFound = null;

            foreach (Form form in _mdiContainer.MdiChildren)
            {
                if (form is T)
                {
                    if (formIdValue != null)
                    {
                        var identify = form as IIdentifiableForm;
                        Debug.Assert(identify != null, "IIdentifiableForm missing");

                        if (identify != null && identify.GetIdValue() != null && formIdValue != null)
                        {
                            if (identify.GetIdValue().ToString() == formIdValue.ToString())
                            {
                                formFound = form as T;
                                break;
                            }
                        }
                    }
                    else
                    {
                        formFound = form as T;
                        break;
                    }
                }
            }

            return formFound;
        }

        public T FindWindowInstanceByData<T>(object dataIdValue) where T : FrmBase
        {
            T formFound = null;
            if (dataIdValue == null) return null;

            foreach (Form form in _mdiContainer.MdiChildren)
            {
                if (form is T)
                {
                    var identify = form as IIdentifiableForm;
                    Debug.Assert(identify != null, "IIdentifiableForm missing");

                    if (identify != null && identify.GetIdValue() != null && dataIdValue != null)
                    {
                        if (identify.GetIdValueData() != null &&
                            identify.GetIdValueData().ToString() == dataIdValue.ToString())
                        {
                            formFound = form as T;
                            break;
                        }
                    }
                }
            }

            return formFound;
        }

        public Form GetActiveWindow()
        {
            return _mdiContainer.ActiveMdiChild;
        }

        public Form GetMainWindow()
        {
            return _mdiContainer;
        }

        public IList<FrmBase> FindDirtyWindows()
        {
            IList<FrmBase> dirtyWindows = new List<FrmBase>();

            FrmBase baseForm;
            IEditableForm editForm;

            foreach (Form form in _mdiContainer.MdiChildren)
            {
                editForm = form as IEditableForm;
                if (editForm != null && editForm.IsDirty)
                {
                    baseForm = form as FrmBase;
                    if (baseForm != null)
                    {
                        dirtyWindows.Add(baseForm);
                    }
                }
            }

            return dirtyWindows;
        }

        public void CloseAllWindows()
        {
            foreach (Form form in _mdiContainer.MdiChildren)
            {
                form.Close();
            }
        }

        public void CloseAllForms()
        {
            for (int index = Application.OpenForms.Count - 1; index >= 0; index--)
            {
                if (index >= 0 && index < Application.OpenForms.Count)
                {
                    Form form = Application.OpenForms[index];
                    if (form != _mdiContainer)
                    {
                        form.Close();
                        form.Dispose();
                    }
                }
            }

            _mdiContainer.Close();
            _mdiContainer.Dispose();
            _mdiContainer = null;
        }

        #endregion
    }
}