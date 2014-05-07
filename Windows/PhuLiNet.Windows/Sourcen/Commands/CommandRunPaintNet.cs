using Windows.Core.Helpers;
using Technical.Imaging;
using Windows.Core.Helpers;

namespace Windows.Core.Commands
{
    public class CommandRunPaintNet : BaseCommand
    {
        public CommandRunPaintNet()
            : base()
        {
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            using (var busy = new StatusBusy("Paint.NET wird geladen ...", true))
            {
                PaintNetHelper.EditPicture();
            }
        }

        #endregion
    }
}