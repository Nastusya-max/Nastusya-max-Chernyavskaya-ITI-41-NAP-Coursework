using System;
using System.Windows;
using OpenTK.Wpf;
using OpenTK.Graphics.OpenGL;
using OpentTKGame;
using System.Net.Sockets;

namespace GameConsole
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UdpClient udpClient;
        bool isHost;

        Game game = new Game(800, 600);
       /// <summary>
       /// Метод инициализации компонентов
       /// </summary>
        public MainWindow(UdpClient udpClient, bool isHost)
        {
            this.udpClient = udpClient;
            this.isHost = isHost;

            InitializeComponent();
            
            var settings = new GLWpfControlSettings();
            settings.MajorVersion = 3;
            settings.MinorVersion = 6;
            OpenTKControl.Start(settings);
        }

        private void OpenTKControl_Render(TimeSpan obj)
        {
            GL.ClearColor(System.Drawing.Color.CornflowerBlue);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-Width, Width, Height, -Height, 0d, 1d);
            game.Rendering(obj);
        }

        private void OpenTKControl_Ready()
        {

            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.Texture2D);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            game.Initialization(LeftBar, RightBar, udpClient, isHost);
        }

        private void RightBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
