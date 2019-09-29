using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BatteryMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            batteryStatus.Content = GetPowerSource();
            powerSource.Content = GetBatteryStatus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //Application.Exit();
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            batteryStatus.Content = GetPowerSource();
            powerSource.Content = GetBatteryStatus();
        }

        public String GetPowerSource()
        {

            string strPowerLineStatus = "Default";
            // Getting the current system power status.
            switch (SystemInformation.PowerStatus.PowerLineStatus)
            {
                case System.Windows.Forms.PowerLineStatus.Offline:
                    strPowerLineStatus = "Battery";
                    break;
                case System.Windows.Forms.PowerLineStatus.Online:
                    strPowerLineStatus = "AC Power";
                    break;
                case System.Windows.Forms.PowerLineStatus.Unknown:
                    strPowerLineStatus = "Unknown";
                    break;
            }
            return strPowerLineStatus;
        }
        public float GetBatteryStatus()
        {
            float batterylife;
            batterylife = SystemInformation.PowerStatus.BatteryLifePercent;
            batterylife *= 100.0f;
            return batterylife;
        }
    }
}

