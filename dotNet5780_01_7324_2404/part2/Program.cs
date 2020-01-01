//dotNet_5780_01_part2
//yaakov taber 319187324
//moshe helfgot 206262404
//This program maintains a calendar for a hotel owner
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] calendar = new bool[12, 31]; //Two-dimensional array for calendar representation
            char choice;
            do
            {
                //Print the menu and get a choice from the user
                Console.WriteLine(@"
Please enter a choice
a: to add a reservation 
b: to print occupancy periods
c: to print the number of days and the percentage of occupancy
e: to exit");
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case 'a':
                        if (addReservation(calendar))
                            Console.WriteLine("reservation successfully added");
                        else
                            Console.WriteLine("reservation can't be added");
                        break;
                    case 'b':
                        printOccupancy(calendar);
                        break;
                    case 'c':
                        printOccupancyPercentage(calendar);
                        break;
                    case 'e':
                        break;
                    default:
                        Console.WriteLine("error invalid choice");
                        break;
                }
            } while (choice != 'e');
        }


        public static bool addReservation(bool[,] calendar)
        {
            int startDay, startMonthe, vacationDuration;

            do
            {                              //Get a date and check if it's valid
                Console.WriteLine("enter the begin day");
                startDay = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter the begin monthe");
                startMonthe = Convert.ToInt32(Console.ReadLine());
                if (startDay <= 0 || startDay > 31 || startMonthe <= 0 || startMonthe > 12)
                {
                    Console.WriteLine("error invalid date");
                }
            } while ((startDay <= 0 || startDay > 31 || startMonthe <= 0 || startMonthe > 12));

            Console.WriteLine("enter the vacation duration");
            vacationDuration = Convert.ToInt32(Console.ReadLine());

                            //Check if dates are available
            int k = 0;
            for (int i = startMonthe - 1; i < 12; i++)
            {
                for (int j = (i == startMonthe - 1) ? startDay - 1 : 0; j < 31 && k < vacationDuration; k++, j++)
                {
                    if (calendar[i, j])
                        return false;
                }
            }
                         //Check that the loop is not over due year-end
            if (k != vacationDuration)
                return false;
                         //Marking the days as busy
            k = 0;
            for (int i = startMonthe - 1; i < 12; i++)
            {
                for (int j = (i == startMonthe - 1) ? startDay - 1 : 0; j < 31 && k < vacationDuration - 1; k++, j++)
                {
                    calendar[i, j] = true;
                }
            }

            return true;
        }

        public static void printOccupancy(bool[,] calendar)
        {
            bool validFirstDate = false;
            int firstDay = 0, firstmonthe = 0;
            int lastDay = 0, lasttmonthe = 0;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (calendar[i, j] && !validFirstDate)  //Finding the first busy day
                    {
                        firstDay = j + 1;
                        firstmonthe = i + 1;
                        validFirstDate = true;
                    }
                    if (!calendar[i, j] && validFirstDate)  //Finding the last busy day
                    {
                        if (j == 0)
                        {
                            lastDay = 31;
                            lasttmonthe = i;
                        }
                        else
                        {
                            lastDay = j;
                            lasttmonthe = i + 1;
                        }
                                        //Print the dates found
                        Console.WriteLine("{0}/{1}-{2}/{3}", firstDay, firstmonthe, lastDay, lasttmonthe);
                        validFirstDate = false;
                    }
                }
            }
        }

        public static void printOccupancyPercentage(bool[,] calendar)
        {
            int numOfBusyDays = 0;      //Counting the busy days
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (calendar[i, j])
                    {
                        numOfBusyDays++;
                    }
                }
            }//Calculate the percentage of occupation
            float Percentage = (numOfBusyDays / 372f) * 100;
            //Printing the occupation in two ways
            Console.WriteLine("number of busy days: {0}", numOfBusyDays);
            Console.WriteLine("annual occupancy Percentage: {0} %", Percentage);
        }
    }
}
