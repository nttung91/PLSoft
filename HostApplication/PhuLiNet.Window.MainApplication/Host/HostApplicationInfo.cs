using System.Collections.Generic;
using System.Diagnostics;
using Windows.Core.WindowsManager;
using Manor.Plugin.Contracts;

namespace PhuLiNet.Window.MainApplication.Host
{
    internal class HostApplicationInfo : IHostApplication
    {
        private static HostApplicationInfo _singleton;

        private HostApplicationInfo()
        {
        }

        internal static HostApplicationInfo Get()
        {
            if (_singleton == null) _singleton = new HostApplicationInfo();
            return _singleton;
        }

        public Dictionary<string, string> CustomCommandLineParameters { get; set; }

        public void RefreshToolbar()
        {
            var form = WindowManager.GetInstance().GetMainWindow() as FrmStartForm;
            if (form != null)
            {
               // form.EnableDisableMenuItems();
            }
        }

        public bool NavigationMenuExpanded
        {
            get
            {
                var form = WindowManager.GetInstance().GetMainWindow() as FrmStartForm;
                if (form != null)
                {
                    //return form.NavigationMenuExpanded;
                }
                return false;
            }
            set
            {
                var form = WindowManager.GetInstance().GetMainWindow() as FrmStartForm;
                if (form != null)
                {
                   // form.NavigationMenuExpanded = value;
                }
            }
        }

        public bool CtrlPressed
        {
            get
            {
                var form = WindowManager.GetInstance().GetMainWindow() as FrmStartForm;
                Debug.Assert(form != null, "form != null");
                return false;
            }
        }
    }
}