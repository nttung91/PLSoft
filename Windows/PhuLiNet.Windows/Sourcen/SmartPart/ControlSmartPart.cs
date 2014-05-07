using System.Windows.Forms;

namespace Windows.Core.SmartPart
{
    /// <summary>
    /// Control smart part
    /// </summary>
    public class ControlSmartPart : AbstractSmartPart
    {
        public ControlSmartPart(Control control) : base(control)
        {
        }

        public override void Init()
        {
            _initDone = true;
        }

        public override void Deinit()
        {
            _initDone = false;
        }

        public override void Destroy()
        {
            if (_control is Control)
            {
                var c = _control as Control;
                c.Hide();
                c.Dispose();
                _control = null;
            }
        }
    }
}