using GeoLib.Contracts;
using GeoLib.Proxies;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GeoLib.Client.Contracts;

namespace GeoLib.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GeoClient proxy;

        public MainWindow()
        {
            InitializeComponent();

            proxy = new GeoClient("tcpEP");

            this.Title = "UI Runnig on Thread " + Thread.CurrentThread.ManagedThreadId + " | Process" + Process.GetCurrentProcess().Id.ToString();
        }

        private void btnGetInfo_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtZipCode.Text))
            {
                GeoClient proxy = new GeoClient("tcpEP");

                ZipCodeData data = proxy.GetZipInfo(txtZipCode.Text);
                if (data != null)
                {
                    lblCity.Content = data.City;
                    lblState.Content = data.State;
                }

                proxy.Close();
            }
        }

        private void btnGetZipCodes_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtState.Text))
            {
                //EndpointAddress address = new EndpointAddress("net.tcp://localhost:8009/GeoService");
                //var binding = new NetTcpBinding();

                //GeoClient proxy = new GeoClient(binding, address);

                //GeoClient proxy = new GeoClient("tcpEP");
                var data = proxy.GetZips(txtState.Text);
                if (data != null)
                    lstZips.ItemsSource = data;

                //proxy.Close();
            }
        }

        private void btnMakeCall_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMessage.Text))
            {
                EndpointAddress address = new EndpointAddress("net.tcp://localhost:8010/MessageService");
                var binding = new NetTcpBinding();

                ChannelFactory<IMessageService> factory = new ChannelFactory<IMessageService>(binding, address);
                //ChannelFactory<IMessageService> factory = new ChannelFactory<IMessageService>("");

                var proxy = factory.CreateChannel();

                proxy.ShowMsg(txtMessage.Text);

                factory.Close();
                
                //MessageClient proxy = new MessageClient();
                //proxy.ShowMessage(txtMessage.Text);

                //proxy.Close();
            }
        }
    }
}
