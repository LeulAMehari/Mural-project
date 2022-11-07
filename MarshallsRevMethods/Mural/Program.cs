using System;
using static MarshallsRevenue;
using static System.Console;

namespace Mural
{
    class Mural
    {
        const int MAX_MURALS = 30;

        public static string[] muralModels = { "L", "S", "A", "C", "O" };
        public static string[] muralTypes = { "Landscape", "Seascape", "Abstract", "Children", "Other" };

        string[] customerInterior = new string[MAX_MURALS];
        string[] customerExterior = new string[MAX_MURALS];
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
        public void DataEntry()
        {
            Write("Enter Your name ");

            CustomerInterior[0] = ReadLine();
            MarshallsRevenue.GetMonth();
        }
    }
}
