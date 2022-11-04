using System;
using static System.Console;
using System.Globalization;
class MarshallsRevenue
{
    enum Months
    {
        January = 1, February, March, April, May, June, July, August, September, October, November, December
    }
    static void Main()
    {
        const int MAX_MURALS = 30;
        string[] interiorStyle = new string[MAX_MURALS];
        string[] exteriorStyle = new string[MAX_MURALS];
        string[] muralModels = { "L", "S", "A", "C", "O" };
        string[] muralTypes = { "Landscape", "Seascape", "Abstract", "Children", "Other" };
        string[] customerInterior = new string[MAX_MURALS];
        string[] customerExterior = new string[MAX_MURALS];


        int month = GetMonth();
        int[] ordersArray = GetNumMurals();
        int interior = ordersArray[0];
        int exterior = ordersArray[1];

        string[] exteriorCodes = new string[exterior];
        string[] interiorCodes = new string[interior];
        int[] countExteriorTypes = { 0, 0, 0, 0, 0 };
        bool check = false;

        ComputeRevenue(month, interior, exterior);
        DataEntry(muralModels, muralTypes, interiorStyle, exteriorStyle, customerInterior, customerExterior, interiorCodes, exteriorCodes, interior, exterior, check);
        GetSelectedMurals(muralModels, muralTypes, interior, exterior, customerInterior, customerExterior, interiorCodes,  exteriorCodes);

    }
    public static int GetMonth()
    {
        Write("Enter Month ");
        WriteLine("HHHHHHEEEEEEEEEEEYYYYYYYYY");
        int mymonth;
        string entry = ReadLine();
        int.TryParse(entry, out mymonth);
        while (mymonth < 1 || mymonth > 12)
        {
            WriteLine("Enter a Valid month");
            entry = ReadLine();
            int.TryParse(entry, out mymonth);
        }
        return mymonth;
    }
    public static int[] GetNumMurals()
    {
        int[] myArray = new int[2];           // since we can't return two values we will put num_murals to the array then return the array
        Write("Enter number of interior murals scheduled ");
        int interiorM = Convert.ToInt32(ReadLine());
        while (interiorM < 0 || interiorM > 30)
        {
            WriteLine("Enter a Valid number of interior Murals");
            interiorM = Convert.ToInt32(ReadLine());
        }
        myArray[0] = interiorM;

        Write("Enter number of exterior murals scheduled ");
        int exteriorM = Convert.ToInt32(ReadLine());

        while (exteriorM < 0 || exteriorM > 30)
        {
            WriteLine("Enter a Valid number of exterior Murals");
            exteriorM = Convert.ToInt32(ReadLine());
            
        }
        myArray[1] = exteriorM;
        return myArray;
    }
    public static void ComputeRevenue(int month, int interior, int exterior)
    {
        double interiorCost = 500.00;
        double exteriorCost = 750.00;
        const double interiorCostChange = 450.00;
        const double EXTERIORCOSTCHANGE = 699.00;

        if (month == 12 || month == 1 || month == 2)
        {
            exterior = 0;
        }

        if (month == 4 || month == 5 || month == 9 || month == 10)
        {
            exteriorCost = EXTERIORCOSTCHANGE;
        }

        if (month == 7 || month == 8)
        {
            interiorCost = interiorCostChange;
        }

        double priceInt = interior * interiorCost;
        double priceExt = exterior * exteriorCost;
        double totalPrice = priceExt + priceInt;


        WriteLine("For the month of " + (Months)month);
        WriteLine("{0} interior murals are scheduled at {1} each for a total of {2}",
            interior, interiorCost.ToString("C", CultureInfo.GetCultureInfo("en-US")),
            priceInt.ToString("C", CultureInfo.GetCultureInfo("en-US")));
        WriteLine("{0} extrior murals are scheduled at {1} each for a total of {2}",
            exterior, exteriorCost.ToString("C", CultureInfo.GetCultureInfo("en-US")),
            priceExt.ToString("C", CultureInfo.GetCultureInfo("en-US")));
        WriteLine("Total revenue expected is {0}", totalPrice.ToString("C", CultureInfo.GetCultureInfo("en-US")));
    }
    public static void DataEntry(string[] muralModels, string[] muralTypes, string[] interiorStyle, string[] exteriorStyle, string[] customerInterior, string[] customerExterior, string[] interiorCodes, string[] exteriorCodes, int interior, int exterior, bool check)
    {
        int intCustomers = interior;
        int extCustomers = exterior;
        string name;
        int[] countInteriorTypes = { 0, 0, 0, 0, 0 };
        int[] countExteriorTypes = { 0, 0, 0, 0, 0 };
      
        WriteLine("The interior order is ");
        for (int i = 0; i < intCustomers; ++i)
        {
            Write("Enter Your name ");
            name = ReadLine();
            WriteLine("Enter Mural Style ");
            WriteLine("L: for Landscape\nS: for Seascape\nA: for Abstract\nC: for Children\nO: for other");
            string muralStyle = ReadLine();
            customerInterior[i] = name;

            while (check == false)
            {
                bool exists = Array.Exists(muralModels, element => element == muralStyle);
                if (exists)
                {
                    int index = Array.IndexOf(muralModels, muralStyle);
                    string val = muralTypes[index];
                    countInteriorTypes[index] += 1;
                    interiorStyle[i] = val;
                    interiorCodes[i] = muralStyle;
                    check = true;
                }
                else
                {
                    WriteLine("Please enter a valid mural style");
                    muralStyle = ReadLine();
                }
            }
            check = false;
        }
        WriteLine();
        WriteLine("You are now entering exteriror");

        for (int i = 0; i < extCustomers; ++i)
        {
            Write("Enter Your name ");
            name = ReadLine();
            WriteLine("Enter Mural Style");
            WriteLine("L: for Landscape\nS: for Seascape\nA: for Abstract\nC: for Children\nO: for other");
            string muralStyle = ReadLine();
            customerExterior[i] = name;
            while (check == false)
            {
                bool exists = Array.Exists(muralModels, element => element == muralStyle);
                if (exists)
                {
                    int index = Array.IndexOf(muralModels, muralStyle);
                    string val = muralTypes[index];
                    countExteriorTypes[index] += 1;
                    exteriorStyle[i] = val;
                    exteriorCodes[i] = muralStyle;
                    check = true;
                }
                else
                {
                    System.Console.WriteLine("Please enter a valid mural style");
                    muralStyle = ReadLine();
                }
            }
            check = false;
        }
        WriteLine("The interior order is ");
        for (int i = 0; i < muralTypes.Length; ++i)
        {
            WriteLine("{0,-10}{1,-17}", muralTypes[i], countInteriorTypes[i]);
        }
        WriteLine();
        WriteLine("The exterior order is ");
        for (int i = 0; i < muralTypes.Length; ++i)
        {
            WriteLine("{0,-10}{1,-17}", muralTypes[i], countExteriorTypes[i]);
        }
        WriteLine("heyy");
    }
    
    public static void GetSelectedMurals(string[] muralModels, string[] muralTypes, int interior, int exterior, string[] cusInterior, string[] cusExterior, string[] codesInterior, string[] codesExterior)
    {
        const string QUIT = "Z";
        int totalCus = interior + exterior;
        WriteLine("Enter a Mural Type or Z to quit ");
        string mStyle = ReadLine();

        while (mStyle != QUIT)
        {
            for (int j = 0; j < codesInterior.Length; ++j)
            {
                if (codesInterior[j] == mStyle)
                {
                    WriteLine("{0} Interior", cusInterior[j]);
                }
            }
            for (int x = 0; x < codesExterior.Length; ++x)
            {
                if (codesExterior[x] == mStyle)
                {
                    WriteLine("{0} Exterior", cusExterior[x]);
                }
            }
            WriteLine("Enter a Mural Type or Z to quit ");
            mStyle = ReadLine();
        }
    }
}
