using System;
using System.Collections.Generic;
using System.Linq;

class Function
{
    public static int Recursion(int n)
    {
        if (n <= 1) return 1;

        return Recursion(n / 2) + Recursion(n / 3) + Recursion(n / 6) + n;
    }

    public static int Loop(int n)
    {
        if (n <= 1) return 1;



        return n;
    }
}
