using GeoLib.Services;
using GeoLib.WindowsHost.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
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

namespace GeoLib.WindowsHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ServiceHost hostGeoManager = null;
        private ServiceHost hostMessageManager = null;

        public static MainWindow MainUI { get; set; }

        private SynchronizationContext syncContext;

        public MainWindow()
        {
            InitializeComponent();

            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;

            MainUI = this;

            this.Title = "UI Runnig on Thread" + Thread.CurrentThread.ManagedThreadId + " | Process" + Process.GetCurrentProcess().Id.ToString();

            this.syncContext = SynchronizationContext.Current;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            hostGeoManager = new ServiceHost(typeof(GeoManager));
            hostMessageManager = new ServiceHost(typeof(MessageManager));

            hostGeoManager.Open();
            hostMessageManager.Open();

            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            hostGeoManager.Close();
            hostMessageManager.Close();

            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
        }

        public void ShowMessage(string message)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            //lblMessage.Content = message + Environment.NewLine + "(marshaling from thread " + threadId + " to thread " + Thread.CurrentThread.ManagedThreadId + "| Process" + Process.GetCurrentProcess().Id + ")";

            SendOrPostCallback callback = (arg) =>
            {
                lblMessage.Content = message + Environment.NewLine + "(marshaling from thread " + threadId + " to thread " + Thread.CurrentThread.ManagedThreadId + "| Process" + Process.GetCurrentProcess().Id + ")";
            };

            syncContext.Send(callback, null);
        }

        private void btnInProc_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                using (ChannelFactory<IMessageService> factory = new ChannelFactory<IMessageService>(""))
                {
                    IMessageService proxy = factory.CreateChannel();
                    proxy.ShowMessage(DateTime.Now.ToLongTimeString() + " from in-process call.");
                }
            });

            thread.IsBackground = true;
            thread.Start();
        }
    }
}
 