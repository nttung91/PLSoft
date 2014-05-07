using System;
using Technical.Settings;
using Windows.Core.Style;

namespace Windows.Core.Commands
{
    public class CommandSetAppearance : BaseCommand
    {
        public CommandSetAppearance()
        {
            Log = false;
            Audit = false;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            EStyles style;
            var settingsProvider = Provider.Get();
            var section = settingsProvider.LoadSection("BasicWindowSettings");
            bool enumParseOk = Enum.TryParse(section.GetSetting("LookAndFeel", "Default").Value, out style);

            if (enumParseOk)
            {
                var appearance = new SetAppearance();
                appearance.SetLookAndFeel(style, section.GetSetting<string>("Skin", null).Value);
            }
        }

        #endregion
    }
}