using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zodiac_Compatibility
{
    class Finder
    {
        public int ZodiacIdFinder(Main window)
        {
            int Day = Convert.ToInt32(window.Day.Text);
            int Month = Convert.ToInt32(window.Month.Text);
            float result;
            if (Month == 10)
                result = Convert.ToSingle(Month + Convert.ToSingle(Day / 100.0));
            else
                result = Convert.ToSingle(Month + Convert.ToSingle((Day / 100.0)));

            if (result >= 1.21 && result <= 2.18)
            {
                return 1;
            }
            else if(result >= 2.19 && result <= 3.20)
            {
                return 2;
            }
            else if (result >= 3.21 && result <= 4.20)
            {
                return 3;
            }
            else if (result >= 4.21 && result <= 5.20)
            {
                return 4;
            }
            else if (result >= 5.21 && result <= 6.21)
            {
                return 5;
            }
            else if (result >= 6.22 && result <= 7.22)
            {
                return 6;
            }
            else if (result >= 7.23 && result <= 8.22)
            {
                return 7;
            }
            else if (result >= 8.23 && result <= 9.23)
            {
                return 8;
            }
            else if (result >= 9.24 && result <= 10.23)
            {
                return 9;
            }
            else if (result >= 10.24 && result <= 11.22)
            {
                return 10;
            }
            else if (result >= 11.23 && result <= 12.21)
            {
                return 11;
            }
            else if (result >= 12.22 && result <= 1.20)
            {
                return 12;
            }

            return 1;
        }
    }
}
