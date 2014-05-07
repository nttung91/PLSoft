using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Windows.Core.BaseForms;
using Windows.Core.BaseForms;
using MessageBox = Windows.Core.Forms.MessageBox;

namespace Windows.Core.Commands
{
    public class CommandCloseAllForms : BaseDialogCommand
    {
        public bool ApplicationExit { get; set; }

        public CommandCloseAllForms()
        {
            Log = false;
            Audit = false;
        }

        public override void Execute()
        {
            IList<FrmBase> dirtyForms = WindowManager.FindDirtyWindows();

            if (dirtyForms != null && dirtyForms.Count == 0)
            {
                WindowManager.CloseAllForms();
                ApplicationExit = true;
            }
            else
            {
                string formInfo = string.Empty;

                foreach (FrmBase form in dirtyForms)
                {
                    formInfo += form.Text + Environment.NewLine;
                }

                DialogResult = MessageBox.ShowYesNo("Möchten Sie wirklich die Anwendung beenden?" +
                                                    Environment.NewLine +
                                                    "Sie haben noch folgende Fenster nicht gespeichert." +
                                                    Environment.NewLine +
                                                    Environment.NewLine +
                                                    formInfo,
                    "Anwendung beenden");

                if (DialogResult == DialogResult.Yes)
                {
                    WindowManager.CloseAllForms();
                    ApplicationExit = true;
                }
                else
                {
                    ApplicationExit = false;
                }
            }
        }
    }
}