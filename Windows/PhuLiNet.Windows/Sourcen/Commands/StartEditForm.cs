using System;
using System.Windows.Forms;
using Windows.Core.BaseForms;
using PhuLiNet.Business.Common.CslaBase;
using Windows.Core.BaseForms;
using Windows.Core.Instructions;
using Windows.Core.WindowsManager;

namespace Windows.Core.Commands
{
    public class StartEditForm<T, TK> : BaseWindowCommand where T : FrmEditBusinessBase, new()
    {
        private readonly TK _businessObjectId;
        private readonly IInstruction _instruction;
        private readonly string _loadingMsg;

        public event EventHandler<EditFormStartedEventArgs> EditFormStarted;

        private void OnEditFormStarted(IPhuLiBusinessBase businessObject)
        {
            if (EditFormStarted != null)
            {
                EditFormStarted(this, new EditFormStartedEventArgs(businessObject));
            }
        }

        public StartEditForm(IInstruction instruction, TK businessObjectId, string loadingMsg)
        {
            _instruction = instruction;
            _businessObjectId = businessObjectId;
            _loadingMsg = loadingMsg;
        }

        public StartEditForm(IInstruction instruction, string loadingMsg)
            : this(instruction, default(TK), loadingMsg)
        {
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            var initParams = new FormInstructionInitParameter
            {
                EntityKey = _businessObjectId,
                Instruction = _instruction
            };
            var options = new WindowPrepareOptions
            {
                StatusText = _loadingMsg,
                ExistingFormReloadBusinessData = false,
                NewFormLoadBusinessData = true,
                FormDataIdValueToSearchFor = _businessObjectId,
                UseExistingFormIfPresent = (_instruction is EditInstruction),
                // In case of an edit instruction, look for a open window with the same entity
                NewFormState = FormWindowState.Maximized,
                ShowWaitForm = true,
                InitalizationParameters = initParams
            };
            bool newWindow;
            var editForm = WindowManager.PrepareShowWindow<T>(options, out newWindow);

            if (newWindow)
            {
                OnEditFormStarted(editForm.BusinessObject);
                editForm.Show();
            }
        }

        #endregion
    }
}