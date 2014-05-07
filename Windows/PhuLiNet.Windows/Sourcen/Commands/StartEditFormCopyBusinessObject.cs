using System;
using System.Diagnostics;
using System.Windows.Forms;
using Windows.Core.BaseForms;
using Windows.Core.Localization;
using Windows.Core.Commands;
using Windows.Core.WindowsManager;
using PhuLiNet.Business.Common.CopyManager;
using PhuLiNet.Business.Common.CslaBase;

namespace Windows.Core.Commands
{
    public class StartEditFormCopyBusinessObject<T> : StartEditFormCopyBusinessObject
        where T : FrmEditBusinessBase, new()
    {
        public StartEditFormCopyBusinessObject(IPhuLiBusinessBase businessObjectToCopy)
            : base(typeof (T), businessObjectToCopy)
        {
        }

        public StartEditFormCopyBusinessObject(ICopyManager<IPhuLiBusinessBase> copyManager)
            : base(typeof (T), copyManager)
        {
        }
    }

    public class StartEditFormCopyBusinessObject : BaseWindowCommand
    {
        private readonly Type _editFormType;
        private readonly ICopyManager<IPhuLiBusinessBase> _copyManager;

        public StartEditFormCopyBusinessObject(Type editFormType, IPhuLiBusinessBase businessObjectToCopy)
            : this(editFormType, new StandardCopyManager(businessObjectToCopy))
        {
        }

        public StartEditFormCopyBusinessObject(Type editFormType, ICopyManager<IPhuLiBusinessBase> copyManager)
        {
            _editFormType = editFormType;
            _copyManager = copyManager;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            var businessObjectToLoad = _copyManager.Copy();

            var options = new WindowPrepareOptions
            {
                StatusText = CommandRes.CopyLoading,
                ExistingFormReloadBusinessData = false,
                NewFormLoadBusinessData = true,
                UseExistingFormIfPresent = false, // copy always should create a new one
                NewFormState = FormWindowState.Maximized,
                ShowWaitForm = true,
                InitalizationParameters = businessObjectToLoad
            };

            var methodInfo =
                WindowManager.GetType()
                    .GetMethod("ShowWindow", new[] {typeof (WindowPrepareOptions)})
                    .MakeGenericMethod(_editFormType);
            Debug.Assert(methodInfo != null);

            var form = methodInfo.Invoke(WindowManager, new object[] {options}) as Form;
                // Invocation here only possible via Reflection...
            if (form != null && _copyManager is StandardCopyManager)
            {
                form.Text = string.Format("{0} {1}", CopyManagerBase.CopyPrefixText, form.Text);
            }
        }

        #endregion
    }
}