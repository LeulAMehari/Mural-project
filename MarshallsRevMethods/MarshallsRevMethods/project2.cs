using System;
using static System.Console;

class Mural
{
    public static char[] muralCodes = { 'L', 'S', 'A', 'C', 'O' };
    public static string[] muralTypes = {"Landscape", "Seascape", "Abstract", "Children's", "Other"};
    public string Name { get ; set; }
    private char code;
    private string muralType;
    
    public Mural()
    {
        Name = "";
        Code = 'I';
    }
    
    public char Code
    {
        get
        {
            return code;
        }
        set
        {
            int length = muralCodes.Length;

            for (int i = 0; i < muralCodes.Length; ++i)
            {
                if (value == muralCodes[i])
                {
                    length = i;
                    i = muralCodes.Length;
                }

            }

            if (length == muralCodes.Length)
            {
                code = 'I';
                muralType = " Invalid";
            }
            else
            {
                code = value;
                muralType = muralTypes[length] + " ";
            }
            //WriteLine(value);
            

        }
    }
    public string MuralType
    {
        get
        {
            return muralType;
        }
    }
}