using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace IP_Adressen_Scanner
{
    internal class Scanner
    {
        public bool PingHost(string ip)
        {
            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send(ip, 1000);
                return reply.Status == IPStatus.Success;
            }
            catch
            {
                return false;
            }
        }
    }
}
