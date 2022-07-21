using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Zodiac_Compatibility
{
    public class ChekBox
    {

        public void ChekDay(Main window, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^1-9]+");
            if (window.Day.Text.Length == 0)
            {
                e.Handled = regex.IsMatch(e.Text);
            }
            else if (window.Day.Text.Length == 1 && (window.Day.Text[0] == '1' || window.Day.Text[0] == '2'))
            {
                regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }
            else if (window.Day.Text.Length == 1 && window.Day.Text[0] == '3')
            {
                regex = new Regex("[^0-1]+");
                e.Handled = regex.IsMatch(e.Text);
            }
            else
            {
                e.Handled = true;
            }
        }
        public void ChekMonth(Main window, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^1-9]+");
            if (window.Month.Text.Length == 0)
            {
                e.Handled = regex.IsMatch(e.Text);
            }
            else if (window.Month.Text.Length == 1 && window.Month.Text[0] == '1')
            {
                regex = new Regex("[^0-2]+");
                e.Handled = regex.IsMatch(e.Text);
            }
            else
            {
                e.Handled = true;
            }
        }
        public void ChekYear(Main window, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^1-2]+");
            if (window.Year.Text.Length == 0)
            {
                e.Handled = regex.IsMatch(e.Text);
            }
            else if (window.Year.Text.Length == 1 && window.Year.Text[0] == '1')
            {
                regex = new Regex("[^9]+");
                e.Handled = regex.IsMatch(e.Text);
            }
            else if (window.Year.Text.Length == 1 && window.Year.Text[0] == '2')
            {
                regex = new Regex("[^0]+");
                e.Handled = regex.IsMatch(e.Text);
            }
            else if (window.Year.Text.Length == 2 && window.Year.Text[1] == '9')
            {
                regex = new Regex("[^4-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }
            else if (window.Year.Text.Length == 2 && window.Year.Text[1] == '0')
            {
                regex = new Regex("[^0-2]+");
                e.Handled = regex.IsMatch(e.Text);
            }
            else if (window.Year.Text.Length == 3 && window.Year.Text[0] == '1')
            {
                regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }
            else if (window.Year.Text.Length == 3 && (window.Year.Text[2] == '0' || window.Year.Text[2] == '1'))
            {
                regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }
            else if (window.Year.Text.Length == 3 && window.Year.Text[2] == '2')
            {
                regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
