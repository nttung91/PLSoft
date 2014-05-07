using System.Reflection;
using Windows.Core.Helpers;
using Windows.Core.Helpers;

namespace Windows.Core.Commands
{
    public class CommandSetApplicationName : BaseCommand
    {
        private string _appName;

        public CommandSetApplicationName()
        {
        }

        public CommandSetApplicationName(string appName)
        {
            _appName = appName;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            if (string.IsNullOrEmpty(_appName))
            {
                _appName = AssemblyProduct;
            }

            ApplicationHelper.ApplicationName = _appName;
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetEntryAssembly()
                    .GetCustomAttributes(typeof (AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute) attributes[0]).Product;
            }
        }

        #endregion
    }
}