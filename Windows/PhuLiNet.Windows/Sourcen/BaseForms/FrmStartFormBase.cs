using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Windows.Core.Commands;
using Techical.Icons;

namespace Windows.Core.BaseForms
{
    public partial class FrmStartFormBase : XtraForm, IHelpOnForm
    {
        private string _helpFileExtension = CommandShowHelp.HelpFileExtensionDefault;

        public FrmStartFormBase()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            switch (keys)
            {
                case Keys.Control | Keys.S:
                {
                    CommandExecutor.Execute(new CommandSave());
                    return true;
                }
                case Keys.Control | Keys.R:
                {
                    CommandExecutor.Execute(new CommandReload());
                    return true;
                }
                case Keys.Control | Keys.E:
                {
                    CommandExecutor.Execute(new CommandExport(ExportType.XLSX));
                    return true;
                }
                case Keys.Control | Keys.W:
                {
                    CommandExecutor.Execute(new CommandSwitch());
                    return true;
                }
                case Keys.F1:
                {
                    ShowHelp();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref message, keys);
        }

        private void FrmStartFormBase_Load(object sender, EventArgs e)
        {
            Icon = IconManager.GetIcon(EIcons.manor_logo);
        }

        [Browsable(true)]
        public string HelpFileName { get; set; }

        [Browsable(false)]
        public string HelpFileExtension
        {
            get { return _helpFileExtension; }
            set { _helpFileExtension = value; }
        }

        protected void ShowHelp()
        {
            CommandExecutor.Execute(ActiveMdiChild != null
                ? new CommandShowHelp(ActiveMdiChild)
                : new CommandShowHelp((IHelpOnForm) this));
        }

        //.Net Memory Leak Problem: http://memprofiler.com/forum/viewtopic.php?t=1160
        protected override void OnMdiChildActivate(EventArgs e)
        {
            base.OnMdiChildActivate(e);
            try
            {
                typeof (Form).InvokeMember("FormerlyActiveMdiChild",
                    BindingFlags.Instance | BindingFlags.SetProperty |
                    BindingFlags.NonPublic, null,
                    this, new object[] {null});
            }
            catch (Exception)
            {
                Debug.Assert(false, "Windows.Forms Memory Leak Bugfix failed.");
                // Something went wrong. Maybe we don't have enough 
                // permissions to perform this or the 
                // "FormerlyActiveMdiChild" property no longer 
                // exists. 
            }
        }
    }
}