using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using Technical.Utilities.Helpers;
using Windows.Core.Forms;

namespace Windows.Core.Commands
{
    public class CommandShowExternalFile : BaseCommand
    {
        protected string _fileName;

        public CommandShowExternalFile(string fileName)
        {
            _fileName = fileName;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            if (_fileName == null)
            {
                Debug.Assert(false, "Execute " + ToString() + ": Datei-Pfad nicht gesetzt");
                return;
            }

            FileInfo fileInfo = null;

            try
            {
                fileInfo = new FileInfo(_fileName);
            }
            catch (Exception e)
            {
                MessageBox.ShowError(string.Format("Die Datei [{0}] kann nicht angezeigt werden.", _fileName), e.Message,
                    "Fehler beim Anzeigen der Datei");
            }

            if (fileInfo != null && fileInfo.Exists)
            {
                var launcher = new FileLauncher(_fileName);

                try
                {
                    launcher.Run();
                }
                catch (Win32Exception e)
                {
                    MessageBox.ShowError(string.Format("Die Datei [{0}] kann nicht angezeigt werden.", _fileName),
                        e.Message, "Fehler beim Anzeigen der Datei");
                }
            }
            else
            {
                MessageBox.ShowError("Datei nicht gefunden",
                    String.Format("Die Datei [{0}] konnte nicht gefunden werden.",
                        _fileName),
                    "Datei nicht gefunden");
            }
        }

        #endregion
    }
}