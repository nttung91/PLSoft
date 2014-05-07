using System.Collections.Generic;

namespace Manor.ConnectionStrings.Configuration
{
    public interface IDataAdapter
    {
        IDictionary<string, IConnectionString> Load();
        void Validate();
    }
}