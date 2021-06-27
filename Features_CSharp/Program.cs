using System;

namespace Features_CSharp
{
    public delegate void PrintDelegate(string str);
    public delegate void printValue(int value);
    class Program
    {
        public static void Main(string[] args)
        {
            /*
             * 1. Anonymous method can be defined using the delegate keyworkd
             * 2. It must be assigned to a delegate
             * 3. It can access out variables or functions
             * 4. It can be passed as a parameter
             * 5. These type of methods can be used as event handlers.
             */

            PrintDelegate pr = new PrintDelegate(delegate (string str) {
                Console.WriteLine(str.ToUpper());
            });
            pr.Invoke("Hello World");

            PrintDelegate pr2 = delegate (string str)
            {
                Console.WriteLine(str.ToLower());
            };
            pr2.Invoke("Hello World");

            pr = new PrintDelegate((string str) => Console.WriteLine(str.ToUpper()));
            pr += (string str) => Console.WriteLine(str.ToLower());
            pr.Invoke("Hello World");

            // Anonymous method can access variables defined in an outer function
            int x = 10;
            printValue pv = new printValue(delegate (int val) { 
                val += x;
                Console.WriteLine("The value is " + val);
            });
            pv(25);

            // The anonymous method can also be passed to a method that accepts the delegate as a parameter
            PrintHelperMethod(delegate(int value) { Console.WriteLine("Value: " + value); }, 100);
        }

        public static void PrintHelperMethod(printValue pv, int value)
        {
            value += 10;
            pv.Invoke(value);
        }
    }
}