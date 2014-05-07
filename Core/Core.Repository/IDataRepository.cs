using System;

namespace Core.Repository
{
    public interface IDataRepository : IDisposable
    {
        string Id { get; }
        T GetDataProvider<T>() where T : class;
        T GetDataProvider<T>(string id) where T : class;
    }
}