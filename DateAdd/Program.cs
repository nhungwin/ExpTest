using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAdd
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isValidDateInput = false;
            bool isValidAddDaysInput = false;
            string date = "";
            string addDays = "";

            InputValidation validation = new InputValidation();

            //For exit program
            Console.WriteLine("Enter X for exit!\n\n");

            //For user input
            do
            {
                if (!isValidDateInput)
                {
                    Console.Write("Enter a valid date(dd/mm/yyyy) please: ");
                    date = Console.ReadLine().Trim();

                    //For exit program
                    if (date.ToUpper() == "X") return;

                    //Validate date input
                    if (!validation.IsValidDate(date))
                    {
                        Console.WriteLine("Invalid date: " + date);
                        continue;
                    }
                    else
                    {
                        //Date is valid
                        isValidDateInput = true;
                    }

                }

                if (!isValidAddDaysInput)
                {
                    Console.Write("Enter a number of days to add (only positive integer from 0): ");
                    addDays = Console.ReadLine().Trim();

                    //For exit program
                    if (addDays.ToUpper() == "X") return;

                    //Validate number of days input
                    if (!validation.IsNumeric(addDays))
                    {
                        Console.WriteLine("Invalid a number of days: " + addDays);
                        continue;
                    }
                    else
                    {
                        //Number of days is valid
                        isValidAddDaysInput = true;
                    }
                }

                //Process valid input
                if (isValidDateInput && isValidAddDaysInput)
                {
                    //Process input
                    Date newDate = new Date(date, int.Parse(addDays));
                    //Output new date
                    Console.WriteLine("New date: " + newDate.NewDate + "\n\n");

                    //Reset flags for restart
                    isValidDateInput = false;
                    isValidAddDaysInput = false;
                }

            } while (!isValidDateInput || !isValidAddDaysInput);

        }
    }
}
