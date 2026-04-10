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

        public List<string> ScanRange(string baseIp, int start, int end)
        {
            List<string> activeHosts = new List<string>();

            for (int i = start; i <= end; i++)
            {
                string ip = $"{baseIp}.{i}";
                if (PingHost(ip))
                {
                    Console.WriteLine($"[+] Aktiv: {ip}");
                    activeHosts.Add(ip);
                }
            }
            return activeHosts;
        }
    }
}
