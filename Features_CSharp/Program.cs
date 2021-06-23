using System;

namespace Features_CSharp
{

    class Program
    {
        public void passByValue(int x)
        {
            x = 50;
        }

        public void passByReference(ref int x)
        {
            x = 50;
        }

        public static void Main(string[] args)
        {
            // The ref keyword is used to pass or return references of values to or from methods.

            int x = 5;
            Console.WriteLine("Value of x: " + x);
            new Program().passByValue(x);
            Console.WriteLine("Value of x after pass by value: " + x);
            new Program().passByReference(ref x);
            Console.WriteLine("Value of x after pass by reference: " + x);
        }
    }
}