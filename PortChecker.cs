using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace IP_Adressen_Scanner
{
    public class PortChecker
    {
        private readonly int[] _defaultPorts = { 22, 80, 443, 3389, 8080 };

        public bool IsPortOpen(string ip, int port)
        {
            try
            {
                using TcpClient client = new TcpClient();
                var result = client.BeginConnect(ip, port, null, null);
                bool success = result.AsyncWaitHandle.WaitOne(1000);
                client.EndConnect(result);
                return success;
            }
            catch
            {
                return false;
            }
        }

        public List<int> ScanPorts(string ip)
        {
            List<int> openPorts = new List<int>();

            foreach (int port in _defaultPorts)
            {
                if (IsPortOpen(ip, port))
                {
                    Console.WriteLine($"  Port {port}: OFFEN");
                    openPorts.Add(port);
                }
            }
            return openPorts;
        }
    }
}
