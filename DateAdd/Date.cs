using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAdd
{
    public class Date
    {
        int _dd = 0;
        int _mm = 0;
        int _yyyy = 0;
        int _numberOfDays = 0;
        string _date = "";
        public string NewDate { get; set; }
        public Date(string date, int numberOfDays)
        {
            _date = date;
            _numberOfDays = numberOfDays;

            //Process input
            ProcessDateInput();
            //Workout a new date
            WorkoutNewDate();
        }

        /// <summary>
        /// Process date input
        /// </summary>
        private void ProcessDateInput()
        {
            string[] dateParts = _date.Split('/');
            _dd = int.Parse(dateParts[0]);
            _mm = int.Parse(dateParts[1]);
            _yyyy = int.Parse(dateParts[2]);
        }

        /// <summary>
        /// Workout new date
        /// </summary>
        private void WorkoutNewDate()
        {
            int newDD = _dd;
            int newMM = _mm;
            int newYYYY = _yyyy;
            int remainingDays = _numberOfDays;
            int daysOfMonth = 0;
            int state = 1;

            while (state != 0)
            {
                switch (state)
                {
                    //Workout days state
                    case 1:
                        if (remainingDays == 0)
                        {
                            state = 0;
                            break;
                        }

                        //Reset dd, mm, yyyy
                        if (newYYYY == 9999)
                        {
                            newYYYY = 1;
                            newMM = 1;
                            newDD = 0;
                        }

                        //Get days of present month
                        daysOfMonth = GetDaysOfMonth(newMM);

                        for (int i = newDD; i < daysOfMonth; i++)
                        {
                            if (remainingDays > 0)
                            {
                                newDD++;
                                remainingDays--;
                            }
                            else
                            {
                                //Complete state
                                state = 0;
                                break;
                            }
                        }

                        //Check remaining days
                        if (remainingDays > 0)
                        {
                            //Set to months state
                            state = 2;
                        }
                        break;
                    //Workout months state
                    case 2:
                        //Reset dd
                        newDD = 0;

                        //Check for max month
                        if (newMM < 12)
                        {
                            //Increase to next month
                            newMM++;
                            //Check remaining days
                            if (remainingDays > 0)
                            {
                                //Set to days state
                                state = 1;
                            }
                        }
                        else
                        {
                            //Set to years state
                            state = 3;
                        }
                        break;
                    //Workout years state
                    case 3:
                        //Reset days
                        newDD = 0;
                        //Reset momth
                        newMM = 0;
                        //Check for max year
                        if (newYYYY < 9999)
                        {
                            //Increase to next year
                            newYYYY++;
                            //Check remaining days
                            if (remainingDays > 0)
                            {
                                //Set to days state
                                state = 1;
                            }
                        }
                        else
                        {
                            //Set to days state
                            state = 1;
                        }
                        break;
                    default:
                        break;
                }
            }

            //Format of new date
            NewDate = string.Format("{0:00}/{1:00}/{2:0000}", newDD, newMM, newYYYY);
        }

        /// <summary>
        /// Get maximum days of a month
        /// </summary>
        /// <param name="newDD"></param>
        /// <returns></returns>
        private int GetDaysOfMonth(int newDD)
        {
            int daysOfMonth = 0;
            switch (newDD)
            {
                case 1:
                    daysOfMonth = 31;
                    break;
                case 2:
                    daysOfMonth = 28;
                    break;
                case 3:
                    daysOfMonth = 31;
                    break;
                case 4:
                    daysOfMonth = 30;
                    break;
                case 5:
                    daysOfMonth = 31;
                    break;
                case 6:
                    daysOfMonth = 30;
                    break;
                case 7:
                    daysOfMonth = 31;
                    break;
                case 8:
                    daysOfMonth = 31;
                    break;
                case 9:
                    daysOfMonth = 30;
                    break;
                case 10:
                    daysOfMonth = 31;
                    break;
                case 11:
                    daysOfMonth = 30;
                    break;
                case 12:
                    daysOfMonth = 31;
                    break;
                default:
                    break;
            }

            return daysOfMonth;
        }
    }
}
