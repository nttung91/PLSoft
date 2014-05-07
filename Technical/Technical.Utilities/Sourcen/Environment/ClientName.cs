using System;

namespace Technical.Utilities.Environment
{
    public class ClientName
    {
        public static string Get()
        {
            string clientName;
            try
            {
                clientName = System.Environment.GetEnvironmentVariable("CLIENTNAME");

                if (!string.IsNullOrEmpty(clientName))
                {
                    clientName = clientName.ToUpper();
                }
            }
            catch (Exception)
            {
                clientName = string.Empty;
            }

            return clientName;
        }
    }
}