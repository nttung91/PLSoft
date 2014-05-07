using System.Diagnostics;
using System.Windows.Forms;

namespace Windows.Core.WindowsManager
{
    public static class WindowManager
    {
        private static IWindowManager _windowManager;

        public static IWindowManager GetInstance()
        {
            Debug.Assert(_windowManager != null, "Please call CreateInstance at startup");

            if (_windowManager == null)
            {
                Form mdiContainer = GetMdiContainer();
                Debug.Assert(mdiContainer != null, "MdiContainer not found.");
                _windowManager = new DefaultWindowManager(mdiContainer);
            }

            return _windowManager;
        }

        public static void CreateInstance(Form mdiContainer)
        {
            Debug.Assert(_windowManager == null, "WindowManager exists already");
            Debug.Assert(mdiContainer != null, "mdiContainer is null");

            if (_windowManager == null)
            {
                _windowManager = new DefaultWindowManager(mdiContainer);
            }
        }

        private static Form GetMdiContainer()
        {
            Form mdiContainer = null;

            foreach (Form form in Application.OpenForms)
            {
                if (form.IsMdiContainer)
                {
                    mdiContainer = form;
                    break;
                }
            }

            return mdiContainer;
        }

        private static Form _mdiContainer;

        public static Form GetCachedMdiContainer()
        {
            if (_mdiContainer == null)
            {
                _mdiContainer = GetMdiContainer();
            }

            return _mdiContainer;
        }
    }
}