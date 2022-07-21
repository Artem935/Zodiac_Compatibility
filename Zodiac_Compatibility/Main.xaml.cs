using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Zodiac_Compatibility
{

    public partial class Main : Page
    {
        SqlConnection sqlConnection = null;
        public Main()
        {
            Random rund = new Random();
            InitializeComponent();
            Day.Text = "10";
            Month.Text = "7";
            Year.Text = "2003";

            if (!Settings.Eng)
            {
                DayLabel.Content = "День";
                MonthLabel.Content = "Місяць";
                YearLabel.Content = "Рік";
                NameLabel.Content = "Ім'я";
            }
        }
        private void UserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (UserName.Text.Length == 0)
            {
                UserName.Text = " ";
                UserName.Select(UserName.Text.Length, 0);
            }
        }
        private void UserName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"\p{L}");
            e.Handled = !regex.IsMatch(e.Text);
        }
        private void UserName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space) e.Handled = true;
        }
        private void Day_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            ChekBox chekBox = new ChekBox();
            chekBox.ChekDay(this, e);
        }
        private void Day_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space) e.Handled = true;
        }
        private void Month_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            ChekBox chekBox = new ChekBox(); 
            chekBox.ChekMonth(this,e);
        }
        private void Month_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space) e.Handled = true;
        }
        private void Month_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(Month.Text))
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ZodiacDB"].ConnectionString);
                sqlConnection.Open();
                SqlDataReader dataReader = null;
                SqlCommand cmdSel = new SqlCommand($"SELECT Day FROM Calendar WHERE id = {Convert.ToInt32(Month.Text)}", sqlConnection);
                dataReader = cmdSel.ExecuteReader();
                while (dataReader.Read())
                    if (Convert.ToInt32(Day.Text) > Convert.ToInt32(dataReader["Day"].ToString()))
                    {
                        Day.Text = Convert.ToInt32(dataReader["Day"].ToString()).ToString();
                    }
                dataReader.Close();
            }
        }
        private void Year_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            ChekBox chekBox = new ChekBox();
            chekBox.ChekYear(this, e);
        }
        private void Year_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space) e.Handled = true;
        }
        
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Finder finder = new Finder();
            int Id = finder.ZodiacIdFinder(this);
            NavigationService.Navigate(new ServiceSelection(Id));
        }
    }
}
