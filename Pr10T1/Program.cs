using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pr10T1   // NO CHANGES PERMITTED TO THIS CLASS
{
    class Program
    {
        static void populateList(string FileName, Appointments CS)
        {
            StreamReader Input = new StreamReader(FileName);
            while (!Input.EndOfStream)
            {
                string[] data = Input.ReadLine().Split(',');
                Tutor newOne;
                if (data.Length == 5)
                    newOne = new Tutor(data[0], int.Parse(data[1]), double.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]));
                else
                {
                    Bursar newBursar = new Bursar(data[0], int.Parse(data[1]), double.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), data[5], int.Parse(data[6]));
                    newOne = newBursar;
                }
                CS.makeAppointment(newOne);
            }
        }

        static void Main(string[] args)
        {
            string FileName = "FewTutors.txt"; ;
            double Budget = 150000;
            int choice;
            do
            {
                Console.Clear();
                Appointments CS = new Appointments(Budget);
                populateList(FileName, CS);
                Console.WriteLine("INDICATE WHICH FUNCTIONALITY YOU WISH TO TEST (methods function independently of each other)");
                Console.WriteLine("1. Display list of appointed tutors (with total hours worked)");
                Console.WriteLine("2. Determine and display list of tutors identified to be terminated");
                Console.WriteLine("9. TERMINATE PROCESSING");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: CS.displayAppointees();
                            Console.WriteLine("Press enter to continue................");
                            Console.ReadLine();
                       break;
                    case 2: Console.WriteLine("List of tutors who have worked at most 2 hours 36 minutes per day:");
                            CS.identifyTerminations(2, 36);
                            Console.WriteLine("Press enter to continue................");
                            Console.ReadLine();
                            break;
                    case 9: break;
                    default: Console.WriteLine("Incorrect selection - press enter to continue");
                        Console.ReadLine();
                        break;
                }
            } while (choice != 9);
            Console.WriteLine("Processing terminated - press enter to continue");
            Console.ReadLine();
        }
    }
}
