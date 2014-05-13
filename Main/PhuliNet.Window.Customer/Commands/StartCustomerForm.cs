using System;
using System.Windows.Forms;
using Windows.Core.BaseForms;
using Windows.Core.Commands;
using Windows.Core.Instructions;
using Windows.Core.WindowsManager;
using PhuliNet.Window.Customer.Customer;

namespace PhuliNet.Window.Customer.Commands
{
    public class StartCustomerForm : BaseWindowCommand
    {
        private readonly IInstruction _instruction;
        private readonly string _loadingMsg;

        public StartCustomerForm()
        {
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            var options = new WindowPrepareOptions
            {
                StatusText = _loadingMsg,
                ExistingFormReloadBusinessData = false,
                NewFormLoadBusinessData = true,
               // FormDataIdValueToSearchFor = _businessObjectId,
                UseExistingFormIfPresent = (_instruction is EditInstruction),
                // In case of an edit instruction, look for a open window with the same entity
                NewFormState = FormWindowState.Maximized,
                ShowWaitForm = true,
               // InitalizationParameters = initParams
            };
            bool newWindow;
            var editForm = WindowManager.PrepareShowWindow<Form1>(options, out newWindow);

            if (newWindow)
            {
                editForm.Show();
            }
        }

        #endregion
    }
}