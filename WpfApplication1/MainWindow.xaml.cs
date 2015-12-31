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
            ProcessStartInfo psi = new ProcessStartInfo("ipconfig");
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;

            var proc = Process.Start(psi);
            //jhvjvjgvjgvhg
            string s = proc.StandardOutput.ReadToEnd();

            textBox.Text = s;

        }

        private void ping_Click(object sender, RoutedEventArgs e)
        {
            Ping p = new Ping();
            PingReply r;
            string s;
            s = ipa.Text;
            r = p.Send(s);
            try
            {
                if (r.Status == IPStatus.Success)
                {
                    textBox.Text = "Ping to " + s.ToString() +/* "[" + r.Address.ToString() + "]" +*/ " Successful"
                       + " Response delay = " + r.RoundtripTime.ToString() + " ms" + "\n";
                }
            }
            catch
            {

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
}
