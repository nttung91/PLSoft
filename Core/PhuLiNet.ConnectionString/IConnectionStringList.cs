using Manor.ConnectionStrings.DbTypes;

namespace Manor.ConnectionStrings
{
    public interface IConnectionStringList
    {
        void Add(EDbType dbType, IConnectionString connectionString);
        IConnectionString Get(EDbType dbType);
        void SetOracleUserId();
        bool HasDbType(EDbType dbType);
        void Clear();
        bool IsEmpty { get; }
    }
}