using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для ServiceSelection.xaml
    /// </summary>
    public partial class ServiceSelection : Page
    {
        SqlConnection sqlConnection = null;
        public int Id;
        public ServiceSelection(int Id)
        {
            Main main = new Main();
            Finder finder = new Finder();
            InitializeComponent();
            Text(Id);
            ColorChengerText(AboutYou1);
            ColorChengerText(AboutYou);
        }
        private void ReturnMain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Main());
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Text(int id)
        {
            string LanguageShort;
            string LanguageLong;
            if (Settings.Eng)
            {
                LanguageShort = "ShortDescriptionENG";
                LanguageLong = "LongDescriptionENG";
            }
            else
            {
                LanguageShort = "ShortDescriptionUKR";
                LanguageLong = "LongDescriptionUKR";
            }
                

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ZodiacDB"].ConnectionString);
            sqlConnection.Open();
            SqlDataReader dataReader = null;

            SqlCommand cmd1 = new SqlCommand($"SELECT {LanguageShort} FROM Text WHERE id = {id}", sqlConnection);
            dataReader = cmd1.ExecuteReader();
            while (dataReader.Read())
                AboutYou1.Text = dataReader[$"{LanguageShort}"].ToString();
            dataReader.Close();

            SqlCommand cmd2 = new SqlCommand($"SELECT {LanguageLong} FROM Text WHERE id = {id}", sqlConnection);
            dataReader = cmd2.ExecuteReader();
            while (dataReader.Read())
                AboutYou.Text = dataReader[$"{LanguageLong}"].ToString();
            dataReader.Close();
        }
        
        async void ColorChengerText(TextBlock textBlock)
        {
            for (byte r = 35,g = 35,b = 62; r < 255 & g < 255 & b < 255; r += 10, g += 10, b += 9,await Task.Delay(25))
            {
                textBlock.Foreground = new SolidColorBrush(Color.FromRgb(r, g, b));
            }
        }
    }
}
