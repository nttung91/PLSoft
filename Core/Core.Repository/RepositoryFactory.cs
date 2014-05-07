using System.Collections.Generic;
using System.Diagnostics;

namespace Core.Repository
{
    public static class RepositoryFactory
    {
        private static IDictionary<string, IDataRepository> _dalManagers = new Dictionary<string, IDataRepository>();
        private static IDataRepository _defaultDalManager;

        public static IDataRepository GetDefaultInstance()
        {
            Debug.Assert(_defaultDalManager != null, "No DefaultDalManager instance exists");

            return _defaultDalManager;
        }

        public static void AddDefaultInstance(IDataRepository manager)
        {
            _dalManagers.Add(manager.Id, manager);
            _defaultDalManager = _dalManagers[manager.Id];
        }

        public static void AddInstance(IDataRepository manager)
        {
            Debug.Assert(!_dalManagers.ContainsKey(manager.Id),
                string.Format("DalManager with id [{0}] exists already", manager.Id));
            _dalManagers.Add(manager.Id, manager);
        }

        public static void ClearInstance()
        {
            _dalManagers.Clear();
            _dalManagers = null;
        }
    }
}