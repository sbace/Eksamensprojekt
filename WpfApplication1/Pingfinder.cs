using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class PingFinder
    {
        public string ExecuteCommand(string command)
        {
            Ping p = new Ping();
            PingReply r;
            string s;
            s = command;
           


            try
            {
                r = p.Send(s);
                if (r.Status == IPStatus.Success)
                {
                    return "Ping to " + s.ToString() + " Successful"
                       + " Response delay = " + r.RoundtripTime.ToString() + " ms" + "\n";
                }
                else
                {
                    return "No ping";
                }


            }
            catch (Exception ex)
            {
                return "That is not a valid address!!!";
            }


        }
    }
}
