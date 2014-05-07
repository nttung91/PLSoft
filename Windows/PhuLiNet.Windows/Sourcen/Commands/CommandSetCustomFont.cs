using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraBars;
using Technical.Settings;
using Windows.Core.Style;

namespace Windows.Core.Commands
{
    public class CommandSetCustomFont : BaseCommand
    {
        public CommandSetCustomFont()
        {
            Log = false;
            Audit = false;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            var settingsProvider = Provider.Get();
            var section = settingsProvider.LoadSection("BasicWindowSettings");
            var customFont = section.GetSetting<Font>("CustomFont").Value;

            if (customFont == null) customFont = DefaultFont.Get();
            AppearanceObject.DefaultFont = customFont;
            BarAndDockingController.Default.AppearancesBar.ItemsFont = customFont;
        }

        #endregion
    }
}