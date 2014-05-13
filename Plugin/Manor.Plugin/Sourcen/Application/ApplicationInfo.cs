using System;

namespace Manor.Plugin.Application
{
    internal class ApplicationInfo : IApplicationInfo
    {
        #region IApplicationInfo Members

        public string Name { get; internal set; }

        public Version Version { get; internal set; }

        public DateTime Date { get; internal set; }

        public bool AutoStart { get; internal set; }

        #endregion

        internal ApplicationInfo()
        {
        }
    }
}