using Windows.Core.Forms.Cryptography;
using Windows.Core.Localization;

namespace Windows.Core.Commands
{
    public class CommandShowCryptForm : BaseWindowCommand
    {
        public override void Execute()
        {
            WindowManager.ShowWindow<FrmCryptString>(CommandRes.DataLoading, true);
        }
    }
}