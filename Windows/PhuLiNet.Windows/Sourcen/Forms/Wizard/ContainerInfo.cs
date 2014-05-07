using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Windows.Core.Forms.Wizard
{
    /// <summary>
    /// Manages aspects of the container that must be known by the wizard.
    /// </summary>
    public class ContainerInfo
    {
        protected Control _pluginArea;
        protected SimpleButton _btnBack;
        protected SimpleButton _btnNext;
        protected SimpleButton _btnFinish;
        protected SimpleButton _btnCancel;
        protected SimpleButton _btnHelp;

        /// <summary>
        /// Return the control that is the plugin container.
        /// </summary>
        public Control PluginArea
        {
            get { return _pluginArea; }
        }

        /// <summary>
        /// Returns the back button control.
        /// </summary>
        public SimpleButton BackButton
        {
            get { return _btnBack; }
        }

        /// <summary>
        /// Returns the next button control.
        /// </summary>
        public SimpleButton NextButton
        {
            get { return _btnNext; }
        }

        /// <summary>
        /// Returns the cancel button control.
        /// </summary>
        public SimpleButton CancelButton
        {
            get { return _btnCancel; }
        }

        /// <summary>
        /// Returns the finish button control.
        /// </summary>
        public SimpleButton FinishButton
        {
            get { return _btnFinish; }
        }

        /// <summary>
        /// Returns the help button control.
        /// </summary>
        public SimpleButton HelpButton
        {
            get { return _btnHelp; }
        }

        /// <summary>
        /// Defines the plugin area (required) and optional buttons to manage the flow of the wizard.
        /// </summary>
        public ContainerInfo(Control pluginArea, SimpleButton btnBack, SimpleButton btnNext, SimpleButton btnFinish,
            SimpleButton btnCancel, SimpleButton btnHelp)
        {
            if (pluginArea == null)
            {
                throw new ArgumentNullException("The pluginArea parameter is required.");
            }

            _pluginArea = pluginArea;
            _btnBack = btnBack;
            _btnNext = btnNext;
            _btnFinish = btnFinish;
            _btnCancel = btnCancel;
            _btnHelp = btnHelp;
        }
    }
}