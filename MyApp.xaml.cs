using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FractalGenerator
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MyApp : System.Windows.Application
    {
        public MyApp()
        {
            InitializeComponent();
        }

        [System.STAThreadAttribute()]
        public static void Main()
        {
            SplashScreen splash = new SplashScreen("images/Splash.png");
            splash.Show(false);
            MyApp app = new MyApp();
            app.InitializeComponent();
            splash.Close(TimeSpan.FromSeconds(0.75));
            app.Run();
        }

    }   // class
}   // namespace
