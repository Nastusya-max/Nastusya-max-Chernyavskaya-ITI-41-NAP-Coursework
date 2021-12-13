using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameConsole
{
    /// <summary>
    /// Interaction logic for ConnectWindow.xaml
    /// </summary>
    public partial class ConnectWindow : Window
    {
        UdpClient _udpClient;

        public ConnectWindow()
        {
            InitializeComponent();
        }

        private void Host_Click(object sender, RoutedEventArgs e)
        {
            _udpClient = new UdpClient(33441);

            IPEndPoint iPEndPoint = null;
            _udpClient.Receive(ref iPEndPoint);
            _udpClient.Connect(iPEndPoint);

            var game = new MainWindow(_udpClient, true);
            Close();
            game.Show();
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            _udpClient = new UdpClient(Ip.Text, 33441);

            var init = Encoding.UTF8.GetBytes("hello kitti");
            _udpClient.Send(init, init.Length);

            var game = new MainWindow(_udpClient, false);
            Close();
            game.Show();
        }
    }
}
