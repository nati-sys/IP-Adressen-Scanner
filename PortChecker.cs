using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace IP_Adressen_Scanner
{
    public class PortChecker
    {
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
    }
}
