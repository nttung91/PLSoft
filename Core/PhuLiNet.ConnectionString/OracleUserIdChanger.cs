using System.Security.Principal;
using Manor.Utilities.Environment;
using Manor.Utilities.Extensions;

namespace Manor.ConnectionStrings
{
    /// <summary>
    /// Replaces oracle user when using proxy authentication
    /// </summary>
    public class OracleUserIdChanger
    {
        private readonly IIdentity _identity;
        private const string UserIdPrefixDefault = "ops$";

        public string OracleUserId
        {
            get { return string.Format("{0}{1}", UserIdPrefixDefault, _identity.NameWithoutDomain()); }
        }

        public OracleUserIdChanger()
            : this(WindowsIdentity.GetCurrent())
        {
        }

        public OracleUserIdChanger(IIdentity identity)
        {
            _identity = identity;
        }

        public void SetCurrentUser(IConnectionString connectionString)
        {
            if (connectionString is TextualConnectionString)
            {
                var oracleConnectionString = new OracleConnectionString(((TextualConnectionString)connectionString).ConnectionString);
                SetCurrentUserToOracleConnectionString(oracleConnectionString);
                connectionString.ConnectionString = oracleConnectionString.ConnectionString;
            }
            else if (connectionString is OracleConnectionString)
            {
                SetCurrentUserToOracleConnectionString((OracleConnectionString)connectionString);
            }
        }

        private void SetCurrentUserToOracleConnectionString(OracleConnectionString oracleConnectionString)
        {
            lock (this)
            {
                if (oracleConnectionString.HasProxyUserAndPassword)
                {
                    oracleConnectionString.User = OracleUserId;
                    oracleConnectionString.Password = null;
                }

                if (!oracleConnectionString.HasUser &&
                    !oracleConnectionString.HasProxyUserAndPassword)
                {
                    oracleConnectionString.User = OracleUserId;
                    var passwordGenerator = new PasswordGenerator(_identity);
                    oracleConnectionString.Password = passwordGenerator.GeneratePassword();
                }
            }
        }
    }
}