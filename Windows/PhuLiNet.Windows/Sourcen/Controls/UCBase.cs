using System;
using System.ComponentModel;
using DevExpress.XtraEditors;
using Windows.Core.Helpers;

namespace Windows.Core.Controls
{
    [ToolboxItem(false)]
    public partial class UCBase : XtraUserControl
    {
        public UCBase()
        {
            InitializeComponent();
        }

        protected virtual void InitBindings()
        {
        }

        protected virtual void InitBusinessData()
        {
        }

        protected virtual void InitControls()
        {
        }

        protected virtual void InitValidators()
        {
        }

        [Obsolete("Replaced by IsDesignerHosted")]
        protected bool DevelopmentMode
        {
            get
            {
                if (Site != null && Site.DesignMode)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Checks if control is in design mode.
        /// </summary>
        public bool IsDesignerHosted
        {
            get { return BaseFormsUtilities.IsDesignerHosted(this); }
        }
    }
}