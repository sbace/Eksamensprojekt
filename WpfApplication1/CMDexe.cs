using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WpfApplication1
{
    public class CMDexe
    {
        public string ExecuteCommand (string command)
        {
            ProcessStartInfo psi = new ProcessStartInfo(command);
            psi.UseShellExecute = false;

            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = false;

            var proc = Process.Start(psi);
            string s = proc.StandardOutput.ReadToEnd();

            return s;
        }
    }
}
