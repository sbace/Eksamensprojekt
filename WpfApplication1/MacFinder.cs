using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class CommandExecutor
    {       

        public string ExecuteCommand(string command)
        {
            ProcessStartInfo psi = new ProcessStartInfo(command);
            psi.UseShellExecute = false;

            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;

            var proc = Process.Start(psi);
            string s = proc.StandardOutput.ReadToEnd();

            return s;
        }
    }
}
