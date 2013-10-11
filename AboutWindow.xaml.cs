using System;
using System.Windows;

namespace FractalGenerator
{
    /// <summary>
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void OnOkClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }   // class
}   // namespace
