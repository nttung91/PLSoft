using System;
using Windows.Core.Forms;
using Windows.Core.Forms.ImageMgmt;

namespace Windows.Core.Commands
{
    public class CommandStartFrmImage : BaseDialogCommand
    {
        private byte[] _pictureAsBytes;

        public byte[] Picture
        {
            get { return _pictureAsBytes; }
        }

        public CommandStartFrmImage(byte[] picture)
            : base()
        {
            _pictureAsBytes = picture;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            var form = WindowManager.PrepareShowDialog<FrmImage>("Starte Bildanzeige", false);
            form.PictureAsBytes = _pictureAsBytes;
            DialogResult = form.ShowDialog();

            _pictureAsBytes = form.PictureAsBytes;

            form.PictureAsBytes = null;
            form.Dispose();
            form = null;

            //Nach speicherintensiver Bildbearbeitung Garbage Collector laufen lassen
            GC.Collect();
        }

        #endregion
    }
}