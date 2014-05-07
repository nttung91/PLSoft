using System.IO;
using System.Windows.Forms;
using Windows.Core.BaseForms;
using Windows.Core.Commands;

namespace Windows.Core.HelpProvider
{
    public class HelpFromFileSystemProvider : HelpProviderBase
    {
        protected override bool FileExists(string filePath)
        {
            return new FileInfo(filePath).Exists;
        }

        protected override string GetHelpfileFullName(IHelpOnForm help, bool useLanguage)
        {
            var helpfilename = GetHelpFileNameWithoutPath(help, useLanguage);
            return !string.IsNullOrEmpty(helpfilename)
                ? Path.Combine(Application.StartupPath, "HelpFiles", helpfilename)
                : null;
        }

        protected override void OpenHelpfile(string fullName)
        {
            CommandExecutor.Execute(new CommandShowExternalFile(fullName));
        }
    }
}