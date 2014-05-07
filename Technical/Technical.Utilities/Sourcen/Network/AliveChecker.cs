using System;
using System.Net.NetworkInformation;

namespace Technical.Utilities.Network
{
    public class AliveChecker
    {
        public static bool IsAlive(string hostName)
        {
            bool isAlive;
            int timeout = 1000; //Timeout in MilliSekunden

            try
            {
                using (var ping = new Ping())
                {
                    PingReply reply = ping.Send(hostName, timeout); //Senden der Anfrage
                    isAlive = reply.Status == IPStatus.Success;
                }
            }
            catch (Exception)
            {
                isAlive = false;
            }

            return isAlive;
        }
    }
}