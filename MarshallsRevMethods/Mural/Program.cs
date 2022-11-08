using System;
using static MarshallsRevenue;
using static System.Console;

namespace Mural
{
    class Mural
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
                while (value < 1 || value > 12)
                {
                    WriteLine("Enter a Valid month");
                    int.TryParse(ReadLine(), out mymonth);
                }
                mymonth = value;
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


        public void DataEntry()
        {
            Write("Enter Your name ");

            CustomerInterior[0] = ReadLine();
            MarshallsRevenue.GetMonth();
        }
    }
}
