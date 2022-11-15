using System;
using static System.Console;
using System.Globalization;

public class MarshallsRevenue
{
    enum Months
    {
        January = 1, February, March, April, May, June, July, August, September, October, November, December
    }

    static void Main()
    {
        const int MAX_MURALS = 30;
        string[] customerInterior = new string[MAX_MURALS];
        string[] customerExterior = new string[MAX_MURALS];
        int month = GetMonth();
        int[] ordersArray = GetNumMurals();
        int interior = ordersArray[0];
        int exterior = ordersArray[1];

        char[] muralCodeInt = new char[interior];
        char[] muralCodeExt = new char[exterior];
        string[] muralTypeInt = new string[interior];
        string[] muralTypeEx = new string[exterior];

        int count = 0;         //To know which murals design (interior or exterior) the program is calling in dataEntry method         

        DataEntry(customerInterior, interior, muralCodeInt, muralTypeInt, count);
        count += 1;
        DataEntry(customerExterior, exterior, muralCodeExt, muralTypeEx, count);
        GetSelectedMurals(customerInterior, interior, muralCodeInt, muralTypeInt, customerExterior, exterior, muralCodeExt, muralTypeEx);

    }
    public static int GetMonth()
    {
        Write("Enter Month ");

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
        int interiorM;
        string interiorMu = ReadLine();
        bool checkVal = int.TryParse(interiorMu, out interiorM);
        while (interiorM < 0 || interiorM > 30 || checkVal == false)
        {
            WriteLine("Enter a Valid number of interior Murals");
            interiorMu = ReadLine();
            checkVal = int.TryParse(interiorMu, out interiorM);

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
    public static double ComputeRevenue(int month, int interior, int exterior)
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

        return totalPrice;
    }
    public static void DataEntry(string[] customerOrders, int customers, char[] muralCode, string[] muralType, int count)
    {
    
        string name;
        bool check;

        Mural myMural = new Mural();
     

        if (count == 0)
        {
            WriteLine("Values for the interior murals");
            WriteLine("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
        }
        else if (count == 1)
        {
            WriteLine("Values for the exterior murals");
            WriteLine("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
        }


        for (int i = 0; i < customers; ++i)
        {
            Mural muralM = new Mural();
            // mural.Code[i] = mural.Code;
            WriteLine("Enter\n L: for Landscape\nS: for Seascape\nA: for Abstract\nC: for Children\nO: for other");
            char muralStyle;
            check = char.TryParse(ReadLine().ToUpper(), out muralStyle);
            while (check == false)
            {
                WriteLine("Please enter a valid code");
                WriteLine("L: for Landscape\nS: for Seascape\nA: for Abstract\nC: for Children\nO: for other");
                check = char.TryParse(ReadLine().ToUpper(), out muralStyle);
            }
          
            muralM.Code = muralStyle;
            while (muralM.Code == 'I')
            {
                WriteLine("Please enter a valid code");
                WriteLine("L: for Landscape\nS: for Seascape\nA: for Abstract\nC: for Children\nO: for other");
                check = char.TryParse(ReadLine().ToUpper(), out muralStyle);
                muralM.Code = muralStyle;
            }
            muralCode[i] = muralM.Code;
            muralType[i] = muralM.MuralType;

            Write("Enter Your name ");
            name = ReadLine();
            muralM.Name = name;
            customerOrders[i] = muralM.Name;
        }
        
        WriteLine("The order is ");
        for (int i = 0; i < muralType.Length; ++i)
        {
            WriteLine("{0,-10}{1,-17}", muralType[i], customerOrders[i]);
        }
        WriteLine(); 
    }

    public static void GetSelectedMurals(string[] customerInterior, int interior, char[]  muralCodeInt, string[] muralTypeInt, string[] customerExterior, int exterior, char[] muralCodeExt, string[]muralTypeEx)
    {
        const char QUIT = 'Z';
        int totalCus = interior + exterior;
        WriteLine("Enter a Mural Type or Z to quit ");
        char mStyle = Convert.ToChar(ReadLine());

        while (mStyle != QUIT)
        {
            while (mStyle != 'L' && mStyle != 'l' && mStyle != 'S' && mStyle != 's' && mStyle != 'A' && mStyle != 'a' && mStyle != 'C' && mStyle != 'c' && mStyle != 'O'
                && mStyle != 'o')
            {
                Write("Valid entries include only L, S, A, C or O, try again: ");
                
                mStyle = Convert.ToChar(ReadLine());
            }
            for (int j = 0; j < muralCodeInt.Length; ++j)
            {
                if (muralCodeInt[j] == mStyle)
                {
                    WriteLine("{0}: Interior", customerInterior[j]);
                }
            }
            for (int x = 0; x < muralCodeExt.Length; ++x)
            {
                if (muralCodeExt[x] == mStyle)
                {
                    WriteLine("{0}: Exterior", customerExterior[x]);
                }
            }
            WriteLine("Enter a Mural Type or Z to quit ");
            mStyle = Convert.ToChar(ReadLine());
        }
    }
}