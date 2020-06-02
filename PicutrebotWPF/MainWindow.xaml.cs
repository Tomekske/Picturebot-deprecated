using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Controls.Primitives;
using NavigationDrawerPopUpMenu2;
using MaterialDesignThemes.Wpf;

namespace PopupApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var stack = new StackPanel() { Orientation = Orientation.Horizontal};
            stack.Children.Add(new PackIcon { Kind = PackIconKind.LogicGateAnd, Height = 25, Width = 25, Margin = new Thickness(10, 0, 0, 0) });
            stack.Children.Add(new TextBlock() { Text = "ItemJow", VerticalAlignment = VerticalAlignment.Center, Margin = new Thickness(20, 10, 0, 0) });
            
            ListViewMenu.Items.Add(new ListViewItem() { Content = stack, Name = "ItemJow", Height = 60 });

        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome": usc = new UserControlHome(); GridMain.Children.Add(usc); break;
                case "ItemCreate": usc = new UserControlCreate(); GridMain.Children.Add(usc); break;
                case "ItemJow": usc = new UserControlHome(); GridMain.Children.Add(usc); break;
                default:
                    break;
            }
        }
    }
}
