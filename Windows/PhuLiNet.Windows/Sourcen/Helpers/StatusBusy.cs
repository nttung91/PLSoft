using System;
using System.Windows.Forms;
using Windows.Core.Localization;
using DevExpress.XtraBars;
using Windows.Core.Helpers;
using Technical.Settings;

namespace Windows.Core.Helpers
{
    public class StatusBusy : IDisposable
    {
        private readonly string _oldStatus;
        private readonly Cursor _oldCursor;
        private static Form _frmMain;
        private static BarItem _statusBarItem;
        private readonly bool _showWaitForm;

        public StatusBusy(bool showWaitForm) : this(StatusBusyRes.LoadingData, showWaitForm)
        {
        }

        public StatusBusy(string statusText, bool showWaitForm)
        {
            if (_statusBarItem != null)
            {
                _oldStatus = _statusBarItem.Caption;
                _statusBarItem.Caption = statusText;
                Application.DoEvents();
            }
            if (_frmMain != null)
            {
                _oldCursor = _frmMain.Cursor;
                _frmMain.Cursor = Cursors.WaitCursor;
            }

            var settingsProvider = Provider.Get();

            if (settingsProvider != null)
            {
                var section = settingsProvider.LoadSection("BasicWindowSettings");
                _showWaitForm = showWaitForm && section.GetSetting("ShowWaitForm", true).Value;
            }
            else
            {
                _showWaitForm = false;
            }

            if (_showWaitForm)
                WaitFormHelper.Start(statusText);
        }

        public static void SetMainForm(Form frmMain)
        {
            _frmMain = frmMain;
        }

        public static void SetMainForm(Form frmMain, BarItem statusBarItem)
        {
            _frmMain = frmMain;
            _statusBarItem = statusBarItem;
        }

        public static void UnSetMainForm()
        {
            _frmMain = null;
            _statusBarItem = null;
        }

        // IDisposable
        private bool _disposedValue; // To detect redundant calls

        protected void Dispose(bool disposing)
        {
            if (!_disposedValue)
                if (disposing)
                {
                    if (_frmMain != null)
                    {
                        _frmMain.Cursor = _oldCursor;
                    }
                    if (_statusBarItem != null)
                    {
                        _statusBarItem.Caption = _oldStatus;
                    }
                    if (_showWaitForm)
                    {
                        WaitFormHelper.Stop();
                    }
                }
            _disposedValue = true;
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}