using System.Collections.Generic;

namespace Manor.ConnectionStrings.DbTypes
{
    public class DatabaseType
    {
        public EDbType DbType { get; set; }
        public List<Database> Databases { get; set; }

        public DatabaseType()
        {
            Databases = new List<Database>();
        }

        public override string ToString()
        {
            return DbType.ToString();
        }
    }
}