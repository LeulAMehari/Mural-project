using System;
using static System.Console;

namespace Mural
{
    public class Mural
    {
        const int MAX_MURALS = 30;

        int mymonth;

        public static string[] muralModels = { "L", "S", "A", "C", "O" };
        public static string[] muralTypes = { "Landscape", "Seascape", "Abstract", "Children", "Other" };

        string[] customerInterior = new string[MAX_MURALS];
        string[] customerExterior = new string[MAX_MURALS];

        public int MyMonth
        {
            get
            {
                return mymonth;
            }
            set
            {
                mymonth = value;
                while (mymonth < 1 || mymonth > 12)
                {
                    Write("Enter a Valid month: ");
                    string input = ReadLine();
                    int.TryParse(input, out mymonth);

                }
                
            }
        }
        public string[] CustomerInterior
        {
            get 
            {
                return customerInterior;
            }
            set
            {

            }
        }

        public static int GetMonth()
        {
            Write("Enter Month ");
            Mural var = new Mural();
            int temp;
            int.TryParse(ReadLine(), out temp);
            var.MyMonth = temp;
            return var.MyMonth;
        }
        public int[] GetNumMurals()
        {
            int[] myArray = new int[2];           // since we can't return two values we will put num_murals to the array then return the array
            Write("Enter number of interior murals scheduled ");
            int interiorM;
            bool checkVal = int.TryParse(ReadLine(), out interiorM);
            while (interiorM < 0 || interiorM > 30 || checkVal == false)
            {
                WriteLine("Enter a Valid number of interior Murals");
                checkVal = int.TryParse(ReadLine(), out interiorM);

            }
            myArray[0] = interiorM;
            Write("Enter number of exterior murals scheduled ");
            string exteriorMu = ReadLine();
            int exteriorM;
            checkVal = int.TryParse(exteriorMu, out exteriorM);

            while (exteriorM < 0 || exteriorM > 30 || checkVal == false)
            {
                WriteLine("Enter a Valid number of exterior Murals");
                exteriorMu = ReadLine();
                checkVal = int.TryParse(exteriorMu, out exteriorM);

            }
            myArray[1] = exteriorM;
            return myArray;
        }

        public void DataEntry()
        {
            Write("Enter Your name ");

            CustomerInterior[0] = ReadLine();
            //MarshallsRevenue.GetMonth();
        }
    }
}
