using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Windows.Navigation;

namespace Zodiac_Compatibility
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            MyFrame.Content = new Main();
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Button_Click_Full(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }
        private void Button_Click_Turn(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void Button_Click_Settings(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new Settings();
        }
    }
}