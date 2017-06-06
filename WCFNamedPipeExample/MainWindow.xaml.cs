using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using WCFNamedPipeExample.Services;

namespace WCFNamedPipeExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        public static MainWindow main;
        private ServiceHost host;
        public MainWindow()
        {
            InitializeComponent();
            main = this;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            string baseAddress = "net.pipe://127.0.0.1/Loggger";

            try
            {
                // Server code
                host = new ServiceHost(typeof(LogService), new Uri(baseAddress));
                host.AddServiceEndpoint(typeof(ILogService), new NetNamedPipeBinding(NetNamedPipeSecurityMode.None), "");
                host.Open();


            }
            catch (CommunicationException ce)
            {
                MessageBox.Show(string.Format("An exception occured: {0}", ce.Message));
                host.Abort();
            }
            catch (Exception ce)
            {
                MessageBox.Show(string.Format("An exception occured: {0}", ce.Message));
                host.Abort();
            }
        }

        private void btnEnd_Click(object sender, RoutedEventArgs e)
        {
            this.host.Close();
        }
    }
}
