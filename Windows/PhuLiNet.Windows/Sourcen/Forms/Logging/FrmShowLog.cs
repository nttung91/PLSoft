using System;
using DevExpress.XtraBars;
using Manor.Logging;
using Windows.Core.BaseForms;

namespace Windows.Core.Forms.Logging
{
    internal partial class FrmShowLog : FrmReadOnlyBase
    {
        public FrmShowLog()
        {
            InitializeComponent();
            InitBindings();
        }

        protected override void InitBindings()
        {
        }

        private void bbiDelLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            rttLogging.Text = null;

            if (Logger.GetInstance().GetLogger() is LoggerTextWriter)
            {
                var logger = Logger.GetInstance().GetLogger() as LoggerTextWriter;
                logger.ClearLog();
            }
        }

        private void bbiLogApp_ItemClick(object sender, ItemClickEventArgs e)
        {
            UpdateLog();
        }

        private void UpdateLog()
        {
            if (Logger.GetInstance().GetLogger() is LoggerTextWriter)
            {
                var logger = Logger.GetInstance().GetLogger() as LoggerTextWriter;
                rttLogging.Text = logger.Log;
            }
        }

        private void FrmShowLog_Shown(object sender, EventArgs e)
        {
            UpdateLog();
        }

        private void FrmShowLog_Enter(object sender, EventArgs e)
        {
            UpdateLog();
        }
    }
}