using System;
using Manor.Utilities.Cryptography;

namespace Manor.ConnectionStrings.Configuration
{
    internal class ConnectionStringDecrypter
    {
        public string Decrypt(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException("connectionString");
            var cryptEngine = new CryptEngine(CryptEngine.AlgorithmType.Des);
            return cryptEngine.Decrypt(connectionString);
        }
    }
}