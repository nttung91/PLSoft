using System.Drawing;
using System.Windows.Forms;
using Windows.Core.Colors;

namespace Windows.Core.Helpers.Controls.Item
{
    internal class EditorEnablerDisabler : IControlInfo
    {
        public EditorEnablerDisabler(Control ctrl)
        {
            _ctrl = ctrl;

            InitiallyEnabled = ctrl.Enabled;
            InitialBackColor = ctrl.BackColor;
            InitialForeColor = ctrl.ForeColor;
        }

        private Control _ctrl;
        public bool InitiallyEnabled { get; private set; }

        public Color InitialBackColor { get; private set; }
        public Color InitialForeColor { get; private set; }

        public bool CanEnable()
        {
            return !_ctrl.Enabled && InitiallyEnabled;
        }

        public bool CanDisable()
        {
            return _ctrl.Enabled && InitiallyEnabled;
        }

        #region IControlInfo Members

        public bool Enabled
        {
            set
            {
                if (value)
                {
                    if (CanEnable())
                    {
                        _ctrl.ForeColor = InitialForeColor;
                        _ctrl.BackColor = InitialBackColor;
                        _ctrl.Enabled = value;
                    }
                }
                else
                {
                    if (CanDisable())
                    {
                        _ctrl.ForeColor = Color.Black;
                        _ctrl.BackColor = ColorRepository.ReadOnlyBackColor;
                        _ctrl.Enabled = value;
                    }
                }
            }
        }


        public bool IsControl(Control control)
        {
            return _ctrl == control;
        }

        #endregion
    }
}