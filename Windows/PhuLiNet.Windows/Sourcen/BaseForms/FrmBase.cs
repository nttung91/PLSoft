using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraPrinting;
using Windows.Core.BaseForms;
using Windows.Core.Commands;
using Windows.Core.Controls;
using Windows.Core.DxExtensions;
using Windows.Core.Forms.Wizardv2;
using Windows.Core.Helpers;
using Windows.Core.Messaging.Handler;

namespace Windows.Core.BaseForms
{
    /// <summary>
    /// Base form with common features
    /// </summary>
    public partial class FrmBase : XtraForm, IIdentifiableForm, IHelpOnForm, IFormMessages, IFormPermissions,
        IExportableForm, IPrintableForm
    {
        private string _helpFileExtension = CommandShowHelp.HelpFileExtensionDefault;
        private bool _rememberPosition = true;

        protected BaseMessageHandler _messageHandler;

        public FrmBase()
        {
            InitializeComponent();

            if (!IsDesignerHosted)
            {
                InitMessageHandler();
                RegisterMessageHandlerEvents();
            }
        }

        protected virtual void InitBindings()
        {
        }

        protected virtual void InitBindingTree()
        {
        }

        protected virtual void InitBusinessData()
        {
        }

        protected virtual void ClearBindings()
        {
        }

        protected virtual void InitControls()
        {
        }

        protected virtual void RefreshControls()
        {
        }

        #region IIdentifiableForm Members

        public virtual object GetIdValue()
        {
            return GetType().Name;
        }

        public virtual object GetIdValueData()
        {
            return null;
        }

        #endregion

        #region DesignerHosted

        [Obsolete("Replaced by IsDesignerHosted")]
        protected bool DevelopmentMode
        {
            get { return BaseFormsUtilities.IsDesignerHosted(this); }
        }

        /// <summary>
        /// Checks if control is in design mode.
        /// </summary>
        public bool IsDesignerHosted
        {
            get { return BaseFormsUtilities.IsDesignerHosted(this); }
        }

        #endregion

        #region IHelpOnForm Members

        [Browsable(true)]
        public string HelpFileName { get; set; }

        [Browsable(false)]
        public string HelpFileExtension
        {
            get { return _helpFileExtension; }
            set { _helpFileExtension = value; }
        }

        [Browsable(true)]
        public bool RememberPosition
        {
            get { return _rememberPosition; }
            set { _rememberPosition = value; }
        }

        #endregion

        #region Message Handler Methods

        protected virtual void InitMessageHandler()
        {
            _messageHandler = MessageHandlerFactory.GetNoMessageHandler();
        }

        protected virtual void RegisterMessageHandlerEvents()
        {
            _messageHandler.OnReceiveMessage += MessageHandler_OnReceiveMessage;
        }

        protected virtual void ClearMessageHandler()
        {
            if (_messageHandler != null)
            {
                _messageHandler.OnReceiveMessage -= MessageHandler_OnReceiveMessage;
                _messageHandler = null;
            }
        }

        protected virtual void MessageHandler_OnReceiveMessage(IMessageHandler sender, ReceiveMessageEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IFormMessages Members

        public IMessageHandler MessageHandler
        {
            get { return _messageHandler; }
        }

        public IMessageReceiver MessageReceiver
        {
            get { return _messageHandler; }
        }

        #endregion

        private void FrmBase_Load(object sender, EventArgs e)
        {
            var positionHandler = new FormPositionHandler(this);
            positionHandler.RememberPosition = _rememberPosition;
            positionHandler.SetDefaultPosition();
            //TODO : NTG
           // Icon = IconManager.GetIcon(EIcons.window_32);
        }

        private void FrmBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClearMessageHandler();

            var positionHandler = new FormPositionHandler(this);
            positionHandler.RememberPosition = _rememberPosition;
            positionHandler.SavePosition();
        }

        public virtual void InitPermissions()
        {
        }

        private List<IPrintable> GetPrintableControls()
        {
            return this.GetAllControls<IPrintable>().Where(control => !(control is LayoutControl)).ToList();
        }

        private List<IPrintableControl> GetCustomPrintImplementorControls()
        {
            return this.GetAllControls<IPrintableControl>().ToList();
        }

        private List<IExportableControl> GetCustomExportImplementorControls()
        {
            return this.GetAllControls<IExportableControl>().ToList();
        }

        private T SelectSingleOrActiveControl<T>(IList<T> controls)
        {
            if (controls == null) return default(T);
            if (controls.Count == 1)
            {
                return controls[0];
            }

            foreach (var control in controls)
            {
                var ucGridBase = control as UCGridBase;
                if (ucGridBase != null)
                {
                    if (ucGridBase.ActiveControl != null)
                    {
                        return control;
                    }
                }
                else
                {
                    var ctr = control as Control;
                    if (ctr != null && ctr.Focused)
                    {
                        return control;
                    }
                }
            }

            return default(T);
        }

        private IPrintable GetPrintableControl()
        {
            var printableControls = GetPrintableControls();
            return SelectSingleOrActiveControl(printableControls);
        }

        private IExportableControl GetCustomExportImplementorControl()
        {
            var customExportControls = GetCustomExportImplementorControls();
            return SelectSingleOrActiveControl(customExportControls);
        }

        private IPrintableControl GetCustomPrintImplementorControl()
        {
            var customPrintControls = GetCustomPrintImplementorControls();
            return SelectSingleOrActiveControl(customPrintControls);
        }

        private bool HasControls<T>(IList<T> controls)
        {
            return controls != null && controls.Count > 0;
        }

        private bool HasPrintableControls
        {
            get
            {
                var printableControls = GetPrintableControls();
                return HasControls(printableControls);
            }
        }

        private bool HasCustomPrintImplementors
        {
            get
            {
                var controls = GetCustomPrintImplementorControls();
                return HasControls(controls);
            }
        }

        private bool HasCustomExportImplementors
        {
            get
            {
                var controls = GetCustomExportImplementorControls();
                return HasControls(controls);
            }
        }

        public virtual void Export(ExportType exportType)
        {
            var customExportImplControl = GetCustomExportImplementorControl();
            if (customExportImplControl != null)
            {
                customExportImplControl.Export(exportType);
            }
            else
            {
                var printableControl = GetPrintableControl();
                if (printableControl != null)
                {
                    GridExport.ExportGrid(printableControl, exportType);
                }
            }
        }

        public virtual bool ExportEnabled
        {
            get { return HasCustomExportImplementors || HasPrintableControls; }
        }

        public virtual void Print()
        {
            var customPrintImplControl = GetCustomPrintImplementorControl();
            if (customPrintImplControl != null)
            {
                customPrintImplControl.Print();
            }
            else
            {
                var printableControl = GetPrintableControl();
                if (printableControl != null)
                {
                    GridPrint.PrintComponent(printableControl, false);
                }
            }
        }

        public virtual bool PrintEnabled
        {
            get { return HasCustomPrintImplementors || HasPrintableControls; }
        }
    }
}