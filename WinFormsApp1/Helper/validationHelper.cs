using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Helper
{
    public class validationHelper
    {

        // Checking if the device is connected to internet
        public static bool internetAvailability()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "portal.azure.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
