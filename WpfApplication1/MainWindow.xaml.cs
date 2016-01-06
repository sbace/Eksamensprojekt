using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net;
using System.Text.RegularExpressions;

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
            //textBox.Text = mac;

            String input = ipc;
            Regex ip = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
            //string[] result = ip.Split(input);
            MatchCollection result = ip.Matches(input);

            if (result.Count == 3)
            {
                textBox.Text += "IP adresse is " + result[0] + "\n";
                textBox.Text += "Subnet adresse is " + result[1] + "\n";
                textBox.Text += "Gateway adresse is " + result[2] + "\n";

            }
            
            //            textBox.Text = s;
            

        }

        private void ping_Click(object sender, RoutedEventArgs e)
        {
            Ping p = new Ping();
            PingReply r;
            string s;
            s = ipa.Text;
            
            //Min try catch virker ikke, dvs programmet crasher ved invalid ping

            try
            {
                r = p.Send(s);
                if (r.Status == IPStatus.Success)
                {
                    textBox.Text = "Ping to " + s.ToString() + " Successful"
                       + " Response delay = " + r.RoundtripTime.ToString() + " ms" + "\n";
                }
                else
                {
                    textBox.Text = "No ping";
                }

           
            }
            catch (Exception ex)
            {
                textBox.Text="That is not a valid address!!!";
            }
            
            
        }

        private void WanIp_Click(object sender, RoutedEventArgs e)
        {
            //Virker fint
            String url = "http://bot.whatismyipaddress.com/";
            String result = null;

            try
            {
                WebClient client = new WebClient();
                result = client.DownloadString(url);
                textBox.Text = "My WAN IP is " + result;
            }
            catch (Exception ex) { textBox.Text="127.0.0.1"; }
        }

        private void mac_Click(object sender, RoutedEventArgs e)
        {
           
            var cmd = new CMDexe();
            string mac = cmd.ExecuteCommand("getmac");
            textBox.Text = mac;


        }
    }

    


        /*
       private void textBox1_Validated(object sender, EventArgs e)
       {
           if (string.IsNullOrEmpty(ipa.Text) || ipa.Text == "")
           {
               MessageBox.Show("Please use valid IP or web address!!");
           }
       }*/
        /*private void ipa_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ipa.Text) || ipa.Text == "")
            {
                MessageBox.Show("Skriv lige en valid adresse!!");
            }
        }
        */
        /*private void richTextBox_TextChanged(object sender, TextChangedEventArgs e)
       

        }*/
    }

