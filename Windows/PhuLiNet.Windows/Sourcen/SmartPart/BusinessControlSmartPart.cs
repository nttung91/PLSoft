using System.Windows.Forms;
using Windows.Core.Controls;

namespace Windows.Core.SmartPart
{
    /// <summary>
    /// Business control smart part
    /// </summary>
    public class BusinessControlSmartPart : AbstractSmartPart
    {
        public BusinessControlSmartPart(IBusinessControl businessControl)
            : base(businessControl)
        {
        }

        public override void Init()
        {
            var businessControl = _control as IBusinessControl;

            if (businessControl != null)
                businessControl.InitBusiness();

            _initDone = true;
        }

        public override void Deinit()
        {
            var businessControl = _control as IBusinessControl;

            if (businessControl != null)
                businessControl.ClearBusiness();

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