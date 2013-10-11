using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Resources;
using System.IO;

namespace FractalGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapCanvas bitmapCanvas;

        public MainWindow()
        {
            InitializeComponent();

            ddlMap.SelectedIndex = 0;
            GenerateMap();

            bitmapCanvas = new BitmapCanvas(700, 700);
            bitmapCanvas.Background = Brushes.Black;
            DockPanel.SetDock(bitmapCanvas, Dock.Top);
            dockPanel.Children.Add(bitmapCanvas);

            menuResetZoom.CommandTarget = bitmapCanvas;

            txtStatus.Text = "Ready";
        }

        protected void OnRefreshDrawingVisual(object sender, RoutedEventArgs e)
        {
            Refresh(this.bitmapCanvas);
        }

        private void Refresh(UIElement uiElement)
        {
            uiElement.InvalidateVisual();
            //uiElement.Dispatcher.Invoke(DispatcherPriority.Render, new Action(delegate(){}));
        }

        #region Commands

        private void CanExecuteCloseCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ExecutedCloseCommand(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void CanExecuteHelpCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ExecutedHelpCommand(object sender, ExecutedRoutedEventArgs e)
        {
            AboutWindow aboutWin = new AboutWindow();
            aboutWin.ShowDialog();
        }

        private void CanExecuteResetZoomCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ExecutedResetZoomCommand(object sender, ExecutedRoutedEventArgs e)
        {
            BitmapCanvas target = e.Source as BitmapCanvas;
            if (target != null)
                target.Reset();
        }

        #endregion

        #region Map

        private void GenerateMap()
        {
            string mapName = (ddlMap.SelectedItem as ComboBoxItem).Content.ToString();
            Uri mapUri = new Uri("maps/" + mapName, UriKind.Relative);
            StreamResourceInfo info = Application.GetResourceStream(mapUri);
            MapHelper.ReadMap(info);
        }

        protected void OnSelectingMap(object sender, SelectionChangedEventArgs e)
        {
            GenerateMap();

            if (this.bitmapCanvas != null)
                this.bitmapCanvas.Run();
        }

        #endregion

    }   // class
}   // namespace
