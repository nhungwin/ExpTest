using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAdd
{
    public class InputValidation
    {
        public bool IsValidDate(string date)
        {
            //Check if whole string is valid
            if (string.IsNullOrWhiteSpace(date))
            {
                return false;
            }

            string[] dateParts = date.Split('/');

            //Check valid array length
            if (dateParts.Length != 3)
            {
                return false;
            }

            //Check valid numeric individual items in the array such as dd, mm, yyyy
            foreach (var item in dateParts)
            {
                if (!IsNumeric(item))
                {
                    return false;
                }
            }

            //Validate dd
            int dd = int.Parse(dateParts[0]);
            if (dateParts[0].Length != 2 || dd < 1 || dd > 31)
            {
                return false;
            }
            //Validate mm
            int mm = int.Parse(dateParts[1]);
            if (dateParts[1].Length != 2 || mm < 1 || mm > 12)
            {
                return false;
            }

            //Validate yyyy
            int yyyy = int.Parse(dateParts[2]);
            if (dateParts[2].Length != 4 || yyyy < 1 || yyyy > 9999)
            {
                return false;
            }

            return true;

        }

        //Check input string for numeric
        public bool IsNumeric(string input)
        {
            int test;
            return int.TryParse(input, out test);
        }
    }
}
