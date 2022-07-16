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

namespace Zodiac_Compatibility
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    
    public partial class Settings : Page
    {
        public static bool Eng { get; set; }
        public Settings()
        {
            InitializeComponent();
        }
        private void Button_ChangeToUkrainian(object sender, RoutedEventArgs e)
        {
            Settings.Eng = false;
        }

        private void Button_ChangeToEnglish(object sender, RoutedEventArgs e)
        {
            Settings.Eng = true;
        }

        private void ReturnMain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Main());
        }


    }
}
