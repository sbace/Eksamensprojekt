using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Ipconfig_Click(object sender, RoutedEventArgs e)
        {
            var cmd = new CMDexe();
            string ipc = cmd.ExecuteCommand("ipconfig");

            String input = ipc;
            Regex ip = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
            MatchCollection result = ip.Matches(input);

            if (result.Count == 3)
            {
                textBox.Text = "IP adresse is " + result[0] + "\n";
                textBox.Text += "Subnet adresse is " + result[1] + "\n";
                textBox.Text += "Gateway adresse is " + result[2] + "\n";

            }
            else
            {
                textBox.Text = ipc;
            }
        }

        private void ExecutePing()
        {
            string s;
            s = ipa.Text;

            var pfind = new PingFinder();
            string pfound = pfind.ExecuteCommand(s);
            textBox.Text = pfound;
        }

        private void ping_Click(object sender, RoutedEventArgs e)
        {
            ExecutePing();
        }

        private void ipa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ExecutePing();
            }
        }

        private void WanIp_Click(object sender, RoutedEventArgs e)
        {
            String url = "http://bot.whatismyipaddress.com/";
            String result = null;

            try
            {
                WebClient client = new WebClient();
                result = client.DownloadString(url);
                textBox.Text = "My WAN IP is " + result;
            }
            catch (Exception ex) { textBox.Text = "127.0.0.1"; }
        }

        private void mac_Click(object sender, RoutedEventArgs e)
        {
            var cmd = new CMDexe();
            string mac = cmd.ExecuteCommand("getmac");
            textBox.Text = mac;
        }
    }
}    

