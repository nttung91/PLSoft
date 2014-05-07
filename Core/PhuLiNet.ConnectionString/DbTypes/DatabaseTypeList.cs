using System;
using System.Collections.Generic;
using System.Linq;

namespace Manor.ConnectionStrings.DbTypes
{
    public class DatabaseTypeList : List<DatabaseType>
    {
        internal EDbType GetDbType(string databaseId)
        {
            if (databaseId == null) throw new ArgumentNullException("databaseId");

            return
                this.Where(
                    dbType =>
                        dbType.Databases.Any(database => database.Id.ToLowerInvariant() == databaseId.ToLowerInvariant()))
                    .Select(dbType => dbType.DbType)
                    .FirstOrDefault();
        }

        internal EDatabaseMode GetDbMode(string databaseId)
        {
            if (databaseId == null) throw new ArgumentNullException("databaseId");

            var found = EDatabaseMode.Unkown;

            foreach (var dbType in this)
            {
                foreach (var database in dbType.Databases)
                {
                    if (database.Id.ToLowerInvariant() == databaseId.ToLowerInvariant())
                    {
                        found = database.DbMode;
                        break;
                    }
                }

                if (found != EDatabaseMode.Unkown) break;
            }

            return found;
        }

        internal string GetDatabaseId(EDbType databaseType, EDatabaseMode databaseMode)
        {
            string found = null;

            foreach (var dbType in this)
            {
                foreach (var database in dbType.Databases)
                {
                    if (dbType.DbType == databaseType && database.DbMode == databaseMode)
                    {
                        found = database.Id;
                        break;
                    }
                }

                if (found != null) break;
            }

            return found;
        }
    }
}