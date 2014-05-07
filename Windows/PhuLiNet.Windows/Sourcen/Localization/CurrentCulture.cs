using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace Windows.Core.Localization
{
    internal class CurrentCulture
    {
        private static CultureInfo _lastThreadCurrentCulture;
        private static CultureInfo _lastThreadCurrentUiCulture;
        private static CultureInfo _lastApplicationCurrentCulture;

        public static void Set(string name)
        {
            SaveCurrentCultures();
            SetCulture(name);
        }

        public static void Reset()
        {
            if (_lastApplicationCurrentCulture != null)
            {
                Application.CurrentCulture = _lastApplicationCurrentCulture;
                _lastApplicationCurrentCulture = null;
            }
            if (_lastThreadCurrentCulture != null)
            {
                Thread.CurrentThread.CurrentCulture = _lastThreadCurrentCulture;
                _lastThreadCurrentCulture = null;
            }
            if (_lastThreadCurrentUiCulture != null)
            {
                Thread.CurrentThread.CurrentUICulture = _lastThreadCurrentUiCulture;
                _lastThreadCurrentUiCulture = null;
            }
        }

        private static void SaveCurrentCultures()
        {
            _lastApplicationCurrentCulture = Application.CurrentCulture;
            _lastThreadCurrentCulture = Thread.CurrentThread.CurrentCulture;
            _lastThreadCurrentUiCulture = Thread.CurrentThread.CurrentUICulture;
        }

        private static void SetCulture(string name)
        {
            var cultureInfo = new CultureInfo(name);
            Application.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

        public static CultureInfo GetThreadCulture()
        {
            return Thread.CurrentThread.CurrentCulture;
        }

        public static CultureInfo GetThreadUICulture()
        {
            return Thread.CurrentThread.CurrentUICulture;
        }
    }
}