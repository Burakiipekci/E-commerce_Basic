using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf.RightClickCustomSettings
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

        private void webBrowser_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true; // varsayılan sağ tıklama menüsünü engelle

            // özelleştirilmiş sağ tıklama menüsünü oluştur
            ContextMenu customContextMenu = new ContextMenu();

            // özelleştirilmiş sağ tıklama menüsüne öğeler ekleyin
            MenuItem item1 = new MenuItem();
            item1.Header = "Yenile";
            item1.Click += new RoutedEventHandler(item1_Click);
            customContextMenu.Items.Add(item1);

            MenuItem item2 = new MenuItem();
            item2.Header = "Sayfa Kaynağını Görüntüle";
            item2.Click += new RoutedEventHandler(item2_Click);
            customContextMenu.Items.Add(item2);

            // özelleştirilmiş sağ tık menüsünü gösterin
            customContextMenu.IsOpen = true;

            // sağ tıklama konumunu alın
            Point position = e.GetPosition(sender as UIElement);

            // özelleştirilmiş sağ tık menüsünü konumlandırın
            customContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            customContextMenu.HorizontalOffset = position.X;
            customContextMenu.VerticalOffset = position.Y;
        }

        private void item1_Click(object sender, RoutedEventArgs e)
        {
            webBrowser1.Refresh(); // WebBrowser aracındaki sayfayı yenile
        }

        private void item2_Click(object sender, RoutedEventArgs e)
        {
            string html = (string)webBrowser1.InvokeScript("document.documentElement.outerHTML"); // WebBrowser aracındaki sayfanın kaynak kodunu al

            // kaynak kodu görüntülemek için yeni bir pencere aç
            Window sourceWindow = new Window();
            sourceWindow.Height = 500;
            sourceWindow.Width = 800;
            sourceWindow.Title = "Sayfa Kaynağı";
            TextBox textBox = new TextBox();
            textBox.Text = html;
            textBox.IsReadOnly = true;
            sourceWindow.Content = textBox;
            sourceWindow.ShowDialog();
        }
    }
}
