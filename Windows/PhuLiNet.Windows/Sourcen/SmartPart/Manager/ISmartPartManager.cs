using System.Collections.Generic;

namespace Windows.Core.SmartPart.Manager
{
    /// <summary>
    /// Basic Interface for a Smart Part Manager
    /// </summary>
    public interface ISmartPartManager
    {
        void AddSmartPart(string key, ISmartPart smartPart);
        ISmartPart GetSmartPart(string key);
        bool HasSmartPart(string key);
        void RemoveSmartPart(string key);
        void DestroySmartPart(string key);
        void DeinitAll();
        void DestroyAll();
        List<ISmartPart> GetSmartParts();
    }
}