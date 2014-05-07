using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Windows.Core.Helpers
{
    public class FileHelperDialog
    {
        public static bool CreatePath(string fileName)
        {
            FileInfo fInfo;
            try
            {
                fInfo = new FileInfo(fileName);
            }
            catch (Exception e)
            {
                XtraMessageBox.Show("Ungültiger Dateiname " + fileName + Environment.NewLine + e.Message,
                    "Ungültiger Dateiname", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!fInfo.Directory.Exists)
            {
                if (
                    XtraMessageBox.Show(
                        "Das Verzeichnis " + fInfo.Directory.ToString() +
                        " existiert nicht. Soll das Verzeichnis angelegt werden?", "Verzeichnis fehlt",
                        MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return false;

                try
                {
                    fInfo.Directory.Create();
                }
                catch (Exception e)
                {
                    XtraMessageBox.Show(
                        "Das Verzeichnis " + fInfo.Directory.ToString() + " konnte nicht angelegt werden." +
                        Environment.NewLine + e.Message, "Ungültiger Verzeichnisname.", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
    }
}