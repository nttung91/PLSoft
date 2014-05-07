using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Principal;
using Technical.Settings.Contracts;

namespace Technical.Settings.Empty
{
    /// <summary>
    /// Empty or no config implementation
    /// </summary>
    public class EmptyConfig : IConfigProvider, IConfigAdmin
    {
        private string _appName;
        private string _instance;
        private IIdentity _identity;

        private Dictionary<string, IConfigSection> _sectionList = new Dictionary<string, IConfigSection>();

        public EmptyConfig(string appName, string instance)
        {
            _appName = appName;
            _instance = instance;
        }

        #region IConfig Members

        public string Name
        {
            get { return _appName; }
        }

        public string InstanceName
        {
            get { return _instance; }
        }

        public IIdentity Identity
        {
            get { return _identity; }
            set { _identity = value; }
        }

        public IConfigSection LoadSection(string sectionId)
        {
            Debug.Assert(_identity != null, "Current user undefined");

            if (!_sectionList.ContainsKey(sectionId))
            {
                _sectionList.Add(sectionId, new EmptySection(sectionId));
            }
            return _sectionList[sectionId];
        }

        public IConfigSection LoadSection(string sectionId, bool createIfMissing)
        {
            return LoadSection(sectionId);
        }

        public IConfigSection LoadSingleSetting(string sectionId, string settingId)
        {
            Debug.Assert(_identity != null, "Current user undefined");

            if (!_sectionList.ContainsKey(sectionId))
            {
                _sectionList.Add(sectionId, new EmptySection(sectionId));
            }

            var section = _sectionList[sectionId];
            return section;
        }

        public void SaveSection(IConfigSection section)
        {
            Debug.Assert(_identity != null, "Current user undefined");
        }

        #endregion

        IConfigSection IConfigAdmin.CreateSection(string sectionId, string description)
        {
            Debug.Assert(_identity != null, "Current user undefined");

            if (!_sectionList.ContainsKey(sectionId))
            {
                _sectionList.Add(sectionId, new EmptySection(sectionId));
            }
            return _sectionList[sectionId];
        }
    }
}