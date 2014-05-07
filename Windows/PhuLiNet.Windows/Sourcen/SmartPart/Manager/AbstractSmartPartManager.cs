using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Windows.Core.SmartPart.Manager
{
    /// <summary>
    /// Basic Smart Part Manager implementation
    /// </summary>
    public abstract class AbstractSmartPartManager : ISmartPartManager
    {
        protected Dictionary<string, ISmartPart> _smartParts;

        protected AbstractSmartPartManager()
        {
            _smartParts = new Dictionary<string, ISmartPart>();
        }

        #region ISmartPartManager Members

        public virtual void AddSmartPart(string key, ISmartPart smartPart)
        {
            Debug.Assert(!HasSmartPart(key), String.Format("Can't add SmartPart {0}, because it is already added.", key));

            if (HasSmartPart(key))
                throw new InvalidOperationException(
                    String.Format("Can't add SmartPart {0}, because it is already added.", key));

            if (smartPart.DisplayName == null)
                smartPart.DisplayName = key;

            smartPart.Key = key;

            _smartParts.Add(key, smartPart);
        }

        public virtual ISmartPart GetSmartPart(string key)
        {
            Debug.Assert(HasSmartPart(key),
                String.Format("Can't get SmartPart {0} value, because it doesn't exist.", key));

            ISmartPart smartPart = null;
            if (HasSmartPart(key)) smartPart = _smartParts[key] as ISmartPart;

            return smartPart;
        }

        public virtual bool HasSmartPart(string key)
        {
            return _smartParts == null ? false : _smartParts.ContainsKey(key);
        }

        public virtual void RemoveSmartPart(string key)
        {
            _smartParts.Remove(key);
        }

        public virtual void DestroySmartPart(string key)
        {
            ISmartPart smartPart = null;
            if (HasSmartPart(key)) smartPart = _smartParts[key] as ISmartPart;
            smartPart.Deinit();
            smartPart.Destroy();

            _smartParts.Remove(key);
        }

        public virtual void DeinitAll()
        {
            foreach (KeyValuePair<string, ISmartPart> p in _smartParts)
            {
                p.Value.Deinit();
            }
        }

        public virtual void DestroyAll()
        {
            foreach (KeyValuePair<string, ISmartPart> p in _smartParts)
            {
                p.Value.Deinit();
                p.Value.Destroy();
            }

            _smartParts.Clear();
        }

        public virtual List<ISmartPart> GetSmartParts()
        {
            //copy and return smartpart list
            var smartParts = new List<ISmartPart>();

            foreach (KeyValuePair<string, ISmartPart> p in _smartParts)
                smartParts.Add(p.Value);

            return smartParts;
        }

        #endregion
    }
}